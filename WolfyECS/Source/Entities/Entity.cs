using System.Diagnostics;

namespace WolfyECS
{
    public class Entity
    {
        private readonly EntityManager _entityManager;
        private readonly ComponentManager _componentManager;
        public uint Id { get; }
        public string Name { get; set; }
        
        internal Entity(uint id, EntityManager entityManager, ComponentManager componentManager)
        {
            Id = id;
            _entityManager = entityManager;
            _componentManager = componentManager;
        }

        public T AddComponent<T>() where T : EntityComponent, new()
        {
            var component = new T();
            component.EntityId = Id;
            _componentManager.AddComponent<T>(Id, component);
            Debug.WriteLine(typeof(T));
            return component;
        }

        public void RemoveComponent<T>(T component) where T : EntityComponent
        {
            _componentManager.RemoveComponent<T>(Id);
        }

        public T GetComponent<T>() where T : EntityComponent
        {
            return _componentManager.GetComponent<T>(Id);
            /*var mapper = _componentManager.GetComponent<T>();
            return mapper.Get(Id);*/
        }
    }
}
