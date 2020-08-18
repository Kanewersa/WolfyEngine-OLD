using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class RandomMovementComponent : EntityComponent
    {
        [ProtoMember(1)] public float Timer;
        [ProtoMember(2)] public float Delay;

        public RandomMovementComponent() { }
    }
}
