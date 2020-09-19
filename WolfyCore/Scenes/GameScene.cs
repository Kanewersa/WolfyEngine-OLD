using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WolfyCore.ECS;
using WolfyECS;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

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

            World.Initialize(graphics);
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
        }

        public override void HandleMouseEvent(object sender, MouseState state)
        {
            if (state.LeftButton == ButtonState.Pressed)
            {
                var mousePosition = Entity.Player.GetComponent<CameraComponent>().ScreenToWorldSpace(new Vector2(state.X, state.Y));
                var coordinates = Vector2.Floor(mousePosition / Runtime.GridSize);
                var transform = Entity.Player.GetComponent<TransformComponent>();
                var map = transform.GetMap();
                if (coordinates.X < 0 || coordinates.Y < 0 || coordinates.X > map.Size.X || coordinates.Y > map.Size.Y)
                    return;
                if (Entity.Player.HasComponent<PathMovementComponent>() ||
                    Entity.Player.HasComponent<PathRequestComponent>())
                {
                    Entity.Player.RemoveComponent<PathMovementComponent>();
                    Entity.Player.RemoveComponent<PathRequestComponent>();
                }

                Entity.Player.AddComponent(new PathRequestComponent(map.Id, -1, transform.GridTransform, coordinates));
            }

        }
    }
}
