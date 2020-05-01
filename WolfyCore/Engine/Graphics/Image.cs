using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        [ProtoMember(6)] public float Rotation { get; set; } = 0f;
        [ProtoMember(7)] public Vector2 Origin { get; set; } = Vector2.Zero;
        [ProtoMember(8)] public SpriteEffects SpriteEffect { get; set; } = SpriteEffects.None;
        

        [ProtoIgnore] public Vector2 Position;
        [ProtoIgnore] public Rectangle SourceRectangle { get; set; } = Rectangle.Empty;
        [ProtoIgnore] public Texture2D Texture { get; private set; }

        public Image() { }

        public Image(string path) { Path = path; }

        public void LoadContent(ContentManager content)
        {
            if (Texture != null)
                Console.WriteLine("Image " + Texture.Name + " was already loaded!");
            
            if (string.IsNullOrEmpty(Path))
                throw new FileNotFoundException("Texture file is missing or wrong path! Path: " + Path);

            if (Path.EndsWith(".png"))
            {
                Path = Path.Remove(Path.Length - 4);
            }
            
            Texture = content.Load<Texture2D>(Path);

            if (SourceRectangle == Rectangle.Empty)
                SourceRectangle = Texture.Bounds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRectangle,
                Color * Alpha, Rotation, Origin, Scale, SpriteEffect, Depth);
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
