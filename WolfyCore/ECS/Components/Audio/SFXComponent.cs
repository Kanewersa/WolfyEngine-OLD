using ProtoBuf;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class SFXComponent : EntityComponent
    {
        /// <summary>
        /// The sound to be played.
        /// </summary>
        [ProtoMember(1)] public Sound Sound { get; private set; }

        public SFXComponent() { }

        public SFXComponent(string audioFile, short playChance, short playDelay, float volume = -1)
        {
            Sound = new Sound(audioFile, volume);
        }
    }
}
