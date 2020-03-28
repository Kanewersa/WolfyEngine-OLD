using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    public class Player : Sprite
    {
        public Input Input;

        private KeyboardState _currentKeyboardState;
        public Vector2D GridPosition { get; set; }
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private Vector2 _positionOffset;
        private float _timer = 0.01f;
        private float _speed = 100;
        private bool _moving;
        private Vector2 _direction;
        private Vector2 _tileSize;

        public override Rectangle Bounds =>
            new Rectangle(0,0, _animations["Walk"].FrameWidth, _animations["Walk"].FrameHeight);

        public Player(Dictionary<string, Animation> animations, Vector2D startingPosition)
        {
            _image = new Image();
            GridPosition = startingPosition;
            _startPosition = new Vector2(startingPosition.X * GridSize, startingPosition.Y * GridSize);
            _endPosition = _startPosition;
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value, GridSize);
        }

        public override void Move()
        {
            base.Move();

            _currentKeyboardState = Keyboard.GetState();

            if (_currentKeyboardState.IsKeyDown(Keys.LeftShift) && _moving)
                _speed = 500;
            else
                _speed = 100;
            

            if (_currentKeyboardState.IsKeyDown(Input.Up) && !_moving)
            {
                var vector = new Vector2(0, -GridSize);
                //var canMove = OnMove.Invoke(this, GridPosition + new Vector2D(0,-1));
                //if (!canMove) return;
                _endPosition += vector;
                _direction = Vector2.Normalize(vector);
                Position = _startPosition;
                _animationManager.SetDirection(Direction.Up);
                _moving = true;
            }
            else if (_currentKeyboardState.IsKeyDown(Input.Down) && !_moving)
            {
                var vector = new Vector2(0, GridSize);
                //var canMove = OnMove.Invoke(this, GridPosition + new Vector2D(0, 1));
                //if (!canMove) return;
                _endPosition += vector;
                _direction = Vector2.Normalize(vector);
                Position = _startPosition;
                _animationManager.SetDirection(Direction.Down);
                _moving = true;
            }
            else if (_currentKeyboardState.IsKeyDown(Input.Left) && !_moving)
            {
                var vector = new Vector2(-GridSize, 0);
                //var canMove = OnMove.Invoke(this, GridPosition + new Vector2D(-1, 0));
                //if (!canMove) return;
                _endPosition += vector;
                _direction = Vector2.Normalize(vector);
                Position = _startPosition;
                _animationManager.SetDirection(Direction.Left);
                _moving = true;
            }
            else if (_currentKeyboardState.IsKeyDown(Input.Right) && !_moving)
            {
                var vector = new Vector2(GridSize, 0);
                //var canMove = OnMove.Invoke(this, GridPosition + new Vector2D(1, 0));
                //if (!canMove) return;
                _endPosition += vector;
                _direction = Vector2.Normalize(vector);
                Position = _startPosition;
                _animationManager.SetDirection(Direction.Right);
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
                }
            }

            Move();
        }
    }
}
