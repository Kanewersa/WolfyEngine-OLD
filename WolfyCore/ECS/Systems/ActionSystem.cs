using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<ActionComponent>();
            RequireComponent<StartActionComponent>();

            ActionsManager.Initialize(graphics);
        }

        public override void LoadContent(ContentManager content)
        {
            ActionsManager.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var actionComponent = entity.GetComponent<ActionComponent>();

                // If actions were not yet executed
                if (!actionComponent.Executed)
                {
                    // If there are actions to be executed
                    if (actionComponent.Actions != null)
                    {
                        // Push actions to execute
                        ActionsManager.PushActions(actionComponent.Actions);
                    }
                    
                    actionComponent.Executed = true;
                }

                // If all actions were executed
                if (ActionsManager.Empty)
                {
                    // Unlock the movement of met entity
                    var metEntity = entity.GetComponent<StartActionComponent>().MetEntity;
                    metEntity.GetComponent<MovementComponent>().LockedMovement = false;

                    // Remove action component
                    entity.RemoveComponent<StartActionComponent>();
                    entity.RemoveComponent<ActionComponent>();
                    actionComponent.Executed = false;
                }
            });

            ActionsManager.Update(gameTime);
        }
    }
}
