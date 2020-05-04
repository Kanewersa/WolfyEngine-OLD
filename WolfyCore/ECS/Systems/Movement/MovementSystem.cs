using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class MovementSystem : EntitySystem
    {
        public MovementSystem() { }

        public override void Initialize()
        {
            RequireComponent<MovementActionComponent>();
            RequireComponent<MovementComponent>();
            RequireComponent<TransformComponent>();
        }
        
        public override void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                var action = entity.GetComponent<MovementActionComponent>();
                if (!action.IsMoving) return;

                var transform = entity.GetComponent<TransformComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
                transform.Transform += movement.DirectionVector / 100 * movement.Speed * delta;

                if (Vector2.Distance(action.StartTransform, transform.Transform) >= Runtime.GridSize)
                {
                    transform.Transform = action.TargetTransform;
                    entity.RemoveComponent<MovementActionComponent>();
                }

            }
        }
    }
}
