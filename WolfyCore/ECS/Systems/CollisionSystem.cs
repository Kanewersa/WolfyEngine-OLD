using System;
using System.Linq;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.ECS
{
    [ProtoContract] public class CollisionSystem : EntitySystem
    {
        public CollisionSystem() { }

        public override void Initialize()
        {
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
                    // ... present when entity should have collision and delete it if it shouldn't.
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
                    entity.RemoveIfHasComponent<MovementActionComponent>();

                    // Check if the entity is the player who met an NPC
                    if (canMove == null && entity.HasComponent<InputComponent>())
                    {
                        var input = entity.GetComponent<InputComponent>();
                        
                        Entity metEntity = map.GetEntity(movementAction.TargetGridTransform);
                        if(metEntity == Entity.Empty)
                            throw new Exception("Entity expected at position " + movementAction.TargetGridTransform + " but was not present.");

                        if(metEntity.GetIfHasComponent(out ActionComponent action))
                        {
                            Console.WriteLine("Met entity has {0} actions.", action.Actions.Count);
                            entity.AddComponent(action);
                            var startAction = new StartActionComponent(metEntity);
                            entity.AddComponent(startAction);
                            metEntity.GetComponent<MovementComponent>().LockedMovement = true;
                        }
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
