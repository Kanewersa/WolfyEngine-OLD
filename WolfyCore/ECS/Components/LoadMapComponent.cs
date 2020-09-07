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
    }
}