using System;
using WolfyCore.Actions;
using WolfyCore.ECS;

namespace WolfyEngine.Forms
{
    public partial class BaseVariableDocument : VariableDocument
    {
        public BaseVariableDocument()
        {
            InitializeComponent();
        }

        public override void Initialize(BaseVariable variable)
        {
            base.Initialize(variable);
        }

        private void HighlightImage(object sender, EventArgs e)
        {
            BooleanButton.Image = Icons.toggle_right;
        }

        private void RestoreImage(object sender, EventArgs e)
        {
            BooleanButton.Image = Icons.toggle_left1;
        }

        private void BooleanButton_Click(object sender, EventArgs e)
        {
            OnTypeChanged(new Tuple<Type, BaseVariable>(typeof(WolfyBool), Variable));
        }
    }
}
