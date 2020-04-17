using System;
using System.Collections.Generic;
using WolfyShared.ECS;

namespace WolfyEngine
{
    public class SchemeManager
    {
        public List<EntityScheme> Schemes { get; set; }

        public SchemeManager()
        {
            Schemes = new List<EntityScheme>();

            // Create NPC scheme
            CreateScheme("NPC",
                new List<ComponentType>
                {
                    ComponentType.Animation,
                    ComponentType.Collision,
                    ComponentType.Movement
                });
                // Create static object scheme
            CreateScheme("Static",
                new List<ComponentType>
                {
                    ComponentType.Animation,
                    ComponentType.Collision
                });
        }

        public EntityScheme CreateScheme(string name, List<ComponentType> componentTypes = null)
        {
            var scheme = new EntityScheme(name);
            foreach(var comp in componentTypes)
                scheme.AddType(comp);
            Schemes.Add(scheme);
            return scheme;
        }

        public void AddScheme(EntityScheme scheme)
        {
            Schemes.Add(scheme);
        }

        public void RemoveScheme(EntityScheme scheme)
        {
            Schemes.Remove(scheme);
        }
    }
}
