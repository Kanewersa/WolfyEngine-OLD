using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

            ActionsListView.MouseDoubleClick += OpenSelectActionForm;
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
            _actionComponent = ActionsListView.BuildActionComponent(_actionComponent);
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

        private void CreateNewActionForm(object sender, System.EventArgs e)
        {
            int insertionIndex = ActionsListView.ActionItems.Count;
            if (ActionsListView.SelectedIndices.Any())
            {
                insertionIndex = ActionsListView.SelectedIndices.First();
                
            }

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
            DarkMessageBox.ShowWarning("Removing actions is yet to be implemented.", "Error");
        }

        private int _lastActionIndex;

        private void OpenSelectActionForm(object sender, EventArgs e)
        {
            if (!ActionsListView.SelectedIndices.Any())
                return;

            _lastActionIndex = ActionsListView.SelectedIndices.First();

            var action = ActionsListView.ActionItems[_lastActionIndex].Action;

            if (action == null)
            {
                CreateNewActionForm(this, null);
                return;
            }

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

        private void darkButton1_Click(object sender, EventArgs e)
        {
            for (var index = 0; index < ActionsListView.ActionItems.Count; index++)
            {
                var action = ActionsListView.ActionItems[index];

                Console.WriteLine(index + ": " + action.GetDescription());
            }
        }
    }
}
