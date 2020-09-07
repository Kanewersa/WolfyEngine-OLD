using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.Game
{
    [ProtoContract] public class Map
    {
        /// <summary>
        /// Unique id of the map.
        /// </summary>
        [ProtoMember(1)] public int Id { get; set; }

        /// <summary>
        /// In-game name of the map.
        /// </summary>
        [ProtoMember(2)] public string Name { get; set; }

        [ProtoMember(3)] public List<int> Neighbors { get; set; }

        /// <summary>
        /// Size of the map.
        /// </summary>
        [ProtoMember(4)] public Vector2D Size { get; set; }

        // TODO: ! Important ! Determine if more than one EntityLayer is allowed in Map instance.
        [ProtoMember(5)] public List<BaseLayer> Layers { get; set; } = new List<BaseLayer>();
        [ProtoMember(6)] public EntityLayer EntityLayer { get; set; }

        [ProtoIgnore] private readonly int DrawOffset = 2;

        [ProtoIgnore] public Vector2D TileSize => Runtime.TileSize;
        [ProtoIgnore] public bool Initialized { get; private set; }

        public Map() { }

        public Map(string name, Vector2D mapSize)
        {
            Name = name;
            Size = mapSize;
            EntityLayer = new EntityLayer("Entities layer", mapSize) { Order = 1 };
            Layers = new List<BaseLayer> { EntityLayer };
        }

        public void Initialize(GraphicsDevice graphics)
        {
            ((EntityLayer)Layers.First(x => x is EntityLayer))
                .LoadEntities(EntityController.GetEntities(Id));

            foreach (var layer in Layers)
            {
                layer.Initialize(graphics);
            }

            Initialized = true;
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

        /// <summary>
        /// Unloads the map layers.
        /// </summary>
        public void Unload()
        {
            Layers.ForEach(layer => layer.Unload());
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

        public void AddEntity(Entity e, Vector2 position)
        {
            var layer = (EntityLayer)Layers.First(x => x is EntityLayer);
            layer.AddEntity(e, position);
        }

        /// <summary>
        /// Moves given entity to new position on the map.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="oldPosition"></param>
        /// <param name="newPosition"></param>
        public void MoveEntity(Entity e, Vector2 oldPosition, Vector2 newPosition)
        {
            var layer = (EntityLayer) Layers.First(x => x is EntityLayer);

            layer.SetEntity(oldPosition, Entity.Empty);
            
            if (newPosition != -Vector2.One)
                layer.SetEntity(newPosition, e);
        }

        public void RemoveEntity(Vector2 position)
        {
            var e = ((EntityLayer)Layers.FirstOrDefault(x => x is EntityLayer))?.RemoveEntity(position) ?? Entity.Empty;
        }
    }
}
