using System;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
using WolfyEngine.Forms;
using WolfyShared.Controllers;
using WolfyShared.Engine;
using WolfyShared.Game;

namespace WolfyEngine.Controls
{
    public partial class LayersPanel : DarkToolWindow
    {
        private Map _currentMap;

        public event LayerEventHandler OnLayerChanged;

        public BaseLayer SelectedLayer { get; private set; }

        public LayersPanel()
        {
            InitializeComponent();
        }

        public void LoadMap(Map map)
        {
            _currentMap = map;
            if (map == null)
            {
                toolStrip.Enabled = false;
                layersTree.Nodes.Clear();
                layersTree.Refresh();
                return;
            }
            BuildTree(map);
            toolStrip.Enabled = true;
        }

        private void BuildTree(Map map)
        {
            layersTree.Nodes.Clear();

            var mainNode = new DarkTreeNode("Layers");
            layersTree.Nodes.Add(mainNode);

            foreach (var layer in map.Layers)
            {
                mainNode.Nodes.Add(new DarkTreeNode(layer.Order + ": " + layer.Name));
            }

            mainNode.Expanded = true;
        }

        private void RefreshTree(Map map)
        {
            layersTree.Nodes.Clear();
            BuildTree(map);
        }

        private void LayersTree_Click(object sender, EventArgs e)
        {
            // Return if user clicked empty space in tree view
            if (layersTree.SelectedNodes.Count < 1)
                return;

            var clickedNode = layersTree.SelectedNodes[0];

            // If user clicked main node
            if (clickedNode == layersTree.Nodes[0])
            {
                // Invoke null to hide tileset control
                OnLayerChanged?.Invoke(null);
            }
            // If user clicked one of the sub nodes
            else
            {
                // Load the selected layer
                var index = clickedNode.VisibleIndex;
                SelectedLayer = _currentMap.Layers[index - 1];
                OnLayerChanged?.Invoke(SelectedLayer);
            }
        }

        private void NewLayerButton_Click(object sender, EventArgs e)
        {
            if (TilesetsController.Instance.TilesetsData.Info.Count == 0)
            {
                DarkMessageBox.ShowWarning(
                    "Create the tileset first!",
                    "No available tilesets.");
                return;
            }

            if (_currentMap.Layers.Count > 9)
            {
                DarkMessageBox.ShowWarning(
                    "There can't be more than 10 layers!",
                    "Layers limit reached.");
                return;
            }

            using var form = new NewLayerForm(_currentMap);
            form.OnLayerCreate += delegate(BaseLayer layer)
            {
                OnLayerChanged?.Invoke(layer);
                RefreshTree(_currentMap);
            };
            form.ShowDialog();
        }

        private void MoveLayerUp(object sender, EventArgs e)
        {
            if (SelectedLayer == null) return;

            // Do nothing if there is only one layer
            if (_currentMap.Layers.Count == 1) return;

            // Do nothing if selected layer is currently first
            if (SelectedLayer.Order == 1) return;
            _currentMap.Layers[SelectedLayer.Order-2].Order += 1;
            SelectedLayer.Order -= 1;
            SortLayers();
        }

        private void MoveLayerDown(object sender, EventArgs e)
        {
            if (SelectedLayer == null) return;

            // Do nothing if there is only one layer
            if (_currentMap.Layers.Count == 1) return;

            // Do nothing if selected layer is currently last
            if (SelectedLayer.Order == 10
                || SelectedLayer == _currentMap.Layers.Last()) return;

            _currentMap.Layers[SelectedLayer.Order].Order -= 1;
            SelectedLayer.Order += 1;
            SortLayers();
        }

        private void SortLayers()
        {
            _currentMap.Layers = _currentMap.Layers.OrderBy(x => x.Order).ToList();
            RefreshTree(_currentMap);
        }

        private void RemoveSelectedLayer(object sender, EventArgs e)
        {
            if (SelectedLayer == null) return;

            if (SelectedLayer is EntityLayer)
            {
                var count = _currentMap.Layers.Count(x => x is EntityLayer);
                if (count == 1)
                {
                    DarkMessageBox.ShowWarning(
                        "There must always be at least one entity layer.",
                        "Entity layer count");
                    return;
                }
            }

            var result = DarkMessageBox.ShowInformation(
                "Are you sure you want to delete this layer?",
                "Are you sure?",
                DarkDialogButton.YesNo);

            if (result == DialogResult.Yes)
            {
                _currentMap.Layers.Remove(SelectedLayer);
                RefreshTree(_currentMap);
                OnLayerChanged?.Invoke(null);
            }
        }
    }
}
