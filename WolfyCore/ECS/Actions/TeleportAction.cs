using System;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class TeleportAction : WolfyAction
    {
        [ProtoMember(1)] private readonly int _newMapId;
        [ProtoMember(2)] private readonly Vector2 _newPosition;

        public TeleportAction() { }

        public TeleportAction(Entity target, int newMapId, Vector2 newPosition)
        {
            Asynchronous = false;
            Target = target;
            _newMapId = newMapId;
            _newPosition = newPosition;
        }

        public override void Execute()
        {
            if(!Target.HasComponent<TransformComponent>())
                throw new Exception("Could not perform TeleportAction on target entity. Entity didn't have transform component.");

            var transform = Target.GetComponent<TransformComponent>();
            transform.CurrentMap = _newMapId;
            transform.GridTransform = _newPosition;
            Completed = true;
        }

        public override void Validate()
        { }

        public override string GetDescription()
        {
            return "Teleport " + Target + " to map " + _newMapId + " with position " + _newPosition;
        }
    }
}
