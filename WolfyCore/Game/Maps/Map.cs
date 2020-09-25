using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.Game
{
    /// <summary>
    /// In-game map.
    /// </summary>
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

        /// <summary>
        /// Stores positions of map borders.
        /// </summary>
        [ProtoMember(3)] public Dictionary<Vector2, int> Neighbors { get; set; }

        /// <summary>
        /// Size of the map.
        /// </summary>
        [ProtoMember(4)] public Vector2D Size { get; set; }

        /// <summary>
        /// Layers of the map.
        /// </summary>
        [ProtoMember(5)] public List<BaseLayer> Layers { get; set; } = new List<BaseLayer>();

        /// <summary>
        /// Stores the entities.
        /// </summary>
        [ProtoIgnore] public EntityLayer EntityLayer { get; private set; }

        /// <summary>
        /// Added to visible area during draw.
        /// </summary>
        [ProtoIgnore] private const int DrawOffset = 3;

        /// <summary>
        /// TileSize of the game.
        /// </summary>
        [ProtoIgnore] public Vector2D TileSize => Runtime.TileSize;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Map() { }

        /// <summary>
        /// Creates new map with given name and size.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mapSize"></param>
        public Map(string name, Vector2D mapSize)
        {
            Name = name;
            Size = mapSize;
            EntityLayer = new EntityLayer("Entities", mapSize) { Order = 1 };
            Layers = new List<BaseLayer> { EntityLayer };
        }

        /// <summary>
        /// Initializes the layers.
        /// </summary>
        /// <param name="graphics"></param>
        public void Initialize(GraphicsDevice graphics)
        {
            Neighbors ??= new Dictionary<Vector2, int>();
            LoadEntities();

            foreach (var layer in Layers)
            {
                layer.Initialize(graphics);
            }
        }

        /// <summary>
        /// Loads the entities from Entity Controller.
        /// </summary>
        public void LoadEntities()
        {
            EntityLayer = (EntityLayer)Layers.Find(x => x is EntityLayer);
            EntityLayer.LoadEntities(EntityController.GetEntities(Id));
        }

        /// <summary>
        /// Loads content of all layers.
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            foreach (var layer in Layers)
            {
                layer.LoadContent(content);
            }
        }

        /// <summary>
        /// Draws the visible area of the map.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        /// <param name="visibleArea"></param>
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

        public void ActivateEntities()
        {
            EntityLayer.ActivateEntities();
        }

        /// <summary>
        /// Returns the entity at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Entity GetEntity(Vector2 position)
        {
            return EntityLayer.GetEntity(position);
        }

        /// <summary>
        /// Adds the entity to the entity layer.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="position"></param>
        public void AddEntity(Entity e, Vector2 position)
        {
            EntityLayer.AddEntity(e, position);
        }

        /// <summary>
        /// Moves given entity to the new position on the map.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="oldPosition"></param>
        /// <param name="newPosition"></param>
        public void MoveEntity(Entity e, Vector2 oldPosition, Vector2 newPosition)
        {
            if (EntityLayer.GetEntity(oldPosition) == e)
                EntityLayer.SetEntity(oldPosition, Entity.Empty);

            if (newPosition.X >= 0
                && newPosition.Y >= 0
                && newPosition.X < Size.X
                && newPosition.Y < Size.Y
                && newPosition != -Vector2.One)
                EntityLayer.SetEntity(newPosition, e);
        }

        /// <summary>
        /// Removes the entity located at given position.
        /// </summary>
        /// <param name="position"></param>
        public void RemoveEntity(Vector2 position)
        {
            EntityLayer.RemoveEntity(position);
        }

        /// <summary>
        /// Removes the entity from entities list.
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity(Entity entity)
        {
            EntityLayer.RemoveEntity(entity);
        }

        /// <summary>
        /// Sets the entity on given position.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="position"></param>
        public void SetEntity(Entity e, Vector2 position)
        {
            EntityLayer.SetEntity(position, e);
        }
    }
}
