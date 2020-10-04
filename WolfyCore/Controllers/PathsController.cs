using System.IO;

namespace WolfyCore.Controllers
{
    public class PathsController
    {
        private static PathsController _instance;
        public static PathsController Instance => _instance ??= new PathsController();

        private string _mainPath;
        public string MainPath
        {
            get => _mainPath;
            private set
            {
                _mainPath = value;
                AudioPath = Path.Combine(MainPath, "Audio");
                DataPath = Path.Combine(MainPath, "Data");
                FontsPath = Path.Combine(MainPath, "Fonts");
                GraphicsPath = Path.Combine(MainPath, "Graphics");
                SpritesPath = Path.Combine(GraphicsPath, "Sprites");
                AutoTilesPath = Path.Combine(GraphicsPath, "Autotiles");
                TilesetsGraphicsPath = Path.Combine(GraphicsPath, "Tilesets");
                MapsPath = Path.Combine(DataPath, "Maps");
                MapsDataPath = Path.Combine(MapsPath, "MapsData.wolf");
                TilesetsPath = Path.Combine(DataPath, "Tilesets");
                TilesetsDataPath = Path.Combine(TilesetsPath, "TilesetsData.wolf");
                EntityDataPath = Path.Combine(DataPath, "EntityData.wolf");
                InventoryDataPath = Path.Combine(DataPath, "Inventories.wolf");
                VariablesDataPath = Path.Combine(DataPath, "Variables.wolf");
                    
                BgmPath = Path.Combine(AudioPath, "Bgm");
                SfxPath = Path.Combine(AudioPath, "Sfx");

                GameSettingsPath = Path.Combine(DataPath, "GameData.wolf");
                WorldPath = Path.Combine(DataPath, "Worlds.wolf");
                SerializationHelperPath = Path.Combine(DataPath, "Serialization.wolf");

                /*ContentWorkingPath = Path.Combine(GraphicsPath, "working");
                ContentIntermediatePath = Path.Combine(ContentWorkingPath, "inter");
                ContentOutputPath = Path.Combine(ContentWorkingPath, "output");*/
            }
        }

        // Main folders
        public string AudioPath { get; private set; }
        public string BgmPath { get; private set; }
        public string SfxPath { get; private set; }
        public string DataPath { get; private set; }
        public string FontsPath { get; private set; }
        public string GraphicsPath { get; private set; }

        // Graphics folders
        public string SpritesPath { get; private set; }
        public string AutoTilesPath { get; private set; }
        public string TilesetsGraphicsPath { get; private set; }

        // Data folders
        public string MapsPath { get; private set; }
        public string MapsDataPath { get; private set; }
        public string TilesetsPath { get; private set; }
        public string TilesetsDataPath { get; private set; }
        public string EntityDataPath { get; private set; }
        public string InventoryDataPath { get; private set; }
        public string VariablesDataPath { get; private set; }

        public string GameSettingsPath { get; private set; }
        public string WorldPath { get; private set; }
        public string SerializationHelperPath { get; private set; }

        // Content manager paths
        /*public string ContentWorkingPath { get; private set; }
        public string ContentIntermediatePath { get; private set; }
        public string ContentOutputPath { get; private set; }*/

        public void SetMainPath(string path)
        {
            MainPath = path;
        }
    }
}
