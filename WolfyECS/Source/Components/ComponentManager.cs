using System;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class ComponentManager
    {
    [ProtoMember(1)] public Dictionary<uint, int> EntityMap { get; set; }
    [ProtoMember(2)] private int _size = 1;

    [ProtoIgnore] private EntityComponent[] _components;

    [ProtoMember(3, OverwriteList = true)]
    public EntityComponent[] Components
    {
        get => _components;
        set => _components = value;
    }

    [ProtoMember(4)] public Type ComponentType { get; set; }

    private const int MaxComponents = 1024;

    public ComponentManager(Type type)
    {
        ComponentType = type;
        EntityMap = new Dictionary<uint, int>();
        Components = new EntityComponent[MaxComponents];
    }

    public ComponentManager()
    {
        EntityMap = new Dictionary<uint, int>();
        Components = new EntityComponent[MaxComponents];
    }

    public int AddComponent(Entity entity, EntityComponent component)
    {
        int index = _size - 1;

        // Add component to the components array
        Components[index] = component;

        // Add pointer to the component index inside array
        EntityMap.Add(entity.Id, index);

        _size++;
        return index;
    }

    public bool HasComponent(Entity entity)
    {
        if (EntityMap.ContainsKey(entity.Id))
        {
            return Components[EntityMap[entity.Id]] != null;
        }

        return false;
    }

    public EntityComponent GetComponent(Entity entity)
    {
        return Components[EntityMap[entity.Id]];
    }

    public void DestroyComponent(Entity entity)
    {
        if(!EntityMap.ContainsKey(entity.Id)) return;
        
        int index = EntityMap[entity.Id];
        int lastComponent = _size - 1;
        Components[index] = Components[lastComponent];
        EntityMap.Remove(entity.Id);
        _size--;
        // TODO Searching key by value in a dictionary is not effective
        // Reversed dictionary may be a solution but it requires extra memory
        // however it might be worth it if components are removed frequently from entities
        uint movedEntity = EntityMap.FirstOrDefault(x => x.Value == lastComponent).Key;
        if(EntityMap.ContainsKey(movedEntity))
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