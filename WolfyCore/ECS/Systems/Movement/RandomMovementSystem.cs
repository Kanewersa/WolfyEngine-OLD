﻿using System;
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
            RequireComponent<TransformComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                var random = entity.GetComponent<RandomMovementComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                if (entity.HasComponent<MovementActionComponent>()) return;
                //if (movement.IsMoving || movement.WasMoving) return;

                random.Timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (!(random.Timer < 0)) continue;

                var transform = entity.GetComponent<TransformComponent>();
                var movementAction = entity.AddComponent<MovementActionComponent>();
                var direction = Random.GetRandomDirection();

                movementAction.Set(transform.GridTransform, transform.GridTransform + direction, false);

                movement.DirectionVector = direction;

                random.Timer = random.Frequency;
            }
        }
    }
}
