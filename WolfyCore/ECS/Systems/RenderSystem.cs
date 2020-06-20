using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Handles the camera and draws all game objects.
    /// </summary>
    [ProtoContract] public class RenderSystem : EntitySystem
    {
        public Matrix CameraTransform { get; private set; }

        public RenderSystem()
        {
            CameraTransform = new Matrix(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
        }

        public override void Initialize()
        {
            RequireComponent<TransformComponent>();
            RequireComponent<CameraComponent>();
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: CameraTransform, samplerState: SamplerState.PointClamp);
            IterateEntities(entity =>
            {
                var transform = entity.GetComponent<TransformComponent>();
                var camera = entity.GetComponent<CameraComponent>();
                var map = transform.GetMap();

                camera.SetMapBoundaries(map.Size * Runtime.GridSize);

                if (entity.GetIfHasComponent<AnimationComponent>(out var animation))
                    camera.Update(animation);
                else camera.Update();

                CameraTransform = camera.Transform;

                Console.WriteLine("Drawing map...");
                Console.WriteLine("Entity position is: " + transform.GridTransform);
                Console.WriteLine("Visible area is: " + camera.GetVisibleArea());
                map.Draw(spriteBatch, gameTime, camera.GetVisibleArea());
            });
            spriteBatch.End();
        }
    }
}
