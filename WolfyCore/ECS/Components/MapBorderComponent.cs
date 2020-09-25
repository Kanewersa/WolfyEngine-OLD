using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Entities with that component teleport other entities to different map.
    /// </summary>
    [ProtoContract]
    public class MapBorderComponent : EntityComponent
    {
        /// <summary>
        /// The map on which entity is located.
        /// </summary>
        [ProtoMember(1)] public int OriginMap { get; set; }

        /// <summary>
        /// The map to which entities are teleported.
        /// </summary>
        [ProtoMember(2)] public int TargetMap { get; set; }

        /// <summary>
        /// The entity coordinates.
        /// </summary>
        [ProtoMember(3)] public Vector2 Origin { get; set; }

        /// <summary>
        /// The coordinates to which entities are teleported.
        /// </summary>
        [ProtoMember(4)] public Vector2 Target { get; set; }

        /// <summary>
        /// The direction to move the entity before teleport.
        /// </summary>
        [ProtoMember(5)] public int OriginDirection { get; set; }

        /// <summary>
        /// The direction to move the entity after teleport.
        /// </summary>
        [ProtoMember(6)] public int TargetDirection { get; set; }

        public MapBorderComponent() { }
    }
}
