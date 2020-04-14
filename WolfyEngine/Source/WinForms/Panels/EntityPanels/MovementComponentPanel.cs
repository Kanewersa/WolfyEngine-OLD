using System;
using DarkUI.Docking;
using WolfyECS;
using WolfyShared.ECS;
using WolfyShared.Engine;
using Random = System.Random;

namespace WolfyEngine.Controls
{
    public partial class MovementComponentPanel : ComponentPanel
    {
        private MovementComponent _movementComponent;
        private RandomMovementComponent _randomMovementComponent;
        private FollowMovementComponent _followMovementComponent;
        private FixedMovementComponent _fixedMovementComponent;

        public MovementComponentPanel()
        {
            InitializeComponent();
            MovementTypeBox.DataSource = Enum.GetValues(typeof(MovementType));
        }

        public override void Initialize(Entity entity)
        {
            Entity = entity;

            if (entity.HasComponent<MovementComponent>())
            {
                // Fill values in editor with parameters of existing MovementComponent
                _movementComponent = entity.GetComponent<MovementComponent>();

                MovementTypeBox.SelectedIndex =
                    MovementTypeBox.FindStringExact(_movementComponent.MovementType.ToString());
                SpeedNumericUpDown.Value = (decimal) _movementComponent.Speed;
                FrequencyNumericUpDown.Value = (decimal) _movementComponent.Frequency;

                LoadMovementType(_movementComponent.MovementType);
            }
            else
            {
                // Random movement is default movement type
                MovementTypeBox.SelectedIndex =
                    MovementTypeBox.FindStringExact(MovementType.Random.ToString());
                SpeedNumericUpDown.Value = 0;
                FrequencyNumericUpDown.Value = 0;
                LoadMovementType(MovementType.Random);
            }
        }

        private void LoadMovementType(MovementType movementType)
        {
            switch (movementType)
            {
                case MovementType.Random:
                    FollowRangeNumericUpDown.Enabled = false;
                    break;
                case MovementType.Fixed:
                    FollowRangeNumericUpDown.Enabled = false;
                    break;
                case MovementType.Follow:
                    _followMovementComponent = Entity.GetIfHasComponent<FollowMovementComponent>();
                    FollowRangeNumericUpDown.Enabled = true;
                    FollowRangeNumericUpDown.Value = _followMovementComponent.Range;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Unload(Entity entity)
        {
            entity.RemoveComponent<MovementComponent>();
            Close();
        }

        public override void Save()
        {
            _movementComponent = Entity.GetIfHasComponent<MovementComponent>();

            _movementComponent.Frequency = (float)FrequencyNumericUpDown.Value;
            _movementComponent.Speed = (float)SpeedNumericUpDown.Value;
            _movementComponent.MovementType = (MovementType) MovementTypeBox.SelectedValue;

            switch (_movementComponent.MovementType)
            {
                case MovementType.Follow:
                {
                    _followMovementComponent = Entity.GetIfHasComponent<FollowMovementComponent>();

                    _followMovementComponent.Range = (int) FollowRangeNumericUpDown.Value;

                    Entity.RemoveIfHasComponent<RandomMovementComponent>();
                    Entity.RemoveIfHasComponent<FixedMovementComponent>();
                    break;
                }
                case MovementType.Random:
                    _randomMovementComponent = Entity.GetIfHasComponent<RandomMovementComponent>();

                    Entity.RemoveIfHasComponent<FollowMovementComponent>();
                    Entity.RemoveIfHasComponent<FixedMovementComponent>();
                    break;
                case MovementType.Fixed:
                    _fixedMovementComponent = Entity.GetIfHasComponent<FixedMovementComponent>();

                    Entity.RemoveIfHasComponent<FollowMovementComponent>();
                    Entity.RemoveIfHasComponent<RandomMovementComponent>();
                    // TODO Implement fixed movement
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown movement type");
            }
        }

        private void MovementTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = (MovementType) MovementTypeBox.SelectedValue;
            LoadMovementType(type);
        }
    }
}
