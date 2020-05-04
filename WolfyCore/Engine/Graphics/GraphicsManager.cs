using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyCore.Engine
{
    public static class GraphicsManager
    {
        /// <summary>
        /// Loads all textures in given directory and returns them in a list.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="graphicsDevice"></param>
        /// <returns></returns>
        public static List<Texture2D> LoadTextureList(string directory, GraphicsDevice graphicsDevice)
        {
            List<Texture2D> blendedTextures = new List<Texture2D>();
            //load any valid files in directory
            foreach (var fileName in Directory.GetFiles(directory, "*.jpg|*.png|*.gif"))
            {
                var blendedTexture = LoadFromFileStream(fileName, graphicsDevice);
                if (blendedTexture != null)
                    blendedTextures.Add(blendedTexture);
            }
            return blendedTextures;
        }

        /// <summary>
        /// Loads all textures in given directory and returns them in a dictionary
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="graphicsDevice"></param>
        /// <returns></returns>
        public static Dictionary<string, Texture2D> LoadTextureDictionary(string directory, GraphicsDevice graphicsDevice)
        {
            Dictionary<string, Texture2D> blendedTextures =
                new Dictionary<string, Texture2D>();
            //load any valid files in directory
            foreach (var fileName in Directory.GetFiles(directory, "*.jpg|*.png|*.gif"))
            {
                var blendedTexture = LoadFromFileStream(fileName, graphicsDevice);
                if (blendedTexture != null)
                    blendedTextures.Add(fileName, blendedTexture);
            }
            return blendedTextures;
        }

        /// <summary>
        /// Loads texture in given path and returns it.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="graphicsDevice"></param>
        /// <returns></returns>
        public static Texture2D LoadFromFileStream(string path, GraphicsDevice graphicsDevice)
        {
            Texture2D file;

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                file = Texture2D.FromStream(graphicsDevice, fileStream);
            }

            //Setup a render target to hold our final texture which will have pre-multiplied alpha values
            RenderTarget2D result = new RenderTarget2D(graphicsDevice, file.Width, file.Height);
            graphicsDevice.SetRenderTarget(result);
            graphicsDevice.Clear(Color.Black);

            //Multiply each color by the source alpha, and write in just the color values into the final texture
            var blendColor = new BlendState
            {
                ColorWriteChannels = ColorWriteChannels.Red | ColorWriteChannels.Green | ColorWriteChannels.Blue,
                AlphaDestinationBlend = Blend.Zero,
                ColorDestinationBlend = Blend.Zero,
                AlphaSourceBlend = Blend.SourceAlpha,
                ColorSourceBlend = Blend.SourceAlpha
            };

            var spriteBatch = new SpriteBatch(graphicsDevice);
            spriteBatch.Begin(SpriteSortMode.Immediate, blendColor);
            spriteBatch.Draw(file, file.Bounds, Color.White);
            spriteBatch.End();

            //Now copy over the alpha values from the PNG source texture to the final one, without multiplying them
            var blendAlpha = new BlendState
            {
                ColorWriteChannels = ColorWriteChannels.Alpha,
                AlphaDestinationBlend = Blend.Zero,
                ColorDestinationBlend = Blend.Zero,
                AlphaSourceBlend = Blend.One,
                ColorSourceBlend = Blend.One
            };

            spriteBatch.Begin(SpriteSortMode.Immediate, blendAlpha);
            spriteBatch.Draw(file, file.Bounds, Color.White);
            spriteBatch.End();

            spriteBatch.Dispose();

            //Release the GPU back to drawing to the screen
            graphicsDevice.SetRenderTarget(null);

            return result;
        }
    }
}
