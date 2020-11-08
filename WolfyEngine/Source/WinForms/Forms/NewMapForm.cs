using System;
using System.Windows.Forms;
using WolfyCore.Controllers;
using WolfyEngine.Controls;
using WolfyCore.Engine;
using WolfyCore.Game;

namespace WolfyEngine.Forms
{
    public partial class NewMapForm : WolfyForm
    {
        public event MapEventHandler OnMapCreate;
        private string BackgroundMusicPath { get; set; }

        public NewMapForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void CreateButton_Click(object sender, System.EventArgs e)
        {
            // Create new map here!
            var name = nameTextBox.Text;
            var width = (int) widthBox.Value;
            var height = (int) heightBox.Value;

            var map = new Map(name, new Vector2D(width,height));
            
            if(!string.IsNullOrEmpty(BackgroundMusicPath))
                map.BackgroundMusic = new Sound(BackgroundMusicPath, 1, true);

            OnMapCreate?.Invoke(map);

            Close();
        }

        private void SelectBGMAsset(object sender, MouseEventArgs e)
        {
            using (var form = new AssetSelectForm(PathsController.Instance.BgmPath))
            {
                form.OnAssetSelected += delegate(string name, string path, string relativePath, string extension)
                {
                    BGMTextBox.Text = name;
                    BackgroundMusicPath = relativePath;
                };
                form.ShowDialog();
            }
        }
    }
}
