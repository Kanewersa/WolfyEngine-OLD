using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WolfyCore.Engine;

namespace WolfyEngine.Utils
{
    public class Selector
    {
        private List<Image> _images;

        public bool Enabled { get; set; } = true;

        private readonly string[] _imagesPaths =
        {
            "Assets/Editor/selector1",
            "Assets/Editor/selector2",
            "Assets/Editor/selector3",
            "Assets/Editor/selector4"
        };

        public Selector(float scale)
        {
            _images = new List<Image>();
            for (var i = 0; i < 4; i++)
            {
                _images.Add(new Image(_imagesPaths[i]));
                _images[i].Scale = scale;
            }
        }

        public void Initialize(GraphicsDevice graphics)
        {
            
        }

        public void LoadContent(ContentManager content)
        {
            foreach (var image in _images)
            {
                image.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Enabled) return;

            foreach (var image in _images)
                image.Draw(spriteBatch);
        }


        #region Positioning methods

        /// <summary>
        /// Sets positions for all selector images
        /// </summary>
        /// <param name="value"></param>
        public void SetPosition(Vector2 value)
        {
            _images.ForEach(x => x.Position = value);
        }

        /// <summary>
        /// Sets positions for all selector images
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        /// <param name="four"></param>
        public void SetPosition(Vector2 one, Vector2 two, Vector2 three, Vector2 four)
        {
            _images[0].Position = one;
            _images[1].Position = two;
            _images[2].Position = three;
            _images[3].Position = four;
        }

        /// <summary>
        /// Sets position of image with given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetPosition(int index, Vector2 value)
        {
            _images[index].Position = value;
        }

        /// <summary>
        /// Sets X position of image with given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetPositionX(int index, float value)
        {
            _images[index].Position.X = value;
        }

        /// <summary>
        /// Sets Y position of image with given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetPositionY(int index, float value)
        {
            _images[index].Position.Y = value;
        }

        /// <summary>
        /// Returns X position of image with given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float GetPositionX(int index)
        {
            return _images[index].Position.X;
        }

        /// <summary>
        /// Returns Y position of image with given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float GetPositionY(int index)
        {
            return _images[index].Position.Y;
        }

        #endregion
    }
}
