using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Config;
using DarkUI.Controls;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyEngine.Controls
{
    public partial class ActionsListView : DarkListView
    {
        private ActionComponent ActionComponent { get; set; }

        /// <summary>
        /// Stores all actions as <see cref="ActionListViewItem"/>s to allow the cancellation of changes.
        /// </summary>
        public List<ActionListViewItem> ActionItems { get; set; }

        /// <summary>
        /// Determines if drag operation is being performed.
        /// </summary>
        private bool PerformingDrag { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ActionsListView() : base()
        {
            InitializeComponent();
            MultiSelect = true;

            MouseDown += delegate(object sender, MouseEventArgs args)
            {
                if (args.Button != MouseButtons.Left || args.Clicks != 1)
                    return;
                if (!Items.Any())
                    return;
                
                var itemIndex = args.Y / ItemHeight;
                if (Items.Count <= itemIndex)
                    return;

                //SelectItem(itemIndex);
                DraggedItemIndex = itemIndex;
                PerformingDrag = true;
                DoDragDrop(Items[itemIndex], DragDropEffects.Copy);
            };

            MouseUp += delegate(object sender, MouseEventArgs args)
            {
                PerformingDrag = false;
            };
        }

        /// <summary>
        /// Initializes the list.
        /// </summary>
        /// <param name="entity"></param>
        public void Initialize(Entity entity)
        {
            ActionItems ??= new List<ActionListViewItem>();

            if (!entity.GetIfHasComponent(out ActionComponent component))
                return;

            ActionComponent = component;
            component.Actions ??= new List<WolfyAction>();
            BindActionItems(component.Actions, false, null);
            DisplayActions(ActionItems);
        }

        /// <summary>
        /// Fills the <see cref="ActionItems"/> with given actions.
        /// </summary>
        /// <param name="actions"></param>
        /// <param name="isIfAction"></param>
        /// <param name="parent"></param>
        private void BindActionItems(List<WolfyAction> actions, bool isIfAction, ActionListViewItem parent)
        {
            foreach (var action in actions)
            {
                var actionItem = new ActionListViewItem(action, isIfAction, parent);
                ActionItems.Add(actionItem);

                if (action is WolfyCondition condition)
                {
                    // Add if actions
                    BindActionItems(condition.GetIfActions(), true, actionItem);
                    // Add empty item to serve as a boundary
                    ActionItems.Add(new ActionListViewItem(null, true, actionItem));
                    // Add 'else' item
                    ActionItems.Add(actionItem);
                    // Add else actions
                    BindActionItems(condition.GetElseActions(), false, actionItem);
                    // Add empty item to serve as a boundary
                    ActionItems.Add(new ActionListViewItem(null, false, actionItem));
                    // Add 'end' item
                    ActionItems.Add(actionItem);
                }
            }
        }


        /// <summary>
        /// Displays the given actions on <see cref="ActionsListView"/>.
        /// </summary>
        /// <param name="items"></param>
        private void DisplayActions(List<ActionListViewItem> items)
        {
            var nesting = 0;
            var conditionsCounter = new Dictionary<ActionListViewItem, int>();

            foreach (var item in items)
            {
                if (item.IsCondition())
                {
                    if (!conditionsCounter.ContainsKey(item))
                        conditionsCounter.Add(item, 0);

                    conditionsCounter[item] = conditionsCounter[item] + 1;

                    switch (conditionsCounter[item])
                    {
                        case 1:
                            Display(item.GetDescription(), nesting);
                            break;
                        case 2:
                            Display("else", nesting);
                            break;
                        case 3:
                            Display("end", nesting);
                            break;
                    }
                }
                else Display(item.GetDescription(), nesting);

                if (!item.HasAction())
                {
                    nesting--;
                    if (nesting < 0) nesting = 0;
                    continue;
                }

                if (item.IsCondition())
                {
                    if (conditionsCounter[item] == 3)
                    {
                        if(!item.HasParent())
                            nesting--;
                        if (nesting < 0) nesting = 0;
                        conditionsCounter.Remove(item);
                    }
                    else
                    {
                        nesting++;
                    }
                }

                if (nesting < 0) nesting = 0;
            }
        }

        /// <summary>
        /// Displays the given string on <see cref="ActionsListView"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nesting"></param>
        private void Display(string text, int nesting)
        {
            Items.Add(new DarkListItem(new string(' ', nesting*3) + text));
        }

        /// <summary>
        /// Creates <see cref="WolfyAction"/> list from <see cref="ActionItems"/>.
        /// </summary>
        public ActionComponent BuildActionComponent(ActionComponent component)
        {
            ActionItems = ActionItems.Distinct().Where(x => x.HasAction()).ToList();

            ActionItems.ForEach(item =>
            {
                if (item.IsCondition())
                {
                    ((WolfyCondition) item.Action).GetIfActions().Clear();
                    ((WolfyCondition) item.Action).GetElseActions().Clear();
                }
            });

            var actions = new List<WolfyAction>(ActionItems.Count);

            ActionItems.ForEach(item =>
            {
                if (item.HasParent())
                {
                    var list = item.IsIfAction
                        ? ((WolfyCondition)item.Parent.Action).GetIfActions()
                        : ((WolfyCondition)item.Parent.Action).GetElseActions();

                    if (!list.Contains(item.Action))
                        list.Add(item.Action);
                }
                else actions.Add(item.Action);
            });

            component.Actions = actions;
            return component;
        }

        /// <summary>
        /// Adds given action and sets it on the given index.
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

            if (action is WolfyCondition)
            {
                // Add empty item to serve as a boundary
                ActionItems.Add(new ActionListViewItem(null, true, newItem));
                // Add 'else' item
                ActionItems.Add(newItem);
                // Add empty item to serve as a boundary
                ActionItems.Add(new ActionListViewItem(null, false, newItem));
                // Add 'end' item
                ActionItems.Add(newItem);
            }

            ResetDisplay();
        }

        private Tuple<int, int> GetConditionRange(ActionListViewItem item)
        {
            return new Tuple<int, int>(ActionItems.IndexOf(item), ActionItems.LastIndexOf(item));
        }

        /// <summary>
        /// Replaces action on given index with given action.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="index"></param>
        public void ReplaceAction(WolfyAction action, int index)
        {
            var currentAction = ActionItems[index];
            var isIfAction = currentAction.IsIfAction;
            var parent = currentAction.Parent;
            var newItem = new ActionListViewItem(action, isIfAction, parent);

            if (currentAction.IsCondition())
            {
                var range = GetConditionRange(currentAction);
                for (var i = range.Item1; i <= range.Item2; i++)
                {
                    if (ActionItems[i] == currentAction)
                        ActionItems[i] = newItem;
                    else if (ActionItems[i].Parent == currentAction)
                        ActionItems[i].Parent = newItem;
                }
            }
            else ActionItems[index] = newItem;
            
            ResetDisplay();
        }

        /// <summary>
        /// Clears action items and displays them again.
        /// </summary>
        public void ResetDisplay()
        {
            Items.Clear();
            DisplayActions(ActionItems);
        }

        #region Drag and Drop

        private int LastHoveredItemIndex { get; set; } = -1;
        private int DraggedItemIndex { get; set; }

        /// <summary>
        /// Executed when dragging starts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DarkListItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// Executes when mouse is moved during drag operation. Handles selection highlight.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragOver(object sender, DragEventArgs e)
        {
            var pnt = PointToClient(new Point(e.X, e.Y));
            var itemIndex = pnt.Y / ItemHeight;
            if (itemIndex >= Items.Count)
                return;

            SelectedIndices.Clear();
            LastHoveredItemIndex = itemIndex;
            SelectItem(LastHoveredItemIndex);
            SelectedIndices.Add(DraggedItemIndex);
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Executed when drag operation is finished. Performs changes on items list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (!PerformingDrag || LastHoveredItemIndex == -1) return;

            // Don't do anything if item stayed in place.
            if (LastHoveredItemIndex == DraggedItemIndex) return;

            var draggedItem = ActionItems[DraggedItemIndex];
            var hoveredAction = ActionItems[LastHoveredItemIndex];

            if (draggedItem.IsCondition())
            {
                var range = GetConditionRange(hoveredAction);
                var firstHoveredActionIndex = range.Item1;
                var lastHoveredActionIndex = range.Item2;

                // Prevent dragging condition onto itself.
                if (DraggedItemIndex >= firstHoveredActionIndex && DraggedItemIndex <= lastHoveredActionIndex)
                    return;
                
                var actionsToMove = ActionItems.GetRange(firstHoveredActionIndex, lastHoveredActionIndex - firstHoveredActionIndex + 1);

                if (DraggedItemIndex > LastHoveredItemIndex)
                {
                    ActionItems.RemoveRange(firstHoveredActionIndex, lastHoveredActionIndex - firstHoveredActionIndex + 1);
                    ActionItems.InsertRange(LastHoveredItemIndex, actionsToMove);
                }
                else
                {
                    ActionItems.InsertRange(LastHoveredItemIndex, actionsToMove);
                    ActionItems.RemoveRange(firstHoveredActionIndex, lastHoveredActionIndex - firstHoveredActionIndex + 1);
                }
            }
            else
            {
                // TODO: Dragging when no item is hovered
                if (DraggedItemIndex > LastHoveredItemIndex)
                {
                    ActionItems.RemoveAt(DraggedItemIndex);
                    ActionItems.Insert(LastHoveredItemIndex, draggedItem);
                }
                else
                {
                    ActionItems.Insert(LastHoveredItemIndex, draggedItem);
                    ActionItems.RemoveAt(DraggedItemIndex);
                }
            }

            draggedItem.Parent = hoveredAction.Parent;
            draggedItem.IsIfAction = hoveredAction.IsIfAction;

            LastHoveredItemIndex = -1;
            ResetDisplay();
        }

        #endregion
    }
}
