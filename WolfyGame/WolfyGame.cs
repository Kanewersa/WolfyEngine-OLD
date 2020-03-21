using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WolfyShared.Controllers;
using WolfyShared.Engine;
using WolfyShared.Game;

namespace WolfyGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class WolfyGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Map currentMap;
        private MovementController _movementController;

        private Camera _camera;
        private Player _player;

        public static int ScreenHeight;
        public static int ScreenWidth;

        public WolfyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;

            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;

            Window.ClientSizeChanged += Window_ClientSizeChanged;
            // Initialize the controllers
            // Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)

            _movementController = new MovementController();

            PathsController.Instance.SetMainPath("");
            TilesetsController.Instance.InitializeProject();
            MapsController.Instance.InitializeProject();
            GameController.Instance.InitializeProject();

            // Load the game from current folder
            var id = GameController.Instance.Settings.StartingMap;
            currentMap = MapsController.Instance.GetMap(id);
            currentMap.Initialize(graphics.GraphicsDevice);

            base.Initialize();
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            graphics.ApplyChanges();

            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        ///
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            // Create the camera
            _camera = new Camera();
            _camera.SetMapBoundaries(new Vector2(
                currentMap.Size.X * currentMap.TileSize.X, 
                currentMap.Size.Y * currentMap.TileSize.Y));

            var movement = new Dictionary<string, Animation>()
            {
                { "Walk", new Animation("001-Fighter01.png", 4, 4) }
            };

            foreach (var pair in movement)
            {
                pair.Value.Image.Initialize(graphics.GraphicsDevice);
            }

            var coordinates = GameController.Instance.Settings.StartingCoordinates;

            _player = new Player(movement, coordinates)
            {
                Position = new Vector2(
                    coordinates.X * currentMap.TileSize.X,
                    coordinates.Y * currentMap.TileSize.Y),
                GridPosition = new Vector2D(coordinates.X,coordinates.Y),
                Input = new Input()
                {
                    Up = Keys.Up,
                    Down = Keys.Down,
                    Left = Keys.Left,
                    Right = Keys.Right,
                }
            };

            foreach (var layer in currentMap.Layers)
            {
                if (layer is EntityLayer lay)
                {
                    lay.Rows[coordinates.Y].Tiles[coordinates.X].Entity = _player;
                    lay.Entities.Add(_player);
                    _player.OnMove += (entity, position) =>
                        _movementController.MoveEntity(entity, currentMap, lay, position);
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            currentMap.Update(gameTime);

            _camera.Update(_player);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(transformMatrix: _camera.Transform, samplerState: SamplerState.PointClamp);

            currentMap.Draw(spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
