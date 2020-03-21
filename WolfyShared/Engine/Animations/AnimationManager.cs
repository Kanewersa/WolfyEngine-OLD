using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyShared.Engine
{
    public class AnimationManager
    {
        private Animation _animation;
        public Animation Animation
        {
            get => _animation;
            private set
            {
                _animation = value;
                GetAnimationOffset(_animation, GridSize);
            }
        }

        private float _timer;
        

        public int GridSize { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PositionOffset { get; set; }
        public Directions Direction { get; set; }

        public AnimationManager(Animation animation, int gridSize)
        {
            GridSize = gridSize;
            Animation = animation;
            Direction = Directions.Down;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Animation.Texture,
                Position + PositionOffset,
                new Rectangle(
                    Animation.CurrentFrame * Animation.FrameWidth,
                    Animation.CurrentDirection * Animation.FrameHeight,
                    Animation.FrameWidth,
                    Animation.FrameHeight),
                Color.White);
        }

        public void Play(Animation animation)
        {
            if (Animation == animation)
                return;

            Animation = animation;
            Animation.CurrentFrame = 0;
            _timer = 0;
        }

        public void Stop()
        {
            _timer = 0;

            Animation.CurrentFrame = 0;
        }

        private void GetAnimationOffset(Animation animation, int gridSize)
        {
            var width = -(animation.FrameWidth - gridSize) / 2;
            var height = -(animation.FrameHeight - gridSize);
            PositionOffset = new Vector2(width, height);
        }

        public void SetDirection(Directions direction)
        {
            Direction = direction;
            Animation.CurrentDirection = Direction switch
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

            if (_timer > Animation.FrameSpeed)
            {
                _timer = 0f;

                Animation.CurrentFrame++;

                if (Animation.CurrentFrame >= Animation.FrameCount)
                    Animation.CurrentFrame = 0;

            }
        }
    }
}
