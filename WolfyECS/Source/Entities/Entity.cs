using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract(AsReferenceDefault = true)] public class Entity
    {
        [ProtoMember(1)] public uint Id { get; }
        [ProtoMember(2)] private int _worldId;

        [ProtoIgnore] private World World => World.WorldInstance;

        public Entity() { }

        internal Entity(uint id, int worldId)
        {
            Id = id;
            _worldId = worldId;
        }

        /// <summary>
        /// Creates and returns the new component of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddComponent<T>() where T : EntityComponent, new()
        {
            return World.AddComponent<T>(this);
        }

        /// <summary>
        /// Adds given component of T type to entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        public void AddComponent<T>(T component) where T : EntityComponent, new()
        {
            World.AddComponent<T>(this, component);
        }

        /// <summary>
        /// Returns true if entity has component of given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool HasComponent<T>() where T : EntityComponent
        {
            return World.HasComponent<T>(this);
        }

        /// <summary>
        /// Returns component of given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : EntityComponent
        {
            return World.GetComponent<T>(this);
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
            return World.GetComponents(this);
        }

        /// <summary>
        /// Removes component of given type from entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveComponent<T>() where T : EntityComponent
        {
            World.RemoveComponent<T>(this);
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
            World.DestroyEntity(this);
        }
    }
}
