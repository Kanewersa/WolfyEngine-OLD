using System.Collections.Generic;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyEngine.Controls
{
    public partial class ActionComponentPanel : ComponentPanel
    {
        private ActionComponent _actionComponent;

        public List<ActionListViewItem> ActionItems { get; set; }
        
        public ActionComponentPanel()
        {
            InitializeComponent();
        }

        public override void Initialize(Entity entity)
        {
            Entity = entity;

            if (!entity.GetIfHasComponent(out ActionComponent comp))
                return;
            _actionComponent = comp;
            BindActionItems(comp.Actions);
            DisplayActions(comp.Actions);
        }

        private void BindActionItems(List<WolfyAction> actions)
        {
            foreach (var action in actions)
            {
                ActionListViewItem actionItem = new ActionListViewItem(action);
                ActionItems.Add(actionItem);
                if (action is WolfyCondition condition)
                {
                    BindChildren(condition, actionItem);
                }
            }
        }

        private void BindChildren(WolfyCondition condition, ActionListViewItem item, ActionListViewItem parent = null)
        {
            foreach (var action in condition.GetIfActions())
            {
                var newItem = new ActionListViewItem(action, true, parent);
                newItem.IfChildren.Add(item);
                if (action is WolfyCondition subCondition)
                {
                    BindChildren(subCondition, newItem, item);
                }
            }

            foreach (var action in condition.GetElseActions())
            {
                var newItem = new ActionListViewItem(action, false, parent);
                newItem.IfChildren.Add(item);
                if (action is WolfyCondition subCondition)
                {
                    BindChildren(subCondition, newItem, item);
                }
            }
        }

        /// <summary>
        /// Displays the given actions on <see cref="ActionsListView"/>.
        /// </summary>
        /// <param name="actions"></param>
        /// <param name="nesting"></param>
        private void DisplayActions(List<WolfyAction> actions, int nesting = 0)
        {
            foreach (var action in actions)
            {
                Display(action.GetDescription(), nesting);
                if (action is WolfyCondition condition)
                {
                    DisplayActions(condition.GetIfActions(), nesting++);
                    Display("else", nesting);
                    DisplayActions(condition.GetElseActions(), nesting++);
                    Display("end", nesting);
                }
            }
        }

        /// <summary>
        /// Displays the given string on <see cref="ActionsListView"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nesting"></param>
        private void Display(string text, int nesting)
        {
            ActionsListView.Items.Add(new DarkListItem(new string('\t', nesting) + text));
        }

        public override void Save()
        {
            BuildActionComponent();
        }

        private void BuildActionComponent()
        {
            ActionItems = ActionItems.Distinct().ToList();
            List<WolfyAction> actions = BuildActions(ActionItems);
            _actionComponent.Actions = actions;
        }

        private List<WolfyAction> BuildActions(List<ActionListViewItem> items)
        {
            List<WolfyAction> actions = new List<WolfyAction>(items.Count);

            foreach (var item in items)
            {
                actions.Add(item.Action);
                if (item.HasChildren())
                {
                    item.BuildActions(item.Action as WolfyCondition);
                    //item.BuildActions(item.Action as WolfyCondition);
                }
            }

            return actions;
        }

        public override void Unload(Entity entity)
        {
            entity.RemoveComponent<ActionComponent>();
            Close();
        }

        private void AddActionButton_Click(object sender, System.EventArgs e)
        {
            int insertionIndex = ActionItems.Count;
            if (ActionsListView.SelectedIndices.Any())
                insertionIndex = ActionsListView.SelectedIndices.First();
            

        }

        private void RemoveActionButton_Click(object sender, System.EventArgs e)
        {
            if (ActionsListView.SelectedIndices.Any())
            {
                foreach (var selectedIndex in ActionsListView.SelectedIndices)
                {
                    var actionToRemove = ActionItems[selectedIndex];

                    if (actionToRemove.HasParent())
                        actionToRemove.Parent.RemoveItem(actionToRemove);
                    else ActionItems.RemoveAt(selectedIndex);
                }
            }
            else
            {
                DarkMessageBox.ShowWarning("Select the action to remove first", "Error");
            }
        }
    }
}
