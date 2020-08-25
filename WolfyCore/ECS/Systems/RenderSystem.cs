using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Services;
using ProtoBuf;
using WolfyCore.Engine;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Handles the camera and draws all game objects.
    /// </summary>
    [ProtoContract] public class RenderSystem : EntitySystem
    {
        public Matrix CameraTransform { get; private set; }
        public int LastMapId { get; private set; }

        public RenderTarget2D BackBufferRenderTarget { get; private set; }
        public LUTManager LUTManager { get; private set; }

        private ContentManager ContentManager => World.WorldInstance.ContentManager;
        private GraphicsDevice GraphicsDevice => World.WorldInstance.GraphicsDevice;
        
        public RenderSystem()
        {
            CameraTransform = new Matrix(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            LUTManager = new LUTManager();
        }

        public override void Initialize()
        {
            RequireComponent<TransformComponent>();
            RequireComponent<CameraComponent>();
        }

        public override void LoadContent(ContentManager content)
        {
            LUTManager.LoadContent(content, GraphicsDevice);
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

                // Initialize the map if last map was changed.
                if (map.Id != LastMapId)
                {
                    map.Initialize(GraphicsDevice, World.WorldInstance);
                    map.LoadContent(ContentManager);
                    camera.SetMapBoundaries(map.Size * Runtime.GridSize);
                }
                LastMapId = map.Id;

                // Update the camera
                if (entity.GetIfHasComponent<AnimationComponent>(out var animation))
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
        }
    }
}
