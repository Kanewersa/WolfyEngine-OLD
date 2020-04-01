using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using WolfyECS;
using WolfyShared.Engine;
using WolfyShared.Game;

namespace WolfyShared.ECS
{
    public class CollisionSystem : EntitySystem
    {
        public Map CurrentMap { get; private set; }

        public void SetMap(Map map) { CurrentMap = map; }

        private bool CanPass(TileLayer layer, Vector2 position)
        {
            return layer.Rows[(int)position.Y].Tiles[(int)position.X].Passage;
        }

        private bool CanPass(EntityLayer layer, Vector2 position)
        {
            if (position.X < 0 || position.Y < 0) return false;
            return true;
            //return layer.Rows[(int) position.Y].Tiles[(int) position.X].Entity == null;
        }

        private bool CanPassLayer(BaseLayer layer, Vector2 position)
        {
            return layer switch
            {
                TileLayer til => CanPass(til, position),
                EntityLayer ent => CanPass(ent, position),
                _ => throw new Exception("Unknown layer type.")
            };
        }
        
        public override void Initialize()
        {
            RequireComponent<MovementComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                var movement = entity.GetComponent<MovementComponent>();
                
                if (!movement.IsMoving) continue;
                
                // Check collision
                var position = movement.GridPosition;
                position += movement.GridDirection;
                if (   position.X < 0 
                       || position.Y < 0
                       || position.X >= CurrentMap.Size.X
                       || position.Y >= CurrentMap.Size.Y)
                {
                    movement.IsMoving = false;
                    continue;
                }

                movement.IsMoving = CurrentMap.Layers.All(
                    layer => CanPassLayer(layer, position));

                if (!movement.IsMoving) continue;

                foreach(var collisionEntity in Entities)
                {
                    if (entity == collisionEntity) continue;
                    var comp = collisionEntity.GetComponent<MovementComponent>();
                    if(position == comp.GridPosition)
                    {
                        movement.IsMoving = false;
                        break;
                    }
                }
            }
        }
    }
}
