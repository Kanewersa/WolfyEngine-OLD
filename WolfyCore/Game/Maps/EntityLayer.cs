﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.Game
{
    [ProtoContract] public class EntityLayer : BaseLayer
    {
        [ProtoMember(2)] public List<EntityTileRow> Rows { get; set; }
        [ProtoMember(3)] public List<Entity> Entities { get; set; }
        public EntityLayer() { }

        public EntityLayer(string name, Vector2D mapSize)
        {
            Name = name;
            Rows = new List<EntityTileRow>();
            Size = mapSize;
            Entities = new List<Entity>();
            for (var i = 0; i < mapSize.Y; i++)
            {
                Rows.Add(new EntityTileRow(mapSize.X));
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle visibleArea)
        {
            Console.WriteLine("Drawing entity layer...");
            for (var y = visibleArea.Y; y < visibleArea.Height; y++)
            {
                for (var x = visibleArea.X; x < visibleArea.Width; x++)
                {
                    var entity = Rows[y].Tiles[x].Entity;
                    if (entity == Entity.Empty)
                        continue;

                    if (entity.GetIfHasComponent(out AnimationComponent animation))
                    {
                        animation.Draw(spriteBatch);
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override bool TileOccupied(Vector2 position)
        {
            return Rows[(int) position.Y].Tiles[(int) position.X].Entity != new Entity();
        }
    }
}
