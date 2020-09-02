using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WolfyCore.Controllers;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    public class LoadingSystem : EntitySystem
    {
        private const int UpdateDistance = 2;

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<LoadMapComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var loadInfo = entity.GetComponent<LoadMapComponent>();

                Map map = MapsController.Instance.GetMap(loadInfo.MapId);

                List<int> mapsIds = new List<int>();
                GetNeighboringMaps(mapsIds, map, UpdateDistance);
            });
        }

        private void GetNeighboringMaps(List<int> neighbors, Map map, int range)
        {
            if (range == 0)
                return;

            /*foreach (int neighbor in map.Neighbors)
            {
                if (!neighbors.Contains(neighbor))
                {
                    neighbors.Add(neighbor);
                    GetNeighboringMaps(neighbors, MapsController.Instance.GetMap(neighbor), --range);
                }
            }*/
        }
    }
}
