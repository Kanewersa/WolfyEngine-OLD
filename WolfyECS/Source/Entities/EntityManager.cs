using System;
using System.Collections.Generic;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class EntityManager
    {
        [ProtoIgnore] private World _world;
        [ProtoIgnore] private Queue<uint> _pendingIds = new Queue<uint>(16);
        [ProtoMember(1)]
        public uint[] Ids
        {
            get => _pendingIds.ToArray();
            set => _pendingIds = new Queue<uint>(value);
        }
        [ProtoMember(2)] private uint _lastId;

        public EntityManager () { }

        public EntityManager(World world)
        {
            _world = world;
            _pendingIds = new Queue<uint>(16);
        }

        public void Initialize(World world)
        {
            _world = world;
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
