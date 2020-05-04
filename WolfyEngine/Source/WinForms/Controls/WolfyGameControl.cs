using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Forms.Controls;
using WolfyECS;
using WolfyEngine.Utils;
using WolfyCore;
using WolfyCore.Game;
using WolfyCore.Scenes;

namespace WolfyEngine.Controls
{
    public partial class WolfyGameControl : MonoGameControl
    {
        public GameScene Scene { get; set; }
        public bool GameRunning { get; set; }
        public Selector Selector { get; }
        public Map CurrentMap { get; private set; }
        public World World { get; private set; }

        private GameTime _gameTime;

        private bool _paused;

        public bool Paused
        {
            get => _paused;
            set
            {
                _paused = value;
                Scene.Paused = value;
            }
        }

        public WolfyGameControl()
        {
            Selector = new Selector((float)Runtime.GridSize/48);

            Scene = new GameScene(Width, Height, World);
        }

        protected override void Initialize()
        {
            base.Initialize();

            Selector.Initialize(GraphicsDevice);
            Scene.SetWorld(World);
            Scene.SetMap(CurrentMap);
            Scene.Initialize(GraphicsDevice);
            
            LoadContent(Editor.Content);
        }

        protected void LoadContent(ContentManager content)
        {
            Selector.LoadContent(content);
            Scene.LoadContent(content);
        }

        protected override void Draw()
        {
            base.Draw();
            if (!GameRunning) return;

            Scene.Draw(Editor.spriteBatch, _gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _gameTime = gameTime;
            if (!GameRunning) return;

            Scene.Update(gameTime);
        }

        public void StartGame(ContentManager content)
        {
            GameRunning = true;
            var systems = World.GetSystems();
            var systemTypes = systems.ConvertAll(x => x.GetType());
            var newSystemTypes = ReflectiveEnumerator.GetSubTypes<EntitySystem>();
            var notExistingTypes = newSystemTypes.Except(systemTypes).ToList();

            foreach (var system in systems)
            {
                system.Initialize();
                system.LoadContent(content);
            }

            if (notExistingTypes.Any())
            {
                foreach (var type in notExistingTypes)
                {
                    var system = (EntitySystem)Activator.CreateInstance(type);
                    World.AddSystem(system);
                    system.Initialize();
                    system.LoadContent(content);
                }
            }

            // TODO Add entities to correct systems
        }

        public void LoadWorld(World world)
        {
            World = world;
        }

        public void LoadMap(Map map)
        {
            CurrentMap.Initialize(Editor.graphics, World);
            CurrentMap.LoadContent(Editor.Content);
            CurrentMap = map;

        }
    }
}
