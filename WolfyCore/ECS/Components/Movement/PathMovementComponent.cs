using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract]
    public class PathMovementComponent : EntityComponent
    {
        [ProtoMember(1)] public List<Vector2> MovementPath { get; set; }

        public PathMovementComponent() { }

        public PathMovementComponent(List<Vector2> movementPath)
        {
            MovementPath = movementPath;
        }
    }
}
