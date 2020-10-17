using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using WolfyCore.Actions;
using WolfyCore.Controllers;
using WolfyCore.ECS;

namespace WolfyEngine.Forms
{
    public partial class VariablesForm : WolfyForm
    {
        public event EventHandler<BaseVariable> VariableSelected;
        private Dictionary<uint, BaseVariable> Variables { get; set; }
        private List<BaseVariable> DisplayedVariables { get; set; }
        public int VariablesLimit { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="allowSelect">Determines if form works as a selection form.</param>
        public VariablesForm(bool allowSelect = false)
        {
            InitializeComponent();

            if (!allowSelect)
                SelectVariableButton.Hide();
            else
            {
                VariablesListView.MouseDoubleClick += delegate(object sender, MouseEventArgs args)
                {
                    if (VariablesListView.SelectedIndices.Any())
                    {
                        SelectVariable(this, null);
                    }
                };
            }

            Variables = VariablesController.Instance.GetVariables();
            VariablesLimit = Variables.Count;
            DisplayedVariables = new List<BaseVariable>(VariablesLimit);
            FilterVariables(this, null);
            LoadVariables();
        }

        private void VariablesListView_Click(object sender, EventArgs e)
        {
            if (!VariablesListView.SelectedIndices.Any())
                return;

            var variable = GetSelectedVariable();
            if (variable == null)
                return;

            DisplayDocument(CreateDocument(variable));
        }

        private BaseVariable GetSelectedVariable()
        {
            if (!VariablesListView.SelectedIndices.Any())
                return null;
            
            var variableIndex = VariablesListView.SelectedIndices[0];
            var str = VariablesListView.Items[variableIndex].Text;
            var variableId = str.Substring(0, str.IndexOf(":", StringComparison.Ordinal));
            return VariablesController.Instance.GetVariable(uint.Parse(variableId));
        }

        private void SwitchVariableType(object sender, Tuple<Type, BaseVariable> tuple)
        {
            if (tuple.Item1 == tuple.Item2.GetType())
                return;

            var changedVariable = VariablesController.Instance.GetVariable(tuple.Item2.Id);
            var id = changedVariable.Id;
            var name = changedVariable.Name;
            
            changedVariable = tuple.Item1 switch
            {
                { } variable when variable == typeof(WolfyVariable) => new WolfyVariable(),
                { } boolean when boolean == typeof(WolfyBool) => new WolfyBool(),
                { } basic when basic == typeof(BaseVariable) => new BaseVariable(),
                _ => throw new ArgumentOutOfRangeException("Unknown variable type.")
            };

            changedVariable.Id = id;
            changedVariable.Name = name;
            VariablesController.Instance.ReplaceVariable(id, changedVariable);

            DockPanel.RemoveContent(DockPanel.ActiveDocument);
            DisplayDocument(CreateDocument(changedVariable));
        }

        private VariableDocument CreateDocument(BaseVariable variable)
        {
            // Load selected variable and display its content
            VariableDocument document = variable switch
            {
                WolfyVariable _ => new WolfyVariableDocument(),
                WolfyBool _ => new WolfyBoolDocument(),
                _ => new BaseVariableDocument()
            };

            document.Initialize(variable);
            document.TypeChanged += SwitchVariableType;
            document.NameChanged += delegate(object sender, BaseVariable variable)
            {
                foreach (var item in VariablesListView.Items)
                {
                    if (uint.Parse(item.Text.Substring(0, item.Text.IndexOf(":"))) == variable.Id)
                    {
                        item.Text = variable.FormattedName();
                        return;
                    }
                }
            };
            return document;
        }

        private void DisplayDocument(VariableDocument document)
        {
            var activeDocument = DockPanel.GetDocuments()
                .FirstOrDefault(x => ((VariableDocument)x).Variable.Id == document.Variable.Id);
            if (activeDocument != null)
            {
                DockPanel.ActiveContent = activeDocument;
                return;
            }

            DockPanel.AddContent(document);

            if (DockPanel.GetDocuments().Count > 4)
            {
                DockPanel.RemoveContent(DockPanel.GetDocuments().First());
            }
        }

        private void SetVariablesLimitButton_Click(object sender, EventArgs e)
        {
            using var form = new VariablesLimitForm();
            form.ShowDialog();
            form.Initialize(VariablesLimit);
            form.SaveClick += delegate(object o, int i)
            {
                VariablesLimit = i;
                if (Variables.Count > VariablesLimit)
                    // Remove variables with higher id than limit.
                    VariablesController.Instance.RemoveVariables((uint)VariablesLimit);
                else if (Variables.Count < VariablesLimit)
                    // Create missing variables.
                    VariablesController.Instance.CreateVariables(VariablesLimit - Variables.Count);
                    
                FilterVariables(this, null);
                LoadVariables();
            };
        }

        private void FilterVariables(object sender, EventArgs e)
        {
            // Perform searching for variables with given name.
            var filterValue = SearchBox.Text;

            DisplayedVariables.Clear();
            DisplayedVariables = new List<BaseVariable>(VariablesLimit);

            if (string.IsNullOrEmpty(filterValue))
            {
                foreach (var variable in Variables)
                {
                    DisplayedVariables.Add(variable.Value);
                }
                LoadVariables();
                return;
            }

            foreach (var variable in Variables)
            {
                uint.TryParse(filterValue, out var id);
                if (variable.Value.Name.Contains(filterValue) || variable.Key == id)
                {
                    DisplayedVariables.Add(variable.Value);
                }
            }

            LoadVariables();
        }

        private void LoadVariables()
        {
            VariablesListView.Items.Clear();
            foreach (var variable in DisplayedVariables)
            {
                VariablesListView.Items.Add(new DarkListItem(variable.FormattedName()));
            }
        }

        private void SelectVariable(object sender, EventArgs e)
        {
            var variable = GetSelectedVariable();
            if (variable == null)
                return;

            VariableSelected?.Invoke(this, GetSelectedVariable());
            Close();
        }
    }
}
