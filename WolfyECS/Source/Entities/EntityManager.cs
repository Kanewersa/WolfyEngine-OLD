using System;
using System.Collections.Generic;

namespace WolfyECS
{
    public class EntityManager
    {
        private readonly World _world;
        private Queue<uint> _pendingIds;
        private uint _lastId;

        public EntityManager(World world)
        {
            _world = world;
            _pendingIds = new Queue<uint>();
        }

        public Entity CreateEntity()
        {
            var id = GetId();
            var entity = new Entity(id, _world);
            return entity;
        }

        public Entity CreateEntity(string name)
        {
            var entity = CreateEntity();
            entity.Name = name;
            return entity;
        }

        public void DestroyEntity(Entity entity)
        {
            _pendingIds.Enqueue(entity.Id);
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
