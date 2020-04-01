using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WolfyECS;
using WolfyShared.Controllers;
using WolfyShared.ECS;
using WolfyShared.Engine;
using WolfyShared.Game;

namespace WolfyShared.Scenes
{
    public class GameScene : Scene
    {
        public bool Paused { get; private set; }
        public Camera Camera { get; private set; }
        public Rectangle VisibleArea { get; private set; }
        public Map CurrentMap { get; private set; }

        public Entity Player;
        public Entity Npc;
        public InputSystem InputSystem { get; set; }
        public MovementSystem MovementSystem { get; set; }
        public CollisionSystem CollisionSystem { get; set; }
        public AnimationSystem AnimationSystem { get; set; }
        public RoutineMovementSystem RoutineMovementSystem { get; set; }
        
        public World CurrentWorld { get; set; }

        public GameScene(int screenWidth, int screenHeight) : base(screenWidth, screenHeight)
        {
            InputSystem = new InputSystem();
            MovementSystem = new MovementSystem();
            CollisionSystem = new CollisionSystem();
            AnimationSystem = new AnimationSystem();
            RoutineMovementSystem = new RoutineMovementSystem();
            
            CurrentWorld = new World();
        }

        public override void Initialize(GraphicsDevice graphics)
        {
            base.Initialize(graphics);

            Camera = new Camera()
            {
                ScreenWidth = this.ScreenWidth,
                ScreenHeight = this.ScreenHeight
            };

            var mapId = GameController.Instance.Settings.StartingMap;
            CurrentMap = MapsController.Instance.GetMap(mapId);
            CurrentMap.Initialize(graphics);

            Camera.SetMapBoundaries(new Vector2(
                CurrentMap.Size.X * CurrentMap.TileSize.X,
                CurrentMap.Size.Y * CurrentMap.TileSize.Y));

            var movementAnimation = new Dictionary<string, Animation>()
            {
                { "Walk", new Animation("001-Fighter01.png", 4, 4) }
            };

            var npcMovementAnimation = new Dictionary<string, Animation>()
            {
                { "Walk", new Animation("001-Fighter01.png", 4, 4) }
            };

            foreach (var pair in movementAnimation)
            {
                pair.Value.Image.Initialize(graphics);
            }

            foreach (var pair in npcMovementAnimation)
            {
                pair.Value.Image.Initialize(graphics);
            }

            var coordinates = GameController.Instance.Settings.StartingCoordinates;

            CollisionSystem.SetMap(CurrentMap);
            
            // Setup world

            CurrentWorld.AddSystem(InputSystem);
            CurrentWorld.AddSystem(CollisionSystem);
            CurrentWorld.AddSystem(MovementSystem);
            CurrentWorld.AddSystem(AnimationSystem);
            CurrentWorld.AddSystem(RoutineMovementSystem);
            
            CurrentWorld.Initialize();

            // Should be called after systems are added and initialized
            Player = CurrentWorld.CreateEntity("Player");
            Player.AddComponent<InputComponent>();
            Player.AddComponent<CollisionComponent>();
            Player.AddComponent<MovementComponent>();
            Player.AddComponent<AnimationComponent>();

            var movement = Player.GetComponent<MovementComponent>();
            movement.Speed = 100;
            movement.GridPosition = (Vector2)coordinates;
            movement.Direction = new Vector2(0,0);
            movement.Transform = (Vector2) coordinates * CurrentMap.TileSize.X;
            
            var animation = Player.GetComponent<AnimationComponent>();
            animation.Position = movement.Transform;
            animation.StartPosition = movement.Transform;
            animation.EndPosition = movement.Transform;
            animation.Animations = movementAnimation;
            animation.AnimationManager =
                new AnimationManager(animation.Animations.First().Value, CurrentMap.TileSize.X);
            
            // Create Npc


            Npc = CurrentWorld.CreateEntity("NPC");

            Npc.AddComponent<CollisionComponent>();
            Npc.AddComponent<MovementComponent>();
            Npc.AddComponent<AnimationComponent>();
            Npc.AddComponent<RoutineMovementComponent>();

            movement = Npc.GetComponent<MovementComponent>();
            animation = Npc.GetComponent<AnimationComponent>();
            var routine = Npc.GetComponent<RoutineMovementComponent>();

            movement.Speed = 60;
            movement.GridPosition = new Vector2(0,0);
            movement.Direction = new Vector2(0, 0);
            movement.Transform = movement.GridPosition * CurrentMap.TileSize.X;

            animation.Position = movement.Transform;
            animation.StartPosition = movement.Transform;
            animation.EndPosition = movement.Transform;
            animation.Animations = npcMovementAnimation;
            animation.AnimationManager =
                new AnimationManager(animation.Animations.First().Value, CurrentMap.TileSize.X);

            routine.MovementFrequency = 1;
            routine.Timer = routine.MovementFrequency;

            //
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
            MeasureTime.Start("Update took: ");

            if (Paused) return;

            RoutineMovementSystem.Update(gameTime);
            InputSystem.Update(gameTime);
            CollisionSystem.Update(gameTime);
            MovementSystem.Update(gameTime);
            AnimationSystem.Update(gameTime);

            // TODO Update equipment here
            
            CurrentMap.Update(gameTime);
            Camera.Update(Player.GetComponent<AnimationComponent>());
            VisibleArea = Camera.GetVisibleArea();
            MeasureTime.Stop();
        }

        
    }
}
