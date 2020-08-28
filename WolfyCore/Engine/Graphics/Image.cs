using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace WolfyCore.Engine
{
    /// <summary>
    /// Stores <see cref="Texture2D"/> and it's properties applied on draw.
    /// </summary>
    [ProtoContract] public class Image : IDisposable
    {
        /// <summary>
        /// Alpha of the image. Value of 1 means totally opaque and value of 0 means totally transparent.
        /// </summary>
        [ProtoMember(1)] public float Alpha { get; set; } = 1.0f;

        /// <summary>
        /// Color of the image. Multiplies the <see cref="Texture"/> color during <see cref="Draw"/>.
        /// </summary>
        [ProtoMember(2)] public Color Color { get; set; } = Color.White;

        /// <summary>
        /// Scale of the image.
        /// </summary>
        [ProtoMember(3)] public float Scale { get; set; } = 1.0f;

        /// <summary>
        /// Depth of the image. Determines the drawing order when <see cref="SpriteSortMode.BackToFront"/> or
        /// <see cref="SpriteSortMode.FrontToBack"/> is used by <see cref="SpriteBatch"/>.
        /// </summary>
        [ProtoMember(4)] public float Depth { get; set; } = 0f;

        /// <summary>
        /// Path to the source file of <see cref="Texture2D"/>.
        /// </summary>
        [ProtoMember(5)] public string Path { get; set; }

        /// <summary>
        /// Clockwise rotation of the image.
        /// </summary>
        [ProtoMember(6)] public float Rotation { get; set; } = 0f;

        /// <summary>
        /// Center of the rotation.
        /// </summary>
        [ProtoMember(7)] public Vector2 Origin { get; set; } = Vector2.Zero;

        /// <summary>
        /// Modificator for drawing.
        /// </summary>
        [ProtoMember(8)] public SpriteEffects SpriteEffect { get; set; } = SpriteEffects.None;
        
        /// <summary>
        /// The drawing location on screen.
        /// </summary>
        [ProtoIgnore] public Vector2 Position;

        /// <summary>
        /// The region of the texture which should be rendered.
        /// </summary>
        [ProtoIgnore] public Rectangle SourceRectangle { get; set; } = Rectangle.Empty;

        /// <summary>
        /// The texture.
        /// </summary>
        [ProtoIgnore] public Texture2D Texture { get; private set; }

        public Image() { }

        public Image(string path) { Path = path; }

        /// <summary>
        /// Loads the image texture.
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            if (Texture != null)
                return;

            if (string.IsNullOrEmpty(Path))
                throw new FileNotFoundException("Texture file is missing or has a wrong path! Path: " + Path);

            if (Path.EndsWith(".png"))
                Path = Path.Remove(Path.Length - 4);

            Texture = content.Load<Texture2D>(Path);

            if (SourceRectangle == Rectangle.Empty)
                SourceRectangle = Texture.Bounds;
        }

        /// <summary>
        /// Draws the <see cref="Texture"/> with image parameters.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRectangle,
                Color * Alpha, Rotation, Origin, Scale, SpriteEffect, Depth);
        }

        /// <summary>
        /// Sets the scale of image based on tile and texture size.
        /// </summary>
        /// <param name="tileSize"></param>
        /// <param name="textureSize"></param>
        public void SetScale(int tileSize, int textureSize)
        {
            Scale = tileSize / (float)textureSize;
        }

        /// <summary>
        /// Disposes the texture.
        /// </summary>
        public void Dispose()
        {
            Texture?.Dispose();
        }

    }
}
