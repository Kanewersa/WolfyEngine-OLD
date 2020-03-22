using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    [ProtoContract] public class Map
    {
        [ProtoMember(1)] public int Id { get; set; }
        [ProtoMember(2)] public string Name { get; set; }
        [ProtoMember(3)] public Vector2D TileSize { get; set; }
        [ProtoMember(4)] public Vector2D Size { get; set; }
        [ProtoMember(5)] public List<BaseLayer> Layers { get; set; } = new List<BaseLayer>();

        public Map() { }

        public Map(string name, Vector2D mapSize, Vector2D tileSize)
        {
            Name = name;
            Size = mapSize;
            TileSize = tileSize;
            Layers = new List<BaseLayer>
            {
                new EntityLayer("Entities layer", mapSize) { Order = 1 }
            };

        }

        public void Initialize(GraphicsDevice graphics)
        {
            foreach (var layer in Layers)
            {
                layer.Initialize(graphics);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle visibleArea)
        {
            var startX = visibleArea.X / TileSize.X;
            var startY = visibleArea.Y / TileSize.Y;
            var endX = visibleArea.Width / TileSize.X + startX;
            var endY = visibleArea.Height / TileSize.Y + startY;

            var visibleTiles = new Rectangle(startX, startY, endX, endY);

            Layers.ForEach(layer => layer.Draw(spriteBatch, visibleTiles));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Layers.ForEach(layer => layer.Draw(spriteBatch));
        }

        public void Update(GameTime gameTime)
        {
            Layers.ForEach(layer => layer.Update(gameTime));
        }
    }
}
