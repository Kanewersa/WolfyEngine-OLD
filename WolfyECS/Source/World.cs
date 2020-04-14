using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract(AsReferenceDefault = true)] public class World
    {
        [ProtoMember(1)] private EntityManager _entityManager;
        [ProtoMember(2)] private List<EntitySystem> _systems;
        [ProtoMember(3)] private ComponentManager[] _componentManagers;
        [ProtoMember(4)] private Dictionary<Entity, ComponentMask> _entityMasks;

        public World()
        {
            _entityManager = new EntityManager(this);
            _systems = new List<EntitySystem>(64);
            _componentManagers = new ComponentManager[64];
            _entityMasks = new Dictionary<Entity, ComponentMask>();
        }
        
        public void Initialize()
        {
            foreach(var system in _systems)
                system.Initialize();
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
            _entityMasks.Add(entity, new ComponentMask(0));
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
            _entityMasks.Remove(entity);
        }

        #endregion
        
        
        public void AddSystem(EntitySystem entitySystem)
        {
            _systems.Add(entitySystem);
        }

        public void UpdateEntityMask(Entity e, ComponentMask oldMask)
        {
            var newMask = _entityMasks[e];

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
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].AddComponent<T>();
            UpdateEntityMask(e, oldMask);
            return component;
        }

        public void AddComponent<T>(Entity e, T component) where T : EntityComponent
        {
            var manager = GetComponentManager<T>();
            manager.AddComponent(e, component);

            // Check if systems are interested in component
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].AddComponent<T>();
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
            return (from manager
                    in _componentManagers
                    where manager != null && manager.HasComponent(e)
                    select manager.GetComponent(e)).ToList();
        }

        public void RemoveComponent<T>(Entity e) where T : EntityComponent
        {
            var manager = GetComponentManager<T>();
            manager.DestroyComponent(e);
            
            // Check if systems are interested in components
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].RemoveComponent<T>();
            UpdateEntityMask(e, oldMask);
        }

        #endregion

        private ComponentManager GetComponentManager<T>() where T : EntityComponent
        {
            var family = Family.GetComponentFamily<T>();

            if (family > _componentManagers.Length)
                Array.Resize(ref _componentManagers, family + 16);
            
            if (_componentManagers.ElementAtOrDefault(family) == null)
            {
                var manager = new ComponentManager();
                _componentManagers[family] = manager;
                return manager;
            }

            return _componentManagers[family];
        }
    }
}