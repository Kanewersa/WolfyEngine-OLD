using System.Drawing;
using System.IO;
using DarkUI.Forms;
using WolfyShared.Controllers;
using WolfyShared.Game;

namespace WolfyEngine.Forms
{
    public partial class NewTilesetForm : DarkForm
    {
        private string _selectedAsset;

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

        private void Form_OnAssetSelected(string str)
        {
            var fullPath = Path.Combine(PathsController.Instance.TilesetsGraphicsPath, str);

            var extension = Path.GetExtension(fullPath);

            using (var temp = new Bitmap(fullPath))
            {
                var img = new Bitmap(temp);
                graphicsPreviewBox.Image = extension == ".png" ? img : null;
            }


            _selectedAsset = fullPath;
        }

        private void CreateButton_Click(object sender, System.EventArgs e)
        {
            if (_selectedAsset == null)
            {
                DarkMessageBox.ShowWarning(
                    "Select the tileset graphics",
                    "No tileset graphics");
                return;
            }

            var tileset = new Tileset(
                nameTextBox.Text,
                ProjectsController.Instance.CurrentProject.TileSize,
                _selectedAsset);

            TilesetsController.Instance.AddTileset(tileset);

            Close();
        }
    }
}
