using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract]
    public class World
    {
        [ProtoMember(1)] private EntityManager _entityManager;
        [ProtoMember(2)] private List<EntitySystem> _systems;
        [ProtoMember(3)]
        private ComponentManager[] _componentManagers;

        [ProtoMap(DisableMap = true)]
        [ProtoMember(4)] private Dictionary<Entity, ComponentMask> _entityMasks;

        private const int ComponentsLimit = 64;

        [ProtoMember(5)] internal readonly int WorldId;

        public static World WorldInstance;
        private static readonly IdDispenser _worldIdDispenser;

        public const int WorldsLimit = 16;

        static World()
        {
            _worldIdDispenser = new IdDispenser(WorldsLimit);
            //Worlds = new World[WorldsLimit];
        }

        public static void SetWorld(World world)
        {
            WorldInstance = world;
        }

        public World()
        {
            WorldId = (int)_worldIdDispenser.GetId();
            _entityManager = new EntityManager(this.WorldId);

            _systems = new List<EntitySystem>();
            _componentManagers = new ComponentManager[ComponentsLimit];
            _entityMasks = new Dictionary<Entity, ComponentMask>();
        }

        /// <summary>
        /// Initializes the world.
        /// </summary>
        public void Initialize(List<Type> componentTypes)
        {
            if (ComponentsChanged(componentTypes))
                SortComponentManagers(componentTypes);
            

            foreach(var system in _systems)
                system.Initialize();
        }

        /// <summary>
        /// Returns true if component types in project changed.
        /// </summary>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        private bool ComponentsChanged(List<Type> componentTypes)
        {
            List<string> oldTypes = new List<string>(ComponentsLimit);
            List<string> newTypes = new List<string>(ComponentsLimit);

            if (_componentManagers == null) return false;
            foreach (var component in componentTypes)
            {
                newTypes.Add(component.Name);
            }

            for (int i = 1; i < ComponentsLimit; i++)
            {
                if (_componentManagers[i] == null) break;
                oldTypes.Add(_componentManagers[i].ComponentType);
            }

            return !oldTypes.SequenceEqual(newTypes);
        }

        private void SortComponentManagers(List<Type> componentTypes)
        {
            var managersCount = 0;

            // Get managers count
            for (int i = 1; i < ComponentsLimit; i++)
            {
                if (_componentManagers[i] == null)
                    break;
                managersCount++;
            }

            // Add missing types

            for (int i = 0; i < componentTypes.Count; i++)
            {
                var hasComponent = false;

                for (int j = 1; j < managersCount; j++)
                {
                    if (componentTypes[i].Name == _componentManagers[j].ComponentType)
                    {
                        hasComponent = true;
                        break;
                    }
                }

                if (!hasComponent)
                {
                    managersCount++;

                    // Make space in array for new component
                    if(_componentManagers[ComponentsLimit-1] != null)
                        throw new Exception("Components limit reached!");

                    for (int j = ComponentsLimit-1; j > i; j--)
                    {
                        if (_componentManagers[j] == null) continue;

                        _componentManagers[j + 1] = _componentManagers[j];
                    }

                    _componentManagers[i + 1] =
                        new ComponentManager(componentTypes[i].Name);
                }
            }

            // Get obsolete types
            var obsoleteIndexes = new List<int>(ComponentsLimit);

            for (int i = 1; i < managersCount; i++)
            {
                var hasComponent = false;

                foreach (var type in componentTypes)
                {
                    if (_componentManagers[i].ComponentType == type.Name)
                    {
                        hasComponent = true;
                        break;
                    }
                }

                if(!hasComponent)
                {
                    obsoleteIndexes.Add(i);
                }
            }

            // Remove obsolete types
            foreach (var index in obsoleteIndexes)
            {
                if(managersCount <= 1)
                    throw new Exception("Tried to delete last available component type.");

                // Move all elements after the index one to the left
                for (int i = index; i < ComponentsLimit-1; i++)
                {
                    if (_componentManagers[i] == null) break;
                    _componentManagers[i] = _componentManagers[i + 1];
                }

                managersCount--;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var system in _systems)
            {
                system.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var system in _systems)
            {
                system.Draw(gameTime, spriteBatch);
            }
        }

        public ComponentManager[] GetComponentManagers()
        {
            return _componentManagers;
        }

        #region Entities methods

        public Entity CreateEntity()
        {
            var entity = _entityManager.CreateEntity();
            _entityMasks.Add(entity, new ComponentMask(0));
            return entity;
        }

        public uint EntityCount()
        {
            return _entityManager.EntityCount;
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

        public List<EntitySystem> GetSystems()
        {
            return _systems;
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
            var comp = manager.GetComponent(e);
            return (T) comp;
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
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].RemoveComponent<T>();
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
                var manager = new ComponentManager(typeof(T).Name);
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