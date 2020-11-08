using System;
using System.Drawing;
using System.IO;
using DarkUI.Forms;
using WolfyCore;
using WolfyCore.Controllers;
using WolfyCore.Game;

namespace WolfyEngine.Forms
{
    public partial class NewTilesetForm : WolfyForm
    {
        private string _selectedAsset;
        private string _assetExtension;

        public NewTilesetForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void SelectGraphicsButton_Click(object sender, System.EventArgs e)
        {
            using var form = new AssetSelectForm(PathsController.Instance.TilesetsGraphicsPath);
            form.OnAssetSelected += Form_OnAssetSelected;
            form.ShowDialog();
        }

        private void Form_OnAssetSelected(string assetName, string fullPath, string relativePath, string extension)
        {
            using (var temp = new Bitmap(fullPath))
            {
                var img = new Bitmap(temp);
                graphicsPreviewBox.Image = extension == ".png" ? img : null;
            }

            _selectedAsset = relativePath;
            _assetExtension = extension;
        }

        private void CreateButton_Click(object sender, System.EventArgs e)
        {
            if (_selectedAsset == null)
            {
                DarkMessageBox.ShowWarning(
                    "Select the tileset graphics.",
                    "No tileset graphics");
                return;
            }

            var tileset = new Tileset(
                nameTextBox.Text,
                _selectedAsset,
                _assetExtension);

            TilesetsController.Instance.AddTileset(tileset);

            Close();
        }
    }
}
