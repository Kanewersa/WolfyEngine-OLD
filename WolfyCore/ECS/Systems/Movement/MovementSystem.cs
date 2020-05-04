using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class MovementSystem : EntitySystem
    {
        public MovementSystem() { }

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
