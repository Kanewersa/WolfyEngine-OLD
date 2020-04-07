using System;
using DarkUI.Docking;
using WolfyECS;
using WolfyShared.ECS;
using WolfyShared.Engine;

namespace WolfyEngine.Controls
{
    public partial class MovementComponentPanel : ComponentPanel
    {
        private MovementComponent _movementComponent;
        private RoutineMovementComponent _routineMovementComponent;

        public MovementComponentPanel()
        {
            InitializeComponent();
            MovementTypeBox.DataSource = Enum.GetValues(typeof(MovementType));
        }

        public override void Initialize(Entity entity)
        {
            _movementComponent = entity.AddComponent<MovementComponent>();
            _routineMovementComponent = entity.AddComponent<RoutineMovementComponent>();
        }

        public override void Unload(Entity entity)
        {
            entity.RemoveComponent<MovementComponent>();
            Close();
        }

        private void MovementTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set movement type here
            // TODO Add different movement types
        }

        private void FrequencyNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _routineMovementComponent.MovementFrequency = 
                (float)FrequencyNumericUpDown.Value;
        }

        private void SpeedNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _movementComponent.Speed = (float)SpeedNumericUpDown.Value;
        }
    }
}
