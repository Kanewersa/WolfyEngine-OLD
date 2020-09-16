using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class SFXComponent : EntityComponent
    {
        /// <summary>
        /// Name of the audio file.
        /// </summary>
        [ProtoMember(1)] public string AudioFile;

        /// <summary>
        /// Chance of playing the sound.
        /// </summary>
        [ProtoMember(2)] public short PlayChance;

        /// <summary>
        /// Delay between playing the sound.
        /// </summary>
        [ProtoMember(3)] public short PlayDelay;

        /// <summary>
        /// Maximum distance from which sound can be heard.
        /// </summary>
        [ProtoMember(4)] public float MaxDistance;

        /// <summary>
        /// Indicates if sound can be played again.
        /// </summary>
        [ProtoMember(5)] public float Timer;

        /// <summary>
        /// Indicates if Sfx was played at least once.
        /// </summary>
        [ProtoMember(6)] public bool Played;

        /// <summary>
        /// Sound volume.
        /// </summary>
        [ProtoMember(7)] public float Volume;

        /// <summary>
        /// The loaded sound.
        /// </summary>
        [ProtoIgnore] public SoundEffect Sound;
        
        public SFXComponent() { }

        public SFXComponent(string audioFile, short playChance, short playDelay, float volume = -1)
        {
            AudioFile = audioFile;
            PlayChance = playChance;
            PlayDelay = playDelay;
            Volume = volume;
        }
    }
}
