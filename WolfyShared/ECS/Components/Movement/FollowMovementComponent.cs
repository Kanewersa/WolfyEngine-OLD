using WolfyECS;

namespace WolfyShared.ECS
{
    public class FollowMovementComponent : EntityComponent
    {
        public int Range { get; set; }
        public float Timer { get; set; }
    }
}