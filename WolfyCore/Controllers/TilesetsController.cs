using System.Collections.Generic;
using System.IO;
using WolfyCore.Game;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class TilesetsController : IController
    {
        private static TilesetsController _instance;
        public static TilesetsController Instance => _instance ??= new TilesetsController();

        private string _tilesetsPath => PathsController.Instance.TilesetsPath;
        private string _tilesetsDataPath => PathsController.Instance.TilesetsDataPath;

        public Dictionary<int, Tileset> LoadedTilesets { get; set; }
        public TilesetsData TilesetsData { get; set; }
        public Tileset LastTileset { get; private set; }

        public TilesetsController()
        {
            LoadedTilesets = new Dictionary<int, Tileset>();
        }

        /// <summary>
        /// Loads the tilesets data for current project
        /// </summary>
        public void InitializeProject()
        {
            TilesetsData = File.Exists(_tilesetsDataPath)
                ? Serialization.ProtoDeserialize<TilesetsData>(_tilesetsDataPath)
                : new TilesetsData();
        }

        /// <summary>
        /// Deserializes and sets the tilesets for given map
        /// </summary>
        /// <param name="map"></param>
        public void LoadMap(Map map)
        {
            foreach (var layer in map.Layers)
            {
                if (layer is TileLayer lay)
                {
                    lay.Tileset = GetTileset(lay.TilesetId);
                }
            }
        }

        /// <summary>
        /// Adds given tileset to the project
        /// </summary>
        /// <param name="tileset"></param>
        /// <returns></returns>
        public void AddTileset(Tileset tileset)
        {
            var info = new TilesetInfo
            {
                TilesetName = tileset.Name,
                TilesetId = TilesetsData.GetNextId(),
                GraphicsPath = tileset.Image.Path
            };

            info.FileName = "Tileset" + info.TilesetId;
            TilesetsData.Info.Add(info.TilesetId, info);
            tileset.Id = info.TilesetId;
            LoadedTilesets.Add(tileset.Id, tileset);
            LastTileset = tileset;
            SaveTileset(tileset);
        }

        /// <summary>
        /// Removes the tileset with given id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveTileset(int id)
        {
            if (LoadedTilesets.ContainsKey(id))
                LoadedTilesets.Remove(id);
            if (LastTileset.Id == id)
                LastTileset = null;

            TilesetsData.Info.Remove(id);
            TilesetsData.PendingIds.Enqueue(id);
        }

        /// <summary>
        /// Proto-serializes given tileset
        /// </summary>
        /// <param name="tileset"></param>
        public void SaveTileset(Tileset tileset)
        {
            var file = TilesetsData.Info[tileset.Id].FileName;
            var tilesetPath = Path.Combine(_tilesetsPath, file);
            Serialization.ProtoSerialize(tileset, tilesetPath);
        }

        /// <summary>
        /// Deserializes and returns tileset with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tileset GetTileset(int id)
        {
            if (LoadedTilesets.ContainsKey(id))
            {
                LastTileset = LoadedTilesets[id];
                return LastTileset;
            }

            var file = TilesetsData.Info[id].FileName;
            var path = Path.Combine(_tilesetsPath, file);
            var tileset = Serialization.ProtoDeserialize<Tileset>(path);
            LoadedTilesets.Add(id, tileset);
            LastTileset = tileset;
            return tileset;
        }

        /// <summary>
        /// Saves TilesetsData and all tilesets
        /// </summary>
        public void SaveData()
        {
            foreach (var pair in LoadedTilesets)
            {
                SaveTileset(pair.Value);
            }

            LoadedTilesets.Clear();
            if(LastTileset != null)
                LoadedTilesets.Add(LastTileset.Id, LastTileset);
            Serialization.ProtoSerialize(TilesetsData, _tilesetsDataPath);
        }
    }
}
