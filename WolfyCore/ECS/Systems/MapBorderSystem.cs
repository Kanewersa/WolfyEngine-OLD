using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.ECS
{
    [ProtoContract]
    public class MapBorderSystem : EntitySystem
    {
        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<TransformComponent>();
            RequireComponent<BorderTeleportComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var teleportation = entity.GetComponent<BorderTeleportComponent>();

                if (teleportation.MovedCount == 0 && !entity.HasComponent<NoCollisionComponent>())
                {
                    teleportation.MovedCount++;
                }

                if (teleportation.MovedCount == 0 && entity.HasComponent<NoCollisionComponent>())
                {
                    return;
                }

                if (!entity.HasComponent<IgnoreCollisionComponent>())
                {
                    entity.AddComponent(new IgnoreCollisionComponent((short)teleportation.Info.OriginDirection));
                }

                if (entity.GetIfHasComponent(out NoCollisionComponent collision))
                {
                    // Restore occupied entity position
                    var transform = entity.GetComponent<TransformComponent>();
                    var map = transform.GetMap();
                    map.SetEntity(teleportation.CoveredEntity, collision.Info.StartGridTransform);
                    var direction = Direction.Get(collision.Info.TargetGridTransform - collision.Info.StartGridTransform);
                    if (direction == teleportation.Info.OriginDirection)
                    {
                        // Teleport entity, set camera fade if entity is player etc.
                        var action = new StartActionComponent(
                            new List<WolfyAction>
                            {
                                new CameraFadeAction(entity, 1, true),
                                new TeleportAction(entity, teleportation.Info.TargetMap, teleportation.Info.Target),
                                new CameraFadeAction(entity, 1, false)
                            },
                            false);
                        entity.AddComponent(action);

                    }

                    entity.RemoveComponent<IgnoreCollisionComponent>();
                    entity.RemoveComponent<BorderTeleportComponent>();
                }
            });
        }
    }
}