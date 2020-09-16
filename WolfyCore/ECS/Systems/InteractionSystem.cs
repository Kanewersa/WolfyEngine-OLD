using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class InteractionSystem : EntitySystem
    {
        public InteractionSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<TransformComponent>();
            RequireComponent<InteractionComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                /*
                 * If there is a dialog going on, speed it up or skip it and return.
                 *
                 * Check if there is an npc on front of entity.
                 * Add action component or handle the interaction the other way.
                 */
            });
        }
    }
}
