using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyECS
{
    public class World
    {
        private EntityManager _entityManager;
        private List<EntitySystem> _systems;
        private List<ComponentManager> _componentManagers;
        private Dictionary<Entity, ComponentMask> _entityMasks;

        public World()
        {
            _entityManager = new EntityManager(this);
            _systems = new List<EntitySystem>(50);
            _componentManagers = new List<ComponentManager>(50);
            _entityMasks = new Dictionary<Entity, ComponentMask>();
        }
        
        public void Initialize()
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }

        #region Entities methods

        public Entity CreateEntity()
        {
            return _entityManager.CreateEntity();
        }

        public Entity CreateEntity(string name)
        {
            return _entityManager.CreateEntity(name);
        }

        public void DestroyEntity(Entity entity)
        {
            _entityManager.DestroyEntity(entity);
            
            foreach(var system in _systems)
                system.UnregisterEntity(entity);
            foreach (var componentManager in _componentManagers)
                componentManager.DestroyComponent(entity);
            // Destroy entity in systems and component managers
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

        public void AddComponent<T>(Entity e) where T : EntityComponent<T>
        {
            var manager = _componentManagers[Family.GetComponentFamily<T>()];
            manager.AddComponent(e, new EntityComponent<T>());
            
            // Check if systems are interested in component
            var oldMask = _entityMasks[e];
            _entityMasks[e].AddComponent<T>();
            UpdateEntityMask(e, oldMask);
        }
        
        public T GetComponent<T>(Entity e) where T : EntityComponent<T>
        {
            var manager = _componentManagers[Family.GetComponentFamily<T>()];
            return manager.GetComponent(e) as T;
        }

        public void RemoveComponent<T>(Entity e) where T : EntityComponent<T>
        {
            var manager = _componentManagers[Family.GetComponentFamily<T>()];
            manager.DestroyComponent(e);
            
            // Check if systems are interested in components
            var oldMask = _entityMasks[e];
            _entityMasks[e].RemoveComponent<T>();
            UpdateEntityMask(e, oldMask);
        }

        #endregion
    }
}