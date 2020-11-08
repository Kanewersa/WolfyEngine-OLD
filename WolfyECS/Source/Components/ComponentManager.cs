using System;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class ComponentManager
    {
        [ProtoMember(1)] public ComponentsMap Components { get; set; }
        [ProtoMember(2)] public ComponentsMap FrozenComponents { get; set; }
        [ProtoMember(5)] public EntityComponent ComponentType { get; private set; }
        [ProtoMember(6)] public bool Temporary { get; private set; }

        private const int MaxComponents = 4096;

        public ComponentManager(EntityComponent componentType)
        {
            ComponentType = componentType;
            Components = new ComponentsMap(MaxComponents);
        }

        public ComponentManager()
        {
            Components = new ComponentsMap(MaxComponents);
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

        public void AddComponent(Entity entity, EntityComponent component)
        {
            Components.AddComponent(entity, component);
        }

        public bool HasComponent(Entity entity)
        {
            return Components.HasComponent(entity);
        }

        public EntityComponent GetComponent(Entity entity)
        {
            return Components.GetComponent(entity);
        }

        public void DestroyComponent(Entity entity)
        {
            Components.DestroyComponent(entity);
        }

        public void FreezeComponent(Entity entity)
        {
            FrozenComponents.AddComponent(entity, Components.DestroyComponent(entity));
        }

        public void EnableComponent(Entity entity)
        {
            Components.AddComponent(entity, FrozenComponents.DestroyComponent(entity));
        }
    }
}