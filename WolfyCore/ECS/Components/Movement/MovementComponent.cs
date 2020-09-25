using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Engine;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.ECS
{
    [ProtoContract] public class MovementComponent : EntityComponent
    {
        [ProtoMember(1)] public Vector2 DirectionVector { get; set; }
        [ProtoIgnore] public int Direction => WolfyCore.Direction.Get(DirectionVector);
        [ProtoMember(2)] public bool LockedMovement;
        [ProtoMember(3)] public float Speed;

        // Editor fields
        [ProtoMember(4)] public MovementType MovementType;

        public MovementComponent() { }

        public void LockMovement()
        {
            LockedMovement = true;
        }

        public void UnlockMovement()
        {
            LockedMovement = false;
        }
    }
}
