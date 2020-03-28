using System;
using System.Collections.Generic;

namespace WolfyECS
{
    public class ComponentManager
    {
        private readonly Dictionary<uint, Dictionary<Type, EntityComponent>> _entities;
        //private readonly Dictionary<uint, List<EntityComponent>> _entities;
        private readonly List<EntitySystem> _systems;

        public ComponentManager(
            Dictionary<uint, Dictionary<Type, EntityComponent>> entities,
            List<EntitySystem> systems)
        {
            _entities = entities;
            _systems = systems;
        }

        public void AddComponent<T>(uint entityId, EntityComponent component) where T : EntityComponent
        {
            _entities[entityId].Add(typeof(T), component);
            component.EntityId = entityId;
        }

        public void RemoveComponent<T>(uint entityId) where T : EntityComponent
        {
            var components = _entities[entityId];
            if (components.ContainsKey(typeof(T)))
            {
                components.Remove(typeof(T));
            }
            else
            {
                throw new Exception("Could not find desired component.");
            }
        }

        public void EntityModified(uint entityId)
        {
            foreach (var system in _systems)
            {
                
            }
        }


        public void ClearComponents(uint entityId)
        {
            _entities[entityId].Clear();
        }

        public T GetComponent<T>(uint entityId) where T : EntityComponent
        {
            return _entities[entityId][typeof(T)] as T;
        }
    }
}
