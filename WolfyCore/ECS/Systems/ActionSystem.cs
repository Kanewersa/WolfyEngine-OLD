﻿using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class ActionSystem : EntitySystem
    {
        [ProtoMember(1)] public ActionsManager ActionsManager;

        public ActionSystem()
        {
            ActionsManager = new ActionsManager();
        }

        public override void Initialize()
        {
            RequireComponent<ActionComponent>();
            RequireComponent<StartActionComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var actionComponent = entity.GetComponent<ActionComponent>();
                if (!actionComponent.Executed)
                {
                    ActionsManager.PushActions(actionComponent.Actions);
                }

                if (ActionsManager.Empty)
                {
                    entity.RemoveComponent<StartActionComponent>();
                    entity.RemoveComponent<ActionComponent>();
                }
            });

            ActionsManager.Update();
        }
    }
}