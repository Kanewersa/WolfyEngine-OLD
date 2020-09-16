using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Handles the camera and draws all game objects.
    /// </summary>
    [ProtoContract] public class RenderSystem : EntitySystem
    {
        public Matrix CameraTransform { get; private set; }
        public int LastMapId { get; private set; } = -1;

        public RenderTarget2D BackBufferRenderTarget { get; private set; }
        public LUTManager LUTManager { get; private set; }

        public ContentManager ContentManager { get; private set; }
        public GraphicsDevice GraphicsDevice { get; private set; }

        public Texture2D BlackPane { get; private set; }
        public float PaneTransparency { get; private set; }
        
        public RenderSystem()
        {
            CameraTransform = new Matrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            LUTManager = new LUTManager();
        }

        public override void Initialize(GraphicsDevice graphics)
        {
            GraphicsDevice = graphics;
            RequireComponent<TransformComponent>();
            RequireComponent<CameraComponent>();
        }

        public override void LoadContent(ContentManager content)
        {
            ContentManager = content;
            LUTManager.LoadContent(content, GraphicsDevice);
            BlackPane = content.Load<Texture2D>("Assets/Shaders/BlackPane");
        }

        public override void Update(GameTime gameTime)
        {
            LUTManager.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var width = GraphicsDevice.PresentationParameters.BackBufferWidth;
            var height = GraphicsDevice.PresentationParameters.BackBufferHeight;

            /* Draw the game to a separate render target.
             * Check if game render target was initialized and
             * if game size (width or height) has changed.*/
            if (BackBufferRenderTarget == null || BackBufferRenderTarget.Width != width ||
                BackBufferRenderTarget.Height != height)
            {
                BackBufferRenderTarget = new RenderTarget2D(GraphicsDevice, width, height, false, SurfaceFormat.Color, DepthFormat.Depth24);
            }
            
            // TODO: Draw any background here!

            // Set render target...
            GraphicsDevice.SetRenderTarget(BackBufferRenderTarget);
            GraphicsDevice.Clear(Color.Black);

            // ...and draw the game.
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, blendState: BlendState.AlphaBlend);
            IterateEntities(entity =>
            {
                var transform = entity.GetComponent<TransformComponent>();
                var camera = entity.GetComponent<CameraComponent>();
                var map = transform.GetMap();

                // Set pane opacity if camera is fading.
                if (camera.FadeToBlack)
                {
                    if (gameTime != null) PaneTransparency += (float)gameTime.ElapsedGameTime.TotalSeconds/camera.FadeDuration;
                    if (PaneTransparency > 1) PaneTransparency = 1;
                }
                else
                {
                    if (gameTime != null) PaneTransparency -= (float)gameTime.ElapsedGameTime.TotalSeconds/camera.FadeDuration;
                    if (PaneTransparency < 0) PaneTransparency = 0;
                }

                // Initialize the map if last map was changed.
                if (map.Id != LastMapId)
                {
                    if (entity.HasComponent<LoadMapComponent>())
                        return;

                    entity.AddComponent<LoadMapComponent>().MapId = map.Id;
                    /*map.Initialize(GraphicsDevice);
                    map.LoadContent(ContentManager);*/
                    camera.SetMapBoundaries(map.Size * Runtime.GridSize);
                    
                }

                LastMapId = map.Id;
                
                // Update the camera
                if (entity.GetIfHasComponent<AnimationComponent>(out var animation) && animation.Initialized)
                    camera.Update(animation);
                else camera.Update();
                CameraTransform = camera.Transform;
                map.Draw(spriteBatch, gameTime, camera.GetVisibleArea());

                if (entity.GetIfHasComponent(out LUTComponent lut))
                {
                    LUTManager.SetNewLUT(lut.LUTPath, lut.TransitionTime);
                }
            });
            spriteBatch.End();

            // Perform color grading.
            Texture2D filterOutput = LUTManager.GetRenderTarget(BackBufferRenderTarget);

            // TODO: Apply any other filters here!

            // Set render target back to the BackBuffer.
            GraphicsDevice.SetRenderTarget(Runtime.RenderTarget);

            // Draw filters to the screen
            LUTManager.Draw(spriteBatch, CameraTransform, filterOutput, width, height);

            
            spriteBatch.Begin();

            for (var x = 0; x < width; x+=128)
            {
                for (var y = 0; y < height; y+=128)
                {
                    spriteBatch.Draw(BlackPane, new Vector2(x,y), new Color(Color.White, PaneTransparency));
                }
            }

            spriteBatch.End();
            
        }
    }
}
