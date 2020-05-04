using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine;
using WolfyCore.Controllers;

namespace WolfyCore.Scenes
{
    public class GameScene : Scene
    {
        public bool Paused { get; set; }
        public Camera Camera { get; private set; }
        public Rectangle VisibleArea { get; private set; }
        public Map CurrentMap { get; private set; }

        public Entity Player;
        public InputSystem InputSystem { get; set; }
        public MovementSystem MovementSystem { get; set; }
        public CollisionSystem CollisionSystem { get; set; }
        public AnimationSystem AnimationSystem { get; set; }
        public RandomMovementSystem RandomMovementSystem { get; set; }
        
        public World CurrentWorld { get; set; }

        public GameScene(int screenWidth, int screenHeight, World world) : base(screenWidth, screenHeight)
        {
            InputSystem = new InputSystem();
            MovementSystem = new MovementSystem();
            CollisionSystem = new CollisionSystem();
            AnimationSystem = new AnimationSystem();
            RandomMovementSystem = new RandomMovementSystem();

            CurrentWorld = world;
        }

        public override void Initialize(GraphicsDevice graphics)
        {
            base.Initialize(graphics);

            if(CurrentMap == null)
                throw new Exception("Current map was not set.");

            Camera = new Camera()
            {
                ScreenWidth = this.ScreenWidth,
                ScreenHeight = this.ScreenHeight
            };

            Camera.SetMapBoundaries(new Vector2(
                CurrentMap.Size.X * CurrentMap.TileSize.X,
                CurrentMap.Size.Y * CurrentMap.TileSize.Y));

            //###################################################################
            var movementAnimation = new Dictionary<string, Animation>
            {
                { "Walk", new Animation("001-Fighter01.png", 4, 4) }
            };

            // LOAD CONTENT
            //foreach (var pair in movementAnimation)
            //{
            //    pair.Value.Image.Initialize(graphics);
            //}
            //
            //###################################################################

            CollisionSystem.SetMap(CurrentMap);
            
            // Setup world

            CurrentWorld.AddSystem(InputSystem);
            CurrentWorld.AddSystem(CollisionSystem);
            CurrentWorld.AddSystem(MovementSystem);
            CurrentWorld.AddSystem(AnimationSystem);
            CurrentWorld.AddSystem(RandomMovementSystem);
            
            CurrentWorld.Initialize(WolfyManager.ComponentTypes);

            foreach (var entity in CurrentMap.Entities)
            {
                if(entity.HasComponent<CollisionComponent>())
                    CollisionSystem.RegisterEntity(entity);
                if (entity.HasComponent<MovementComponent>())
                    MovementSystem.RegisterEntity(entity);
                if (entity.HasComponent<AnimationComponent>())
                    AnimationSystem.RegisterEntity(entity);
                if (entity.HasComponent<RandomMovementComponent>())
                    RandomMovementSystem.RegisterEntity(entity);
            }
        }

        public override void LoadContent(ContentManager content)
        {
            // TODO Image initialization should be moved to separate class/manager
            AnimationSystem.LoadContent(content);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);

            spriteBatch.Begin(transformMatrix: Camera.Transform, samplerState: SamplerState.PointClamp);

            if (Paused)
            {
                // TODO Pause game
            }
            else
            {
                CurrentMap.Draw(spriteBatch, VisibleArea);
                AnimationSystem.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
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

            RandomMovementSystem.Update(gameTime);
            InputSystem.Update(gameTime);
            CollisionSystem.Update(gameTime);
            MovementSystem.Update(gameTime);
            AnimationSystem.Update(gameTime);

            // TODO Update equipment here
            
            CurrentMap.Update(gameTime);
            Camera.Update(Player.GetComponent<AnimationComponent>());
            VisibleArea = Camera.GetVisibleArea();
        }

        public void SetWorld(World world)
        {
            CurrentWorld = world;
        }

        public void SetMap(Map map)
        {
            CurrentMap = map;
        }
    }
}
