﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class RoutineMovementSystem : EntitySystem
    {
        public RoutineMovementSystem() { }
        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<MovementComponent>();
            RequireComponent<RoutineMovementComponent>();
            RequireComponent<TransformComponent>();
        }
        
        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                /*var random = entity.GetComponent<RoutineMovementComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                if (entity.HasComponent<MovementActionComponent>()) return;
                //if (movement.IsMoving || movement.WasMoving) return;

                random.Timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (random.Timer < 0)
                {
                    var transform = entity.GetComponent<TransformComponent>();
                    var movementAction = entity.AddComponent<MovementActionComponent>();
                    var direction = Random.GetRandomDirection();

                    movementAction.Set(transform.GridTransform, transform.GridTransform + direction, false);

                    movement.DirectionVector = direction;

                    //random.Timer = random.Frequency;
                }*/
            });
        }
    }
}
