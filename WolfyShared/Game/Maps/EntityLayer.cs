﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    [ProtoContract] public class EntityLayer : BaseLayer
    {
        [ProtoMember(1)] public Vector2D TileSize { get; set; }
        [ProtoMember(2)] public List<EntityTileRow> Rows { get; set; }

        public List<Entity> Entities { get; set; } = new List<Entity>();

        public EntityLayer() { }

        public EntityLayer(string name, Vector2D mapSize)
        {
            Name = name;
            Rows = new List<EntityTileRow>();
            Size = mapSize;
            for (var i = 0; i < mapSize.Y; i++)
            {
                Rows.Add(new EntityTileRow(mapSize.X));
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Rectangle visibleArea)
        {
            Entities.ForEach(x => x.Draw(spriteBatch));
        }
        public override void Update(GameTime gameTime)
        {
            Entities.ForEach(x => x.Update(gameTime));
        }
    }
}
