using System;
using Microsoft.Xna.Framework;
using WolfyCore;
using WolfyCore.Controllers;
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
        private bool _worksBothWays;

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

        public bool WorksBothWays
        {
            get => _worksBothWays;
            private set
            {
                _worksBothWays = value;
                BothWaysCheckBox.Checked = value;
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

                // TODO: Initialize target map or keep entities by grid transform (not in a list).
                var targetMap = MapsController.Instance.GetMap(border.TargetMap);
                targetMap.Initialize(null);
                var targetEntity = targetMap.GetEntity(SelectedCoordinates);
                if (targetEntity != Entity.Empty && targetEntity.GetIfHasComponent(out MapBorderComponent targetBorder))
                {
                    if (targetBorder.TargetMap == border.OriginMap
                        && targetBorder.Target == border.Origin)
                    {
                        BothWaysCheckBox.Checked = true;
                    }
                }
            }
            else
            {
                SelectedMapId = 0;
                SelectedCoordinates = Vector2.Zero;
                SelectedOriginDirection = 0;
                SelectedTargetDirection = 0;
                BothWaysCheckBox.Checked = true;
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

            // Add teleport target map to the list of neighbors.
            var neighbors = transform.GetMap().Neighbors;
            if (!neighbors.ContainsKey(transform.GridTransform))
                neighbors.Add(transform.GridTransform, SelectedMapId);

            if (WorksBothWays)
            {
                var targetMap = MapsController.Instance.GetMap(SelectedMapId);
                targetMap.Initialize(null);
                var targetEntity = targetMap.GetEntity(SelectedCoordinates);
                if (targetEntity == Entity.Empty)
                {
                    targetEntity = World.WorldInstance.CreateEntity();
                    targetMap.AddEntity(targetEntity, SelectedCoordinates);
                    targetEntity.AddComponent(new InGameNameComponent("Map border"));
                }

                var newMapBorder = targetEntity.GetOrCreateComponent<MapBorderComponent>();
                newMapBorder.Origin = _borderComponent.Target;
                newMapBorder.OriginMap = _borderComponent.TargetMap;
                newMapBorder.OriginDirection = Direction.Reverse(_borderComponent.TargetDirection);
                newMapBorder.Target = _borderComponent.Origin;
                newMapBorder.TargetMap = _borderComponent.OriginMap;
                newMapBorder.TargetDirection = Direction.Reverse(_borderComponent.OriginDirection);

                var newTransform = targetEntity.GetOrCreateComponent<TransformComponent>();
                newTransform.GridTransform = SelectedCoordinates;
                newTransform.Transform = SelectedCoordinates * Runtime.GridSize;
                newTransform.CurrentMap = SelectedMapId;

                neighbors = targetMap.Neighbors;
                if (!neighbors.ContainsKey(_borderComponent.Target))
                    neighbors.Add(_borderComponent.Target, _borderComponent.OriginMap);
            }
        }

        public override void Unload(Entity entity)
        {
            entity.RemoveComponent<MapBorderComponent>();

            // Remove teleport target map from the list of neighbors.
            var transform = entity.GetComponent<TransformComponent>();
            transform.GetMap().Neighbors.Remove(transform.GridTransform);

            Close();
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

        private void BothWaysCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WorksBothWays = BothWaysCheckBox.Checked;
        }
    }
}
