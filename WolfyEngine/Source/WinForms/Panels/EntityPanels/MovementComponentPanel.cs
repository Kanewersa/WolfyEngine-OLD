using System;
using DarkUI.Docking;
using WolfyECS;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyCore.Engine.Exceptions;
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

                if (entity.HasComponent<InputComponent>())
                {
                    // Keyboard-controlled entity is a special case of movement type
                    MovementTypeBox.SelectedIndex = MovementTypeBox.Items.IndexOf(MovementTypeBox.Items[MovementTypeBox.Items.Count - 1]);
                    return;
                }

                LoadMovementType(_movementComponent.MovementType);
            }
            else
            {
                // Random movement is default movement type
                MovementTypeBox.SelectedIndex =
                    MovementTypeBox.FindStringExact(MovementType.Random.ToString());
                SpeedNumericUpDown.Value = 5;
                FrequencyNumericUpDown.Value = 5;
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
                    _followMovementComponent = Entity.GetOrCreateComponent<FollowMovementComponent>();
                    FollowRangeNumericUpDown.Enabled = true;
                    FollowRangeNumericUpDown.Value = _followMovementComponent.Range;
                    break;
                case MovementType.UserControlled:
                    MovementTypeBox.Enabled = false;
                    FollowRangeNumericUpDown.Enabled = false;
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
            _movementComponent = Entity.GetOrCreateComponent<MovementComponent>();

            //_movementComponent.Frequency = (float)FrequencyNumericUpDown.Value;
            _movementComponent.Speed = (float)SpeedNumericUpDown.Value;
            _movementComponent.MovementType = (MovementType) MovementTypeBox.SelectedValue;

            switch (_movementComponent.MovementType)
            {
                case MovementType.Follow:
                {
                    _followMovementComponent = Entity.GetOrCreateComponent<FollowMovementComponent>();

                    _followMovementComponent.Range = (int) FollowRangeNumericUpDown.Value;

                    Entity.RemoveIfHasComponent<RandomMovementComponent>();
                    Entity.RemoveIfHasComponent<FixedMovementComponent>();
                    break;
                }
                case MovementType.Random:
                    _randomMovementComponent = Entity.GetOrCreateComponent<RandomMovementComponent>();

                    Entity.RemoveIfHasComponent<FollowMovementComponent>();
                    Entity.RemoveIfHasComponent<FixedMovementComponent>();
                    break;
                case MovementType.Fixed:
                    _fixedMovementComponent = Entity.GetOrCreateComponent<FixedMovementComponent>();

                    Entity.RemoveIfHasComponent<FollowMovementComponent>();
                    Entity.RemoveIfHasComponent<RandomMovementComponent>();
                    // TODO Implement fixed movement
                    break;
                case MovementType.UserControlled:
                    if (!Entity.HasComponent<InputComponent>())
                        throw new WolfyEcsException("User controlled entity doesn't have InputComponent.");
                    Entity.RemoveIfHasComponent<FollowMovementComponent>();
                    Entity.RemoveIfHasComponent<RandomMovementComponent>();
                    Entity.RemoveIfHasComponent<FixedMovementComponent>();
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
