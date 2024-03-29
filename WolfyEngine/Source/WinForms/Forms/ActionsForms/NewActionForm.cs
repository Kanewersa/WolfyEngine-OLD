﻿using System.Windows.Forms;
using DarkUI.Forms;
using WolfyCore.Actions;
using WolfyECS;
using WolfyEngine.Controls;

namespace WolfyEngine.Forms
{
    public delegate void WolfyActionHandler(WolfyAction action);

    public partial class NewActionForm : WolfyForm
    {
        public Entity Entity { get; private set; }
        public ListDisplay ListDisplay { get; private set; }
        public event WolfyActionHandler OnSelect;

        public NewActionForm()
        {
            InitializeComponent();
        }

        public void Initialize(Entity entity)
        {
            Entity = entity;
            ActionsTabButton_Click(null, null);
        }

        private void ActionsTabButton_Click(object sender, System.EventArgs e)
        {
            ActionsTabButton.Checked = true;
            ConditionsTabButton.Checked = false;
            SetDisplay(new NewActionsListDisplay(null));
        }

        private void ConditionsTabButton_Click(object sender, System.EventArgs e)
        {
            ActionsTabButton.Checked = false;
            ConditionsTabButton.Checked = true;
            SetDisplay(new NewConditionsListDisplay(null));
        }

        private void SetDisplay(ListDisplay listDisplay)
        {
            ListDisplay?.Dispose();

            ListDisplay = listDisplay;
            LayoutPanel.Controls.Add(ListDisplay);
            ListDisplay.Dock = DockStyle.Fill;
            ListDisplay.OnSelect += delegate(WolfyAction action)
            {
                OnSelect?.Invoke(action);
                Close();
            };
            ListDisplay.Initialize(Entity);
            ListDisplay.Show();
        }
    }
}
