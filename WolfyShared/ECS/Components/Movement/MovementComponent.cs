using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;
using WolfyShared.Engine;

namespace WolfyShared.ECS
{
    [ProtoContract] public class MovementComponent : EntityComponent
    {
        [ProtoMember(1)] public Vector2 Transform { get; set; }
        [ProtoMember(2)] public Vector2 GridPosition { get; set; }
        [ProtoMember(3)] public Vector2 Direction { get; set; }
        [ProtoIgnore] public Vector2 GridDirection => Direction / 32;
        [ProtoIgnore] public Vector2 NormalizedDirection => Vector2.Normalize(Direction);
        [ProtoMember(4)] public Direction EnumDirection { get; set; }
        [ProtoMember(5)] public bool IsMoving { get; set; }
        [ProtoMember(6)] public bool WasMoving { get; set; } 
        
        // Editor fields
        [ProtoMember(7)] public MovementType MovementType { get; set; }
        [ProtoMember(8)] public float Speed { get; set; }
        [ProtoMember(9)] public float Frequency { get; set; }

        public MovementComponent() { }
    }
}
