using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyECS
{
    public abstract class EntitySystem
    {
        public List<Entity> Entities { get; protected set; }

        public List<Type> Interests { get; protected set; }
        
        protected EntitySystem()
        {
            Entities = new List<Entity>();
        }

        public virtual void Update(GameTime gameTime)
        { }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { }

        public void EntityDestroyed(Entity entity)
        {
            if (Entities.Contains(entity))
            {
                Entities.Remove(entity);
            }
        }

        public void EntityModified(Entity entity)
        {
            
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public void ValidateEntity(uint entityId)
        {

        }
    }
}
