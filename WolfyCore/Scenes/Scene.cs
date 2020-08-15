using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyCore.Scenes
{
    public abstract class Scene
    {


        protected Scene()
        { }

        public virtual void Initialize(GraphicsDevice graphics)
        {

        }

        public virtual void LoadContent(ContentManager content)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}
