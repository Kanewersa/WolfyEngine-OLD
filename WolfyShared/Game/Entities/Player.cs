using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    public class Player : Entity
    {
        public Input Input;

        public MovementEventHandler OnMove;

        private KeyboardState _currentKeyboardState;

        private Vector2 _startPosition = new Vector2(64,64);
        private Vector2 _endPosition = new Vector2(64,64);
        private float _timer = 0.01f;
        private float _speed = 100;
        private bool _moving;
        private Vector2 _direction;

        public Player(Dictionary<string, Animation> animations)
        {
            _image = new Image();
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public override void Move()
        {
            base.Move();

            _currentKeyboardState = Keyboard.GetState();

            if (_currentKeyboardState.IsKeyDown(Input.Up) && !_moving)
            {
                var vector = new Vector2(0, -GridSize);
                var canMove = OnMove.Invoke(Position + vector);
                if (!canMove) return;
                _endPosition += vector;
                _direction = Vector2.Normalize(vector);
                Position = _startPosition;
                _animationManager.SetDirection(Directions.Up);
                _moving = true;
            }
            else if (_currentKeyboardState.IsKeyDown(Input.Down) && !_moving)
            {
                var vector = new Vector2(0, GridSize);
                var canMove = OnMove.Invoke(Position + vector);
                if (!canMove) return;
                _endPosition += vector;
                _direction = Vector2.Normalize(vector);
                Position = _startPosition;
                _animationManager.SetDirection(Directions.Down);
                _moving = true;
            }
            else if (_currentKeyboardState.IsKeyDown(Input.Left) && !_moving)
            {
                var vector = new Vector2(-GridSize, 0);
                var canMove = OnMove.Invoke(Position + vector);
                if (!canMove) return;
                _endPosition += vector;
                _direction = Vector2.Normalize(vector);
                Position = _startPosition;
                _animationManager.SetDirection(Directions.Left);
                _moving = true;
            }
            else if (_currentKeyboardState.IsKeyDown(Input.Right) && !_moving)
            {
                var vector = new Vector2(GridSize, 0);
                var canMove = OnMove.Invoke(Position + vector);
                if (!canMove) return;
                _endPosition += vector;
                _direction = Vector2.Normalize(vector);
                Position = _startPosition;
                _animationManager.SetDirection(Directions.Right);
                _moving = true;
            }
        }

        protected override void SetAnimations()
        {
            if (_moving)
                _animationManager.Play(_animations["Walk"]);
            else _animationManager.Stop();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_moving)
            {
                Position += _direction * _speed * _timer;
                if (Vector2.Distance(_startPosition, Position) >= GridSize)
                {
                    Position = _endPosition;
                    _startPosition = _endPosition;
                    _moving = false;
                    Console.WriteLine("new position: " + Position);
                }
            }

            Move();
        }
    }
}
