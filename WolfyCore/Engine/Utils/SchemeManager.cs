using System;
using System.Collections.Generic;
using WolfyCore.ECS;

namespace WolfyEngine
{
    public class SchemeManager
    {
        public List<EntityScheme> Schemes { get; set; }

        // TODO Optimize entity schemes.
        public SchemeManager()
        {
            Schemes = new List<EntityScheme>();

            CreateScheme("NPC",
                new List<Type>
                {
                    typeof(AnimationComponent),
                    typeof(MovementComponent),
                    typeof(ActionComponent)
                });
            CreateScheme("Static",
                new List<Type>
                {
                    typeof(AnimationComponent),
                    typeof(ActionComponent)
                });
            CreateScheme("Map border",
                new List<Type>
                {
                    typeof(MapBorderComponent)
                });
        }

        public EntityScheme CreateScheme(string name, List<Type> componentTypes = null)
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
