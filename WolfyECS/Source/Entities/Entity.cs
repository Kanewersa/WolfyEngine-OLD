using System.Diagnostics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class Entity
    {
        [ProtoMember(1)] private readonly World _world;
        
        [ProtoMember(2)] public uint Id { get; }
        [ProtoMember(3)] public string Name { get; set; }
        
        internal Entity(uint id, World world)
        {
            Id = id;
            _world = world;
        }
        
        public T AddComponent<T>() where T : EntityComponent, new()
        {
            return _world.AddComponent<T>(this);
        }

        public bool HasComponent<T>() where T : EntityComponent
        {
            return GetComponent<T>() != null;
        }

        public T GetComponent<T>() where T : EntityComponent
        {
            return _world.GetComponent<T>(this);
        }

        public void RemoveComponent<T>() where T : EntityComponent
        {
            _world.RemoveComponent<T>(this);
        }
    }
}
