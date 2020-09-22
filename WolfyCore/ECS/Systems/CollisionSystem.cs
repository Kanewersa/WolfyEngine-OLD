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
    [ProtoContract] public class CollisionSystem : EntitySystem
    {
        public CollisionSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<TransformComponent>();
            RequireComponent<CollisionComponent>();
            RequireComponent<MovementActionComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var movementAction = entity.GetComponent<MovementActionComponent>();

                if (movementAction.HandledCollision) return;

                var transform = entity.GetComponent<TransformComponent>();
                var map = transform.GetMap();

                // Check if entity can move to target position
                var canMove = !map.Occupied(movementAction.TargetGridTransform);

                if (canMove == true || movementAction.IgnoreCollision)
                {
                    // Mark the collision as handled.
                    movementAction.HandledCollision = true;
                    
                    if (!movementAction.IgnoreCollision)
                    {
                        // Set entity position on the map.
                        map.MoveEntity(entity, movementAction.StartGridTransform, movementAction.TargetGridTransform);
                        // Set entity grid transform to target transform.
                        transform.GridTransform = movementAction.TargetGridTransform;
                    }
                }
                else
                {
                    // Reset entity position.
                    transform.Transform = movementAction.StartTransform;
                    // Remove movement action component.
                    entity.RemoveComponent<MovementActionComponent>();

                    // If entity met the other entity.
                    if (canMove == null)
                    {
                        Entity metEntity = map.GetEntity(movementAction.TargetGridTransform);
                        if (metEntity == Entity.Empty)
                            throw new Exception("Entity expected at position " + movementAction.TargetGridTransform + " but was not present.");

                        if (metEntity.GetIfHasComponent(out MapBorderComponent info))
                        {
                            entity.AddComponent(new BorderTeleportComponent(info));
                        }
                        else
                        {
                            entity.AddComponent(new EntityCollisionComponent(entity, metEntity));
                        }
                    }
                }
            });
        }
    }
}
