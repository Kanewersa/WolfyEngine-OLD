using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.Scenes
{
    public class GameScene : Scene
    {
        public bool Paused { get; set; }
        public Camera Camera { get; private set; }
        public Rectangle VisibleArea { get; private set; }
        public Map CurrentMap { get; private set; }
        private Entity Player { get; set; }
        public World World { get; set; }

        public GameScene(int screenWidth, int screenHeight, World world) : base(screenWidth, screenHeight)
        {
            World = world;
        }

        public override void Initialize(GraphicsDevice graphics)
        {
            base.Initialize(graphics);

            if(CurrentMap == null)
                throw new Exception("Current map was not set.");

            Player = new Entity(1, World.WorldId);

            Camera = new Camera()
            {
                ScreenWidth = this.ScreenWidth,
                ScreenHeight = this.ScreenHeight
            };

            Camera.SetMapBoundaries(new Vector2(
                CurrentMap.Size.X * Runtime.GridSize,
                CurrentMap.Size.Y * Runtime.GridSize));

            
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

        public override void UpdateResolution(int width, int height)
        {
            base.UpdateResolution(width, height);
            Camera.ScreenWidth = width;
            Camera.ScreenHeight = height;
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

        public void SetWorld(World world)
        {
            World = world;
        }

        public void SetMap(Map map)
        {
            CurrentMap = map;
        }
    }
}
