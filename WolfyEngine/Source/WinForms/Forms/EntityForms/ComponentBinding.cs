using System;
using System.Collections.Generic;
using WolfyCore.ECS;
using WolfyECS;
using WolfyEngine.Controls;

namespace WolfyEngine.Forms
{
    public static class ComponentBinding
    {
        private static readonly Dictionary<ComponentType, Type> EnumTypes = new Dictionary<ComponentType, Type>
        {
            { ComponentType.Action, typeof(ActionComponentPanel) },
            { ComponentType.Animation, typeof(AnimationComponentPanel) },
            { ComponentType.Collision, typeof(CollisionComponentPanel) },
            { ComponentType.Movement, typeof(MovementComponentPanel) }
        };

        private static readonly Dictionary<Type, Type> ComponentTypes = new Dictionary<Type, Type>
        {
            { typeof(ActionComponent), typeof(ActionComponentPanel) },
            { typeof(AnimationComponent), typeof(AnimationComponentPanel) },
            { typeof(CollisionComponent), typeof(CollisionComponentPanel) },
            { typeof(MovementComponent), typeof(MovementComponentPanel) }
        };

        private static Type GetPanelType(Type type)
        {
            return !ComponentTypes.ContainsKey(type) ? null : ComponentTypes[type];
        }

        public static Type GetPanelType(ComponentType type)
        {
            if(!EnumTypes.ContainsKey(type))
                throw new NullReferenceException("Type "
                                                 + type
                                                 + " was not declared in ActionBinding.");
            return EnumTypes[type];
        }

        public static dynamic GetPanelInstance(ComponentType componentType)
        {
            var type = GetPanelType(componentType);
            return Convert.ChangeType(Activator.CreateInstance(type), type);
        }

        public static dynamic GetPanelInstance(EntityComponent component)
        {
            var type = GetPanelType(component.GetType());
            return type == null
                ? null
                : Convert.ChangeType(Activator.CreateInstance(type), type);
        }
    }
}
