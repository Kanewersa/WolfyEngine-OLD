using System;
using System.Drawing;
using System.IO;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyShared.Engine;

namespace WolfyEngine.Forms
{
    public partial class AssetSelectForm : DarkForm
    {
        private string _assetsPath;

        public event StringEventHandler OnAssetSelected;

        public AssetSelectForm(string assetsPath)
        {
            InitializeComponent();
            _assetsPath = assetsPath;
            LoadAssetsFromPath(assetsPath);
        }

        private void LoadAssetsFromPath(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Directory.CreateDirectory(path);
            var directory = new DirectoryInfo(path);

            var files = directory.GetFiles("*.png");

            //Clear files tree view
            filesTreeView.Refresh();

            //Fill files tree view with files
            foreach (var file in files)
                filesTreeView.Nodes.Add(new DarkTreeNode(file.Name));
        }

        private void filesTreeView_Click(object sender, EventArgs e)
        {
            if (!filesTreeView.SelectedNodes.Any() || filesTreeView.SelectedNodes[0] == null) return;
            
            PreviewFile(
                Path.Combine(_assetsPath, filesTreeView.SelectedNodes[0].Text));
        }

        private void PreviewFile(string path)
        {
            var extension = Path.GetExtension(path);

            using (var temp = new Bitmap(path))
            {
                var img = new Bitmap(temp);
                previewBox.Image = extension == ".png" ? img : null;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            // Return if no asset was selected
            if (filesTreeView.SelectedNodes[0] == null)
            {
                DarkMessageBox.ShowWarning(
                    "Select the asset in the tree view first",
                    "No asset selected");
                return;
            }

            //Get current asset path
            var assetName = filesTreeView.SelectedNodes[0].FullPath;
            OnAssetSelected?.Invoke(assetName);
            Close();
        }
    }
}
