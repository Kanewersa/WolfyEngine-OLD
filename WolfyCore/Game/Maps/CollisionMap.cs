using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WolfyCore.Game
{
    public class CollisionMap
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Map Map { get; set; }

        public CollisionMap(Map map)
        {
            Width = map.Size.X;
            Height = map.Size.Y;
            Map = map;
        }

        public IEnumerable<Vector2> Neighbors(Vector2 position)
        {
            List<Vector2> neighbors = new List<Vector2>
            {
                position + new Vector2(1, 0),
                position + new Vector2(-1, 0),
                position + new Vector2(0, 1),
                position + new Vector2(0, -1)
            };

            for (var i = 0; i < neighbors.Count; i++)
            {
                if (Map.Occupied(neighbors[i]) != false)
                {
                    neighbors.RemoveAt(i);
                    i--;
                }
            }

            return neighbors;
        }
    }
}
