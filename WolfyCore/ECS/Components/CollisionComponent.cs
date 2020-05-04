using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class CollisionComponent : EntityComponent
    {
        [ProtoMember(1)] public bool IsCollider;

        public CollisionComponent() { }
    }
}
