using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using WolfyECS;
using WolfyEngine.Utils;
using WolfyShared;
using WolfyShared.Game;

namespace WolfyEngine.Controls
{
    public partial class WolfyGameControl : MonoGameControl
    {
        public Selector Selector { get; }
        public Map CurrentMap { get; private set; }
        public World World { get; private set; }
        public Camera Camera { get; private set; }

        public bool GameRunning { get; set; }

        public WolfyGameControl()
        {
            Selector = new Selector((float)Runtime.GridSize/48);
        }

        protected override void Initialize()
        {
            base.Initialize();

            Camera = new Camera()
            {
                ScreenWidth = Width,
                ScreenHeight = Height
            };

            Camera.SetMapBoundaries(new Vector2(
                CurrentMap.Size.X * Runtime.GridSize,
                CurrentMap.Size.Y * Runtime.GridSize));

            Selector.Initialize(Editor.graphics);
        }

        protected void LoadContent(ContentManager content)
        {
            Selector.LoadContent(content);
        }

        protected override void Draw()
        {
            base.Draw();
            if (!GameRunning) return;

            Editor.spriteBatch.Begin(transformMatrix: Camera.Transform, samplerState: SamplerState.PointClamp);

            if (Paused)
            {
                // TODO Do nothing
            }
            else
            {
                CurrentMap.Draw(Editor.spriteBatch);
                //AnimationSystem.Draw(_gameTime, Editor.spriteBatch);
            }

            Editor.spriteBatch.End();
        }

        private GameTime _gameTime;

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _gameTime = gameTime;
            if (!GameRunning) return;

            World.Update(gameTime);
            CurrentMap.Update(gameTime);
            Camera.Update();
            VisibleArea = Camera.GetVisibleArea();
        }

        public void StartGame(ContentManager content)
        {
            GameRunning = true;
            var systems = World.GetSystems();
            var systemTypes = systems.ConvertAll(x => x.GetType());
            var newSystemTypes = ReflectiveEnumerator.GetSubTypes<EntitySystem>();
            var notExistingTypes = newSystemTypes.Except(systemTypes).ToList();

            if (notExistingTypes.Any())
            {
                foreach (var type in notExistingTypes)
                {
                    var system = (EntitySystem)Activator.CreateInstance(type);
                    World.AddSystem(system);
                }
            }

            foreach (var system in systems)
            {
                system.Initialize();
                system.LoadContent(content);
            }

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
