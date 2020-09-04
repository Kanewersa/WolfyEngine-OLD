/*
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class SFXSystem : EntitySystem
    {
        public ContentManager ContentManager { get; private set; }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<TransformComponent>();
            RequireComponent<SFXComponent>();
        }

        public override void LoadContent(ContentManager content)
        {
            ContentManager = content;
        }

        public override void Update(GameTime gameTime)
        {
            var playerTransform = Entity.Player.GetComponent<TransformComponent>();

            IterateEntities(entity =>
            {
                var transform = entity.GetComponent<TransformComponent>();
                var sfx = entity.GetComponent<SFXComponent>();


            });
        }
    }
}
*/
