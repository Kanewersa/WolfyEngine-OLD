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

        public List<ActionListViewItem> ActionItems { get; set; }
        
        public ActionComponentPanel()
        {
            InitializeComponent();
            ActionItems = new List<ActionListViewItem>(64);
        }

        /// <summary>
        /// Initializes the panel.
        /// </summary>
        /// <param name="entity"></param>
        public override void Initialize(Entity entity)
        {
            Entity = entity;

            if (!entity.GetIfHasComponent(out ActionComponent comp))
                return;
            _actionComponent = comp;
            if(comp.Actions == null) comp.Actions = new List<WolfyAction>();
            BindActionItems(comp.Actions);
            DisplayActions(ActionItems);
        }

        /// <summary>
        /// Fills the <see cref="ActionItems"/> with given actions.
        /// </summary>
        /// <param name="actions"></param>
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

        /// <summary>
        /// Handles the nesting of <see cref="ActionListViewItem"/> in <see cref="BindActionItems"/> method.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="item"></param>
        /// <param name="parent"></param>
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
        /// <param name="items"></param>
        /// <param name="nesting"></param>
        private void DisplayActions(List<ActionListViewItem> items, int nesting = 0)
        {
            foreach (var item in items)
            {
                Display(item.GetDescription(), nesting);
                if (item.HasChildren())
                {
                    DisplayActions(item.IfChildren, nesting++);
                    Display("else", nesting);
                    DisplayActions(item.ElseChildren, nesting++);
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

        /// <summary>
        /// Saves the component
        /// </summary>3
        public override void Save()
        {
            _actionComponent = Entity.GetOrCreateComponent<ActionComponent>();
            BuildActionComponent();
        }

        /// <summary>
        /// Creates <see cref="WolfyAction"/> list from <see cref="ActionItems"/>.
        /// </summary>
        private void BuildActionComponent()
        {
            ActionItems = ActionItems.Distinct().ToList();
            List<WolfyAction> actions = BuildActions(ActionItems);
            _actionComponent.Actions = actions;
        }

        /// <summary>
        /// Handles the creation of nested <see cref="WolfyAction"/> list.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<WolfyAction> BuildActions(List<ActionListViewItem> items)
        {
            List<WolfyAction> actions = new List<WolfyAction>(items.Count);

            foreach (var item in items)
            {
                actions.Add(item.Action);
                if (item.HasChildren())
                {
                    item.BuildActions(item.Action as WolfyCondition);
                }
            }
            return actions;
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
            int insertionIndex = ActionItems.Count;
            if (ActionsListView.SelectedIndices.Any())
                insertionIndex = ActionsListView.SelectedIndices.First();

            using (var form = new NewActionForm())
            {
                form.Initialize(Entity);
                form.OnSelect += delegate(WolfyAction action)
                {
                    Console.WriteLine("Added action: {0}", action.GetType());
                    AddAction(action, insertionIndex);
                };
                form.ShowDialog();
            }
        }

        private void AddAction(WolfyAction action, int index)
        {
            ActionListViewItem parent = null;
            bool isIfAction = false;

            if (index != ActionItems.Count)
            {
                var currentItem = ActionItems[index];
                if (currentItem.HasParent())
                {
                    parent = currentItem.Parent;
                    if (currentItem.IsIfAction)
                    {
                        isIfAction = true;
                    }
                }
            }

            var newItem = new ActionListViewItem(action, isIfAction, parent);
            ActionItems.Insert(index, newItem);

            ResetDisplay();
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

                ResetDisplay();
            }
            else
            {
                DarkMessageBox.ShowWarning("Select the action to remove first", "Error");
            }
        }

        private void ResetDisplay()
        {
            ActionsListView.Items.Clear();
            DisplayActions(ActionItems);
        }
    }
}
