using WolfyCore.Actions;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class NewActionsListDisplay : ListDisplay
    {
        public NewActionsListDisplay()
        {
            InitializeComponent();
        }

        #region Movement Actions

        private void TeleportButton_Click(object sender, System.EventArgs e)
        {
            using (var form = new TeleportActionForm())
            {
                form.Initialize(Entity);
                form.OnSave += InvokeOnSelect;
                form.ShowDialog();
            }
        }

        private void MoveEntityButton_Click(object sender, System.EventArgs e)
        {

        }

        #endregion

        #region Camera actions

        private void CameraTargetButton_Click(object sender, System.EventArgs e)
        {

        }

        private void ZoomButton_Click(object sender, System.EventArgs e)
        {

        }

        private void CameraOverlayButton_Click(object sender, System.EventArgs e)
        {

        }

        private void FadeCameraButton_Click(object sender, System.EventArgs e)
        {
            using (var form = new CameraFadeActionForm())
            {
                form.Initialize(Entity);
                form.OnSave += InvokeOnSelect;
                form.ShowDialog();
            }
        }

        #endregion

        #region Other actions

        private void StartDialogButton_Click(object sender, System.EventArgs e)
        {
            using (var form = new StartDialogForm())
            {
                form.Initialize(Entity);
                form.OnSave += InvokeOnSelect;
                form.ShowDialog();
            }
        }

        #endregion
    }
}
