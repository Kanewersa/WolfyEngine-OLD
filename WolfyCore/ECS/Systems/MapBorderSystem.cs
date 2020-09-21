using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract]
    public class MapBorderSystem : EntitySystem
    {
        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<MapBorderComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {

            });
        }
    }
}