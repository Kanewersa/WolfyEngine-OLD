using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyECS
{
    public abstract class EntitySystem
    {
        // Specifies which components are important for the system
        public ComponentMask Signature { get; set; }
        
        // Entities that fit the system Signature
        public List<Entity> Entities { get; protected set; }
        
        private World _world;
        
        protected EntitySystem()
        {
            Entities = new List<Entity>();
            Signature = new ComponentMask(0);
        }

        public virtual void Initialize()
        { }

        public virtual void Update(GameTime gameTime)
        { }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { }

        public void RegisterWorld(World world)
        {
            _world = world;
        }

        protected void RequireComponent<T>() where T : EntityComponent
        {
            Signature = Signature.AddComponent<T>();
        }

        protected void DiscardComponent<T>() where T : EntityComponent
        {
            Signature = Signature.RemoveComponent<T>();
        }
        
        public void RegisterEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public void UnregisterEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        // TODO Obsolete method
        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }
    }
}
