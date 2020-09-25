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
        /// Indicates how many times entity was moved before teleportation.
        /// </summary>
        [ProtoMember(2)] public short MovedCount { get; set; }

        /// <summary>
        /// Entity that was "covered" on map by entity to teleport.
        /// </summary>
        [ProtoMember(3)] public Entity CoveredEntity { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BorderTeleportComponent() { }

        /// <summary>
        /// Creates border teleport component.
        /// </summary>
        /// <param name="info">Border component containing teleportation info.</param>
        /// <param name="metEntity"></param>
        public BorderTeleportComponent(MapBorderComponent info, Entity metEntity)
        {
            Info = info;
            CoveredEntity = metEntity;
        }
    }
}
