using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class MovementSystem : EntitySystem
    {
        public MovementSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<NoCollisionComponent>();
            RequireComponent<MovementComponent>();
            RequireComponent<TransformComponent>();
        }
        
        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var collision = entity.GetComponent<NoCollisionComponent>();
                var action = collision.Info;
                var transform = entity.GetComponent<TransformComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
                transform.Transform += movement.DirectionVector * delta * Runtime.GridSize * movement.Speed / 5;

                if (!collision.MovedOnMap)
                {
                    transform.GetMap().MoveEntity(entity, action.StartGridTransform, action.TargetGridTransform);
                    transform.GridTransform = action.TargetGridTransform;
                    collision.MovedOnMap = true;
                }

                if (Vector2.Distance(action.StartTransform, transform.Transform) >= Runtime.GridSize)
                {
                    transform.Transform = action.TargetTransform;
                    entity.RemoveComponent<NoCollisionComponent>();
                }
            });
        }
    }
}
