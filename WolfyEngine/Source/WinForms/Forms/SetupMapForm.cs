using System;
using System.Windows.Forms;
using WolfyCore.Controllers;
using WolfyEngine.Controls;
using WolfyCore.Engine;
using WolfyCore.Game;

namespace WolfyEngine.Forms
{
    public partial class SetupMapForm : WolfyForm
    {
        public event MapEventHandler OnMapSave;
        private string BackgroundMusicPath { get; set; }
        private bool MapExists { get; set; }
        private int MapId { get; set; }

        public SetupMapForm(int mapId = -1)
        {
            InitializeComponent();
            MapId = mapId;
            MapExists = mapId != -1;

            if (MapExists)
            {
                var map = MapsController.Instance.GetMap(mapId);
                WidthBox.Enabled = false;
                HeightBox.Enabled = false;
                WidthBox.Value = map.Size.X;
                HeightBox.Value = map.Size.Y;
                NameTextBox.Text = map.Name;
                if (map.BackgroundMusic != null)
                {
                    BGMTextBox.Text = map.BackgroundMusic.AudioFile;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveMap(object sender, EventArgs e)
        {
            var name = NameTextBox.Text;
            var width = (int) WidthBox.Value;
            var height = (int) HeightBox.Value;

            Map map;

            if (MapsController.Instance.MapExists(MapId))
            {
                map = MapsController.Instance.GetMap(MapId);
                map.Name = name;
                MapsController.Instance.MapsData.SetMapName(map.Id, name);
            }
            else
            {
                map = new Map(name, new Vector2D(width, height));
                MapsController.Instance.AddMap(map);
            }

            map.BackgroundMusic = string.IsNullOrEmpty(BackgroundMusicPath)
                ? null
                : new Sound(BackgroundMusicPath, 1, true);

            OnMapSave?.Invoke(map);

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
