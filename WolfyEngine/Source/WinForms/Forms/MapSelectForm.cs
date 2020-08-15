using System;
using System.Windows.Forms;
using DarkUI.Docking;
using DarkUI.Forms;
using Microsoft.Xna.Framework;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine.Controls;

namespace WolfyEngine.Forms
{
    public partial class MapSelectForm : DarkForm
    {
        private MapsPanel MapsPanel { get; }
        private MapSelectPanel MapControlPanel { get; }

        public event TransformEvent TileSelected;

        public MapSelectForm()
        {
            InitializeComponent();

            // Add the dock panel message filter to filter through for dock panel splitter
            // input before letting events pass through to the rest of the application.
            Application.AddMessageFilter(DarkDockPanel.DockResizeFilter);

            MapControlPanel = new MapSelectPanel();
            MapsPanel = new MapsPanel { DockArea = DarkDockArea.Left };

            DarkDockPanel.AddContent(MapsPanel);
            DarkDockPanel.AddContent(MapControlPanel);

            MapsPanel.Initialize(false, false);

            MapControlPanel.TileSelected += SelectPosition;
            MapsPanel.OnMapChanged += delegate(Map map)
            {
                MapControlPanel.Initialize(map.Id);
            };
        }

        private void SelectPosition(int id, Vector2 transform)
        {
            TileSelected?.Invoke(id, transform);
            Close();
        }

        public void Initialize(Entity entity)
        {
            if (entity.GetIfHasComponent(out TransformComponent transform))
            {
                MapControlPanel.Initialize(transform.CurrentMap);
            }
            else
            {
                throw new Exception("Entity didn't have TransformComponent.");
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            var tuple = MapControlPanel.GetSelectedPosition();

            if (tuple.Item2 == -Vector2.One)
            {
                DarkMessageBox.ShowWarning("Please select the tile first.", "Error");
                return;
            }

            SelectPosition(tuple.Item1, tuple.Item2);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
