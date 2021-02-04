using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Docking;
using WolfyCore.Controllers;
using WolfyCore.Engine;

namespace WolfyEngine.Forms
{
    public partial class LookupTablesForm : WolfyForm
    {
        private List<LookupSet> LookupData { get; set; }

        private Dictionary<LookupSet, DarkToolWindow> Windows { get; set; }
        //private List<DarkToolWindow> Windows { get; set; }

        public LookupTablesForm()
        {
            InitializeComponent();
            Windows = new Dictionary<LookupSet, DarkToolWindow>();

            LookupData = LookupTablesController.Instance.Data;
            RefreshListView();

            LookupTablesListView.SelectedIndicesChanged += OpenSet;
        }

        private void OpenSet(object sender, EventArgs e)
        {
            if (!LookupTablesListView.SelectedIndices.Any()) return;

            var set = LookupData[LookupTablesListView.SelectedIndices.First()];

            if (Windows.ContainsKey(set))
            {
                DockPanel.ActiveContent = Windows[set];
                return;
            }

            var window = new LookupSetPanel();
            Windows.Add(set, window);
            DockPanel.AddContent(window);
            
            window.LoadSet(set);
        }

        public void RefreshListView()
        {
            LookupTablesListView.Items.Clear();
            for (var i = 0; i < LookupData.Count; i++)
            {
                var set = LookupData[i];
                LookupTablesListView.Items.Add(new DarkListItem(i + ": " + set.Name));
            }
        }

        private void NewLookupButton_Click(object sender, System.EventArgs e)
        {
            LookupData.Add(new LookupSet("New set"));
            RefreshListView();
        }

        private void RemoveLookupButton_Click(object sender, System.EventArgs e)
        {
            if (!LookupTablesListView.SelectedIndices.Any()) return;

            LookupData.RemoveAt(LookupTablesListView.SelectedIndices.First());
            RefreshListView();
        }
    }
}
