using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class RandomMovementComponent : EntityComponent
    {
        [ProtoMember(1)] public float Timer { get; set; }

        public RandomMovementComponent() { }
    }
}
