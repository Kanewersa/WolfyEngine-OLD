using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyShared.Engine
{
    [ProtoContract] public class AnimationManager
    {
        [ProtoIgnore] private Animation _animation;
        [ProtoIgnore] public Animation Animation
        {
            get => _animation;
            private set
            {
                _animation = value;
                if(Animation.Image.Texture != null)
                    GetAnimationOffset(_animation, GridSize);
            }
        }

        [ProtoMember(1)] private float _timer;
        [ProtoMember(2)] public int GridSize { get; set; }
        [ProtoMember(3)] public Vector2 Position { get; set; }
        [ProtoMember(4)] public Vector2 PositionOffset { get; set; }
        [ProtoMember(5)] public Direction Direction { get; set; }

        public AnimationManager() { }

        public AnimationManager(Animation animation, int gridSize)
        {
            GridSize = gridSize;
            Animation = animation;
            Direction = Direction.Down;
        }

        public void Initialize(Animation animation)
        {
            Animation = animation;
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

        public void SetDirection(Direction direction)
        {
            Direction = direction;
            Animation.CurrentDirection = Direction switch
            {
                Direction.Up => 3,
                Direction.Down => 0,
                Direction.Left => 1,
                Direction.Right => 2,
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
