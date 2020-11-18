using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyECS;

namespace WolfyCore.Actions
{
    [ProtoContract] public class ChangeBGMAction : WolfyAction
    {
        [ProtoMember(1)] public string SongTitle;
        [ProtoMember(2)] public int Volume;
        [ProtoMember(3)] public bool IsRepeating;

        public ChangeBGMAction() { }

        public ChangeBGMAction(Entity target, string songTitle, int volume, bool isRepeating)
        {
            Asynchronous = true;
            Target = target;
            SongTitle = songTitle;
            Volume = volume;
            // TODO: Fix BGM repeating.
            IsRepeating = isRepeating;
        }

        public override void Execute()
        {
            if (string.IsNullOrEmpty(SongTitle))
            {
                MediaPlayer.Stop();
                return;
            }

            var bgmPath = Path.Combine(PathsController.Instance.BgmPath, SongTitle);

            bgmPath = Path.ChangeExtension(bgmPath, null);

            Song song = Content.Load<Song>(bgmPath);
            MediaPlayer.Play(song);
        }

        public override void Validate(GameTime gameTime)
        {
            Complete();
        }

        public override string GetDescription()
        {
            if (string.IsNullOrEmpty(SongTitle))
            {
                return "Disable background music";
            }
            return "Change background music to: " + SongTitle;
        }
    }
}
