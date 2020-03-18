using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using System.Drawing;
using WolfyShared.Engine;
using Image = WolfyShared.Engine.Image;

namespace WolfyShared.Game
{
    [ProtoContract] public class Tileset
    {
        //Unique Tilesets id
        [ProtoMember(1)] public int Id { get; set; }
        [ProtoMember(2)] public string Name { get; set; }
        [ProtoMember(3)] public Vector2D TileSize { get; set; }
        [ProtoMember(4)] public Engine.Image Image { get; set; }
        [ProtoMember(5)] public List<TileRow> Rows { get; set; }

        public Tileset () { }
        public Tileset(string name, Vector2D tileSize, string imagePath)
        {
            Name = name;
            TileSize = tileSize;
            Image = new Image(imagePath);
            Rows = new List<TileRow>();

            // Get texture size
            int height, width;
            using (var image = new Bitmap(imagePath))
            {
                height = image.Height/32;
                width = image.Width/32;
            }

            // Create tiles based on texture size
            for (var i = 0; i < height; i++)
            {
                Rows.Add(new TileRow(width, i, TileSize.X));
            }
        }

        public void Initialize(GraphicsDevice graphics)
        {
            Image.Initialize(graphics);
        }

        public void Unload()
        {
            Image.Dispose();
        }
    }
}
