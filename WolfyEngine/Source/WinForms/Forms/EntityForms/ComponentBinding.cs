using System;
using System.Collections.Generic;
using System.Linq;
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
            { typeof(MovementComponent), typeof(MovementComponentPanel) },
            { typeof(MapBorderComponent), typeof(MapBorderComponentPanel) }
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
                : Convert.ChangeType(Activator.CreateInstance(type, componentType), type);
        }

        // TODO: Improve component binding performance (by value search in dictionary).
        public static Type GetComponentTypeByPanel(ComponentPanel panel)
        {
            return ComponentTypes.FirstOrDefault(x => x.Value == panel.GetType()).Key;
        }

        public static IEnumerable<Type> DefinedTypes()
        {
            return ComponentTypes.Keys;
        }

        public static IEnumerable<Type> DefinedPanels()
        {
            return ComponentTypes.Values;
        }
    }
}
