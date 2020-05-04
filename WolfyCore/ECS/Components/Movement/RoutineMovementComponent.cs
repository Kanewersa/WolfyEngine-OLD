using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class RoutineMovementComponent : EntityComponent
    {
        [ProtoMember(1)] public float Timer { get; set; }

        public RoutineMovementComponent() { }
    }
}
