using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Present if entity should ignore collision check.
    /// </summary>
    [ProtoContract]
    public class IgnoreCollisionComponent : EntityComponent
    {
        /// <summary>
        /// Direction which will be ignored.
        /// 4 means all directions.
        /// </summary>
        [ProtoMember(1)] public short Direction { get; set; }
        
        /// <summary>
        /// Determines if component is deleted after one frame.
        /// </summary>
        [ProtoMember(2)] public bool Permanent { get; set; }

        public IgnoreCollisionComponent() { }

        public IgnoreCollisionComponent(short direction, bool permanent = false)
        {
            Direction = direction;
        }
    }
}
