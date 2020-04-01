using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WolfyECS;
using WolfyShared.ECS;

namespace WolfyShared.Scenes
{
    public abstract class Scene
    {
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        protected Scene(int screenWidth, int screenHeight)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }

        public virtual void Initialize(GraphicsDevice graphics)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public virtual void UpdateResolution(int width, int height)
        {
            ScreenHeight = height;
            ScreenWidth = width;
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}
