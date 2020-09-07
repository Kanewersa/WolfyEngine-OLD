using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WolfyCore.Controllers;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    public class LoadingSystem : EntitySystem
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
        }
        
        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var loadInfo = entity.GetComponent<LoadMapComponent>();

                Map map = MapsController.Instance.GetMap(loadInfo.MapId);

                List<int> mapsIds = new List<int> { loadInfo.MapId };

                GetNeighboringMaps(mapsIds, map, UpdateDistance);

                map.Initialize(GraphicsDevice);
                map.LoadContent(ContentManager);
                // TODO: Unload maps that are too far.

                // Load new maps
                foreach (var mapId in mapsIds.Except(LoadedMaps))
                {
                    map = MapsController.Instance.GetMap(mapId);
                    map.Initialize(GraphicsDevice);
                    map.LoadContent(ContentManager);
                }

                // Unload old maps
                foreach (var mapId in LoadedMaps.Except(mapsIds))
                {
                    MapsController.Instance.DisposeMap(mapId);
                }

                LoadedMaps = mapsIds;
                entity.RemoveComponent<LoadMapComponent>();
            });
        }

        private static void GetNeighboringMaps(ICollection<int> neighbors, Map map, int range)
        {
            if (range == 0)
                return;

            foreach (int neighbor in map.Neighbors.Except(neighbors))
            {
                neighbors.Add(neighbor);
                GetNeighboringMaps(neighbors, MapsController.Instance.GetMap(neighbor), --range);
            }
        }
    }
}

