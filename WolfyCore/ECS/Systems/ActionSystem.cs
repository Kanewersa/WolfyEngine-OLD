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

        public ActionSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            ActionsManager ??= new ActionsManager();
            ActionsManager.Initialize(graphics);

            RequireComponent<StartActionComponent>();
        }

        public override void LoadContent(ContentManager content)
        {
            ActionsManager.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var actionComponent = entity.GetComponent<StartActionComponent>();

                if (actionComponent.Executed)
                {
                    if (ActionsManager.Empty)
                        entity.RemoveComponent<StartActionComponent>();
                    
                    return;
                }

                if (actionComponent.Asynchronous)
                {
                    ActionsManager.ExecuteActions(actionComponent.Actions);
                    entity.RemoveComponent<StartActionComponent>();
                }
                else
                {
                    ActionsManager.PushActions(actionComponent.Actions);
                    actionComponent.Executed = true;
                }
            });

            ActionsManager.Update(gameTime);
        }
    }
}
