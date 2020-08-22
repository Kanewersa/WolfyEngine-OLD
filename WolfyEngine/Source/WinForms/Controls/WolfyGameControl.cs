using System;
using System.Linq;
using System.Windows.Forms;
using GeonBit.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using WolfyECS;
using WolfyEngine.Utils;
using WolfyCore.Game;
using WolfyCore.Scenes;
using Entity = GeonBit.UI.Entities.Entity;

namespace WolfyEngine.Controls
{
    public partial class WolfyGameControl : MonoGameControl
    {
        public GameScene Scene { get; set; }
        public Selector Selector { get; }
        public Map CurrentMap { get; private set; }
        public World World { get; private set; }

        private GameTime _gameTime;

        public bool Paused { get; set; }

        public WolfyGameControl()
        {
            Selector = new Selector();
        }

        public void InitializeScene()
        {
            Scene = new GameScene(World);
            //Scene.SetMap(CurrentMap);
            Scene.Initialize(GraphicsDevice);
            Scene.LoadContent(Editor.Content);

            MouseHoverUpdatesOnly = false;
            AlwaysEnableKeyboardInput = true;
        }

        public void UnloadScene()
        {
            Scene = null;
        }

        public void UnloadGui()
        {
            UserInterface.Active = null;
        }

        public void InitializeGui()
        {
            UserInterface.Initialize(Editor.Content, BuiltinThemes.hd);
            // TODO: Create gui layout here!
        }

        protected override void Initialize()
        {
            base.Initialize();
            Selector.Initialize(GraphicsDevice);
            LoadContent(Editor.Content);
        }

        protected void LoadContent(ContentManager content)
        {
            Selector.LoadContent(content);
        }

        protected override void Draw()
        {
            base.Draw();
            GraphicsDevice.Clear(Color.Black);

            Scene.Draw(Editor.spriteBatch, _gameTime);

            // Draw the gui
            if (UserInterface.Active != null)
            {
                UserInterface.Active.Draw(Editor.spriteBatch);
                UserInterface.Active.DrawCursor(Editor.spriteBatch);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (UserInterface.Active != null)
            {
                UserInterface.Active.Update(gameTime);
                UserInterface.Active.MouseInputProvider.Update(gameTime);

                var positionDiff = new Point(PointToScreen(Location).X - Location.X, PointToScreen(Location).Y - Location.Y);
                UserInterface.Active.MouseInputProvider.UpdateMousePosition(new Vector2(MousePosition.X - positionDiff.X,
                                                                                        MousePosition.Y - positionDiff.Y));
                // TODO: Update gui here!
            }


            Focus();
            _gameTime = gameTime;
            if (Paused) return;
            Scene.Update(gameTime);
            
        }

        public void StartGame(ContentManager content)
        {
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
            CurrentMap = map;
            CurrentMap.Initialize(Editor.graphics, World);
            CurrentMap.LoadContent(Editor.Content);
        }
    }
}
