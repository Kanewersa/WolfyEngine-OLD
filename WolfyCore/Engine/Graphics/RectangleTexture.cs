using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyCore.Engine
{
    public class RectangleTexture : Texture2D
    {
        public Rectangle Rectangle { get; private set; }
        public Color Color { get; set; }
        public RectangleTexture(GraphicsDevice graphicsDevice, int width, int height, bool mipmap, SurfaceFormat format, int x, int y, Color color, float alpha) : base(graphicsDevice, width, height, mipmap, format)
        {
            Color[] data = new Color[width*height];

            for (int i = 0; i < data.Length; ++i)
                data[i] = new Color(color, alpha);

            SetData(data);
            Rectangle = new Rectangle(x, y, width, height);
            Color = new Color(color, alpha);
        }

        public void Draw(SpriteBatch sprite, Vector2 position)
        {
            sprite.Draw(this, position, Color);
        }
    }
}
