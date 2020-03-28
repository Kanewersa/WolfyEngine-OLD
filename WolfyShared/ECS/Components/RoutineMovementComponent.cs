using WolfyECS;

namespace WolfyShared.ECS
{
    public class RoutineMovementComponent : EntityComponent
    {
        public float MovementFrequency { get; set; }
        public float Timer { get; set; }
    }
}
