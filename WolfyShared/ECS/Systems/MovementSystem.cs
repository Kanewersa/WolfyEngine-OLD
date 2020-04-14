using System.Diagnostics;
using Microsoft.Xna.Framework;
using WolfyECS;

namespace WolfyShared.ECS
{
    public class MovementSystem : EntitySystem
    {
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
                movement.GridPosition += movement.GridDirection;
                movement.Transform += movement.Direction;
                movement.WasMoving = true;
                movement.IsMoving = false; 
            }
        }
    }
}
