using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using ProtoBuf;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class BGMSystem : EntitySystem
    {
        [ProtoMember(1)] public BGMComponent CurrentBGM { get; set; }

        [ProtoIgnore] public ContentManager ContentManager { get; set; }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<BGMComponent>();
        }

        public override void LoadContent(ContentManager content)
        {
            ContentManager = content;

            if (CurrentBGM != null)
            {
                PlaySong(CurrentBGM);
            }
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var newBGM = entity.GetComponent<BGMComponent>();

                if (CurrentBGM != null && CurrentBGM.Important && !newBGM.Important)
                {
                    entity.RemoveComponent<BGMComponent>();
                    return;
                }

                if (newBGM.Sound == null)
                {
                    newBGM.Important = false;
                    MediaPlayer.Stop();
                }
                else
                {
                    PlaySong(newBGM);
                }

                CurrentBGM = newBGM;

                entity.RemoveComponent<BGMComponent>();
            });
        }

        private void PlaySong(BGMComponent bgm)
        {
            var song = ContentManager.Load<Song>(bgm.Sound.AudioFile);
            MediaPlayer.IsRepeating = bgm.IsRepeating;
            MediaPlayer.Play(song);
        }
    }
}
