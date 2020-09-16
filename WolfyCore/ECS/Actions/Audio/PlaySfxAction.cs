using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyCore.ECS
{
    public class PlaySfxAction : WolfyAction
    {
        [ProtoMember(1)] public string AudioFile { get; private set; }
        [ProtoMember(2)] public float Volume { get; private set; }
        public PlaySfxAction(Entity target, string audioFile, float volume)
        {
            Target = target;
            AudioFile = audioFile;
            Volume = volume;
        }
        public override void Execute()
        {
            var audioComponent = new SFXComponent(AudioFile, 1, 0, Volume);
            Target.AddComponent(audioComponent);
        }

        public override void Validate(GameTime gameTime)
        {
            if (Target.GetComponent<SFXComponent>().Played)
            {
                Target.RemoveComponent<SFXComponent>();
                Complete();
            }
        }

        public override string GetDescription()
        {
            return "Play sound: " + AudioFile;
        }
    }
}
