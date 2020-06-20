using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class MovementActionComponent : EntityComponent
    {
        [ProtoIgnore] public Vector2 StartTransform => StartGridTransform * Runtime.GridSize;
        [ProtoIgnore] public Vector2 TargetTransform => TargetGridTransform * Runtime.GridSize;
        [ProtoMember(1)] public Vector2 StartGridTransform;
        [ProtoMember(2)] public Vector2 TargetGridTransform;

        /// <summary>
        /// Needed to make sure entity doesn't move before collision is checked.
        /// </summary>
        [ProtoMember(3)] public bool IsMoving;

        public MovementActionComponent() { }

        /// <summary>
        /// Sets the properties of component.
        /// </summary>
        /// <param name="startTransform"></param>
        /// <param name="targetTransform"></param>
        /// <param name="isMoving"></param>
        public void Set(Vector2 startTransform, Vector2 targetTransform, bool isMoving)
        {
            StartGridTransform = startTransform;
            TargetGridTransform = targetTransform;
            IsMoving = isMoving;
        }
    }
}
