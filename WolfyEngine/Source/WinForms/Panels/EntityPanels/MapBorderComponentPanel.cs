using System;
using Microsoft.Xna.Framework;
using WolfyCore.ECS;
using WolfyECS;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class MapBorderComponentPanel : ComponentPanel
    {
        private MapBorderComponent _borderComponent;

        private Vector2 _selectedCoordinates = -Vector2.Zero;
        private int _selectedMapId = -1;
        private int _selectedOriginDirection;
        private int _selectedTargetDirection;

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

        public int SelectedOriginDirection
        {
            get => _selectedOriginDirection;
            private set
            {
                _selectedOriginDirection = value;
                BeforeDirectionBox.SelectedItem = BeforeDirectionBox.Items[value];
            }
        }

        public int SelectedTargetDirection
        {
            get => _selectedTargetDirection;
            private set
            {
                _selectedTargetDirection = value;
                AfterDirectionBox.SelectedItem = AfterDirectionBox.Items[value];
            }
        }

        public MapBorderComponentPanel(Type componentType) : base(componentType)
        {
            InitializeComponent();
        }

        public override void Initialize(Entity entity)
        {
            Entity = entity;

            if (entity.GetIfHasComponent(out MapBorderComponent border))
            {
                SelectedMapId = border.TargetMap;
                SelectedCoordinates = border.Target;
                SelectedOriginDirection = border.OriginDirection;
                SelectedTargetDirection = border.TargetDirection;
            }
            else
            {
                SelectedMapId = 0;
                SelectedCoordinates = Vector2.Zero;
                SelectedOriginDirection = 0;
                SelectedTargetDirection = 0;
            }
        }

        public override void Save()
        {
            _borderComponent = Entity.GetOrCreateComponent<MapBorderComponent>();
            var transform = Entity.GetComponent<TransformComponent>();
            _borderComponent.OriginMap = transform.CurrentMap;
            _borderComponent.Origin = transform.GridTransform;

            _borderComponent.Target = SelectedCoordinates;
            _borderComponent.TargetMap = SelectedMapId;
            _borderComponent.OriginDirection = SelectedOriginDirection;
            _borderComponent.TargetDirection = SelectedTargetDirection;
        }

        public override void Unload(Entity entity)
        {
            
        }

        private void SelectDestinationButton_Click(object sender, EventArgs e)
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

        private void BeforeDirectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedOriginDirection = BeforeDirectionBox.SelectedIndex;
        }

        private void AfterDirectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedTargetDirection = AfterDirectionBox.SelectedIndex;
        }
    }
}
