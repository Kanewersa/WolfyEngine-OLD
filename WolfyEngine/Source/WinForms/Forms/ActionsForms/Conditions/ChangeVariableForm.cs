
using System;
using System.Windows.Forms;
using WolfyCore.Actions;
using WolfyCore.Controllers;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyEngine.Forms
{
    public partial class ChangeVariableForm : BaseActionForm
    {
        private BaseVariable SelectedVariable { get; set; }
        private DateTime VariableBoxLastClick { get; set; } = DateTime.MinValue;

        public ChangeVariableForm()
        {
            InitializeComponent();
            // TODO: Create custom variable selection control.
            VariableBox.MouseDown += delegate (object sender, MouseEventArgs args)
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
                return new BoolAction(SelectedVariable.Id, TrueButton.Checked);
            }

            if (VariablePanel.Visible)
            {
                return new VariableAction(SelectedVariable.Id, (float)VariableValueBox.Value);
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
            }
            else if (VariablePanel.Visible)
            {
                return true;
            }

            return true;
        }

        public override void LoadAction(WolfyAction action)
        {
            switch (action)
            {
                case BoolAction boo:
                    InitializeVariable(VariablesController.Instance.GetVariable(boo.VariableId));
                    break;
                case VariableAction var:
                    InitializeVariable(VariablesController.Instance.GetVariable(var.VariableId));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown condition type.");
            }
        }

        private void OpenVariableSelectForm()
        {
            using var form = new VariablesForm(true);
            form.VariableSelected += delegate (object sender, BaseVariable variable)
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
