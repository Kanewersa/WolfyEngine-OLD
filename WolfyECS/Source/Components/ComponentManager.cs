using System.Collections.Generic;
using System.Linq;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class ComponentManager
        
    {
    [ProtoMember(1)] public Dictionary<Entity, int> EntityMap { get; private set; }

    [ProtoMember(2)] private int _size = 1;
    [ProtoMember(3)] public EntityComponent[] Components { get; private set; }

    public ComponentManager()
    {
        EntityMap = new Dictionary<Entity, int>();
        Components = new EntityComponent[1024];
    }

    public int AddComponent(Entity entity, EntityComponent component)
    {
        int index = _size;

        // Add component to the components array
        Components[index] = component;

        // Add pointer to the component index inside array
        EntityMap[entity] = index;

        _size++;
        return index;
    }

    public EntityComponent GetComponent(Entity entity)
    {
        return Components[EntityMap[entity]];
    }

    public void DestroyComponent(Entity entity)
    {
        int index = EntityMap[entity];
        int lastComponent = _size - 1;
        Components[index] = Components[lastComponent];
        EntityMap.Remove(entity);
        _size--;
        // TODO Searching key by value in a dictionary is not effective
        // Reversed dictionary may be a solution but it requires extra memory
        // however it might be worth it if components are removed frequently from entities
        Entity movedEntity = EntityMap.FirstOrDefault(x => x.Value == lastComponent).Key;
        EntityMap[movedEntity] = index;
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