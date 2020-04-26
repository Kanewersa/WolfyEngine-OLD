using System.Collections.Generic;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Docking;
using WolfyEngine.Forms;
using WolfyShared;
using WolfyShared.Controllers;
using WolfyShared.Game;

namespace WolfyEngine.Controls
{
    public delegate void TilesetEventHandler(Tileset tileset);
    public partial class TilesetsPanel : DarkToolWindow
    {
        public event TilesetEventHandler OnTilesetSelected;

        private Tileset _currentTileset;

        private Dictionary<DarkTreeNode, int> _nodeKeys;

        public TilesetsPanel()
        {
            InitializeComponent();
            _nodeKeys = new Dictionary<DarkTreeNode, int>();
        }

        private void BuildTree()
        {
            // Create main node
            var mainNode = new DarkTreeNode("Tilesets");
            tilesetsTree.Nodes.Add(mainNode);
            //MapsController.Instance.MapsData.Info
            // Load sub nodes
            foreach (var info in TilesetsController.Instance.TilesetsData.Info)
            {
                var node = new DarkTreeNode(info.Value.TilesetName);
                _nodeKeys.Add(node, info.Key);
                mainNode.Nodes.Add(node);
            }

            mainNode.Expanded = true;
        }

        private void RefreshTree()
        {
            tilesetsTree.Nodes.Clear();
            _nodeKeys.Clear();
            BuildTree();
        }

        private void TreeViewClicked(object sender, System.EventArgs e)
        {
            // Return if user clicked empty space in tree view
            if (!tilesetsTree.SelectedNodes.Any())
                return;

            var clickedNode = tilesetsTree.SelectedNodes[0];
            
            // If user clicked main node
            if (clickedNode == tilesetsTree.Nodes[0])
            {
                //Invoke null to unload controls
                OnTilesetSelected?.Invoke(null);
            }
            // If user clicked one of the sub nodes
            else
            {
                // Load the tileset with given id
                var tileset = TilesetsController.Instance.GetTileset(_nodeKeys[clickedNode]);
                OnTilesetSelected?.Invoke(tileset);
            }
        }

        private void NewTilesetButton_Click(object sender, System.EventArgs e)
        {
            using (var form = new NewTilesetForm())
            {
                form.ShowDialog();
            }

            RefreshTree();
        }

        private void refreshTreeButton_Click(object sender, System.EventArgs e)
        {
            RefreshTree();
        }

        public void InitializeProject(Project project)
        {
            if (project == null)
            {
                toolStrip.Enabled = false;
                return;
            }

            RefreshTree();
            toolStrip.Enabled = true;
        }
    }
}
