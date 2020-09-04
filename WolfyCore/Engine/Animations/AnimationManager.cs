using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using System;

namespace WolfyCore.Engine
{
    [ProtoContract] public class AnimationManager
    {
        [ProtoIgnore] private Animation _animation;
        [ProtoMember(2)] public Animation Animation
        {
            get => _animation;
            private set
            {
                _animation = value;
                if(Animation.Image.Texture != null)
                    SetAnimationOffset(_animation);
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

        public void LoadContent(ContentManager content)
        {
            if (_animation != null)
            {
                _animation?.LoadContent(content);
                SetAnimationOffset(_animation);
            }
            else
            {
                throw new Exception("Could not load animation in AnimationManager.");
            }
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
            Animation.CurrentFrame = 0;
            _timer = 0;
        }

        private void SetAnimationOffset(Animation animation)
        {
            PositionOffset = new Vector2(
                -(animation.FrameWidth - TileSize.X) / 2.0f,
                -(animation.FrameHeight - TileSize.Y));
        }

        public void SetDirection(int direction)
        {
            Direction = direction;
            Animation.CurrentDirection = direction;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > 1f/Animation.FrameCount)
            {
                _timer = 0f;

                Animation.CurrentFrame++;

                if (Animation.CurrentFrame >= Animation.FrameCount)
                    Animation.CurrentFrame = 0;
            }
        }
    }
}
