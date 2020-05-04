using System;
using Microsoft.Xna.Framework;
using WolfyCore.Engine;
using WolfyECS;
using Random = WolfyCore.Engine.Random;

namespace WolfyCore.ECS
{
    public class RandomMovementSystem : EntitySystem
    {
        public RandomMovementSystem() { }

        public override void Initialize()
        {
            RequireComponent<MovementComponent>();
            RequireComponent<RandomMovementComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                var random = entity.GetComponent<RandomMovementComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                if (movement.IsMoving || movement.WasMoving) return;

                random.Timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (!(random.Timer < 0)) continue;

                movement.IsMoving = true;

                movement.EnumDirection = Engine.Random.GetRandomDirection();

                movement.Direction = movement.EnumDirection switch
                {
                    Direction.Down => new Vector2(0, 32),
                    Direction.Left => new Vector2(-32, 0),
                    Direction.Right => new Vector2(32, 0),
                    Direction.Up => new Vector2(0, -32),
                    _ => throw new ArgumentOutOfRangeException()
                };

                random.Timer = movement.Frequency;
            }
        }
    }
}
