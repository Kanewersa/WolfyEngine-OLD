using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class MapsController
    {
        private static MapsController _instance;
        public static MapsController Instance => _instance ??= new MapsController();

        private string MapsPath => PathsController.Instance.MapsPath;
        private string MapsDataPath => PathsController.Instance.MapsDataPath;

        public Dictionary<int, Map> LoadedMaps { get; set; }
        public MapsData MapsData { get; set; }
        public Map LastMap { get; private set; }

        public MapsController()
        {
            LoadedMaps = new Dictionary<int, Map>();
        }

        /// <summary>
        /// Loads the maps data for current project.
        /// </summary>
        public void InitializeProject(bool empty)
        {
            if (empty) return;

            MapsData = File.Exists(MapsDataPath)
                ? Serialization.ProtoDeserialize<MapsData>(MapsDataPath)
                : new MapsData();
        }

        /// <summary>
        /// Adds given map to the project.
        /// </summary>
        /// <param name="map"></param>
        public void AddMap(Map map)
        {
            var info = new MapInfo
            {
                MapName = map.Name,
                MapId = MapsData.GetNextId()
            };
            info.FileName = "Map" + info.MapId + ".wolf";
            MapsData.AddMap(info.MapId, info);
            map.Id = info.MapId;
            LoadedMaps.Add(map.Id, map);
            LastMap = map;
            SaveMap(map);
        }

        /// <summary>
        /// Removes the map with given id.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveMap(int id)
        {
            if (LoadedMaps.ContainsKey(id))
                LoadedMaps.Remove(id);

            if (LastMap.Id == id)
                LastMap = null;

            MapsData.RemoveMap(id);
            MapsData.PendingIds.Enqueue(id);
        }

        /// <summary>
        /// Disposes the map with given id.
        /// </summary>
        /// <param name="id"></param>
        public void DisposeMap(int id)
        {
            if (LoadedMaps.ContainsKey(id))
            {
                LoadedMaps[id].Unload();
                LoadedMaps.Remove(id);
            }
        }

        /// <summary>
        /// Proto-serializes the given map.
        /// </summary>
        /// <param name="map"></param>
        public void SaveMap(Map map)
        {
            var file = MapsData.GetFileName(map.Id);
            var mapPath = Path.Combine(MapsPath, file);
            Serialization.ProtoSerialize(map, mapPath);
        }

        /// <summary>
        /// Deserializes and returns map with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Map GetMap(int id)
        {
            if (LoadedMaps.ContainsKey(id))
            {
                LastMap = LoadedMaps[id];
                return LastMap;
            }
            var file = MapsData.GetFileName(id);
            var path = Path.Combine(MapsPath, file);
            var map = Serialization.ProtoDeserialize<Map>(path);
            LoadedMaps.Add(id, map);
            LastMap = map;
            return map;
        }

        /// <summary>
        /// Gets the name of map.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMapName(int id)
        {
            return MapsData.GetMapName(id);
        }

        public Dictionary<int, MapInfo> GetMapsInfo()
        {
            return MapsData.GetMapsInfo();
        }

        /// <summary>
        /// Saves MapsData and all loaded maps.
        /// </summary>
        public void Save()
        {
            foreach (var pair in LoadedMaps)
            {
                SaveMap(pair.Value);
            }

            LoadedMaps.Clear();
            if (LastMap != null)
                LoadedMaps.Add(LastMap.Id, LastMap);
            Serialization.ProtoSerialize(MapsData, MapsDataPath);
        }
    }
}
