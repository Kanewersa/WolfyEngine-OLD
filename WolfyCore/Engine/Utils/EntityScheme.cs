using System;
using System.Collections.Generic;
using WolfyECS;

namespace WolfyEngine
{
    public class EntityScheme
    {
        public string Name { get; }
        public List<ComponentType> ComponentTypes { get; private set; }

        public EntityScheme(string name)
        {
            ComponentTypes = new List<ComponentType>();
            Name = name;
        }

        public void AddType(ComponentType type)
        {
            ComponentTypes.Add(type);
        }

        public void RemoveType(ComponentType type)
        {
            ComponentTypes.Remove(type);
        }
    }
}
