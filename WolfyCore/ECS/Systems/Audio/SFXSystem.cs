using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.ECS
{
    [ProtoContract] public class SFXSystem : EntitySystem
    {
        public ContentManager ContentManager { get; private set; }

        /// <summary>
        /// Maximum distance from which sfx can be heard.
        /// </summary>
        public const int MaxDistance = 100;

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
            var playerTransform = Entity.Player.GetComponent<TransformComponent>();

            IterateEntities(entity =>
            {
                var transform = entity.GetComponent<TransformComponent>();
                if (transform.CurrentMap != playerTransform.CurrentMap) return;

                var audio = entity.GetComponent<SFXComponent>();

                if (audio.Timer > 0f)
                {
                    audio.Timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                    return;
                }

                if (!WolfyHelper.RollChance(audio.PlayChance)) return;
                
                // Reset the timer.
                audio.Timer = audio.PlayDelay;

                audio.Sound ??= ContentManager.Load<SoundEffect>(audio.AudioFile);
                
                var distance = Vector2.Distance(transform.GridTransform, playerTransform.GridTransform);

                var volume = 1f;
                if (audio.Volume == -1)
                {
                    if (distance > MaxDistance)
                        volume = 0;
                    else volume /= distance; // TODO: Enhance volume equation.
                }
                else volume = audio.Volume;
                
                audio.Sound.Play(volume, 0, 0);
            });
        }
    }
}

