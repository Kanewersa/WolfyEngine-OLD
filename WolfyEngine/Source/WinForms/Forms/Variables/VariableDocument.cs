using System;
using DarkUI.Docking;
using WolfyCore.ECS;

namespace WolfyEngine.Forms
{
    public partial class VariableDocument : DarkDocument
    {
        public BaseVariable Variable;
        public event EventHandler<Tuple<Type, BaseVariable>> TypeChanged;
        public event EventHandler<BaseVariable> NameChanged; 

        protected virtual void OnTypeChanged(Tuple<Type, BaseVariable> e)
        {
            TypeChanged?.Invoke(this, e);
        }

        public VariableDocument()
        {
            InitializeComponent();
        }

        public virtual void Initialize(BaseVariable variable)
        {
            Variable = variable;
            DockText = variable.FormattedName();
            NameTextBox.Text = variable.Name;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            Variable.Name = NameTextBox.Text;
            NameChanged?.Invoke(this, Variable);
        }
    }
}
