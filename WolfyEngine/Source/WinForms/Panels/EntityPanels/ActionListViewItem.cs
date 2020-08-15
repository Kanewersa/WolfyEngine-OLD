using System.Collections.Generic;
using System.Linq;
using WolfyCore.Actions;

namespace WolfyEngine.Controls
{
    public class ActionListViewItem
    {
        public WolfyAction Action { get; set; }
        public ActionListViewItem Parent { get; set; }
        public List<ActionListViewItem> IfChildren { get; set; } = new List<ActionListViewItem>();
        public List<ActionListViewItem> ElseChildren { get; set; } = new List<ActionListViewItem>();
        public bool IsIfAction { get; set; }

        public ActionListViewItem(WolfyAction action, bool isIfAction = false, ActionListViewItem parent = null)
        {
            Action = action;
            IsIfAction = isIfAction;
            Parent = parent;
        }

        public bool HasChildren()
        {
            return (IfChildren.Any() || ElseChildren.Any()) && Action is WolfyCondition;
        }

        public bool HasParent()
        {
            return Parent != null;
        }

        public ActionListViewItem Search(ActionListViewItem item)
        {
            if (item == this) return this;

            foreach (var ifChild in IfChildren)
            {
                var sr = ifChild.Search(item);
                if (sr != null) return sr;
            }

            foreach (var elseChild in ElseChildren)
            {
                var sr = elseChild.Search(item);
                if (sr != null) return sr;
            }

            return null;
        }

        public void RemoveItem(ActionListViewItem item)
        {
            if (item.IsIfAction)
                IfChildren.Remove(item);
            else ElseChildren.Remove(item);
        }

        public void BuildActions(WolfyCondition parent)
        {
            List<WolfyAction> ifActions = new List<WolfyAction>();
            List<WolfyAction> elseActions = new List<WolfyAction>();

            IfChildren.ForEach(child =>
            {
                ifActions.Add(child.Action);
                if (child.HasChildren())
                {
                    child.BuildActions(child.Action as WolfyCondition);
                }
            });

            ElseChildren.ForEach(child =>
            {
                elseActions.Add(child.Action);
                if (child.HasChildren())
                {
                    child.BuildActions(child.Action as WolfyCondition);
                }
            });

            parent.SetActions(ifActions, elseActions);
        }

        public string GetDescription()
        {
            return Action.GetDescription();
        }
    }
}
