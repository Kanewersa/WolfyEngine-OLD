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
    public delegate void MapEventHandler(Map map);

    public partial class MapsPanel : DarkToolWindow
    {
        private string _mapsPath => PathsController.Instance.MapsPath;
        private string _mapsInfoPath => PathsController.Instance.MapsDataPath;

        private Dictionary<DarkTreeNode, int> _nodeKeys;

        public event MapEventHandler OnMapChanged;

        public MapsPanel()
        {
            InitializeComponent();
            _nodeKeys = new Dictionary<DarkTreeNode, int>();
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

        private void BuildTree()
        {
            // Create main node
            var mainNode = new DarkTreeNode("Maps");
            mapsTree.Nodes.Add(mainNode);
            
            // Load sub nodes
            foreach (var info in MapsController.Instance.MapsData.Info)
            {
                var node = new DarkTreeNode(info.Value.MapName);
                _nodeKeys.Add(node, info.Key);
                mainNode.Nodes.Add(node);
            }

            mainNode.Expanded = true;
        }

        private void RefreshTree()
        {
            mapsTree.Nodes.Clear();
            _nodeKeys.Clear();
            BuildTree();
        }

        private void TreeViewClicked(object sender, System.EventArgs e)
        {
            // Return if user clicked empty space in tree view
            if (mapsTree.SelectedNodes.Count < 1)
                return;

            var clickedNode = mapsTree.SelectedNodes[0];

            // If user clicked main node
            if (clickedNode == mapsTree.Nodes[0])
            {
                // Invoke null to unload controls
                OnMapChanged?.Invoke(null);
            }
            // If user clicked one of the sub nodes
            else
            {
                // Load the map with given id
                var map = MapsController.Instance.GetMap(_nodeKeys[clickedNode]);
                OnMapChanged?.Invoke(map);
            }
        }

        private void refreshTreeButton_Click(object sender, System.EventArgs e)
        {
            RefreshTree();
        }

        private void NewMapButton_Click(object sender, System.EventArgs e)
        {
            using var form = new NewMapForm();
            form.OnMapCreate += FormOnOnMapCreate;
            form.ShowDialog();
        }

        private void FormOnOnMapCreate(Map map)
        {
            MapsController.Instance.AddMap(map);
            OnMapChanged?.Invoke(map);
            RefreshTree();
            mapsTree.Nodes[0].Expanded = true;
            mapsTree.SelectNode(mapsTree.Nodes[0].Nodes.Last());
        }
    }
}
