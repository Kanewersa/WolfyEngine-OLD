using System.Collections.Generic;
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
        //[ProtoMember(1)] public Sound Sound { get; private set; }

        /// <summary>
        /// The sounds to be played.
        /// </summary>
        [ProtoMember(1)] public List<Sound> Sounds { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SFXComponent() { }

        /// <summary>
        /// Creates new <see cref="SFXComponent"/> with new list containing given sound.
        /// </summary>
        /// <param name="sound">Sound to be added to the list.</param>
        public SFXComponent(Sound sound)
        {
            Sounds ??= new List<Sound>();
            
            Sounds.Add(sound);
        }

        /// <summary>
        /// Creates new <see cref="SFXComponent"/> from given list.
        /// </summary>
        /// <param name="sounds">List of the sounds.</param>
        public SFXComponent(List<Sound> sounds)
        {
            Sounds = sounds;
        }

        /// <summary>
        /// Adds given sound to the sounds list.
        /// </summary>
        /// <param name="sound">Sound to be added to the list.</param>
        public void AddSound(Sound sound)
        {
            Sounds ??= new List<Sound>();

            Sounds.Add(sound);
        }

        /// <summary>
        /// Removes given sound from the sounds list.
        /// </summary>
        /// <param name="sound">Sound to be removed from the list.</param>
        public void RemoveSound(Sound sound)
        {
            Sounds ??= new List<Sound>();

            Sounds.Remove(sound);
        }
    }
}
