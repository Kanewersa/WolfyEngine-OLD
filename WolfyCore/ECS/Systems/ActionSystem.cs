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
                ActionsManager.PushActions(actionComponent.Actions);
                entity.RemoveComponent<StartActionComponent>();
            });

            ActionsManager.Update();
        }
    }
}
