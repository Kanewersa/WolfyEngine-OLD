using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class AnimationComponent : EntityComponent
    {
        [ProtoMember(1)] private Vector2 _position;
        [ProtoMember(2)] public AnimationManager AnimationManager { get; set; }
        [ProtoMember(3)] public Dictionary<string, Animation> Animations { get; set; }
        [ProtoMember(4)] public Image Image { get; set; }
        [ProtoIgnore] public Texture2D Texture => Image.Texture;

        public virtual Rectangle Bounds =>
            new Rectangle(0, 0, Animations["Walk"].FrameWidth, Animations["Walk"].FrameHeight);

        [ProtoIgnore] public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;

                if (AnimationManager != null)
                    AnimationManager.Position = _position;
            }
        }

        public void LoadContent(ContentManager content)
        {
            AnimationManager.LoadContent(content);
            foreach (var animation in Animations)
            {
                animation.Value.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            AnimationManager.Draw(spriteBatch);
        }
    }
}
