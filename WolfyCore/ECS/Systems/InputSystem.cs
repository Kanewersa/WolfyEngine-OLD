﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Handles user input.
    /// </summary>
    [ProtoContract] public class InputSystem : EntitySystem
    {
        [ProtoIgnore] private KeyboardState _currentKeyboardState;

        public InputSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<InputComponent>();
            RequireComponent<MovementComponent>();
            RequireComponent<TransformComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var input = entity.GetComponent<InputComponent>();

                _currentKeyboardState = Keyboard.GetState();
                input.ArrowDown = _currentKeyboardState.IsKeyDown(Keys.Down) || _currentKeyboardState.IsKeyDown(Keys.S);
                input.ArrowLeft = _currentKeyboardState.IsKeyDown(Keys.Left) || _currentKeyboardState.IsKeyDown(Keys.A);
                input.ArrowRight = _currentKeyboardState.IsKeyDown(Keys.Right) || _currentKeyboardState.IsKeyDown(Keys.D);
                input.ArrowUp = _currentKeyboardState.IsKeyDown(Keys.Up) || _currentKeyboardState.IsKeyDown(Keys.W);
                input.LeftShift = _currentKeyboardState.IsKeyDown(Keys.LeftShift);
                input.Enter = _currentKeyboardState.IsKeyDown(Keys.Enter);
                input.Escape = _currentKeyboardState.IsKeyDown(Keys.Escape);

                if (input.ArrowUp)
                    AddMovementAction(entity, new Vector2(0, -1));
                else if (input.ArrowRight)
                    AddMovementAction(entity, new Vector2(1, 0));
                else if (input.ArrowDown)
                    AddMovementAction(entity, new Vector2(0, 1));
                else if (input.ArrowLeft)
                    AddMovementAction(entity, new Vector2(-1, 0));
                else if (input.Enter)
                    AddInteraction(entity);
                else if (input.Escape)
                    HandleUI(entity);

                MovementSpeed(entity, input);
            });
        }

        private static void MovementSpeed(Entity e, InputComponent input)
        {
            var movement = e.GetComponent<MovementComponent>();

            movement.Speed = input.LeftShift ? 10f : 5f;
        }

        private static void AddMovementAction(Entity e, Vector2 direction)
        {
            if (e.HasComponent<PathMovementComponent>() || e.HasComponent<PathRequestComponent>())
            {
                e.RemoveComponent<PathMovementComponent>();
                e.RemoveComponent<PathRequestComponent>();
            }

            if (e.HasComponent<MovementActionComponent>()
                || e.HasComponent<StartActionComponent>()
                || e.HasComponent<NoCollisionComponent>()) return;

            var movement = e.GetComponent<MovementComponent>();
            var transform = e.GetComponent<TransformComponent>();

            var movementAction = e.AddComponent<MovementActionComponent>();
            
            movementAction.Set(transform.GridTransform, transform.GridTransform + direction, false);

            movement.DirectionVector = direction;
        }

        private static void AddInteraction(Entity e)
        {
            if (!e.HasComponent<InteractionComponent>())
            {
                e.AddComponent<InteractionComponent>();
            }
        }

        private static void HandleUI(Entity e)
        {
            if (e.HasComponent<DisplayUIComponent>())
            {
                e.RemoveComponent<DisplayUIComponent>();
            }
            else
            {
                e.AddComponent<DisplayUIComponent>();
            }
        }
    }
}
