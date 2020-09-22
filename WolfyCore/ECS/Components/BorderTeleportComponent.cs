using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract]
    public class BorderTeleportComponent : EntityComponent
    {
        /// <summary>
        /// Contains information about map border.
        /// </summary>
        [ProtoMember(1)] public MapBorderComponent Info { get; set; }

        /// <summary>
        /// Indicates if entity was moved.
        /// </summary>
        [ProtoMember(2)] public bool Moved { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BorderTeleportComponent() { }

        /// <summary>
        /// Creates border teleport component.
        /// </summary>
        /// <param name="info">Border component containing teleportation info.</param>
        public BorderTeleportComponent(MapBorderComponent info)
        {
            Info = info;
        }
    }
}
