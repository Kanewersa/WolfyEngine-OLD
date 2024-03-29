﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Engine;

namespace WolfyCore.Game
{
    /// <summary>
    /// Stores the graphic tiles.
    /// </summary>
    [ProtoContract] public class TileLayer : BaseLayer
    {
        /// <summary>
        /// Id of the tileset the layer uses.
        /// </summary>
        [ProtoMember(2)] public int TilesetId { get; set; }

        /// <summary>
        /// Stores the positions of the tiles on texture atlas.
        /// </summary>
        [ProtoMember(3)] public VectorsRow[] Sources { get; set; }

        /// <summary>
        /// Rows containing the tiles.
        /// </summary>
        [ProtoIgnore] public TileRow[] Rows { get; set; }

        /// <summary>
        /// Texture image of the tileset.
        /// </summary>
        [ProtoIgnore] private Image Image => Tileset.Image;

        /// <summary>
        /// Tileset the layer uses.
        /// </summary>
        [ProtoIgnore] public Tileset Tileset { get; set; }

        [ProtoIgnore] private Vector2D _emptyTile = new Vector2D(-1, -1);
        [ProtoIgnore] private Color _temporaryColor = Color.White;
        [ProtoIgnore] private float _temporaryTransparency = 1f;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TileLayer() { }

        /// <summary>
        /// Creates the TileLayer with given name, size and id.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mapSize"></param>
        /// <param name="tilesetId"></param>
        public TileLayer(string name, Vector2D mapSize, int tilesetId)
        {
            Name = name;
            Size = mapSize;
            TilesetId = tilesetId;
            Rows = new TileRow[Size.Y];
            Sources = new VectorsRow[Size.Y];

            // Create tiles
            for (var i = 0; i < Size.Y; i++)
            {
                Rows[i] = new TileRow(Size.X);
                Sources[i] = new VectorsRow(Size.X);
            }
        }

        /// <summary>
        /// Creates the tiles and initializes the layer's tileset.
        /// </summary>
        /// <param name="graphics"></param>
        public override void Initialize(GraphicsDevice graphics)
        {
            Tileset ??= TilesetsController.Instance.GetTileset(TilesetId);

            if (Rows == null)
            {
                Rows = new TileRow[Size.Y];

                for (var i = 0; i < Size.Y; i++)
                {
                    Rows[i] = new TileRow(Size.X);
                }
            }

            for (var y = 0; y < Size.Y; y++)
            {
                for (var x = 0; x < Size.X; x++)
                {
                    var source = Sources[y].Source[x];
                    if(source != _emptyTile)
                        Rows[y].Tiles[x] = Tileset.Rows[source.Y].Tiles[source.X];
                }
            }

            Tileset.Initialize();
        }

        /// <summary>
        /// Loads the tileset content.
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            Tileset.LoadContent(content);
        }

        /// <summary>
        /// Draws the tiles in given area.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        /// <param name="visibleArea"></param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle visibleArea)
        {
            Image.Alpha = _temporaryTransparency;
            Image.Color = _temporaryColor;

            for (var y = visibleArea.Y; y < visibleArea.Height; y++)
            {
                for (var x = visibleArea.X; x < visibleArea.Width; x++)
                {
                    if (y < 0 || x < 0) return;
                    var currentTile = Rows[y].Tiles[x];
                    if (currentTile == null || currentTile.Source == _emptyTile)
                        continue;

                    Image.Position = new Vector2(x * TileSize.X, y * TileSize.Y);
                    Image.SourceRectangle = new Rectangle(currentTile.Source.X, currentTile.Source.Y,
                        TileSize.X, TileSize.Y);
                    Image.Draw(spriteBatch);
                }
            }

            Image.Position = Vector2.Zero;
            Image.SourceRectangle =
                new Rectangle(0,0,Image.Texture.Width, Image.Texture.Height);
            Image.Alpha = 1f;
            Image.Color = Color.White;
        }

        /// <summary>
        /// Disposes the layer.
        /// </summary>
        public override void Unload()
        {
            Image.Dispose();
            Tileset.Unload();
        }

        /// <summary>
        /// Checks if tile at given position is passable.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override bool? TileOccupied(Vector2 position)
        {
            return !Rows[(int) position.Y].Tiles[(int) position.X].Passage;
        }

        /// <summary>
        /// Replaces tiles at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="selectedRegion"></param>
        public void ReplaceTiles(Vector2 position, Rectangle selectedRegion)
        {
            var startIndex = new Vector2(position.X / TileSize.X, position.Y / TileSize.Y);
            var tileIndex = new Vector2(selectedRegion.X, selectedRegion.Y - 1);

            for (var i = (int)startIndex.Y; i <= startIndex.Y + selectedRegion.Height; i++)
            {
                if (i < 0 || i >= Size.Y)
                    return;
                tileIndex.X = selectedRegion.X;
                tileIndex.Y++;
                for (var j = (int)startIndex.X; j <= startIndex.X + selectedRegion.Width; j++)
                {
                    if (j < 0 || j >= Size.X)
                        return;
                    Vector2 mapIndex;
                    if (tileIndex.X * TileSize.X > Image.Texture.Width || tileIndex.Y * TileSize.Y > Image.Texture.Height)
                        mapIndex = -Vector2.One;
                    else
                        mapIndex = tileIndex;

                    var newSource = new Vector2D((int)mapIndex.X, (int)mapIndex.Y);
                    Rows[i].Tiles[j] = Tileset.Rows[(int)mapIndex.Y].Tiles[(int)mapIndex.X];
                    Sources[i].Source[j] = newSource;
                    tileIndex.X++;
                }
            }
        }

        /// <summary>
        /// Fills the tiles.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="selectedRegion"></param>
        public void FillTiles(Vector2 position, Rectangle selectedRegion)
        {
            var source = new Vector2(position.X / TileSize.X, position.Y / TileSize.Y);
            var target = new Vector2(selectedRegion.X, selectedRegion.Y);

            var src = new Vector2D((int) source.X, (int) source.Y);
            var oldTile = Rows[src.Y].Tiles[src.X];
            var targetTile = Tileset.Rows[(int)target.Y].Tiles[(int)target.X];

            if (oldTile.Source == targetTile.Source) return;

            var queue = new Queue<Vector2D>();

            FloodFill(src, oldTile, targetTile, queue);

            while (queue.Count > 0)
            {
                var toCheck = queue.Dequeue();

                FloodFill(toCheck + new Vector2D(-1,0), oldTile, targetTile, queue);
                FloodFill(toCheck + new Vector2D(0, 1), oldTile, targetTile, queue);
                FloodFill(toCheck + new Vector2D(1, 0), oldTile, targetTile, queue);
                FloodFill(toCheck + new Vector2D(0, -1), oldTile, targetTile, queue);
            }

        }

        /// <summary>
        /// Performs the tile filling operation.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="oldTile"></param>
        /// <param name="targetTile"></param>
        /// <param name="queue"></param>
        private void FloodFill(Vector2D src, Tile oldTile, Tile targetTile, Queue<Vector2D> queue)
        {
            // Check if source fits the bounds of map
            if (src.X < 0 || src.X >= Size.X) return;
            if (src.Y < 0 || src.Y >= Size.Y) return;

            // Enqueue source if target tile is the old tile
            if (Rows[src.Y].Tiles[src.X] == oldTile || Rows[src.Y].Tiles[src.X].Empty())
            {
                Rows[src.Y].Tiles[src.X] = targetTile;
                Sources[src.Y].Source[src.X] = targetTile.Source / TileSize.X;
                queue.Enqueue(src);
            }
        }

        private void SetTile(Vector2D src, Tile mainTile, Tile targetTile)
        {
            if (src.X < 0 || src.Y < 0 || src.X > Size.X - 1 || src.Y > Size.Y - 1) return;

            Rows[src.Y].Tiles[src.X] = targetTile;
            Sources[src.Y].Source[src.X] = targetTile.Source / TileSize.X;


            if(src.X - 1 >= 0)
                if (Rows[src.Y].Tiles[src.X - 1] == mainTile || Rows[src.Y].Tiles[src.X - 1].Empty())
                    // Call the function for left neighbor
                    SetTile(new Vector2D(src.X - 1, src.Y), mainTile, targetTile);

            if(src.X + 1 < Size.X)
                if (Rows[src.Y].Tiles[src.X + 1] == mainTile || Rows[src.Y].Tiles[src.X + 1].Empty())
                    // Call the function for right neighbor
                    SetTile(new Vector2D(src.X + 1, src.Y), mainTile, targetTile);
            
            if(src.Y - 1 >= 0)
                if (Rows[src.Y - 1].Tiles[src.X] == mainTile || Rows[src.Y - 1].Tiles[src.X].Empty())
                    // Call the function for upper neighbor
                    SetTile(new Vector2D(src.X, src.Y - 1), mainTile, targetTile);
            
            if(src.Y + 1 < Size.Y)
                if (Rows[src.Y + 1].Tiles[src.X] == mainTile || Rows[src.Y + 1].Tiles[src.X].Empty())
                    // Call the function for bottom neighbor
                    SetTile(new Vector2D(src.X, src.Y + 1), mainTile, targetTile);
        }

        /// <summary>
        /// Sets the temporary color of the layer.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="transparency"></param>
        public void SetColor(Color color, float transparency)
        {
            _temporaryColor = color;
            _temporaryTransparency = transparency;
        }
    }
}
