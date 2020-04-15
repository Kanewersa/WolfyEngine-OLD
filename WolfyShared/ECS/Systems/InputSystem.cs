using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProtoBuf;
using WolfyECS;
using WolfyShared.Engine;

namespace WolfyShared.ECS
{
    [ProtoContract] public class InputSystem : EntitySystem
    {
        [ProtoIgnore] private KeyboardState _currentKeyboardState;
        [ProtoIgnore] private KeyboardState _lastKeyboardState;

        public InputSystem() { }

        public override void Initialize()
        {
            RequireComponent<InputComponent>();
            RequireComponent<MovementComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                var input = entity.GetComponent<InputComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                if (input == null)
                    throw new Exception("Entity in " + this + "is missing input component.");
                if (movement == null)
                    throw new Exception("Entity in " + this + "is missing movement component.");

                _currentKeyboardState = Keyboard.GetState();
                
                input.ArrowDown = _currentKeyboardState.IsKeyDown(Keys.Down);
                input.ArrowLeft = _currentKeyboardState.IsKeyDown(Keys.Left);
                input.ArrowRight = _currentKeyboardState.IsKeyDown(Keys.Right);
                input.ArrowUp = _currentKeyboardState.IsKeyDown(Keys.Up);
                input.LeftShift = _currentKeyboardState.IsKeyDown(Keys.LeftShift);
                
                var isMoving = movement.IsMoving;
                if (isMoving || movement.WasMoving)
                {
                    movement.Speed = input.LeftShift ? 500 : 100;
                }
                else if (!movement.WasMoving)
                {
                    // TODO Tile size
                    if (input.ArrowUp)
                    {
                        movement.IsMoving = true;
                        movement.Direction = new Vector2(0,-32);
                        movement.EnumDirection = Direction.Up;
                    } else if (input.ArrowDown)
                    {
                        movement.IsMoving = true;
                        movement.Direction = new Vector2(0,32);
                        movement.EnumDirection = Direction.Down;
                    } else if (input.ArrowLeft)
                    {
                        movement.IsMoving = true;
                        movement.Direction = new Vector2(-32,0);
                        movement.EnumDirection = Direction.Left;
                    } else if (input.ArrowRight)
                    {
                        movement.IsMoving = true;
                        movement.EnumDirection = Direction.Right;
                        movement.Direction = new Vector2(32,0);
                    }
                }
            }
        }
    }
}
