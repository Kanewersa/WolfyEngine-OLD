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
        public int OriginMap { get; set; }

        /// <summary>
        /// The map to which entities are teleported.
        /// </summary>
        public int TargetMap { get; set; }

        /// <summary>
        /// The entity coordinates.
        /// </summary>
        public Vector2 Origin { get; set; }

        /// <summary>
        /// The coordinates to which entities are teleported.
        /// </summary>
        public Vector2 Target { get; set; }

        /// <summary>
        /// The direction to move the entity before teleport.
        /// </summary>
        public int OriginDirection { get; set; }

        /// <summary>
        /// The direction to move the entity after teleport.
        /// </summary>
        public int TargetDirection { get; set; }
    }
}
