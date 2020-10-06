using System.Collections.Generic;
using System.Linq;
using DarkUI.Controls;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyEngine.Controls
{
    public partial class ActionsListView : DarkListView
    {
        private ActionComponent ActionComponent { get; set; }
        public List<ActionListViewItem> ActionItems { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ActionsListView() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the list.
        /// </summary>
        /// <param name="entity"></param>
        public void Initialize(Entity entity)
        {
            ActionItems ??= new List<ActionListViewItem>(16);

            if (!entity.GetIfHasComponent(out ActionComponent component))
                return;

            ActionComponent = component;
            component.Actions ??= new List<WolfyAction>();
            BindActionItems(component.Actions);
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
            this.Items.Add(new DarkListItem(new string('\t', nesting) + text));
        }

        /// <summary>
        /// Creates <see cref="WolfyAction"/> list from <see cref="ActionItems"/>.
        /// </summary>
        public void BuildActionComponent(ActionComponent component)
        {
            ActionItems = ActionItems.Distinct().ToList();
            var actions = BuildActions(ActionItems);
            component.Actions = actions;
        }

        /// <summary>
        /// Handles the creation of nested <see cref="WolfyAction"/> list.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<WolfyAction> BuildActions(List<ActionListViewItem> items)
        {
            var actions = new List<WolfyAction>(items.Count);

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
        /// Adds the given action and sets it on the given index.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="index"></param>
        public void AddAction(WolfyAction action, int index)
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

        /// <summary>
        /// Replaces the action on given index with given action.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="index"></param>
        public void ReplaceAction(WolfyAction action, int index)
        {
            var currentAction = ActionItems[index];
            var isIfAction = currentAction.IsIfAction;
            var parent = currentAction.Parent;
            ActionItems[index] = new ActionListViewItem(action, isIfAction, parent);
        }

        /// <summary>
        /// Removes action with given index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAction(int index)
        {
            var actionToRemove = ActionItems[index];

            if (actionToRemove.HasParent())
                actionToRemove.Parent.RemoveItem(actionToRemove);
            else ActionItems.RemoveAt(index);
        }

        /// <summary>
        /// Clears the action items and displays them again.
        /// </summary>
        public void ResetDisplay()
        {
            Items.Clear();
            DisplayActions(ActionItems);
        }
    }
}
