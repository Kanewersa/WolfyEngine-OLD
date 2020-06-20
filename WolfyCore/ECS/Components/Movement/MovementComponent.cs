﻿using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Engine;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.ECS
{
    [ProtoContract] public class MovementComponent : EntityComponent
    {
        [ProtoMember(1)] public Vector2 DirectionVector;
        [ProtoIgnore] public int Direction => WolfyHelper.GetDirection(DirectionVector);
        [ProtoMember(2)] public bool IsMoving;
        [ProtoMember(3)] public float Speed;

        // Editor fields
        [ProtoMember(4)] public MovementType MovementType;

        public MovementComponent() { }
    }
}