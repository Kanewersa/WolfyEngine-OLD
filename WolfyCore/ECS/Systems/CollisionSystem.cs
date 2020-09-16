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
            RequireComponent<CollisionComponent>();
            RequireComponent<MovementActionComponent>();
            RequireComponent<TransformComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var movementAction = entity.GetComponent<MovementActionComponent>();

                if (movementAction.IsMoving) return;

                var collision = entity.GetComponent<CollisionComponent>();
                var transform = entity.GetComponent<TransformComponent>();

                // If entity doesn't care about collision
                if (!collision.IsCollider)
                {
                    // TODO Instead of true/false variable make the collision component...
                    // ... present when entity should have collision and delete it otherwise.
                }

                // Check if entity can move to target position
                var map = GetMap(transform.CurrentMap);
                var canMove = !map.Occupied(movementAction.TargetGridTransform);
                if (canMove == true)
                {
                    // Let the entity move on
                    movementAction.IsMoving = true;
                    transform.GridTransform = movementAction.TargetGridTransform;
                    // Set entity on map
                    map.MoveEntity(entity, movementAction.StartGridTransform, movementAction.TargetGridTransform);
                } else
                {
                    // Reset entity position
                    transform.Transform = movementAction.StartTransform;

                    // Remove movement action component
                    entity.RemoveComponent<MovementActionComponent>();

                    // If entity met the other entity
                    if (canMove == null)
                    {
                        Entity metEntity = map.GetEntity(movementAction.TargetGridTransform);
                        if (metEntity == Entity.Empty)
                            throw new Exception("Entity expected at position " + movementAction.TargetGridTransform + " but was not present.");

                        entity.AddComponent(new NpcActionComponent(entity, metEntity));
                    }
                }
            });
        }

        private EntityLayer GetEntityLayer(int mapId)
        {
            return (EntityLayer) MapsController.Instance.GetMap(mapId).Layers.FirstOrDefault(x => x is EntityLayer);
        }

        private Map GetMap(int mapId)
        {
            return MapsController.Instance.GetMap(mapId);
        }
    }
}
