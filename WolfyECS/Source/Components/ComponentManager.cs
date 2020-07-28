using System;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class ComponentManager
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

        //[ProtoMember(6)] public string ComponentType { get; set; }
        [ProtoMember(5)] public EntityComponent ComponentType { get; private set; }
        [ProtoMember(6)] public bool Temporary { get; private set; }

        private const int MaxComponents = 65536;

        public ComponentManager(EntityComponent componentType)
        {
            ComponentType = componentType;
            EntityMap = new Dictionary<Entity, int>();
            ReversedMap = new Dictionary<int, Entity>();
            Components = new EntityComponent[MaxComponents];
        }

        public ComponentManager()
        {
            EntityMap = new Dictionary<Entity, int>();
            ReversedMap = new Dictionary<int, Entity>();
            Components = new EntityComponent[MaxComponents];
        }

        public ComponentManager(bool temporary)
        {
            Temporary = temporary;
        }

        public void Initialize(int family)
        {
            if (Temporary) return;
            ComponentType.SetFamily(family);
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
                throw new Exception("Component is not present in component manager. Component type: " + ComponentType.GetType().FullName);
            }
            return Components[EntityMap[entity]];
        }

        public void DestroyComponent(Entity entity)
        {
            if (!EntityMap.ContainsKey(entity))
                return;

            int index = EntityMap[entity]; // Get index of component to delete
            int lastComponent = _size - 1; // Get index of last component

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
                ReversedMap[index] = lastEntity;                // Replace last entity pointer wit h
            }

            _size--; // Decrease size
        }

        public int ComponentsCount()
        {
            return _size - 1;
        }

        [ProtoAfterDeserialization]
        private void FillComponentsArray()
        {
            if (Components.Length < MaxComponents)
            {
                Array.Resize(ref _components, MaxComponents);
            }
        }
    }
}