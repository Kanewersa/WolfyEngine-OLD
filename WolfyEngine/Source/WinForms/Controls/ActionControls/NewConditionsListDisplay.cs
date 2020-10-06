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

        private void AddBoolButton_Click(object sender, EventArgs e)
        {
            OpenForm(new BoolConditionForm());
        }

        private void AddFloatButton_Click(object sender, EventArgs e)
        {
            OpenForm(new VariableConditionForm());
        }
    }
}
