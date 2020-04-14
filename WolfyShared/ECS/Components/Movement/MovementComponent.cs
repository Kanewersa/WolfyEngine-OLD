using Microsoft.Xna.Framework;
using WolfyECS;
using WolfyShared.Engine;

namespace WolfyShared.ECS
{
    public class MovementComponent : EntityComponent
    {
        public Vector2 Transform { get; set; }
        public Vector2 GridPosition { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 GridDirection => Direction / 32;
        public Vector2 NormalizedDirection => Vector2.Normalize(Direction);
        public Direction EnumDirection { get; set; }
        public bool IsMoving { get; set; }
        public bool WasMoving { get; set; } 
        
        // Editor fields
        public MovementType MovementType { get; set; }
        public float Speed { get; set; }
        public float Frequency { get; set; }
    }
}
