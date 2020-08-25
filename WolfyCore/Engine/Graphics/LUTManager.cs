using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyCore.Engine
{
    public class LUTManager
    {
        public ColorGradingFilter ColorGradingFilter { get; private set; }
        public Texture2D CurrentLUT { get; private set; }
        public Texture2D NewLUT { get; private set; }
        public float LUTTransitionProgress { get; private set; }
        public float LUTTransitionTime { get; private set; } = 1f;

        private ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            _contentManager = content;
            _graphicsDevice = graphics;

            ColorGradingFilter = new ColorGradingFilter(graphics, content, "Assets/Shaders/ColorGrading");
            CurrentLUT = content.Load<Texture2D>("Assets/Shaders/lut_ver5");
            NewLUT = content.Load<Texture2D>("Assets/Shaders/lut_ver5");
        }

        public void Draw(SpriteBatch spriteBatch, Matrix cameraTransform, Texture2D texture, int screenWidth, int screenHeight)
        {
            spriteBatch.Begin(transformMatrix: cameraTransform);
            spriteBatch.Draw(texture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.End();
        }

        public Texture2D GetRenderTarget(Texture2D texture)
        {
            return ColorGradingFilter.Draw(_graphicsDevice, texture, CurrentLUT, NewLUT, 0f);
        }
    }
}
