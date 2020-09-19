using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Priority_Queue;
using WolfyCore.Game;

namespace WolfyCore.Engine
{
    public static class WolfyStar
    {
        // TODO: Optimize pathfinding by using FastPriorityQueue
        /// <summary>
        /// Returns the shortest path from goal to start on given map.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static List<Vector2> GetPath(Vector2 start, Vector2 goal, Map map)
        {
            Vector2 current;
            var collisionMap = new CollisionMap(map);

            var frontier = new SimplePriorityQueue<Vector2>();
            frontier.Enqueue(start, 0);

            var cameFrom = new Dictionary<Vector2, Vector2>
            {
                [start] = -Vector2.One
            };
            var costSoFar = new Dictionary<Vector2, int>
            {
                {start, 0}
            };

            while (frontier.Count > 0)
            {
                current = frontier.Dequeue();
                if (current == goal) break;
                
                foreach (var next in collisionMap.Neighbors(current))
                {
                    var newCost = costSoFar[current] + 1;

                    if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        var priority = newCost + Vector2.Distance(goal, next);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }

            current = goal;
            var path = new List<Vector2>();

            if (!cameFrom.ContainsKey(current))
            {
                path.Add(start);
                return path;
            }

            while (current != start)
            {
                path.Add(current);
                current = cameFrom[current];
            }
            path.Add(start);

            return path;
        }
    }
}
