using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    [ProtoContract] public class Entity
    {
        [ProtoMember(1)] public int Id { get; set; }
        [ProtoMember(2)] public string Name { get; set; }
        [ProtoMember(3)] public Image Image { get; set; }

        public void Initialize(GraphicsDevice graphics)
        {
            Image.Initialize(graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
