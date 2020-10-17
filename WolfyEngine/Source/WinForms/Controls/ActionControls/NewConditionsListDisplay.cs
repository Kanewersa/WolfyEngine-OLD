using System;
using System.Windows.Forms;
using WolfyECS;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class NewConditionsListDisplay : ListDisplay
    {
        public new event WolfyActionHandler OnSelect;

        public NewConditionsListDisplay(Type componentType) : base(componentType)
        {
            InitializeComponent();
        }

        private void AddConditionButton_Click(object sender, EventArgs e)
        {
            OpenForm(new CreateConditionForm());
        }

        private void SetVariableButton_Click(object sender, EventArgs e)
        {
            OpenForm(new ChangeVariableForm());
        }
    }
}
