using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Forms.Controls;
using WolfyCore;
using WolfyCore.Controllers;
using WolfyCore.Engine;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine.Source;
using WolfyEngine.Utils;

namespace WolfyEngine.Controls
{
    public partial class MapSelectControl : InvalidationControl
    {
        public Map Map { get; set; }
        public GridRenderer GridRenderer { get; set; }
        public Selector Selector { get; set; }
        public new Vector2 MousePosition { get; private set; }
        public Vector2 TileCoordinates { get; private set; } = -Vector2.One;
        public Color Color { get; set; } = new Color(60, 63, 65);

        public event TransformEvent TileSelected;

        public MapSelectControl()
        {
            InitializeComponent();
            GridRenderer = new GridRenderer(Runtime.GridSize, Vector2.Zero);
            Selector = new Selector { Color = Color.White };

            MouseMove += delegate(object sender, MouseEventArgs args)
            {
                Invalidate();
            };
            MouseClick += MapControl_MouseClick;
            MouseDoubleClick += OnMouseDoubleClick;
        }

        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            MapControl_MouseClick(sender, e);
            TileSelected?.Invoke(Map.Id, TileCoordinates);
        }

        private void MapControl_MouseClick(object sender, MouseEventArgs e)
        {
            var newPosition = new Vector2((int)(e.X / Runtime.TileSize.X), (int)(e.Y / Runtime.TileSize.Y));
            if (newPosition.X < 0 || newPosition.Y < 0 || newPosition.X > Map.Size.X || newPosition.Y > Map.Size.Y)
            {
                return;
            }

            TileCoordinates = newPosition;
            MousePosition = newPosition * Runtime.GridSize;

            Selector.SetPosition(MousePosition);
            Invalidate();
        }

        protected override void Initialize()
        {
            base.Initialize();

            if (Map == null)
                throw new Exception("Map was not set.");

            Selector.Initialize(GraphicsDevice);
            Map.Initialize(GraphicsDevice, World.WorldInstance);
            LoadContent(Editor.Content);
        }

        public void LoadMap(int mapId)
        {
            Map = MapsController.Instance.GetMap(mapId);
            if (Editor != null)
            {
                Map.Initialize(Editor.graphics, World.WorldInstance);
                Map.LoadContent(Editor.Content);
                TileCoordinates = -Vector2.One;
                Selector.SetPosition(new Vector2(-100, -100));
                Invalidate();
            }
            if(GridRenderer == null)
                GridRenderer = new GridRenderer(Runtime.GridSize, (Vector2)Map.Size);
            else GridRenderer.SetRenderSize((Vector2)Map.Size);
        }

        public Tuple<int, Vector2> GetSelectedPosition()
        {
            return new Tuple<int, Vector2>(Map.Id, TileCoordinates);
        }

        protected void LoadContent(ContentManager content)
        {
            Map.LoadContent(content);
            GridRenderer.LoadContent(content);
            Selector.LoadContent(content);
        }

        protected override void Draw()
        {
            base.Draw();
            GraphicsDevice.Clear(Color);

            Editor.spriteBatch.Begin();
            Map.Draw(Editor.spriteBatch);
            // TODO Fix grid image
            //GridRenderer.Draw(Editor.spriteBatch);
            Selector.Draw(Editor.spriteBatch);
            Editor.spriteBatch.End();
        }
    }
}
