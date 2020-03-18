using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyShared.Controllers;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    [ProtoContract] public class TileLayer : BaseLayer
    {
        [ProtoMember(1)] public Vector2D TileSize { get; set; }
        [ProtoMember(2)] public int TilesetId { get; set; }
        //TODO Tiles should be stored in arrays to improve efficiency
        [ProtoMember(3)] public List<TileRow> Rows { get; set; }

        [ProtoIgnore] private Image Image => Tileset.Image;
        [ProtoIgnore] private Vector2D _emptyTile = new Vector2D(-1, -1);
        [ProtoIgnore] public Tileset Tileset { get; set; }
        
        public TileLayer() { }

        public TileLayer(string name, Vector2D mapSize, Vector2D tileSize, int tilesetId)
        {
            Name = name;
            Size = mapSize;
            TileSize = tileSize;
            TilesetId = tilesetId;
            Rows = new List<TileRow>();

            // Create tiles
            for (var i = 0; i < mapSize.Y; i++)
            {
                Rows.Add(new TileRow(mapSize.X));
            }
        }

        public override void Initialize(GraphicsDevice graphics)
        {
            if (Tileset == null)
                Tileset = TilesetsController.Instance.GetTileset(TilesetId);

            Tileset.Initialize(graphics);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (var y = 0; y < Size.Y; y++)
            {
                for (var x = 0; x < Size.X; x++)
                {
                    var currentTile = Rows[y].Tiles[x];
                    if (currentTile.Source == _emptyTile)
                        continue;
                    
                    Image.Position = new Vector2(x * TileSize.X, y * TileSize.Y);
                    Image.SourceRectangle = new Rectangle(currentTile.Source.X, currentTile.Source.Y,
                        TileSize.X, TileSize.Y);
                    Image.Draw(spriteBatch);
                }
            }

            Image.Position = new Vector2(0,0);
            Image.SourceRectangle =
                new Rectangle(0,0,Image.Texture.Width, Image.Texture.Height);
        }

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

                    Rows[i].Tiles[j] = Tileset.Rows[(int)mapIndex.Y].Tiles[(int)mapIndex.X];
                    Console.WriteLine("Replacing tile for " + Name + ":");
                    Console.WriteLine("Tile {x: "+ i +", y: "+ j +"}" +
                                      "now has source x: "+ mapIndex.Y +", y: "+ mapIndex.X +"");

                    //Rows[i].Tiles[j].value = mapIndex;
                    /*if (mapIndex.Y < 0)
                    {
                        if (mapIndex.X > Tileset.AutoTiles.Count - 1) continue;
                        Rows[i].Tiles[j] = Tileset.AutoTiles[(int)mapIndex.X];
                    }
                    else Rows[i].Tiles[j] = Tileset.Rows[(int)mapIndex.Y].Tiles[(int)mapIndex.X];*/

                    //TODO This part should be fully implemented only if there would be a Dynamic Map Extending feature~
                    /*
                    catch (Exception)
                    {
                        while (Rows.Count <= i)
                        {
                            TileRow row = new TileRow();
                            for (int k = 0; k < Rows[0].Tiles.Count; k++)
                                row.Tiles.Add(new Tile(new Vector2(-1, -1)));
                            Rows.Add(row);
                        }
                        while (Rows[i].Tiles.Count <= j)
                            Rows[i].Tiles.Add(new Tile(-Vector2.One));
                        Rows[i].Tiles[j].value = mapIndex;
                    }*/
                    tileIndex.X++;
                }
            }
        }

        public void Save()
        {

        }

        public void SetColor(Color color, float transparency)
        {
            Image.Alpha = transparency;
            Image.Color = color;
        }
    }
}
