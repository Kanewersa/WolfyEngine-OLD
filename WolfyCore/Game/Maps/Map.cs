using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.Game
{
    [ProtoContract] public class Map
    {
        [ProtoMember(1)] public int Id { get; set; }
        [ProtoMember(2)] public string Name { get; set; }
        [ProtoIgnore] public Vector2D TileSize => Runtime.TileSize;
        [ProtoMember(4)] public Vector2D Size { get; set; }
        [ProtoMember(5)] public List<BaseLayer> Layers { get; set; } = new List<BaseLayer>();
        [ProtoMember(6)] public EntityLayer EntityLayer { get; set; }
        [ProtoIgnore] public List<Entity> Entities => EntityLayer.Entities;
        [ProtoIgnore] private readonly int DrawOffset = 2;

        public Map() { }

        public Map(string name, Vector2D mapSize)
        {
            Name = name;
            Size = mapSize;
            EntityLayer = new EntityLayer("Entities layer", mapSize) { Order = 1 };
            Layers = new List<BaseLayer> { EntityLayer };
        }

        public void Initialize(GraphicsDevice graphics, World world)
        {
            EntityLayer = Layers.First(x => x is EntityLayer) as EntityLayer;

            foreach (var layer in Layers)
            {
                layer.Initialize(graphics);
            }
        }

        public void LoadContent(ContentManager content)
        {
            foreach (var layer in Layers)
            {
                layer.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle visibleArea)
        {
            var startX = visibleArea.X / TileSize.X;
            var startY = visibleArea.Y / TileSize.Y;

            var endX = visibleArea.Width / TileSize.X + startX + DrawOffset;
            var endY = visibleArea.Height / TileSize.Y + startY + DrawOffset;

            if (endX + DrawOffset > Size.X)
                endX = Size.X;
            if (endY + DrawOffset > Size.Y)
                endY = Size.Y;

            var visibleTiles = new Rectangle(startX, startY, endX, endY);
            Layers.ForEach(layer => layer.Draw(spriteBatch, gameTime, visibleTiles));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Layers.ForEach(layer => layer.Draw(spriteBatch));
        }

        public void Update(GameTime gameTime)
        {
            Layers.ForEach(layer => layer.Update(gameTime));
        }

        /// <summary>
        /// Returns true if any layer is occupied at given position or
        /// position is beyond map borders.
        /// </summary>
        /// <param name="position"></param>
        public bool? Occupied(Vector2 position)
        {
            if (position.X < 0
                || position.Y < 0
                || position.X >= Size.X
                || position.Y >= Size.Y)
                return true;

            foreach (var layer in Layers)
            {
                if (layer.TileOccupied(position) == true)
                    return true;
                if (layer.TileOccupied(position) == null)
                    return null;
            }

            return false;
        }

        /// <summary>
        /// Returns the entity at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Entity GetEntity(Vector2 position)
        {
            foreach (var layer in Layers)
            {
                if (layer is EntityLayer entityLayer)
                {
                    return entityLayer.GetEntity(position);
                }
            }

            return Entity.Empty;
        }

        /// <summary>
        /// Moves given entity to new position on the map.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="oldPosition"></param>
        /// <param name="newPosition"></param>
        public void MoveEntity(Entity e, Vector2 oldPosition, Vector2 newPosition)
        {
            var layer = (EntityLayer) Layers.FirstOrDefault(x => x is EntityLayer);
            if(layer == null)
                throw new NullReferenceException("Entity layer was null.");

            layer.Rows[(int) oldPosition.Y].Tiles[(int) oldPosition.X].Entity = Entity.Empty;
            
            if (newPosition != -Vector2.One)
                layer.Rows[(int) newPosition.Y].Tiles[(int) newPosition.X].Entity = e;
        }
    }
}
