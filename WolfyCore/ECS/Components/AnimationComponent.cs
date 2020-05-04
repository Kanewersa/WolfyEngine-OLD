using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Engine;
using WolfyECS;
using Image = WolfyCore.Engine.Image;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace WolfyCore.ECS
{
    [ProtoContract] public class AnimationComponent : EntityComponent
    {
        [ProtoMember(1)] private Vector2 _position;

        [ProtoMember(2)] public Vector2 StartPosition { get; set; }
        [ProtoMember(3)] public Vector2 EndPosition { get; set; }
        //[ProtoMember(4)] public Vector2 PositionOffset { get; set; }
        [ProtoMember(5)] public AnimationManager AnimationManager { get; set; }
        [ProtoMember(6)] public Dictionary<string, Animation> Animations { get; set; }
        [ProtoMember(7)] public Engine.Image Image { get; set; }
        [ProtoIgnore] public Texture2D Texture => Image.Texture;

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

        public AnimationComponent() { }
    }
}
