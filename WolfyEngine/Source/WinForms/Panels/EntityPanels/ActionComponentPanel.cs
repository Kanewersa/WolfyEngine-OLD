using System;
using System.Collections.Generic;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyECS;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class ActionComponentPanel : ComponentPanel
    {
        private ActionComponent _actionComponent;

        public ActionComponentPanel(Type componentType) : base(componentType)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the panel.
        /// </summary>
        /// <param name="entity"></param>
        public override void Initialize(Entity entity)
        {
            Entity = entity;

            ActionsListView.Initialize(entity);
        }

        /// <summary>
        /// Saves the component
        /// </summary>
        public override void Save()
        {
            _actionComponent = Entity.GetOrCreateComponent<ActionComponent>();
            ActionsListView.BuildActionComponent(_actionComponent);
        }

        /// <summary>
        /// Unloads the panel.
        /// </summary>
        /// <param name="entity"></param>
        public override void Unload(Entity entity)
        {
            entity.RemoveComponent<ActionComponent>();
            Close();
        }

        private void AddActionButton_Click(object sender, System.EventArgs e)
        {
            int insertionIndex = ActionsListView.ActionItems.Count;
            if (ActionsListView.SelectedIndices.Any())
                insertionIndex = ActionsListView.SelectedIndices.First();

            using (var form = new NewActionForm())
            {
                form.Initialize(Entity);
                form.OnSelect += delegate(WolfyAction action)
                {
                    ActionsListView.AddAction(action, insertionIndex);
                };
                form.ShowDialog();
            }
        }

        private void RemoveActionButton_Click(object sender, System.EventArgs e)
        {
            if (ActionsListView.SelectedIndices.Any())
            {
                ActionsListView.SelectedIndices.ForEach(index => ActionsListView.RemoveAction(index));
                ActionsListView.ResetDisplay();
            }
            else
            {
                DarkMessageBox.ShowWarning("Select the action to remove first", "Error");
            }
        }

        private int _lastActionIndex;

        private void OpenSelectActionForm(object sender, EventArgs e)
        {
            _lastActionIndex = ActionsListView.SelectedIndices.First();
            var action = ActionsListView.ActionItems[_lastActionIndex].Action;

            using (var form = ActionBinding.GetFormInstance(action))
            {
                form.Initialize(Entity);
                form.LoadAction(action);
                form.OnSave += new WolfyActionHandler(OnActionSave);
                form.ShowDialog();
            }
            
            ActionsListView.ResetDisplay();
        }

        private void OnActionSave(WolfyAction action)
        {
            ActionsListView.ReplaceAction(action, _lastActionIndex);
        }
    }
}
