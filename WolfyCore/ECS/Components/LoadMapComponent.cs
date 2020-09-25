using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class LoadMapComponent : EntityComponent
    {
        /// <summary>
        /// Id of the map to load.
        /// </summary>
        [ProtoMember(1)] public int MapId;

        /// <summary>
        /// The last map that was loaded.
        /// </summary>
        [ProtoMember(2)] public int LastMap;
    }
}