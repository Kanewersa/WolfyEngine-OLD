using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using System.Drawing;
using Microsoft.Xna.Framework.Content;
using WolfyCore.Engine;
using Image = WolfyCore.Engine.Image;

namespace WolfyCore.Game
{
    [ProtoContract] public class Tileset
    {
        //Unique Tilesets id
        [ProtoMember(1)] public int Id { get; set; }
        [ProtoMember(2)] public string Name { get; set; }
        [ProtoIgnore] public Vector2D TileSize => Runtime.TileSize;
        [ProtoMember(4)] public Engine.Image Image { get; set; }
        [ProtoMember(5)] public TileRow[] Rows { get; set; }
        [ProtoMember(6)] public Vector2D Size { get; set; }

        public Tileset () { }
        public Tileset(string name, string imagePath)
        {
            Name = name;
            Image = new Engine.Image(imagePath);

            // Get texture size
            int height, width;
            using (var image = new Bitmap(imagePath))
            {
                height = image.Height/32;
                width = image.Width/32;
            }

            Size = new Vector2D(width, height);
            Rows = new TileRow[Size.Y];

            // Create tiles based on texture size
            for (var i = 0; i < height; i++)
                Rows[i] = new TileRow(width, i, TileSize.X);
        }

        public void Initialize()
        {
            
        }

        public void LoadContent(ContentManager content)
        {
            Image.LoadContent(content);
        }

        public void Unload()
        {
            Image.Dispose();
        }
    }
}
