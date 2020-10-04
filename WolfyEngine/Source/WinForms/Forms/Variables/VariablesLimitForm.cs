using System;
using System.Windows.Forms;
using DarkUI.Forms;
using WolfyCore.Controllers;

namespace WolfyEngine.Forms
{
    public partial class VariablesLimitForm : WolfyForm
    {
        public EventHandler<int> SaveClick;

        public int VariablesLimit { get; set; }

        public VariablesLimitForm()
        {
            InitializeComponent();
        }

        public void Initialize(int limit)
        {
            VariablesLimit = limit;
        }

        private void LimitNumericBox_ValueChanged(object sender, System.EventArgs e)
        {
            VariablesLimit = (int)LimitNumericBox.Value;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (VariablesController.Instance.GetVariables().Count < VariablesLimit)
            {
                var result = DarkMessageBox.ShowWarning("Selected variables limit means deleting the variables with an id higher than newly selected limit. Are you sure you want to proceed?",
                    "Warning",
                    DarkDialogButton.YesNo);

                if (result == DialogResult.No)
                    return;
            }

            SaveClick.Invoke(this, VariablesLimit);
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
