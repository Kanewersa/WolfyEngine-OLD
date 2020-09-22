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
                if (entity.HasComponent<MovementActionComponent>())
                    return;

                var teleportation = entity.GetComponent<BorderTeleportComponent>();

                if (teleportation.Moved)
                {
                    entity.AddComponent(new StartActionComponent(new TeleportAction(entity, teleportation.Info.TargetMap, teleportation.Info.Target), true));
                    entity.RemoveComponent<BorderTeleportComponent>();
                    return;
                }
                
                var transform = entity.GetComponent<TransformComponent>();
                var movementDirection = WolfyHelper.GetDirection(teleportation.Info.OriginDirection);
                var movement = new MovementActionComponent(transform.GridTransform,
                                                           Vector2.Add(transform.GridTransform, movementDirection),
                                                           true);
                entity.AddComponent(movement);

                if (entity == Entity.Player && entity.GetIfHasComponent(out CameraComponent camera))
                {
                    entity.AddComponent(new StartActionComponent(new CameraFadeAction(entity, 1, true, true), true));
                }
            });
        }
    }
}