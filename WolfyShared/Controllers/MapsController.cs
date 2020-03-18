using System.Collections.Generic;
using System.IO;
using WolfyEngine.Engine;
using WolfyShared.Game;

namespace WolfyShared.Controllers
{
    public class MapsController
    {
        private static MapsController _instance;
        public static MapsController Instance => _instance ??= new MapsController();

        private string _mapsPath => PathsController.Instance.MapsPath;
        private string _mapsDataPath => PathsController.Instance.MapsDataPath;

        public Dictionary<int, Map> LoadedMaps { get; set; }
        public MapsData MapsData { get; set; }

        public MapsController()
        {
            LoadedMaps = new Dictionary<int, Map>();
        }

        /// <summary>
        /// Loads the maps data for current project
        /// </summary>
        public void InitializeProject()
        {
            MapsData = File.Exists(_mapsDataPath)
                ? Serialization.ProtoDeserialize<MapsData>(_mapsDataPath)
                : new MapsData();
        }

        /// <summary>
        /// Adds given map to the project
        /// </summary>
        /// <param name="map"></param>
        public void AddMap(Map map)
        {
            var info = new MapInfo
            {
                MapName = map.Name,
                MapId = MapsData.GetNextId()
            };
            // TODO Filename should contain extension
            info.FileName = "Map" + info.MapId;
            MapsData.Info.Add(info.MapId, info);
            map.Id = info.MapId;
            LoadedMaps.Add(map.Id, map);
            SaveMap(map);
        }

        /// <summary>
        /// Removes the map with given id
        /// </summary>
        /// <param name="id"></param>
        public void RemoveMap(int id)
        {
            if (LoadedMaps.ContainsKey(id))
                LoadedMaps.Remove(id);

            MapsData.Info.Remove(id);
            MapsData.PendingIds.Enqueue(id);
        }

        /// <summary>
        /// Proto-serializes given map
        /// </summary>
        /// <param name="map"></param>
        public void SaveMap(Map map)
        {
            var file = MapsData.Info[map.Id].FileName;
            var mapPath = Path.Combine(_mapsPath, file);
            Serialization.ProtoSerialize(map, mapPath);
        }

        /// <summary>
        /// Deserializes and returns map with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Map GetMap(int id)
        {
            if (LoadedMaps.ContainsKey(id)) return LoadedMaps[id];

            var file= MapsData.Info[id].FileName;
            var path = Path.Combine(_mapsPath, file);
            var map = Serialization.ProtoDeserialize<Map>(path);
            LoadedMaps.Add(id, map);
            return map;
        }

        /// <summary>
        /// Saves MapsData and all maps
        /// </summary>
        public void Save()
        {
            foreach (var pair in LoadedMaps)
            {
                SaveMap(pair.Value);
            }

            LoadedMaps.Clear();
            Serialization.ProtoSerialize(MapsData, _mapsDataPath);
        }
    }
}
