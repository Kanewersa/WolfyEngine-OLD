using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
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
                    if (actionComponent.Actions != null)
                    {
                        //List<WolfyAction> copiedActions = new List<WolfyAction>(actionComponent.Actions.ToList());
                        ActionsManager.PushActions(actionComponent.Actions);
                    }
                    
                    actionComponent.Executed = true;
                }

                if (ActionsManager.Empty)
                {
                    var metEntity = entity.GetComponent<StartActionComponent>().MetEntity;
                    metEntity.GetComponent<MovementComponent>().LockedMovement = false;
                    entity.RemoveComponent<StartActionComponent>();
                    entity.RemoveComponent<ActionComponent>();
                    actionComponent.Executed = false;
                }
            });

            ActionsManager.Update();
        }
    }
}
