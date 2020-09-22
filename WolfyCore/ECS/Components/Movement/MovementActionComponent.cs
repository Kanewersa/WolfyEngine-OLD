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
        [ProtoMember(3)] public bool IgnoreCollision;

        /// <summary>
        /// Determines if collision was already handled.
        /// </summary>
        [ProtoMember(4)] public bool HandledCollision { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MovementActionComponent() { }

        /// <summary>
        /// Creates movement action with start and target transforms.
        /// </summary>
        /// <param name="startTransform"></param>
        /// <param name="targetTransform"></param>
        /// <param name="ignoreCollision"></param>
        public MovementActionComponent(Vector2 startTransform, Vector2 targetTransform, bool ignoreCollision = false)
        {
            StartGridTransform = startTransform;
            TargetGridTransform = targetTransform;
            IgnoreCollision = ignoreCollision;
        }

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
        }
    }
}
