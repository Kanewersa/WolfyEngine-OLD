using System;
using System.Windows.Forms;
using WolfyCore.Actions;
using WolfyCore.Controllers;

namespace WolfyEngine.Forms
{
    public partial class ChangeBGMActionForm : BaseActionForm
    {
        public ChangeBGMActionForm()
        {
            InitializeComponent();
        }

        protected override WolfyAction CreateAction()
        {
            return new ChangeBGMAction(Entity,
                                       AssetTextBox.Text,
                                       (int)VolumeBox.Value,
                                       RepeatCheckBox.Checked);
        }

        protected override bool ValidateAction()
        {
            if (string.IsNullOrWhiteSpace(AssetTextBox.Text)
                || VolumeBox.Value < 0
                || VolumeBox.Value > 100)
            {
                return false;
            }

            return true;
        }

        public override void LoadAction(WolfyAction action)
        {
            var bgm = (ChangeBGMAction) action;

            AssetTextBox.Text = bgm.SongTitle;
            VolumeBox.Value = bgm.Volume;
            RepeatCheckBox.Checked = bgm.IsRepeating;
        }

        private void OpenAssetSelectionForm(object sender, EventArgs e)
        {
            using var form = new AssetSelectForm(PathsController.Instance.BgmPath);
            form.OnAssetSelected += Form_OnAssetSelected;
            form.ShowDialog();
        }

        private void Form_OnAssetSelected(string assetName, string fullPath, string extension)
        {
            AssetTextBox.Text = assetName;
        }

        private void AssetTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenAssetSelectionForm(sender, e);
        }
    }
}
