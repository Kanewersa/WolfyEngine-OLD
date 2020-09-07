﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Engine;

namespace WolfyCore.Game
{
    [ProtoContract]
    [ProtoInclude(100, typeof(TileLayer))]
    [ProtoInclude(101, typeof(EntityLayer))]
    public abstract class BaseLayer
    {
        [ProtoMember(1)] public string Name { get; set; }
        [ProtoMember(2)] public Vector2D Size { get; set; }
        [ProtoMember(3)] public int Order { get; set; }
        [ProtoIgnore] public Vector2D TileSize => Runtime.TileSize;

        public virtual void Initialize(GraphicsDevice graphics)
        { }

        public virtual void LoadContent(ContentManager content)
        { }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle visibleArea)
        { }

        // TODO Obsolete method
        public virtual void Draw(SpriteBatch spriteBatch)
        { }

        public virtual void Unload()
        { }

        public virtual void Update(GameTime gameTime)
        { }

        public abstract bool? TileOccupied(Vector2 position);

    }
}
