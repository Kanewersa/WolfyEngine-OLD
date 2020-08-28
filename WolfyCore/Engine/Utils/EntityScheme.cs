using System;
using System.Collections.Generic;
using WolfyECS;

namespace WolfyEngine
{
    public class EntityScheme
    {
        public string Name { get; }
        public List<Type> ComponentTypes { get; private set; }

        public EntityScheme(string name)
        {
            ComponentTypes = new List<Type>();
            Name = name;
        }

        public void AddType(Type type)
        {
            ComponentTypes.Add(type);
        }

        public void RemoveType(Type type)
        {
            ComponentTypes.Remove(type);
        }
    }
}
