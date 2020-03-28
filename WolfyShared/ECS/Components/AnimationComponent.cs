using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WolfyECS;
using WolfyShared.Engine;

namespace WolfyShared.ECS
{
    public class AnimationComponent : EntityComponent
    {
        private Vector2 _position;

        public Vector2 StartPosition { get; set; }
        public Vector2 EndPosition { get; set; }
        public Vector2 PositionOffset { get; set; }
        public AnimationManager AnimationManager { get; set; }
        public Dictionary<string, Animation> Animations { get; set; }
        public Image Image { get; set; }
        public Texture2D Texture => Image.Texture;

        public Vector2 Velocity;
        public virtual Rectangle Bounds =>
            new Rectangle(0, 0, Animations["Walk"].FrameWidth, Animations["Walk"].FrameHeight);

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;

                if (AnimationManager != null)
                    AnimationManager.Position = _position;
            }
        }
    }
}
