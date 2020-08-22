using System;
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
            Rows = new List<EntityTileRow>(mapSize.Y);
            Size = mapSize;
            Entities = new List<Entity>();
            for (var i = 0; i < mapSize.Y; i++)
            {
                Rows.Add(new EntityTileRow(mapSize.X));
            }
        }

        public override void Initialize(GraphicsDevice graphics)
        {
            if(Entities == null) Entities = new List<Entity>();

            Rows = new List<EntityTileRow>(Size.Y);
            for (var i = 0; i < Size.Y; i++)
            {
                Rows.Add(new EntityTileRow(Size.X));
            }

            foreach (var entity in Entities)
            {
                var transform = entity.GetComponent<TransformComponent>().GridTransform;
                Rows[(int)transform.Y].Tiles[(int)transform.X].Entity = entity;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle visibleArea)
        {
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
            for (var y = 0; y < Size.Y; y++)
            {
                for (var x = 0; x < Size.X; x++)
                {
                    var entity = Rows[y].Tiles[x].Entity;
                    if (entity == Entity.Empty)
                        continue;

                    // TODO Draw entities in editor.
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override bool? TileOccupied(Vector2 position)
        {
            return Rows[(int) position.Y].Tiles[(int) position.X].Entity != Entity.Empty ? (bool?) null : false;
        }

        /// <summary>
        /// Returns the entity at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Entity GetEntity(Vector2 position)
        {
            return Rows[(int) position.Y].Tiles[(int) position.X].Entity;
        }
    }
}
