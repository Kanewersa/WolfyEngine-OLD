using System;
using System.Linq;
using Microsoft.Xna.Framework;
using WolfyShared.Game;

namespace WolfyShared.Controllers
{
    public class MovementController
    {
        public bool CanPass(TileLayer layer, Vector2 position)
        {
            return layer.Rows[(int)position.Y].Tiles[(int)position.X].Passage;
        }

        public bool CanPass(EntityLayer layer, Vector2 position)
        {
            if (position.X < 0 || position.Y < 0) return false;
            return layer.Rows[(int) position.Y].Tiles[(int) position.X].Entity == null;
        }

        private bool CanPass(BaseLayer layer, Vector2 position)
        {
            return layer switch
            {
                TileLayer til => CanPass(til, position),
                EntityLayer ent => CanPass(ent, position),
                _ => throw new Exception("Unknown layer type.")
            };
        }

        public bool CanPass(Map map, Vector2 position)
        {
            if (   position.X < 0
                || position.Y < 0
                || position.X/map.TileSize.X > map.Size.X
                || position.Y/map.TileSize.Y > map.Size.Y) return false;

            return map.Layers.All(layer => CanPass(layer, position));
        }

        public void SetMovement(Player player)
        {

        }
    }
}
