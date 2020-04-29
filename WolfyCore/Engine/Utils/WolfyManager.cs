using System;
using System.Collections.Generic;
using WolfyECS;
using WolfyEngine.Engine;

namespace WolfyEngine
{
    public static class WolfyManager
    {
        public static List<Type> ComponentTypes { get; private set; }

        /// <summary>
        /// Performs all operations needed to initialize WolfyEngine.
        /// </summary>
        public static void WolfyInitialize()
        {
            // Set entity component subtypes
            ComponentTypes = ReflectiveEnumerator.GetSubTypes<EntityComponent>();

            Serialization.ProtoInitialize(ComponentTypes);
        }

        public static void InitializeFamilies()
        {
            foreach (var type in ComponentTypes)
            {
                var genericType = typeof(EntityComponent<>).MakeGenericType(type);
                dynamic instance = Activator.CreateInstance(genericType);
                var method = instance.GetType().GetMethod("Family");
                var id = method.Invoke(null, new object[] {} );
                Console.WriteLine(type.Name + " has id " + id);
            }
        }

    }
}
