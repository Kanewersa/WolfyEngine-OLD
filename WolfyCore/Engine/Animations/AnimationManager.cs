using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyCore.Engine
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
                    GetAnimationOffset(_animation);
            }
        }

        [ProtoMember(1)] private float _timer;
        [ProtoIgnore] public Vector2D TileSize => Runtime.TileSize;
        [ProtoMember(3)] public Vector2 Position { get; set; }
        [ProtoMember(4)] public Vector2 PositionOffset { get; set; }
        [ProtoMember(5)] public int Direction { get; set; }

        public AnimationManager() { }

        public AnimationManager(Animation animation)
        {
            Animation = animation;
            Direction = 2;
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

        private void GetAnimationOffset(Animation animation)
        {
            var width = -(animation.FrameWidth - TileSize.X) / 2;
            var height = -(animation.FrameHeight - TileSize.Y);
            PositionOffset = new Vector2(width, height);
        }

        public void SetDirection(int direction)
        {
            Direction = direction;
            Animation.CurrentDirection = direction;
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
