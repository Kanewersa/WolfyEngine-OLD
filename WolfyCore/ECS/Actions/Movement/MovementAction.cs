using System;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.Actions
{
    [ProtoContract] public class MovementAction : WolfyAction
    {
        /// <summary>
        /// Movement direction.
        /// </summary>
        [ProtoMember(1)] public int Direction { get; set; }

        /// <summary>
        /// Determines if movement ignores collision.
        /// </summary>
        [ProtoMember(2)] public bool Collision { get; set; }

        public MovementAction() { }

        public MovementAction(Entity target, int direction, bool asynchronous, bool ignoreCollision)
        {
            Asynchronous = asynchronous;
            Target = target;
            Direction = direction;
            Collision = ignoreCollision;
        }

        public override void Execute()
        {
            if(Target.HasComponent<MovementActionComponent>())
                throw new Exception("Could not perform MovementAction on target entity. Entity already had action component.");

            var transform = Target.GetComponent<TransformComponent>().GridTransform;
            var actionComponent = new MovementActionComponent(transform, transform + WolfyCore.Direction.Get(Direction), Collision);
            Target.AddComponent(actionComponent);
            if (Asynchronous) 
                Complete();
            
        }

        public override void Validate(GameTime gameTime)
        {
            if (!Target.HasComponent<MovementActionComponent>())
                Complete();
        }

        public override string GetDescription()
        {
            return "Move " + Target + " by vector: " + WolfyCore.Direction.Get(Direction);
        }
    }
}
