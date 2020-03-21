﻿using System;
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

            var movement = new Dictionary<string, Animation>()
            {
                { "Walk", new Animation("001-Fighter01.png", 4, 4) }
            };

            foreach (var pair in movement)
            {
                pair.Value.Image.Initialize(graphics.GraphicsDevice);
            }

            var player = new Player(movement)
            {
                Position = new Vector2(64, 64),
                Input = new Input()
                {
                    Up = Keys.Up,
                    Down = Keys.Down,
                    Left = Keys.Left,
                    Right = Keys.Right,
                }
            };

            var coordinates = GameController.Instance.Settings.StartingCoordinates;

            foreach (var layer in currentMap.Layers)
            {
                if (layer is EntityLayer lay)
                {
                    lay.Rows[coordinates.Y].Tiles[coordinates.X].Entity = player;
                    lay.Entities.Add(player);
                    player.OnMove += position => _movementController.CanPass(currentMap, position);
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

            spriteBatch.Begin();

            currentMap.Draw(spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
