using DarkUI.Docking;
using WolfyCore.Controllers;
using WolfyCore.Game;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace WolfyEngine.Controls
{
    public partial class TilesetPainterPanel : DarkToolWindow
    {
        private TilesetsController _tilesetsController;

        public TilesetControl TilesetControl => tilesetControl;

        public event RectangleEvent OnControlClick;

        public TilesetPainterPanel()
        {
            InitializeComponent();
            Resize += InvalidateEditor;
            scrollablePanel.Scroll += InvalidateEditor;
            scrollablePanel.MouseWheel += InvalidateEditor;
            tilesetControl.OnControlClick += delegate(Rectangle rectangle)
            {
                OnControlClick?.Invoke(rectangle);
            };
        }
        
        public void LoadLayer(BaseLayer layer)
        {
            switch (layer)
            {
                case null:
                    tilesetControl.LoadLayer(null);
                    break;
                case TileLayer tileLayer:
                    tilesetControl.LoadLayer(tileLayer);
                    break;
                default:
                    tilesetControl.LoadLayer(null);
                    break;
            }
        }

        public void LoadMap(Map map)
        {
            if (map?.Layers.Count > 0)
            {
                LoadLayer(map.Layers[0]);
            }
        }

        private void InvalidateEditor(object sender, System.EventArgs e)
        {
            tilesetControl.Invalidate();
        }
    }
}
