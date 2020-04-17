using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract(AsReferenceDefault = true)]
    public class World
    {
        [ProtoMember(1)] private EntityManager _entityManager;
        [ProtoMember(2)] private List<EntitySystem> _systems;

        [ProtoMember(3)]
        private ComponentManager[] _componentManagers;

        [ProtoMap(DisableMap = true)]
        [ProtoMember(4)] private Dictionary<uint, ComponentMask> _entityMasks;

        private const int ComponentsLimit = 64;

        public World()
        {
            _entityManager = new EntityManager(this);
            _systems = new List<EntitySystem>();
            _componentManagers = new ComponentManager[ComponentsLimit];
            _entityMasks = new Dictionary<uint, ComponentMask>();
        }

        /// <summary>
        /// Initializes all systems.
        /// </summary>
        public void Initialize()
        {
            for (int i = 0; i < ComponentsLimit; i++)
            {
                if (_componentManagers[i] == null) continue;
                var type = _componentManagers[i].ComponentType;
                if (type == null) continue;
                var genericType = typeof(EntityComponent<>).MakeGenericType(type);
                dynamic instance = Activator.CreateInstance(genericType);
                var method = instance.GetType().GetMethod("Family");
                var id = method.Invoke(null, new object[] { });
                Console.WriteLine(type.Name + " has id " + id);
            }

            foreach(var system in _systems)
                system.Initialize();
            _entityManager.Initialize(this);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }

        #region Entities methods

        public Entity CreateEntity(string name = null)
        {
            var entity = _entityManager.CreateEntity(name);
            _entityMasks.Add(entity.Id, new ComponentMask(0));
            return entity;
        }

        public int EntityCount()
        {
            return _entityMasks.Count;
        }

        public void DestroyEntity(Entity entity)
        {
            _entityManager.DestroyEntity(entity);

            // Destroy entity in systems and component managers
            foreach (var system in _systems)
                system.UnregisterEntity(entity);
            foreach (var componentManager in _componentManagers)
                componentManager?.DestroyComponent(entity);
            _entityMasks.Remove(entity.Id);
        }

        #endregion
        
        
        public void AddSystem(EntitySystem entitySystem)
        {
            _systems.Add(entitySystem);
        }

        public void UpdateEntityMask(Entity e, ComponentMask oldMask)
        {
            var newMask = _entityMasks[e.Id];

            foreach (var system in _systems)
            {
                if (newMask.IsNewMatch(oldMask, system.Signature))
                {
                    system.RegisterEntity(e);
                } else if (newMask.IsNoLongerMatched(oldMask, system.Signature))
                {
                    system.UnregisterEntity(e);
                }
            }
        }

        #region Components methods

        public T AddComponent<T>(Entity e) where T : EntityComponent, new()
        {
            var manager = GetComponentManager<T>();
            var component = new T();
            manager.AddComponent(e, component);
            
            // Check if systems are interested in component
            var oldMask = _entityMasks[e.Id];
            _entityMasks[e.Id] = _entityMasks[e.Id].AddComponent<T>();
            UpdateEntityMask(e, oldMask);
            return component;
        }

        public void AddComponent<T>(Entity e, T component) where T : EntityComponent
        {
            var manager = GetComponentManager<T>();
            manager.AddComponent(e, component);

            // Check if systems are interested in component
            var oldMask = _entityMasks[e.Id];
            _entityMasks[e.Id] = _entityMasks[e.Id].AddComponent<T>();
            UpdateEntityMask(e, oldMask);
        }

        public bool HasComponent<T>(Entity e) where T : EntityComponent
        {
            var manager = GetComponentManager<T>();
            return manager.HasComponent(e);
        }

        public T GetComponent<T>(Entity e) where T : EntityComponent
        {
            var manager = GetComponentManager<T>();
            return manager.GetComponent(e) as T;
        }

        public List<EntityComponent> GetComponents(Entity e)
        {
            var list = (from manager
                    in _componentManagers
                where manager != null && manager.HasComponent(e)
                select manager.GetComponent(e)).ToList();
            return list;
        }

        public void RemoveComponent<T>(Entity e) where T : EntityComponent
        {
            var manager = GetComponentManager<T>();
            manager.DestroyComponent(e);
            
            // Check if systems are interested in components
            var oldMask = _entityMasks[e.Id];
            _entityMasks[e.Id] = _entityMasks[e.Id].RemoveComponent<T>();
            UpdateEntityMask(e, oldMask);
        }

        #endregion

        private ComponentManager GetComponentManager<T>() where T : EntityComponent
        {
            var family = Family.GetComponentFamily<T>();
            if (family > _componentManagers.Length)
                Array.Resize(ref _componentManagers, family + ComponentsLimit);
            
            if (_componentManagers.ElementAtOrDefault(family) == null)
            {
                var manager = new ComponentManager(typeof(T));
                _componentManagers[family] = manager;
                return manager;
            }

            return _componentManagers[family];
        }

        [ProtoBeforeDeserialization]
        private void FillMissingComponent()
        {
            _componentManagers = new ComponentManager[1];
            _componentManagers[0] = new ComponentManager();
        }

        [ProtoAfterDeserialization]
        private void FillComponentsArray()
        {
            if (_componentManagers.Length < ComponentsLimit)
            {
                Array.Resize(ref _componentManagers, ComponentsLimit);
            }
        }

        [ProtoBeforeSerialization]
        private void RemoveRedundantComponent()
        {
            _componentManagers[0] = null;
        }
    }
}