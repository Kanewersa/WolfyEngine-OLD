using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class PathMovementSystem : EntitySystem
    {
        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<TransformComponent>();
            RequireComponent<PathMovementComponent>();
            RequireComponent<MovementComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                if (entity.HasComponent<NoCollisionComponent>())
                    return;

                var path = entity.GetComponent<PathMovementComponent>().MovementPath;

                path.Remove(path.Last());

                if (path.Count == 0)
                {
                    entity.RemoveComponent<PathMovementComponent>();
                    return;
                }

                var transform = entity.GetComponent<TransformComponent>();
                var nextTarget = path.Last();

                if (Vector2.Distance(transform.GridTransform, nextTarget) > 1)
                {
                    entity.RemoveComponent<PathMovementComponent>();
                    entity.RemoveComponent<PathRequestComponent>();
                    entity.AddComponent(new PathRequestComponent(transform.CurrentMap,
                                                                 -1,
                                                                 transform.GridTransform,
                                                                 path.Last()));
                    return;
                }

                entity.AddComponent(new MovementActionComponent(transform.GridTransform, nextTarget));
                entity.GetComponent<MovementComponent>().DirectionVector = nextTarget - transform.GridTransform;
            });
        }
    }
}
