using System;
using System.Collections.Generic;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Docking;
using WolfyCore.Actions;
using WolfyCore.Controllers;
using WolfyCore.ECS;

namespace WolfyEngine.Forms
{
    public partial class VariablesForm : WolfyForm
    {
        private Dictionary<uint, BaseVariable> Variables { get; set; }
        private List<BaseVariable> DisplayedVariables { get; set; }
        //private List<VariableDocument> DisplayedDocuments { get; set; }

        public int VariablesLimit { get; set; }

        public VariablesForm()
        {
            InitializeComponent();
            //DisplayedDocuments = new List<VariableDocument>(4);
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
            
            var variableIndex = VariablesListView.SelectedIndices[0];
            var str = VariablesListView.Items[variableIndex].Text;
            var variableId = str.Substring(0, str.IndexOf(":", StringComparison.Ordinal));
            var variable = VariablesController.Instance.GetVariable(uint.Parse(variableId));

            DisplayDocument(CreateDocument(variable));
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

            //DisplayedDocuments.Remove(DockPanel.ActiveContent as VariableDocument);
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
                if (variable.Value.Name.Contains(filterValue))
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
    }
}
