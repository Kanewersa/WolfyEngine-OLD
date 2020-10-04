using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyCore.Engine
{
    public class LUTManager
    {
        /// <summary>
        /// Shader filter responsible for handling the LUTs. 
        /// </summary>
        public ColorGradingFilter ColorGradingFilter { get; private set; }

        /// <summary>
        /// Last LUT.
        /// </summary>
        public Texture2D CurrentLUT { get; private set; }

        /// <summary>
        /// LUT to be loaded.
        /// </summary>
        public Texture2D NewLUT { get; private set; }

        /// <summary>
        /// Percentage progress of transition between current LUT and new LUT.
        /// </summary>
        public float LUTTransitionProgress { get; private set; } = 0f;

        /// <summary>
        /// Time of the transition between LUTs.
        /// </summary>
        public float LUTTransitionTime { get; private set; } = 5f;

        private ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            _contentManager = content;
            _graphicsDevice = graphics;

            ColorGradingFilter = new ColorGradingFilter(graphics, content, "Assets/Shaders/ColorGrading");
            CurrentLUT = content.Load<Texture2D>("Assets/Shaders/default");
            NewLUT = content.Load<Texture2D>("Assets/Shaders/Night");
        }

        /// <summary>
        /// Updates the LUT transition.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (NewLUT != CurrentLUT)
            {
                if (LUTTransitionProgress >= 1f)
                {
                    /*var temp = CurrentLUT;
                    CurrentLUT = NewLUT;
                    NewLUT = temp;
                    LUTTransitionProgress = 0f;*/
                    return;
                }

                LUTTransitionProgress += (float)gameTime.ElapsedGameTime.TotalSeconds/LUTTransitionTime;
            }
        }

        /// <summary>
        /// Draws the color filter.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="cameraTransform"></param>
        /// <param name="texture"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        /// <param name="fadeColor"></param>
        public void Draw(SpriteBatch spriteBatch, Matrix cameraTransform, Texture2D texture, int screenWidth, int screenHeight, Color fadeColor)
        {
            spriteBatch.Begin(transformMatrix: cameraTransform);
            spriteBatch.Draw(texture, new Rectangle(0, 0, screenWidth, screenHeight), fadeColor);
            spriteBatch.End();
        }

        /// <summary>
        /// Returns the render target from shader.
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public Texture2D GetRenderTarget(Texture2D texture)
        {
            return ColorGradingFilter.Draw(_graphicsDevice, texture, CurrentLUT, NewLUT, LUTTransitionProgress);
        }

        /// <summary>
        /// Sets new LUT.
        /// </summary>
        /// <param name="lutPath"></param>
        /// <param name="transitionTime"></param>
        public void SetNewLUT(string lutPath, float transitionTime)
        {
            LUTTransitionProgress = 0f;
            LUTTransitionTime = transitionTime;
            NewLUT = _contentManager.Load<Texture2D>(lutPath);
        }
    }
}
