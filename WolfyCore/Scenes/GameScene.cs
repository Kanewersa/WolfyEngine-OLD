using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WolfyECS;

namespace WolfyCore.Scenes
{
    public class GameScene : Scene
    {
        public bool Paused { get; set; }
        public World World { get; set; }

        public GameScene(World world)
        {
            World = world;
        }

        public override void Initialize(GraphicsDevice graphics)
        {
            base.Initialize(graphics);

            World.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            World.LoadContent(content);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);

            if (Paused)
            {
                // TODO Pause game
            }
            else World.Draw(spriteBatch, gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Paused) return;

            // TODO Update equipment here
            
            World.Update(gameTime);
            // TODO Fix camera update
            //Camera.Update(Player.GetComponent<AnimationComponent>());
            //VisibleArea = Camera.GetVisibleArea();
        }
    }
}
