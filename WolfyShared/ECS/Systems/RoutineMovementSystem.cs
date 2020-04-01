using System;
using Microsoft.Xna.Framework;
using WolfyECS;
using WolfyShared.Engine;
using Random = WolfyShared.Engine.Random;

namespace WolfyShared.ECS
{
    public class RoutineMovementSystem : EntitySystem
    {
        public override void Initialize()
        {
            RequireComponent<RoutineMovementComponent>();
            RequireComponent<MovementComponent>();
        }
        
        public override void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                var routine = entity.GetComponent<RoutineMovementComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                var elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (movement.IsMoving || movement.WasMoving) return;

                routine.Timer -= elapsed;

                if (routine.Timer < 0)
                {
                    movement.IsMoving = true;

                    movement.EnumDirection = Random.GetRandomDirection();

                    movement.Direction = movement.EnumDirection switch
                    {
                        Direction.Down => new Vector2(0, 32),
                        Direction.Left => new Vector2(-32, 0),
                        Direction.Right => new Vector2(32, 0),
                        Direction.Up => new Vector2(0, -32),
                        _ => throw new ArgumentOutOfRangeException()
                    };

                    routine.Timer = routine.MovementFrequency;
                }
            }
        }
    }
}
