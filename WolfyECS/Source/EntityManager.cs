using System;
using System.Collections.Generic;

namespace WolfyECS
{
    public class EntityManager
    {
        public List<EntitySystem> Systems { get; set; }

        //private Dictionary<uint, List<EntityComponent>> _entities;
        private Dictionary<uint, Dictionary<Type, EntityComponent>> _entities;
        private Queue<uint> _pendingIds;
        private uint _lastId;

        private ComponentManager _componentManager;

        protected EntityManager()
        {
            _entities = new Dictionary<uint, Dictionary<Type, EntityComponent>>();
            _pendingIds = new Queue<uint>();
            _componentManager = new ComponentManager(_entities, Systems);
        }

        private Entity CreateEntity()
        {
            var id = GetId();
            var entity = new Entity(id, this, _componentManager);
            _entities.Add(id, new Dictionary<Type, EntityComponent>());
            return entity;
        }

        protected Entity CreateEntity(string name)
        {
            var entity = CreateEntity();
            entity.Name = name;
            return entity;
        }

        protected void RemoveEntity(uint entityId)
        {
            _entities.Remove(entityId);
            foreach (var system in Systems)
            {
                //system.EntityDestroyed(entityId);
            }
        }

        private uint GetId()
        {
            if (_pendingIds.Count > 0)
                return _pendingIds.Dequeue();
            _lastId++;
            return _lastId;
        }
    }
}
