using System.Diagnostics;

namespace WolfyECS
{
    public class Entity
    {
        private readonly World _world;
        
        public uint Id { get; }
        public string Name { get; set; }
        
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
