using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Present if no collision occurred due to movement.
    /// </summary>
    [ProtoContract]
    public class NoCollisionComponent : EntityComponent
    {
        /// <summary>
        /// Stores information about movement action.
        /// </summary>
        [ProtoMember(1)] public MovementActionComponent Info { get; set; }

        /// <summary>
        /// Determines if entity position on map was changed.
        /// </summary>
        [ProtoMember(2)] public bool MovedOnMap { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NoCollisionComponent() { }

        /// <summary>
        /// Creates <see cref="NoCollisionComponent"/> with given movement data.
        /// </summary>
        /// <param name="info">Movement data.</param>
        public NoCollisionComponent(MovementActionComponent info)
        {
            Info = info;
        }
    }
}
