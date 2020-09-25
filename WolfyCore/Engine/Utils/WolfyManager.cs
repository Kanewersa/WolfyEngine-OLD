using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ProtoBuf.Meta;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyEngine
{
    public static class WolfyManager
    {
        public static List<Type> ComponentTypes { get; private set; }
        public static List<Type> SystemTypes { get; private set; }

        /// <summary>
        /// Performs all operations needed to initialize WolfyEngine.
        /// </summary>
        public static void WolfyInitialize()
        {
            // Set entity component subtypes
            /*ComponentTypes = ReflectiveEnumerator.GetSubTypes<EntityComponent>();
            SystemTypes = ReflectiveEnumerator.GetSubTypes<EntitySystem>();

            // Allow Vector2 serialization
            RuntimeTypeModel.Default.Add(typeof(Vector2), false).Add(1, "X").Add(2, "Y");

            // TODO Remove redundant code (WolfyManager).
            // Add systems to protobuf
            var entitySystem = RuntimeTypeModel.Default[typeof(EntitySystem)];
            entitySystem.AddSubType(101, typeof(AnimationSystem));
            entitySystem.AddSubType(102, typeof(CollisionDetectionSystem));
            entitySystem.AddSubType(103, typeof(InputSystem));
            entitySystem.AddSubType(104, typeof(MovementSystem));
            entitySystem.AddSubType(105, typeof(RandomMovementSystem));
            entitySystem.AddSubType(106, typeof(RoutineMovementSystem));
            entitySystem.AddSubType(107, typeof(RenderSystem));
            entitySystem.AddSubType(108, typeof(ActionSystem));
            entitySystem.AddSubType(109, typeof(TimeSystem));
            entitySystem.AddSubType(110, typeof(DialogSystem));
            entitySystem.AddSubType(111, typeof(InteractionSystem));
            entitySystem.AddSubType(112, typeof(LoadingSystem));

            // Add components
            var entityComponent = RuntimeTypeModel.Default[typeof(EntityComponent)];
            entityComponent.AddSubType(101, typeof(AnimationComponent));
            entityComponent.AddSubType(102, typeof(CollisionComponent));
            entityComponent.AddSubType(103, typeof(InGameNameComponent));
            entityComponent.AddSubType(104, typeof(InputComponent));
            entityComponent.AddSubType(105, typeof(TransformComponent));
            entityComponent.AddSubType(106, typeof(MovementComponent));
            entityComponent.AddSubType(107, typeof(MovementActionComponent));
            entityComponent.AddSubType(108, typeof(FixedMovementComponent));
            entityComponent.AddSubType(109, typeof(FollowMovementComponent));
            entityComponent.AddSubType(110, typeof(RandomMovementComponent));
            entityComponent.AddSubType(111, typeof(RoutineMovementComponent));
            entityComponent.AddSubType(112, typeof(CameraComponent));
            entityComponent.AddSubType(113, typeof(ActionComponent));
            entityComponent.AddSubType(114, typeof(LUTComponent));
            entityComponent.AddSubType(115, typeof(DialogComponent));
            entityComponent.AddSubType(116, typeof(InteractionComponent));
            entityComponent.AddSubType(117, typeof(LoadMapComponent));
            entityComponent.AddSubType(118, typeof(ActiveComponent));

            // Add components generics
            entityComponent.AddSubType(501, typeof(EntityComponent<AnimationComponent>));
            entityComponent.AddSubType(502, typeof(EntityComponent<CollisionComponent>));
            entityComponent.AddSubType(503, typeof(EntityComponent<InGameNameComponent>));
            entityComponent.AddSubType(504, typeof(EntityComponent<InputComponent>));
            entityComponent.AddSubType(505, typeof(EntityComponent<TransformComponent>));
            entityComponent.AddSubType(506, typeof(EntityComponent<MovementComponent>));
            entityComponent.AddSubType(507, typeof(EntityComponent<MovementActionComponent>));
            entityComponent.AddSubType(508, typeof(EntityComponent<FixedMovementComponent>));
            entityComponent.AddSubType(509, typeof(EntityComponent<FollowMovementComponent>));
            entityComponent.AddSubType(510, typeof(EntityComponent<RandomMovementComponent>));
            entityComponent.AddSubType(511, typeof(EntityComponent<RoutineMovementComponent>));
            entityComponent.AddSubType(512, typeof(EntityComponent<CameraComponent>));
            entityComponent.AddSubType(513, typeof(EntityComponent<ActionComponent>));
            entityComponent.AddSubType(514, typeof(EntityComponent<LUTComponent>));
            entityComponent.AddSubType(515, typeof(EntityComponent<DialogComponent>));
            entityComponent.AddSubType(516, typeof(EntityComponent<InteractionComponent>));
            entityComponent.AddSubType(517, typeof(EntityComponent<LoadMapComponent>));
            entityComponent.AddSubType(518, typeof(EntityComponent<ActiveComponent>));

            // Add wolfy actions
            var wolfyAction = RuntimeTypeModel.Default[typeof(WolfyAction)];
            wolfyAction.AddSubType(101, typeof(MovementAction));
            wolfyAction.AddSubType(102, typeof(TeleportAction));
            wolfyAction.AddSubType(103, typeof(DialogAction));
            wolfyAction.AddSubType(104, typeof(CameraFadeAction));
            wolfyAction.AddSubType(105, typeof(ChangeBGMAction));*/

        }
    }
}
