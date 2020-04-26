using ProtoBuf;
using WolfyECS;

namespace WolfyShared.ECS
{
    [ProtoContract] public class RoutineMovementComponent : EntityComponent
    {
        [ProtoMember(1)] public float Timer { get; set; }

        public RoutineMovementComponent() { }
    }
}
