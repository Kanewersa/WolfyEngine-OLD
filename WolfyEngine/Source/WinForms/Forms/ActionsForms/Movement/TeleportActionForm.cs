using DarkUI.Forms;
using Microsoft.Xna.Framework;
using WolfyCore.Actions;
using WolfyCore.Engine;

namespace WolfyEngine.Forms
{
    public partial class TeleportActionForm : BaseActionForm
    {
        private Vector2 _selectedCoordinates = -Vector2.Zero;
        private int _selectedMapId = -1;

        public Vector2 SelectedCoordinates
        {
            get => _selectedCoordinates;
            private set
            {
                _selectedCoordinates = value;
                CoordinatesBox.Text = $"x: {value.X}, y: {value.Y}";
            }
        }

        public int SelectedMapId
        {
            get => _selectedMapId;
            private set
            {
                _selectedMapId = value;
                MapBox.Text = $"Map: {value}";
            }
        }

        public bool MapBorder { get; private set; }
        public Vector2 Direction { get; private set; }

        public TeleportActionForm()
        {
            InitializeComponent();
        }

        protected override WolfyAction CreateAction()
        {
            return new TeleportAction(Entity, SelectedMapId, SelectedCoordinates);
        }

        protected override bool ValidateAction()
        {
            if(SelectedMapId == -1 || SelectedCoordinates == -Vector2.Zero)
             return false;

            return true;
        }

        private void MapBorderBox_CheckedChanged(object sender, System.EventArgs e)
        {
            DirectionBox.Enabled = MapBorderBox.Checked;
            if (DirectionBox.Enabled)
            {
                if (DirectionBox.SelectedIndex < 0)
                {
                    DirectionBox.SelectedIndex = 0;
                }
            }
        }

        private void SelectDestinationButton_Click(object sender, System.EventArgs e)
        {
            using (var form = new MapSelectForm())
            {
                form.Initialize(Entity);
                form.TileSelected += delegate(int id, Vector2 transform)
                {
                    SelectedMapId = id;
                    SelectedCoordinates = transform;
                };
                form.ShowDialog();
            }
        }
    }
}
