using System;
using System.Drawing;
using System.IO;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyCore.Engine;

namespace WolfyEngine.Forms
{
    public partial class AssetSelectForm : DarkForm
    {
        private string AssetsPath { get; set; }
        private bool CorrectAsset { get; set; }

        public event AssetPathHandler OnAssetSelected;

        public AssetSelectForm(string assetsPath)
        {
            InitializeComponent();
            AssetsPath = assetsPath;
            LoadAssetsFromPath(assetsPath);
        }

        private void LoadAssetsFromPath(string path)
        {
            Directory.CreateDirectory(path);
            var directory = new DirectoryInfo(path);

            var extension = "*.png";
            var files = directory.GetFiles("*.png");

            //Clear files tree view
            FilesListView.Items.Clear();
            FilesListView.Refresh();

            foreach (var file in Directory.EnumerateFiles(path, extension, SearchOption.TopDirectoryOnly))
            {
                var compiled = "{name}.xnb";
                var found = path + "\\" + compiled.Replace("{name}", Path.GetFileNameWithoutExtension(file));

                if (File.Exists(found))
                    FilesListView.Items.Add(new DarkListItem(Path.GetFileName(file)));
                else
                {
                    var item = new DarkListItem(Path.GetFileName(file)) { TextColor = Color.IndianRed };
                    FilesListView.Items.Add(item);
                }
            }
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
            if (!FilesListView.SelectedIndices.Any())
            {
                DarkMessageBox.ShowWarning(
                    "Select the asset in the tree view first.",
                    "No asset selected.");
                return;
            }

            var assetName = FilesListView.Items[FilesListView.SelectedIndices[0]].Text;
            var fullPath = Path.Combine(AssetsPath, assetName);
            var extension = Path.GetExtension(fullPath);

            // Check if asset is correct (if it has .xnb counterpart)
            var counterpart = Path.ChangeExtension(fullPath, ".xnb");
            if (!File.Exists(counterpart))
            {
                DarkMessageBox.ShowWarning(
                    "The possible reason is that your asset was added to the project manually." +
                    "Restore the asset using Asset Manager.",
                    "Selected asset was not compiled by Asset Manager.");
                return;
            }

            OnAssetSelected?.Invoke(assetName, fullPath, extension);
            Close();
        }

        private void FilesListView_Click(object sender, EventArgs e)
        {
            if (!FilesListView.SelectedIndices.Any())
                return;

            PreviewFile(
                Path.Combine(AssetsPath, FilesListView.Items[FilesListView.SelectedIndices[0]].Text));
        }

        private void FilesListView_DoubleClick(object sender, EventArgs e)
        {
            if (!FilesListView.SelectedIndices.Any()) return;
            SelectButton_Click(sender, e);
        }

        private void AssetManagerButton_Click(object sender, EventArgs e)
        {
            using var assetForm = new AssetManagerForm();
            assetForm.Closed += delegate
            {
                LoadAssetsFromPath(AssetsPath);
            };
            assetForm.ShowDialog();
        }
    }
}
