using System;
using Microsoft.Xna.Framework.Audio;
using ProtoBuf;

namespace WolfyCore.Game
{
    [ProtoContract] public class Sound
    {
        private float _pitch;
        private float _pan;
        private float _volume;

        /// <summary>
        /// Name of the audio file.
        /// </summary>
        [ProtoMember(1)] public string AudioFile { get; set; }

        /// <summary>
        /// Volume of the sound.
        /// </summary>
        /// <value>Ranging from 0.0 (silence) to 1.0 (full volume).</value>
        [ProtoMember(2)]
        public float Volume
        {
            get => _volume;
            set
            {
                if (value < 0 || value > 1)
                    throw new Exception("Volume value was out of the range.");
                _volume = value;
            }
        }

        /// <summary>
        /// Maximum distance from which sound can be heard.
        /// </summary>
        [ProtoMember(3)] public float HearingRange { get; set; }

        /// <summary>
        /// Determines how much the volume changes due to sound distance change.
        /// </summary>
        [ProtoMember(4)] public float HearingDecreaseRate { get; set; }

        /// <summary>
        /// Determines if volume should be calculated based on sound distance.
        /// </summary>
        [ProtoMember(5)] public bool RangedBasedVolume { get; set; }

        /// <summary>
        /// Determines the sound distribution into multi-channel sound field.
        /// </summary>
        /// <value>Ranging from -1.0 (left speaker) to 1.0 (right speaker).</value>
        [ProtoMember(6)]
        public float Pan
        {
            get => _pan;
            set
            {
                if (value < -1 || value > 1)
                    throw new Exception("Pan value was out of the range.");
                _pan = value;
            }
        }

        /// <summary>
        /// Pitch of the sound.
        /// </summary>
        /// <value>Ranging from -1.0 (down an octave) to 1.0 (up an octave).</value>
        [ProtoMember(7)]
        public float Pitch
        {
            get => _pitch;
            set
            {
                if(value < -1 || value > 1)
                    throw new Exception("Pitch value was out of the range.");
                _pitch = value;
            }
        }

        /// <summary>
        /// Determines if sound should be played continuously.
        /// </summary>
        [ProtoMember(8)] public bool Loop { get; set; }

        /// <summary>
        /// The delay (in seconds) before sound is played again.
        /// </summary>
        [ProtoMember(9)] public float LoopDelay { get; set; }

        /// <summary>
        /// The loaded sound.
        /// </summary>
        [ProtoIgnore] public SoundEffect SoundEffect { get; set; }

        public Sound() { }

        public Sound(string audioFile, float volume = 1, bool loop = false)
        {
            AudioFile = audioFile;
            Volume = volume;
            Loop = loop;
        }
    }
}
