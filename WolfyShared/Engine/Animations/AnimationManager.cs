using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyShared.Engine
{
    public class AnimationManager
    {
        private Animation _animation;

        private float _timer;

        public Vector2 Position { get; set; }
        public Directions Direction { get; set; }

        public AnimationManager(Animation animation)
        {
            _animation = animation;
            Direction = Directions.Down;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture,
                Position,
                new Rectangle(
                    _animation.CurrentFrame * _animation.FrameWidth,
                    _animation.CurrentDirection * _animation.FrameHeight,
                    _animation.FrameWidth,
                    _animation.FrameHeight),
                Color.White);
        }

        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;

            _animation = animation;
            _animation.CurrentFrame = 0;
            _timer = 0;
        }

        public void Stop()
        {
            _timer = 0;

            _animation.CurrentFrame = 0;
        }

        public void SetDirection(Directions direction)
        {
            Direction = direction;
            _animation.CurrentDirection = Direction switch
            {
                Directions.Up => 3,
                Directions.Down => 0,
                Directions.Left => 1,
                Directions.Right => 2,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;

                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                    _animation.CurrentFrame = 0;

            }
        }
    }
}
