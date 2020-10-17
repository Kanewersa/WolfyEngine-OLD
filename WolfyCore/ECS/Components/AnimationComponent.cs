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

        [ProtoIgnore] public bool Initialized { get; set; }
        [ProtoIgnore] public bool PreserveAnimation { get; set; }

        public Rectangle Bounds =>
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

        /// <summary>
        /// Loads all the animations' content.
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            if (string.IsNullOrEmpty(AnimationManager.Animation.Image.Path))
                return;
            
            AnimationManager.LoadContent(content);

            foreach (var animation in Animations)
            {
                animation.Value.LoadContent(content);
            }

            Initialized = true;
        }

        /// <summary>
        /// Draws the animation manager.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            AnimationManager.Draw(spriteBatch);
        }

        /// <summary>
        /// Sets the direction in <see cref="AnimationManager"/>.
        /// </summary>
        /// <param name="direction"></param>
        public void SetDirection(int direction)
        {
            AnimationManager.SetDirection(direction);
        }

        /// <summary>
        /// Disposes the textures in animation manager and all animations.
        /// </summary>
        public void Unload()
        {
            foreach (var animation in Animations)
            {
                animation.Value.Unload();
            }
        }
    }
}
