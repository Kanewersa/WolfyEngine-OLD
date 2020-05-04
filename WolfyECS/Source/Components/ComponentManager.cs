using System;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class ComponentManager
    {
        [ProtoMember(1)] public BiDictionary<Entity, int> EntityMap { get; set; }
        [ProtoMember(2)] private int _size = 1;
        [ProtoMember(3)] private Entity _lastEntity;

        [ProtoIgnore] private EntityComponent[] _components;

        [ProtoMember(4, OverwriteList = true)]
        public EntityComponent[] Components
        {
            get => _components;
            set => _components = value;
        }

        [ProtoMember(5)] public string ComponentType { get; set; }

        private const int MaxComponents = 1024;

        public ComponentManager(string type)
        {
            ComponentType = type;
            EntityMap = new BiDictionary<Entity, int>();
            Components = new EntityComponent[MaxComponents];
        }

        public ComponentManager()
        {
            EntityMap = new BiDictionary<Entity, int>();
            Components = new EntityComponent[MaxComponents];
        }

        public int AddComponent(Entity entity, EntityComponent component)
        {
            int index = _size - 1;

            // Add component to the components array
            Components[index] = component;

            // Add pointer to the component index inside array
            EntityMap.Add(entity, index);

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
            var comp = Components[EntityMap[entity]];
            return Components[EntityMap[entity]];
        }

        public void DestroyComponent(Entity entity)
        {
            if(!EntityMap.ContainsKey(entity)) return;
            
            int index = EntityMap[entity];
            int lastComponent = _size - 1;
            Components[index] = Components[lastComponent];
            EntityMap.Remove(entity);
            _size--;
            Entity movedEntity = EntityMap[lastComponent];
            EntityMap[movedEntity] = index;
        }

        [ProtoAfterDeserialization]
        private void FillComponentsArray()
        {
            if (Components.Length < MaxComponents)
            {
                    Array.Resize(ref _components, MaxComponents);
            }
        }

        // TODO Create lambda expression for components iteration
        /*public void IterateAll(Func lambda)
        {
            for (int i = 1; i < _size; i++)
            {
                lambda(Components[i]);
            }
        }*/
    }
}