using System.Collections.Generic;
using ProtoBuf;

namespace WolfyShared.Game
{
    [ProtoContract] public class EntityTileRow
    {
        [ProtoMember(1)] public int Width { get; set; }
        [ProtoMember(2)] public List<EntityTile> Tiles { get; set; }

        public EntityTileRow () { }

        /// <summary>
        /// Creates a row of entity tiles
        /// </summary>
        /// <param name="width"></param>
        public EntityTileRow(int width)
        {
            Width = width;
            Tiles = new List<EntityTile>();
            //Create tiles
            for (var i = 0; i < width; i++)
            {
                Tiles.Add(new EntityTile());
            }
        }
    }
}
