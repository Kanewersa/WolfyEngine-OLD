﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract(SkipConstructor = true)]
    public abstract class EntitySystem
    {
        // Specifies which components are important for the system
        [ProtoMember(1)] public ComponentMask Signature { get; set; }
        
        // Entities that fit the system Signature
        [ProtoMember(2)] public List<Entity> Entities { get; set; }
        
        [ProtoMember(3)] public int WorldId { get; set; }
        [ProtoIgnore] protected World World => World.WorldInstance;
        
        protected EntitySystem()
        {
            Entities = new List<Entity>();
            Signature = new ComponentMask(0);
        }

        /// <summary>
        /// Performs all operations necessary to initialize the system.
        /// </summary>
        public virtual void Initialize()
        { }

        /// <summary>
        /// Loads any content needed by the system.
        /// </summary>
        /// <param name="content"></param>
        public virtual void LoadContent(ContentManager content)
        { }

        /// <summary>
        /// Updates all the entities system is subscribing to.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        { }

        /// <summary>
        /// Performs all system drawing operations.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { }

        /// <summary>
        /// Adds the component mask to the signature.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected void RequireComponent<T>() where T : EntityComponent
        {
            Signature = Signature.AddComponent<T>();
        }

        /// <summary>
        /// Removes the component mask from the signature.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected void DiscardComponent<T>() where T : EntityComponent
        {
            Signature = Signature.RemoveComponent<T>();
        }

        /// <summary>
        /// Adds the given entity to the system.
        /// </summary>
        /// <param name="entity"></param>
        public void RegisterEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        /// <summary>
        /// Removes the given entity from the system.
        /// </summary>
        /// <param name="entity"></param>
        public void UnregisterEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        /// <summary>
        /// Performs defined action on all entities.
        /// </summary>
        /// <param name="action"></param>
        public void IterateEntities(Action<Entity> action)
        {
            for (int i = 0; i < Entities.Count; i++)
                action(Entities[i]);
        }
    }
}
