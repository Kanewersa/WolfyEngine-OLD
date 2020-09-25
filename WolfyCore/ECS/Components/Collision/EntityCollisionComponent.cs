using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Present if entity-entity collision occurred.
    /// </summary>
    [ProtoContract]
    public class EntityCollisionComponent : EntityComponent
    {
        /// <summary>
        /// Stores information about movement action.
        /// </summary>
        [ProtoMember(1)] public MovementActionComponent Info { get; set; }

        /// <summary>
        /// The entity that triggered the interaction.
        /// </summary>
        [ProtoMember(2)] public Entity Source { get; set; }

        /// <summary>
        /// The entity on which the interaction was triggered.
        /// </summary>
        [ProtoMember(3)] public Entity Target { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EntityCollisionComponent() { }

        public EntityCollisionComponent(Entity source, Entity target, MovementActionComponent info)
        {
            Source = source;
            Target = target;
            Info = info;
        }
    }
}
