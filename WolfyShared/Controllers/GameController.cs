using System.IO;
using WolfyEngine.Engine;
using WolfyShared.Game;

namespace WolfyShared.Controllers
{
    class GameController
    {
        private static GameController _instance;
        public static GameController Instance => _instance ??= new GameController();

        public GameSettings Settings { get; set; }

        private string GameSettingsPath => PathsController.Instance.GameSettingsPath;

        public GameController()
        {
            
        }

        /// <summary>
        /// Loads the game settings for current project
        /// </summary>
        public void InitializeProject()
        {
            Settings = File.Exists(GameSettingsPath)
                ? Serialization.XmlDeserialize<GameSettings>(GameSettingsPath)
                : new GameSettings();
        }

    }
}
