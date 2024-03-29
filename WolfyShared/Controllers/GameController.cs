﻿using System.IO;
using WolfyECS;
using WolfyEngine;
using WolfyEngine.Engine;
using WolfyShared.Engine;
using WolfyShared.Game;

namespace WolfyShared.Controllers
{
    class GameController
    {
        private static GameController _instance;
        public static GameController Instance => _instance ??= new GameController();

        public GameSettings Settings { get; set; }
        public World World { get; private set; }
        public SerializationHelper SerializationHelper { get; private set; }

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
                : new World();
            World.Initialize();
            WolfyManager.InitializeFamilies();
        }

        public void Save()
        {
            Serialization.ProtoSerialize(Settings, GameSettingsPath);
            Serialization.ProtoSerialize(World, WorldPath);
        }
    }
}
