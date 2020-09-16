using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyCore.Controllers;
using WolfyCore.Engine;
using WolfyCore.Game;

namespace WolfyEngine.Forms
{
    public partial class NewLayerForm : WolfyForm
    {
        private Dictionary<DarkListItem, int> _nodeKeys;
        private int _selectedTileset = -1;
        private Map _currentMap;
        private int _selectedLayerOrder;

        public event LayerEventHandler OnLayerCreate;

        public NewLayerForm(Map map, int selectedLayerOrder)
        {
            _currentMap = map;
            _selectedLayerOrder = selectedLayerOrder;

            InitializeComponent();

            _nodeKeys = new Dictionary<DarkListItem, int>();

            // Load list items from tileset data
            var tilesets = TilesetsController.Instance.TilesetsData.Info;

            foreach (var pair in tilesets)
            {
                var item = new DarkListItem(pair.Value.TilesetName);
                tilesetsListView.Items.Add(item);
                _nodeKeys.Add(item, pair.Key);
            }
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void createButton_Click(object sender, System.EventArgs e)
        {
            if (_selectedTileset == -1)
            {
                DarkMessageBox.ShowWarning(
                    "Select the tileset graphics",
                    "No tileset graphics");
                return;
            }

            var layer = new TileLayer(nameTextBox.Text, _currentMap.Size, _selectedTileset)
            {
                Order = _currentMap.Layers.Count + 1
            };

            _currentMap.Layers.Insert(_selectedLayerOrder, layer);
            OnLayerCreate?.Invoke(layer);
            
            Close();
        }

        private void tilesetsListView_Click(object sender, EventArgs e)
        {
            if (!tilesetsListView.SelectedIndices.Any() || !tilesetsListView.Items.Any()) return;

            _selectedTileset = _nodeKeys[tilesetsListView.Items[tilesetsListView.SelectedIndices[0]]];

            // Get tileset image path to display it in image box
            var path = TilesetsController.Instance.TilesetsData.Info[_selectedTileset].GraphicsPath;

            var extension = Path.GetExtension(path);

            using (var temp = new Bitmap(path))
            {
                var img = new Bitmap(temp);
                graphicsPreviewBox.Image = extension == ".png" ? img : null;
            }
        }
    }
}
