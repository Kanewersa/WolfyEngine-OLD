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
        public EntityCollisionComponent() { }

        public EntityCollisionComponent(Entity source, Entity target)
        {
            Source = source;
            Target = target;
        }

        /// <summary>
        /// The entity that triggered the interaction.
        /// </summary>
        public Entity Source { get; set; }

        /// <summary>
        /// The entity on which the interaction was triggered.
        /// </summary>
        public Entity Target { get; set; }
    }
}
