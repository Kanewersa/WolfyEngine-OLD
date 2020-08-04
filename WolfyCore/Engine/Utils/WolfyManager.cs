using System;
using System.Collections.Generic;
using ProtoBuf.Meta;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyECS;
using WolfyEngine.Engine;

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
            ComponentTypes = ReflectiveEnumerator.GetSubTypes<EntityComponent>();
            SystemTypes = ReflectiveEnumerator.GetSubTypes<EntitySystem>();

            // TODO Fix dynamic subtypes loading for protobuf
            // Add systems to protobuf
            var entitySystem = RuntimeTypeModel.Default[typeof(EntitySystem)];
            entitySystem.AddSubType(101, typeof(AnimationSystem));
            entitySystem.AddSubType(102, typeof(CollisionSystem));
            entitySystem.AddSubType(103, typeof(InputSystem));
            entitySystem.AddSubType(104, typeof(MovementSystem));
            entitySystem.AddSubType(105, typeof(RandomMovementSystem));
            entitySystem.AddSubType(106, typeof(RoutineMovementSystem));
            entitySystem.AddSubType(107, typeof(RenderSystem));
            entitySystem.AddSubType(108, typeof(ActionSystem));

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

            // Add components generics
            entityComponent.AddSubType(201, typeof(EntityComponent<AnimationComponent>));
            entityComponent.AddSubType(202, typeof(EntityComponent<CollisionComponent>));
            entityComponent.AddSubType(203, typeof(EntityComponent<InGameNameComponent>));
            entityComponent.AddSubType(204, typeof(EntityComponent<InputComponent>));
            entityComponent.AddSubType(205, typeof(EntityComponent<TransformComponent>));
            entityComponent.AddSubType(206, typeof(EntityComponent<MovementComponent>));
            entityComponent.AddSubType(207, typeof(EntityComponent<MovementActionComponent>));
            entityComponent.AddSubType(208, typeof(EntityComponent<FixedMovementComponent>));
            entityComponent.AddSubType(209, typeof(EntityComponent<FollowMovementComponent>));
            entityComponent.AddSubType(210, typeof(EntityComponent<RandomMovementComponent>));
            entityComponent.AddSubType(211, typeof(EntityComponent<RoutineMovementComponent>));
            entityComponent.AddSubType(212, typeof(EntityComponent<CameraComponent>));
            entityComponent.AddSubType(213, typeof(EntityComponent<ActionComponent>));

            // Add wolfy actions
            var wolfyAction = RuntimeTypeModel.Default[typeof(WolfyAction)];
            wolfyAction.AddSubType(101, typeof(MovementAction));
            wolfyAction.AddSubType(102, typeof(TeleportAction));

        }

        public static void InitializeFamilies()
        {
            foreach (var type in ComponentTypes)
            {
                var genericType = typeof(EntityComponent<>).MakeGenericType(type);
                dynamic instance = Activator.CreateInstance(genericType);
                var method = instance.GetType().GetMethod("Family");
                var id = method.Invoke(null, new object[] {} );
            }
        }

    }
}
