using System.IO;
using WolfyCore.ECS;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class GameController
    {
        private static GameController _instance;
        public static GameController Instance => _instance ??= new GameController();

        public World World { get; set; }
        public GameSettings Settings { get; set; }

        private string GameSettingsPath => PathsController.Instance.GameSettingsPath;
        private string WorldPath => PathsController.Instance.WorldPath;

        public GameController()
        { }

        /// <summary>
        /// Loads the game world and settings for current project
        /// </summary>
        public void InitializeProject()
        {
            Settings = File.Exists(GameSettingsPath)
                ? Serialization.ProtoDeserialize<GameSettings>(GameSettingsPath)
                : new GameSettings();
                
            World = File.Exists(WorldPath)
                ? Serialization.ProtoDeserialize<World>(WorldPath)
                : CreateNewWorld();

            World.SetWorld(World);
            World.Initialize(WolfyManager.ComponentTypes);
            WolfyManager.InitializeFamilies();
        }

        private World CreateNewWorld()
        {
            var world = new World();

            CreatePlayer(world);
            
            return world;
        }

        private Entity CreatePlayer(World world)
        {
            var player = world.CreateEntity();
            var name = player.AddComponent<NameComponent>();
            name.Name = "Player";
            return player;
        }

        public void Save()
        {
            Serialization.ProtoSerialize(Settings, GameSettingsPath);
            Serialization.ProtoSerialize(World.WorldInstance, WorldPath);
        }
    }
}
