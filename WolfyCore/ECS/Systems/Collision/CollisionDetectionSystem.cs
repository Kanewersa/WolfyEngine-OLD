using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class CollisionDetectionSystem : EntitySystem
    {
        public CollisionDetectionSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<TransformComponent>();
            RequireComponent<MovementActionComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var movementAction = entity.GetComponent<MovementActionComponent>();

                // TODO: Change entity direction somewhere else rather than in CollisionSystem.
                if (entity.GetIfHasComponent(out MovementComponent movement))
                {
                    movement.DirectionVector =
                        movementAction.TargetGridTransform - movementAction.StartGridTransform;
                }

                var transform = entity.GetComponent<TransformComponent>();
                var map = transform.GetMap();

                var canMove = !map.Occupied(movementAction.TargetGridTransform);

                if (canMove == false)
                {
                    if (entity.GetIfHasComponent(out IgnoreCollisionComponent collision))
                    {
                        if (collision.Direction == 4 || movement.Direction == collision.Direction)
                            canMove = true;

                        if (!collision.Permanent)
                            entity.RemoveComponent<IgnoreCollisionComponent>();
                    }
                }
                switch (canMove)
                {
                    // No collision
                    case true:
                        entity.AddComponent(new NoCollisionComponent(movementAction));
                        break;
                    // Collision with terrain
                    case false:
                        // Handle any terrain collision here!
                        // entity.AddComponent(new TerrainCollisionComponent(movementAction));
                        break;
                    // Collision with entity
                    case null:
                        var metEntity = map.GetEntity(movementAction.TargetGridTransform);
                        if (metEntity == Entity.Empty)
                            throw new Exception("Entity expected at position " + movementAction.TargetGridTransform + " was not present.");
                        entity.AddComponent(new EntityCollisionComponent(entity, metEntity, movementAction));
                        break;
                }

                entity.RemoveComponent<MovementActionComponent>();
            });
        }

        public bool? HandleIgnoreCollision()
        {

            return false;
        }
    }
}
