using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class FollowMovementComponent : EntityComponent
    {
        [ProtoMember(1)] public int Range { get; set; }
        [ProtoMember(2)] public float Timer { get; set; }

        public FollowMovementComponent() { }
    }
}