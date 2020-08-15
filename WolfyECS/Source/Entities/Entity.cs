using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public struct Entity
    {
        /// <summary>
        /// Unique Id of Entity.
        /// </summary>
        [ProtoMember(1)] public ushort Id { get; }

        /// <summary>
        /// Id of the world entity belongs to.
        /// </summary>
        //[ProtoMember(2)] private short _worldId;

        [ProtoIgnore] private World World => World.WorldInstance;

        /// <summary>
        /// Creates entity with given Id and assigns it a world.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="worldId"></param>
        public Entity(ushort id, short worldId)
        {
            Id = id;
            //_worldId = worldId;
        }

        public static Entity Empty => new Entity(0, -1);
        public static Entity Player => new Entity(1, 1);

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
        public bool HasComponent<T>() where T : EntityComponent, new()
        {
            return World.HasComponent<T>(this);
        }

        /// <summary>
        /// Returns component of given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : EntityComponent, new()
        {
            return World.GetComponent<T>(this);
        }

        /// <summary>
        /// Returns component of given type if entity has one. Otherwise it returns it's new instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetOrCreateComponent<T>() where T : EntityComponent, new()
        {
            return HasComponent<T>()
                ? GetComponent<T>() 
                : AddComponent<T>();
        }

        /// <summary>
        /// Returns true if entity has component of <see cref="T"/> type and outs the component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool GetIfHasComponent<T>(out T component) where T : EntityComponent, new()
        {
            var has = HasComponent<T>();
            component = has ? GetComponent<T>() : null;
            return has;
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
        public void RemoveComponent<T>() where T : EntityComponent, new()
        {
            World.RemoveComponent<T>(this);
        }

        /// <summary>
        /// Removes component of given type if entity has one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveIfHasComponent<T>() where T : EntityComponent, new()
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

        public void Freeze()
        {
            World.FreezeEntity(this);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            return a.Id == b.Id;
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public void GetMask()
        {
            World.GetMask(this).Debug();
        }
    }
}
