using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class SFXSystem : EntitySystem
    {
        [ProtoIgnore] public ContentManager ContentManager { get; private set; }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<TransformComponent>();
            RequireComponent<SFXComponent>();
        }

        public override void LoadContent(ContentManager content)
        {
            ContentManager = content;
        }

        public override void Update(GameTime gameTime)
        {
            var playerTransform = ECS.Entities.Player.GetComponent<TransformComponent>();

            IterateEntities(entity =>
            {
                var audio = entity.GetComponent<SFXComponent>();
                var sound = audio.Sound;

                if (sound.RangedBasedVolume)
                {
                    var transform = entity.GetComponent<TransformComponent>();

                    var distance = Vector2.Distance(transform.Transform, playerTransform.Transform);

                    if (distance > sound.HearingRange)
                        return;

                    sound.Volume = (sound.HearingRange - distance * sound.HearingDecreaseRate) / sound.HearingRange;
                }

                sound.SoundEffect ??= ContentManager.Load<SoundEffect>(sound.AudioFile);

                sound.SoundEffect.Play(sound.Volume, sound.Pitch, sound.Pan);

                entity.RemoveComponent<SFXComponent>();
            });
        }
    }
}

