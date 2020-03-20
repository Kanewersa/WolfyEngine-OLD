using System.Collections.Generic;
using ProtoBuf;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    [ProtoContract] public class TileRow
    {
        [ProtoMember(1)] public int Width { get; set; }
        [ProtoMember(2)] public Tile[] Tiles { get; set; }

        public TileRow () { }

        /// <summary>
        /// Creates a row of tiles with specified graphic source
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="size"></param>
        public TileRow(int width, int height, int size)
        {
            Width = width;
            Tiles = new Tile[width];
            //Create tiles
            for (var i = 0; i < width; i++)
            {
                Tiles[i] = new Tile(new Vector2D(i * size, height * size));
            }
        }

        /// <summary>
        /// Creates a row of empty tiles without graphic source
        /// </summary>
        /// <param name="width"></param>
        public TileRow(int width)
        {
            Width = width;
            Tiles = new Tile[width];
            //Create tiles
            for (var i = 0; i < width; i++)
            {
                Tiles[i] = new Tile(new Vector2D(-1, -1));
            }
        }
    }
}
