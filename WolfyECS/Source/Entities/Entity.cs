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
        
        public void AddComponent<T>() where T : EntityComponent<T>
        {
            _world.AddComponent<T>(this);
        }

        public EntityComponent<T> GetComponent<T>() where T : EntityComponent<T>
        {
            return _world.GetComponent<T>(this);
        }

        public void RemoveComponent<T>() where T : EntityComponent<T>
        {
            _world.RemoveComponent<T>(this);
        }
    }
}
