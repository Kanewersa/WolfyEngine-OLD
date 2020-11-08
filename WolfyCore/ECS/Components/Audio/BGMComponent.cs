using ProtoBuf;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class BGMComponent : EntityComponent
    {
        /// <summary>
        /// Stores information about the BGM.
        /// </summary>
        [ProtoMember(1)] public Sound Sound { get; set; }

        /// <summary>
        /// Determines if BGM should have priority in sound play.
        /// </summary>
        [ProtoMember(2)] public bool Important { get; set; }

        /// <summary>
        /// Determines if BGM should be looped.
        /// </summary>
        [ProtoMember(3)] public bool IsRepeating { get; set; }
    }
}
