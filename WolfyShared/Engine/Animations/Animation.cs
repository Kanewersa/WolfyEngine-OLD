using Microsoft.Xna.Framework.Graphics;

namespace WolfyShared.Engine
{
    public class Animation
    {
        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }

        public int CurrentDirection { get; set; }
        public int DirectionsCount { get; private set; }
        

        public int FrameHeight => Texture.Height / DirectionsCount;
        public int FrameWidth => Texture.Width / FrameCount;
        public float FrameSpeed { get; set; }

        public bool IsLooping { get; set; }

        public Image Image { get; set; }

        public Texture2D Texture => Image.Texture;

        public Animation(string texture, int frameCount, int directionsCount)
        {
            Image = new Image(texture);
            CurrentDirection = 0;
            FrameCount = frameCount;
            DirectionsCount = directionsCount;
            

            IsLooping = true;
            FrameSpeed = .2f;
        }
        
    }
}
