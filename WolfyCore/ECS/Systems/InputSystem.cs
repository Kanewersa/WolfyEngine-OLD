using System;
using Microsoft.Xna.Framework;
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
                input.ArrowDown = _currentKeyboardState.IsKeyDown(Keys.Down);
                input.ArrowLeft = _currentKeyboardState.IsKeyDown(Keys.Left);
                input.ArrowRight = _currentKeyboardState.IsKeyDown(Keys.Right);
                input.ArrowUp = _currentKeyboardState.IsKeyDown(Keys.Up);
                input.LeftShift = _currentKeyboardState.IsKeyDown(Keys.LeftShift);
                input.Enter = _currentKeyboardState.IsKeyDown(Keys.Enter);

                if (input.ArrowUp)
                    MoveEntity(entity, new Vector2(0, -1));
                else if (input.ArrowRight)
                    MoveEntity(entity, new Vector2(1, 0));
                else if (input.ArrowDown)
                    MoveEntity(entity, new Vector2(0, 1));
                else if (input.ArrowLeft)
                    MoveEntity(entity, new Vector2(-1, 0));
            });
        }

        private static void MoveEntity(Entity e, Vector2 direction)
        {
            if (e.HasComponent<MovementActionComponent>()
                || e.HasComponent<StartActionComponent>()) return;

            var movement = e.GetComponent<MovementComponent>();
            var transform = e.GetComponent<TransformComponent>();

            var movementAction = e.AddComponent<MovementActionComponent>();
            
            movementAction.Set(transform.GridTransform, transform.GridTransform + direction, false);

            movement.DirectionVector = direction;
        }
    }
}
