using System;
using DarkUI.Docking;
using Microsoft.Xna.Framework;
using WolfyCore.Engine;

namespace WolfyEngine.Controls
{
    public partial class MapSelectPanel : DarkToolWindow
    {
        public event TransformEvent TileSelected;

        public MapSelectPanel()
        {
            InitializeComponent();
            MapControl.TileSelected += delegate(int id, Vector2 transform)
            {
                TileSelected?.Invoke(id, transform);
            };
        }

        public void Initialize(int mapId)
        {
            MapControl.LoadMap(mapId);
        }

        public Tuple<int, Vector2> GetSelectedPosition()
        {
            return MapControl.GetSelectedPosition();
        }
    }
}
