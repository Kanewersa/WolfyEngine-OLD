﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Docking;
using Microsoft.Xna.Framework;
using WolfyEngine.Forms;
using WolfyCore.Controllers;
using WolfyCore.ECS;
using WolfyCore.Game;

namespace WolfyEngine.Controls
{
    public delegate void MapEventHandler(Map map);

    public partial class MapsPanel : DarkToolWindow
    {
        private readonly Dictionary<DarkTreeNode, int> _nodeKeys;

        public event MapEventHandler OnMapChanged;
        public int LastMap { get; private set; } = -1;

        public MapsPanel()
        {
            InitializeComponent();
            _nodeKeys = new Dictionary<DarkTreeNode, int>();
        }

        public void Initialize(bool disableByDefault = false, bool displayToolStrip = true)
        {
            if (!displayToolStrip)
            {
                ToolStrip.Hide();
            }

            if (disableByDefault)
            {
                ToolStrip.Enabled = false;
                return;
            }

            RefreshTree();
            ToolStrip.Enabled = true;
        }


        private void BuildTree()
        {
            // Create main node
            var mainNode = new DarkTreeNode("Maps");
            mapsTree.Nodes.Add(mainNode);
            
            // Load sub nodes
            foreach (var info in MapsController.Instance.GetMapsInfo())
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

        private void TreeViewClicked(object sender, EventArgs e)
        {
            // Return if user clicked empty space in tree view.
            if (mapsTree.SelectedNodes.Count < 1)
                return;

            var clickedNode = mapsTree.SelectedNodes[0];

            // If user clicked main node
            if (clickedNode == mapsTree.Nodes[0])
            {
                // Invoke null to unload controls.
                OnMapChanged?.Invoke(null);
            }
            // If user clicked one of the sub nodes
            else
            {
                // Load the map with given id.
                var map = MapsController.Instance.GetMap(_nodeKeys[clickedNode]);
                OnMapChanged?.Invoke(map);
            }
        }

        private void RefreshTreeButton_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void NewMapButton_Click(object sender, EventArgs e)
        {
            using var form = new SetupMapForm();
            form.OnMapSave += FormOnMapSave;
            form.ShowDialog();
        }

        private void FormOnMapSave(Map map)
        {
            RefreshTree();
            mapsTree.Nodes[0].Expanded = true;

            if (MapsController.Instance.MapsData.GetMapsInfo().Count == 1)
            {
                map.LoadEntities();
                map.AddEntity(Entities.Player, Vector2.Zero);
            }

            mapsTree.SelectNode(mapsTree.Nodes[0].Nodes.Last());
            OnMapChanged?.Invoke(map);
        }

        private int SelectedMapId { get; set; } = -1;

        private void TreeViewMouseClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Return if user clicked empty space in tree view.
                if (mapsTree.SelectedNodes.Count < 1)
                    return;

                SelectedMapId = _nodeKeys[mapsTree.SelectedNodes[0]];
                MapContextMenu.Show(PointToScreen(e.Location));
            }
        }

        private void EditMap(object sender, EventArgs e)
        {
            if (SelectedMapId == -1) return;

            using (var form = new SetupMapForm(SelectedMapId))
            {
                form.ShowDialog();
            }
        }

        private void RemoveMap(object sender, EventArgs e)
        {
            if (SelectedMapId == -1) return;

            var map = MapsController.Instance.GetMap(SelectedMapId);
            // TODO: Remove map here!
        }
    }
}