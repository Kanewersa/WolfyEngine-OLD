using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WolfyCore.Actions;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.ECS
{
    public class EntityCollisionHandler : EntitySystem
    {
        public EntityCollisionHandler() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<TransformComponent>();
            RequireComponent<EntityCollisionComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var interaction = entity.GetComponent<EntityCollisionComponent>();

                // If entity met a map border
                if (interaction.Target.GetIfHasComponent(out MapBorderComponent mapBorder))
                {
                    interaction.Source.AddComponent(new NoCollisionComponent(interaction.Info));

                    if (interaction.Source.GetIfHasComponent(out BorderTeleportComponent teleportation))
                    {
                        var transform = entity.GetComponent<TransformComponent>();
                        var map = transform.GetMap();
                        map.SetEntity(teleportation.CoveredEntity, interaction.Info.TargetGridTransform);
                        interaction.Source.RemoveComponent<BorderTeleportComponent>();
                    }

                    interaction.Source.AddComponent(new BorderTeleportComponent(mapBorder, interaction.Target));

                    entity.RemoveComponent<EntityCollisionComponent>();
                    return;
                }

                if (interaction.Source == Entity.Player)
                {
                    if (interaction.Target.GetIfHasComponent(out ActionComponent action))
                    {
                        interaction.Source.AddComponent(new StartActionComponent(action.Actions, false));

                        if (interaction.Source.GetIfHasComponent(out MovementComponent sourceMovement))
                            sourceMovement.LockMovement();

                        if (interaction.Target.GetIfHasComponent(out MovementComponent targetMovement))
                        {
                            if (sourceMovement != null)
                            {
                                targetMovement.DirectionVector =
                                    Direction.Reverse(sourceMovement.DirectionVector);
                            }
                            targetMovement.LockMovement();
                        }
                    }
                }
                else
                {
                    // TODO: Handle interactions between NPCs.
                }

                entity.RemoveComponent<EntityCollisionComponent>();
            });
        }
    }
}
