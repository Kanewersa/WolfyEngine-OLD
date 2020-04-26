using ProtoBuf;
using WolfyECS;

namespace WolfyShared.ECS
{
    [ProtoContract] public class RandomMovementComponent : EntityComponent
    {
        [ProtoMember(1)] public float Timer { get; set; }

        public RandomMovementComponent() { }
    }
}
