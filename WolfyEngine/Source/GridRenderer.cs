using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WolfyCore.Engine;

namespace WolfyEngine.Source
{
    public class GridRenderer
    {
        public int GridSize { get; private set; }
        public Vector2 RenderSize { get; private set; }
        public Image GridImage { get; private set; }

        public GridRenderer(int gridSize, Vector2 renderSize)
        {
            GridSize = gridSize;
            RenderSize = renderSize;
            GridImage = new Image("Assets/Icons/GridIcon");
        }

        public void LoadContent(ContentManager content)
        {
            GridImage.LoadContent(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (var y = 0; y < RenderSize.Y; y++)
            {
                for (var x = 0; x < RenderSize.X; x++)
                {
                    GridImage.Position = new Vector2(x * GridSize, y * GridSize);
                    GridImage.Draw(spriteBatch);
                }
            }

            GridImage.Position = Vector2.Zero;
        }

        public void SetRenderSize(Vector2 newSize)
        {
            RenderSize = newSize;
        }
    }
}
