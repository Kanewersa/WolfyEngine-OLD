using System;
using System.Collections.Generic;
using WolfyCore.ECS;
using WolfyECS;
using WolfyEngine.Controls;

namespace WolfyEngine.Forms
{
    public static class ComponentBinding
    {
        private static readonly Dictionary<Type, Type> ComponentTypes = new Dictionary<Type, Type>
        {
            { typeof(ActionComponent), typeof(ActionComponentPanel) },
            { typeof(AnimationComponent), typeof(AnimationComponentPanel) },
            { typeof(CollisionComponent), typeof(CollisionComponentPanel) },
            { typeof(MovementComponent), typeof(MovementComponentPanel) }
        };

        private static Type GetPanelType(Type type)
        {
            return ComponentTypes.ContainsKey(type) ? ComponentTypes[type] : null;
        }

        public static dynamic GetPanelInstance(Type componentType)
        {
            var type = GetPanelType(componentType);
            return type == null
                ? null
                : Convert.ChangeType(Activator.CreateInstance(type), type);
        }
    }
}
