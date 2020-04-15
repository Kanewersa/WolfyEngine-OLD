using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract(AsReferenceDefault = true)] public class Entity
    {
        [ProtoIgnore] private World _world;
        
        [ProtoMember(2)] public uint Id { get; }
        [ProtoMember(3)] public string Name { get; set; }
        
        public Entity() { }

        internal Entity(uint id, World world)
        {
            Id = id;
            _world = world;
        }

        public void Initialize(World world)
        {
            _world = world;
        }
        
        /// <summary>
        /// Creates and returns the new component of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddComponent<T>() where T : EntityComponent, new()
        {
            return _world.AddComponent<T>(this);
        }

        /// <summary>
        /// Adds given component of T type to entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        public void AddComponent<T>(T component) where T : EntityComponent, new()
        {
            _world.AddComponent<T>(this, component);
        }

        /// <summary>
        /// Returns true if entity has component of given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool HasComponent<T>() where T : EntityComponent
        {
            return _world.HasComponent<T>(this);
        }

        /// <summary>
        /// Returns component of given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : EntityComponent
        {
            return _world.GetComponent<T>(this);
        }

        /// <summary>
        /// Returns component of given type if entity has one. Otherwise it returns it's new instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetIfHasComponent<T>() where T : EntityComponent, new()
        {
            return HasComponent<T>()
                ? GetComponent<T>() 
                : AddComponent<T>();
        }

        /// <summary>
        /// Returns all components of entity.
        /// </summary>
        /// <returns></returns>
        public List<EntityComponent> GetComponents()
        {
            return _world.GetComponents(this);
        }

        /// <summary>
        /// Removes component of given type from entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveComponent<T>() where T : EntityComponent
        {
            _world.RemoveComponent<T>(this);
        }

        /// <summary>
        /// Removes component of given type if entity has one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveIfHasComponent<T>() where T : EntityComponent
        {
            if (HasComponent<T>())
                RemoveComponent<T>();
        }

        /// <summary>
        /// Destroys the entity.
        /// </summary>
        public void Destroy()
        {
            _world.DestroyEntity(this);
        }
    }
}
