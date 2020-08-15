﻿using System;
using Microsoft.Xna.Framework;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyCore.Actions
{
    public class MovementAction : WolfyAction
    {
        public MovementActionComponent ActionComponent;

        public MovementAction() { }

        public MovementAction(Entity target, Vector2 startTransform, Vector2 endTransform)
        {
            Asynchronous = false;
            Target = target;
            ActionComponent = new MovementActionComponent(startTransform, endTransform);
        }

        public override void Execute()
        {
            if(Target.HasComponent<MovementActionComponent>())
                throw new Exception("Could not perform MovementAction on target entity. Entity already had action component.");
            Target.AddComponent(ActionComponent);
        }

        public override void Validate()
        {
            if (!Target.HasComponent<MovementActionComponent>())
                Completed = true;
        }

        public override string GetDescription()
        {
            return "Move " + Target + " from " + ActionComponent.StartGridTransform + " to " +
                   ActionComponent.TargetGridTransform;
        }
    }
}