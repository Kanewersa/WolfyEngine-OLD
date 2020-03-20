using Microsoft.Xna.Framework.Graphics;

namespace WolfyShared.Engine
{
    public class Animation
    {
        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }
        public int FrameHeight => Texture.Height;
        public int FrameWidth => Texture.Width / FrameCount;
        public float FrameSpeed { get; set; }

        public bool IsLooping { get; set; }

        public Image Image { get; set; }

        public Texture2D Texture => Image.Texture;

        public Animation(string texture, int frameCount)
        {
            Image = new Image(texture);

            FrameCount = frameCount;

            IsLooping = true;
            FrameSpeed = .2f;
        }
        
    }
}
