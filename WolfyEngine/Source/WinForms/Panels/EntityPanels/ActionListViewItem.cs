using System;
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

        public bool IsCondition()
        {
            return Action is WolfyCondition;
        }
        
        public bool HasAction()
        {
            return Action != null;
        }

        public bool HasChildren()
        {
            return (IfChildren.Any() || ElseChildren.Any()) && IsCondition();
        }

        public bool HasParent()
        {
            return Parent != null;
        }

        public void RemoveItem(ActionListViewItem item)
        {
            if (item.IsIfAction)
                IfChildren.Remove(item);
            else ElseChildren.Remove(item);
        }

        public string GetDescription()
        {
            return Action == null ? "..." : Action.GetDescription();
        }
    }
}
