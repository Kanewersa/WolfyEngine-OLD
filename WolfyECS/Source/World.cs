using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract]
    public class World
    {
        [ProtoMember(1)] private readonly EntityManager _entityManager;
        [ProtoMember(2)] private readonly List<EntitySystem> _systems;
        [ProtoMember(3, OverwriteList = true)]
        private ComponentManager[] _componentManagers;

        [ProtoMap(DisableMap = true)]
        [ProtoMember(4)] private readonly Dictionary<Entity, ComponentMask> _entityMasks;

        private const int ComponentsLimit = 64;

        [ProtoMember(5)] public readonly sbyte WorldId;

        [ProtoIgnore] private GraphicsDevice _graphicsDevice;
        [ProtoIgnore] private ContentManager _contentManager;

        public static World WorldInstance;
        private static readonly IdDispenser WorldIdDispenser;

        public const int WorldsLimit = 16;

        static World()
        {
            WorldIdDispenser = new IdDispenser(WorldsLimit);
            //Worlds = new World[WorldsLimit];
        }

        public void Debug()
        {
            foreach (var system in _systems)
            {
                Console.WriteLine("System " + system.GetType() + " has entities: " + system.Entities.Count);
            }
        }

        public static void SetWorld(World world)
        {
            WorldInstance = world;
        }

        public World()
        {
            WorldId = (sbyte) WorldIdDispenser.GetId();
            _entityManager = new EntityManager(this.WorldId);
            _systems = new List<EntitySystem>();
            _componentManagers = new ComponentManager[ComponentsLimit];
            _entityMasks = new Dictionary<Entity, ComponentMask>();
        }

        /// <summary>
        /// Initializes the world.
        /// </summary>
        public void Initialize(GraphicsDevice graphics)
        {
            // Load families for every present entity component type
            for (int f = 1; f < _componentManagers.Length; f++)
            {
                if (_componentManagers[f] == null)
                    break;

                _componentManagers[f].Initialize(f);
            }

            if (graphics != null)
            {
                _graphicsDevice = graphics;
            }

            // Load all systems
            foreach(var system in _systems)
                system.Initialize(graphics);
        }

        public void LoadContent(ContentManager content)
        {
            _contentManager = content;
            foreach (var system in _systems)
            {
                system.LoadContent(content);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var system in _systems)
            {
                system.Update(gameTime);
            }

            foreach (var system in _systems)
            {
                system.PostUpdate(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var system in _systems)
            {
                system.Draw(gameTime, spriteBatch);
            }
        }

        public ComponentMask GetMask(Entity entity)
        {
            return _entityMasks[entity];
        }

        #region Entities

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

        public void FreezeEntity(Entity entity)
        {
            foreach (var system in _systems)
                system.FreezeEntity(entity);
            foreach (var componentManager in _componentManagers)
                componentManager.FreezeComponent(entity);
        }

        public void EnableEntity(Entity entity)
        {
            foreach (var system in _systems)
            {
                bool matchingMask = system.Signature.Matches(_entityMasks[entity]);
                system.EnableEntity(entity, matchingMask);
            }
            foreach (var componentManager in _componentManagers)
                componentManager.EnableComponent(entity);
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

        #region Components

        public void EnableComponent<T>(Entity e) where T : EntityComponent, new()
        {
            GetComponentManager<T>().EnableComponent(e);

            // Check if systems are interested in components
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].RemoveComponent<T>();
            UpdateEntityMask(e, oldMask);
        }

        public void FreezeComponent<T>(Entity e) where T : EntityComponent, new()
        {
            GetComponentManager<T>().FreezeComponent(e);

            // Check if systems are interested in components
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].RemoveComponent<T>();
            UpdateEntityMask(e, oldMask);
        }

        public T AddComponent<T>(Entity e) where T : EntityComponent, new()
        {
            var component = new T();
            GetComponentManager<T>().AddComponent(e, component);

            // Check if systems are interested in component
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].AddComponent<T>();
            UpdateEntityMask(e, oldMask);
            return component;
        }

        public void AddComponent<T>(Entity e, T component) where T : EntityComponent, new()
        {
            GetComponentManager<T>().AddComponent(e, component);

            // Check if systems are interested in component
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].AddComponent<T>();
            UpdateEntityMask(e, oldMask);
        }

        public bool HasComponent<T>(Entity e) where T : EntityComponent, new()
        {
            return GetComponentManager<T>().HasComponent(e);
        }

        public T GetComponent<T>(Entity e) where T : EntityComponent, new()
        {
            return (T)GetComponentManager<T>().GetComponent(e);
        }

        public List<EntityComponent> GetComponents(Entity e)
        {
            var list = (from manager
                    in _componentManagers
                where manager != null && manager.HasComponent(e)
                select manager.GetComponent(e)).ToList();
            return list;
        }

        public void RemoveComponent<T>(Entity e) where T : EntityComponent, new()
        {
            GetComponentManager<T>().DestroyComponent(e);

            // Check if systems are interested in components
            var oldMask = _entityMasks[e];
            _entityMasks[e] = _entityMasks[e].RemoveComponent<T>();
            UpdateEntityMask(e, oldMask);
        }

        #endregion

        #region Component Managers

        private ComponentManager CreateComponentManager<T>(int index) where T : EntityComponent, new()
        {
            return _componentManagers[index] = new ComponentManager(new EntityComponent<T>());
        }

        private ComponentManager GetComponentManager<T>() where T : EntityComponent, new()
        {
            var family = Family.GetComponentFamily<T>();
            if (family > _componentManagers.Length)
                Array.Resize(ref _componentManagers, family + ComponentsLimit);

            // TODO Instantiate component managers to make null check unnecessary
            if (_componentManagers[family] == null ||
                _componentManagers[family] != null && _componentManagers[family].Temporary)
            {
                return CreateComponentManager<T>(family);
            }

            return _componentManagers[family];
        }

        #endregion


        [ProtoBeforeSerialization]
        private void FillEmptyComponents()
        {
            for (int i = 0; i < _componentManagers.Length; i++)
            {
                if (_componentManagers[i] == null)
                    _componentManagers[i] = new ComponentManager(true);
            }
        }
    }
}