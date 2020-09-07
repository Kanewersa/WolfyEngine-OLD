using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WolfyCore.Engine;
using WolfyECS;
using Random = WolfyCore.Engine.Random;

namespace WolfyCore.ECS
{
    public class RandomMovementSystem : EntitySystem
    {
        public RandomMovementSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<MovementComponent>();
            RequireComponent<RandomMovementComponent>();
            RequireComponent<TransformComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                if (entity.HasComponent<MovementActionComponent>()) return;
                var movement = entity.GetComponent<MovementComponent>();
                if (movement.LockedMovement) return;

                var random = entity.GetComponent<RandomMovementComponent>();

                random.Timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (random.Timer < 0)
                {
                    var transform = entity.GetComponent<TransformComponent>();
                    var movementAction = entity.AddComponent<MovementActionComponent>();

                    var direction = Random.GetRandomDirection();

                    movementAction.Set(transform.GridTransform, transform.GridTransform + direction, false);

                    movement.DirectionVector = direction;

                    random.Timer = random.Delay;
                }
            });
        }
    }
}
