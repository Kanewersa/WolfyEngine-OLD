using System.Collections.Generic;
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
        public Entity Player { get; private set; }
        public Entity Npc { get; private set; }

        public InputSystem InputSystem { get; set; }
        public MovementSystem MovementSystem { get; set; }
        public CollisionSystem CollisionSystem { get; set; }
        public AnimationSystem AnimationSystem { get; set; }
        public RoutineMovementSystem RoutineMovementSystem { get; set; }

        public GameScene(int screenWidth, int screenHeight) : base(screenWidth, screenHeight)
        {
            InputSystem = new InputSystem();
            MovementSystem = new MovementSystem();
            CollisionSystem = new CollisionSystem();
            AnimationSystem = new AnimationSystem();
            RoutineMovementSystem = new RoutineMovementSystem();
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

            /*Player = new Player(movement, coordinates)
            {
                Position = new Vector2(
                    coordinates.X * CurrentMap.TileSize.X,
                    coordinates.Y * CurrentMap.TileSize.Y),
                GridPosition = new Vector2D(coordinates.X, coordinates.Y),
                Input = new Input()
                {
                    Up = Keys.Up,
                    Down = Keys.Down,
                    Left = Keys.Left,
                    Right = Keys.Right,
                }
            };

            /*foreach (var layer in CurrentMap.Layers)
            {
                if (layer is EntityLayer lay)
                {
                    lay.Rows[coordinates.Y].Tiles[coordinates.X].Entity = Player;
                    lay.Entities.Add(Player);
                    Player.OnMove += (entity, position) =>
                        MovementController.MoveEntity(entity, CurrentMap, lay, position);
                }
            }*/

            CollisionSystem.SetMap(CurrentMap);

            // Create player

            Player = CreateEntity("Player");

            var input = Player.AddComponent<InputComponent>();
            InputSystem.AddEntity(Player);
            var collision = Player.AddComponent<CollisionComponent>();
            CollisionSystem.AddEntity(Player);
            var movement = Player.AddComponent<MovementComponent>();
            MovementSystem.AddEntity(Player);
            var animation = Player.AddComponent<AnimationComponent>();
            AnimationSystem.AddEntity(Player);



            
            movement.Speed = 100;
            movement.GridPosition = (Vector2)coordinates;
            movement.Direction = new Vector2(0,0);
            movement.Transform = (Vector2)coordinates * CurrentMap.TileSize.X;

            animation.Position = movement.Transform;
            animation.StartPosition = movement.Transform;
            animation.EndPosition = movement.Transform;
            animation.Animations = movementAnimation;
            animation.AnimationManager =
                new AnimationManager(animation.Animations.First().Value, CurrentMap.TileSize.X);

            // Create NPC

            Npc = CreateEntity("NPC");

            collision = Npc.AddComponent<CollisionComponent>();
            CollisionSystem.AddEntity(Npc);
            movement = Npc.AddComponent<MovementComponent>();
            MovementSystem.AddEntity(Npc);
            animation = Npc.AddComponent<AnimationComponent>();
            AnimationSystem.AddEntity(Npc);
            var routine = Npc.AddComponent<RoutineMovementComponent>();
            RoutineMovementSystem.AddEntity(Npc);

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
        }

        
    }
}
