using ProtoBuf;
using WolfyECS;

namespace WolfyShared.ECS
{
    [ProtoContract] public class CollisionComponent : EntityComponent
    {
        [ProtoMember(1)] public bool IsCollider;

        public CollisionComponent() { }
    }
}
