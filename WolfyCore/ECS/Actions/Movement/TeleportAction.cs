using System;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyCore.Actions
{
    [ProtoContract] public class TeleportAction : WolfyAction
    {
        [ProtoMember(1)] public int NewMapId;
        [ProtoMember(2)] public Vector2 NewPosition;

        public TeleportAction() { }

        public TeleportAction(Entity target, int newMapId, Vector2 newPosition)
        {
            Asynchronous = false;
            Target = target;
            NewMapId = newMapId;
            NewPosition = newPosition;
        }

        public override void Execute()
        {
            if(!Target.HasComponent<TransformComponent>())
                throw new Exception("Could not perform TeleportAction on target entity. Entity didn't have transform component.");

            var transform = Target.GetComponent<TransformComponent>();
            var map = MapsController.Instance.GetMap(NewMapId);

            if (transform.CurrentMap == NewMapId)
            {
                map.MoveEntity(Target, transform.GridTransform, NewPosition);
            }
            else
            {
               
                // TODO: Handle teleportation and pathfinding to not loaded maps.
                var oldMap = MapsController.Instance.GetMap(transform.CurrentMap);
                if (oldMap.GetEntity(transform.GridTransform) == Target)
                    oldMap.RemoveEntity(transform.GridTransform);
                else oldMap.RemoveEntity(Target);
                
                map.AddEntity(Target, NewPosition);
            }

            transform.CurrentMap = NewMapId;
            transform.GridTransform = NewPosition;
            transform.Transform = transform.GridTransform * Runtime.GridSize;

            Completed = true;
        }

        public override void Validate(GameTime gameTime)
        { }

        public override string GetDescription()
        {
            return "Teleport "
                   + Target 
                   + " to map "
                   + MapsController.Instance.GetMapName(NewMapId)
                   + ", position: "
                   + NewPosition;
        }
    }
}
