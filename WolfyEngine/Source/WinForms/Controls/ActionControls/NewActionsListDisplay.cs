using System;
using WolfyCore.Actions;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class NewActionsListDisplay : ListDisplay
    {
        public NewActionsListDisplay(Type componentType) : base(componentType)
        {
            InitializeComponent();
        }

        #region Movement Actions

        private void TeleportButton_Click(object sender, System.EventArgs e)
        {
            OpenForm(new TeleportActionForm());
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
            OpenForm(new CameraFadeActionForm());
        }

        #endregion

        #region Other actions

        private void StartDialogButton_Click(object sender, System.EventArgs e)
        {
            OpenForm(new StartDialogForm());
        }

        private void PlaySongButton_Click(object sender, System.EventArgs e)
        {
            OpenForm(new ChangeBGMActionForm());
        }

        #endregion
    }
}
