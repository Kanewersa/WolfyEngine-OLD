using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    [ProtoContract]
    [ProtoInclude(100, typeof(TileLayer))]
    [ProtoInclude(101, typeof(EntityLayer))]
    public abstract class BaseLayer
    {
        [ProtoMember(1)] public string Name { get; set; }
        [ProtoMember(2)] public Vector2D Size { get; set; }
        [ProtoMember(3)] public int Order { get; set; }

        public virtual void Initialize(GraphicsDevice graphics)
        { }

        public virtual void Draw(SpriteBatch spriteBatch, Rectangle visibleArea)
        { }

        public virtual void Update(GameTime gameTime)
        { }
    }
}
