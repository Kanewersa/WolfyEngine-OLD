using System;
using System.Windows.Forms;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyEngine.Forms
{
    public partial class CreateConditionForm : BaseActionForm
    {
        private BaseVariable SelectedVariable { get; set; }

        private DateTime VariableBoxLastClick { get; set; } = DateTime.MinValue;

        public CreateConditionForm()
        {
            InitializeComponent();
            // TODO: Create custom variable selection control.
            VariableBox.MouseDown += delegate(object sender, MouseEventArgs args)
            {
                if (DateTime.Now - VariableBoxLastClick < new TimeSpan(0, 0, 0, 1, 500))
                    OpenVariableSelectForm();
                else VariableBoxLastClick = DateTime.Now;

                if (args.X >= VariableBox.Width - 20)
                    OpenVariableSelectForm();
            };
        }

        public override void Initialize(Entity entity)
        {
            base.Initialize(entity);
        }

        protected override WolfyAction CreateAction()
        {
            if (BoolPanel.Visible)
            {
                return new BoolCondition(SelectedVariable.Id, TrueButton.Checked);
            }
            
            if(VariablePanel.Visible)
            {
                var variableOperator = 0;
                if (GreaterButton.Checked)
                    variableOperator = 1;
                if (SmallerButton.Checked)
                    variableOperator = -1;

                return new VariableCondition(SelectedVariable.Id, variableOperator, (float)VariableValueBox.Value);
            }

            throw new ArgumentOutOfRangeException("Unknown condition type.");
        }

        protected override bool ValidateAction()
        {
            if (SelectedVariable == null)
                return false;

            if (BoolPanel.Visible)
            {
                if (!TrueButton.Checked && !FalseButton.Checked)
                {
                    return false;
                }
            } else if (VariablePanel.Visible)
            {
                if (!GreaterButton.Checked && !SmallerButton.Checked && !EqualButton.Checked)
                {
                    return false;
                }
            }

            return true;
        }

        public override void LoadAction(WolfyAction action)
        {
            switch (action)
            {
                case BoolCondition boo:
                    InitializeVariable(boo.Variable);
                    if (boo.DesiredValue)
                        TrueButton.Checked = true;
                    else FalseButton.Checked = true;
                    break;
                case VariableCondition var:
                    InitializeVariable(var.Variable);
                    if (var.DesiredOperator > 1)
                        GreaterButton.Checked = true;
                    else if (var.DesiredOperator < 1)
                        SmallerButton.Checked = true;
                    else EqualButton.Checked = true;
                    
                    VariableValueBox.Value = (decimal) var.DesiredValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown condition type.");
            }
        }

        private void OpenVariableSelectForm()
        {
            using var form = new VariablesForm(true);
            form.VariableSelected += delegate(object sender, BaseVariable variable)
            {
                InitializeVariable(variable);
            };
            form.ShowDialog();
        }

        private void InitializeVariable(BaseVariable variable)
        {
            SelectedVariable = variable;
            VariableBox.Items.Clear();
            VariableBox.Items.Add(variable.FormattedName());
            VariableBox.SelectedItem = VariableBox.Items[0];

            BoolPanel.Hide();
            VariablePanel.Hide();

            // Default width = 250
            switch (variable)
            {
                case WolfyVariable _:
                    VariablePanel.Show();
                    Width = 450;
                    break;
                case WolfyBool _:
                    BoolPanel.Show();
                    Width = 340;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown condition type.");
            }
        }
    }
}
