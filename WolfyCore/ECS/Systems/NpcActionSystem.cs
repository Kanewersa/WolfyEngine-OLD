using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class NpcActionSystem : EntitySystem
    {
        public NpcActionSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<NpcActionComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var interaction = entity.GetComponent<NpcActionComponent>();

                // If player is the interaction source.
                if (interaction.Source == Entity.Player)
                {
                    // If target has actions to be executed
                    if (interaction.Target.GetIfHasComponent(out ActionComponent action))
                    {
                        interaction.Source.AddComponent(new StartActionComponent(action.Actions, false));

                        if (interaction.Source.GetIfHasComponent(out MovementComponent sourceMovement))
                            sourceMovement.LockMovement();

                        if (interaction.Target.GetIfHasComponent(out MovementComponent targetMovement))
                            targetMovement.LockMovement();
                    }
                }
                else
                {
                    // TODO: Handle interactions between NPCs.
                }
                
                entity.RemoveComponent<NpcActionComponent>();
            });
        }
    }
}
