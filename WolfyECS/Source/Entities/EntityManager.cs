using System;
using System.Collections.Generic;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class EntityManager
    {
        [ProtoMember(1, AsReference = true)] private World _world;
        [ProtoIgnore] private Queue<uint> _pendingIds;
        [ProtoMember(2)]
        public uint[] Ids
        {
            get => _pendingIds.ToArray();
            set => _pendingIds = new Queue<uint>(value);
        }
        [ProtoMember(3)] private uint _lastId;

        public EntityManager(World world)
        {
            _world = world;
            _pendingIds = new Queue<uint>();
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
