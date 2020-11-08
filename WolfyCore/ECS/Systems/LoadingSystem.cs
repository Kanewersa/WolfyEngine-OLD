using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class LoadingSystem : EntitySystem
    {
        // TODO: Move update distance to settings.
        private const int UpdateDistance = 999;

        private GraphicsDevice GraphicsDevice { get; set; }
        private ContentManager ContentManager { get; set; }
        private List<int> LoadedMaps { get; set; }

        public override void Initialize(GraphicsDevice graphics)
        {
            GraphicsDevice = graphics;
            RequireComponent<LoadMapComponent>();

            LoadedMaps ??= new List<int>();
        }
        
        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var loadInfo = entity.GetComponent<LoadMapComponent>();

                Map map = MapsController.Instance.GetMap(loadInfo.MapId);
                List<int> mapsIds = new List<int> { loadInfo.MapId };
                GetNeighboringMaps(mapsIds, map, UpdateDistance);

                // Unload old maps
                foreach (var mapId in LoadedMaps.Except(mapsIds))
                {
                    MapsController.Instance.DisposeMap(mapId);
                }

                map.Initialize(GraphicsDevice);
                map.LoadContent(ContentManager);
                map.ActivateEntities();

                var bgm = entity.AddComponent<BGMComponent>();

                if (map.BackgroundMusic != null)
                {
                    bgm.Sound = map.BackgroundMusic;
                    bgm.IsRepeating = true;
                }

                // Load new maps
                foreach (var mapId in mapsIds.Except(LoadedMaps))
                {
                    map = MapsController.Instance.GetMap(mapId);
                    map.Initialize(GraphicsDevice);
                    //map.LoadContent(ContentManager);
                    map.ActivateEntities();
                }

                LoadedMaps = mapsIds;
                entity.RemoveComponent<LoadMapComponent>();
            });
        }

        private static void GetNeighboringMaps(ICollection<int> neighbors, Map map, int range)
        {
            if (range == 0) return;
            if (map.Neighbors == null) return;

            foreach (int neighbor in map.Neighbors.Values.Except(neighbors))
            {
                neighbors.Add(neighbor);
                GetNeighboringMaps(neighbors, MapsController.Instance.GetMap(neighbor), --range);
            }
        }
    }
}

