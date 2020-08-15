using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public class WolfyActionsListView : DarkListView
    {
        public static Dictionary<Type, DarkForm> Forms = new Dictionary<Type, DarkForm>
        {
            //{ typeof(MovementAction), new MovementForm() }
        };

        public List<WolfyAction> Actions { get; set; }
        public List<int> NestingLevel { get; set; }
        public int LastNesting;
        public WolfyActionsListView() : base()
        {
            MouseDoubleClick += OpenActionMenu;
        }

        private void OpenActionMenu(object sender, MouseEventArgs e)
        {
            var selectedActionIndex = SelectedIndices.First();

            var action = Actions[selectedActionIndex];

            if (!Forms.ContainsKey(action.GetType()))
                DarkMessageBox.ShowError("Selected action doesn't have it's form implemented yet!", "Unknown action type.");

            var form = Forms[action.GetType()];

            // TODO CREATE FORM INHERITANCE!
            form.ShowDialog();
        }

        public void Initialize(ActionComponent actionComponent)
        {
            LastNesting = 0;
            AddActions(actionComponent.Actions);
        }

        /// <summary>
        /// Adds <see cref="WolfyAction"/> to list view.
        /// </summary>
        /// <param name="actions"></param>
        public void AddActions(List<WolfyAction> actions)
        {
            for (int i = 0; i < actions.Count; i++)
            {
                var action = actions[i];
                NestingLevel[i] = LastNesting;

                if (action is WolfyCondition condition)
                {
                    AddItem(condition.GetDescription(), condition);
                    LastNesting++;
                    AddActions(condition.GetIfActions());
                    LastNesting--;
                    AddItem(GetSpaces(LastNesting) + "else", condition);
                    LastNesting++;
                    AddActions(condition.GetElseActions());
                    LastNesting--;
                    AddItem(GetSpaces(LastNesting) + "end", condition);
                    continue;
                }

                AddItem(action.GetDescription(), action);
            }
        }

        public WolfyAction GetAction()
        {
            throw new NotImplementedException();
        }

        private DarkListItem AddItem(string text, WolfyAction action)
        {
            var item = new DarkListItem(GetSpaces(LastNesting) + text);
            Items.Add(item);
            Actions.Add(action);
            return item;
        }

        private string GetSpaces(int count)
        {
            return new string(' ', count*3);
        }
    }
}
