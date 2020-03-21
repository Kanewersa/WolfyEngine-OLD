using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyShared.Engine
{
    [ProtoContract] public class Image : IDisposable
    {
        [ProtoMember(1)] public float Alpha { get; set; } = 1.0f;
        [ProtoMember(2)] public Color Color { get; set; } = Color.White;
        [ProtoMember(3)] public float Scale { get; set; } = 1.0f;
        [ProtoMember(4)] public float Depth { get; set; } = 0f;
        [ProtoMember(5)] public string Path { get; set; }

        [ProtoIgnore] public Vector2 Position;
        [ProtoIgnore] public Vector2 FixedPosition => new Vector2((int)Position.X, (int)Position.Y);
        [ProtoIgnore] public Rectangle SourceRectangle { get; set; } = Rectangle.Empty;
        [ProtoIgnore] public Texture2D Texture { get; private set; }

        public Image() { }

        public Image(string path) { Path = path; }

        public void Initialize(GraphicsDevice graphics)
        {
            if (Texture != null)
            {
                Console.WriteLine("Image " + Texture.Name + " was already initialized!");
                return;
                //throw new Exception("Image was already initialized!");
            }

            if (!string.IsNullOrEmpty(Path))
                Texture = GraphicsManager.LoadFromFileStream(Path, graphics);
            else
                throw new FileNotFoundException("Texture is missing or wrong path! Path: " + Path);

            if (SourceRectangle == Rectangle.Empty)
                SourceRectangle = Texture.Bounds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRectangle,
                Color * Alpha, 0f, Vector2.Zero, Scale, SpriteEffects.None, Depth);
        }

        public void SetScale(int tileSize, int textureSize)
        {
            Scale = tileSize / (float)textureSize;
        }

        public void Dispose()
        {
            Texture?.Dispose();
        }

    }
}
