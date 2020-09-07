using System;
using System.Collections.Generic;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class ComponentsMap
    {
        [ProtoMap(DisableMap = true)]
        [ProtoMember(1)] public Dictionary<Entity, int> EntityMap { get; set; }
        [ProtoMap(DisableMap = true)]
        [ProtoMember(2)] public Dictionary<int, Entity> ReversedMap { get; set; }
        [ProtoMember(3)] private int _size = 0;

        [ProtoIgnore] private EntityComponent[] _components;

        [ProtoMember(4, OverwriteList = true)]
        public EntityComponent[] Components
        {
            get => _components;
            set => _components = value;
        }

        [ProtoIgnore] private readonly int _maxComponents;

        public ComponentsMap(int maxComponents = 1024)
        {
            EntityMap = new Dictionary<Entity, int>();
            ReversedMap = new Dictionary<int, Entity>();
            Components = new EntityComponent[maxComponents];
            _maxComponents = maxComponents;
        }

        public int AddComponent(Entity entity, EntityComponent component)
        {
            int index = _size;

            // Add component to the components array
            Components[index] = component;

            // Add pointer to the component index inside array
            EntityMap.Add(entity, index);
            ReversedMap.Add(index, entity);

            _size++;
            return index;
        }

        public bool HasComponent(Entity entity)
        {
            if (EntityMap.ContainsKey(entity))
            {
                return Components[EntityMap[entity]] != null;
            }
            return false;
        }

        public EntityComponent GetComponent(Entity entity)
        {
            if (!EntityMap.ContainsKey(entity))
            {
                throw new Exception("Component is not present in components map.");
            }
            return Components[EntityMap[entity]];
        }

        public EntityComponent DestroyComponent(Entity entity)
        {
            if (!EntityMap.ContainsKey(entity))
                return null;

            int index = EntityMap[entity]; // Get index of component to delete
            int lastComponent = _size - 1; // Get index of last component
            EntityComponent removedComponent = Components[index]; // Get the component which will be removed

            EntityMap.Remove(entity); // Remove pointer to component

            if (lastComponent == index)
            {
                ReversedMap.Remove(index); // Remove pointer to entity
            }
            else
            {
                Components[index] = Components[lastComponent];  // Replace deleted component with last component
                Entity lastEntity = ReversedMap[lastComponent]; // Get last entity
                EntityMap[lastEntity] = index;                  // Replace pointer for last entity
                ReversedMap.Remove(lastComponent);              // Remove last component pointer
                ReversedMap[index] = lastEntity;                // Replace last entity pointer with last entity
            }

            _size--; // Decrease size

            return removedComponent;
        }

        public int ComponentsCount()
        {
            return _size - 1;
        }

        [ProtoAfterDeserialization]
        private void FillComponentsArray()
        {
            if (Components.Length < _maxComponents)
            {
                Array.Resize(ref _components, _maxComponents);
            }
        }
    }
}
