using System;
using DarkUI.Docking;
using WolfyCore.ECS;

namespace WolfyEngine.Forms
{
    public partial class VariableDocument : DarkDocument
    {
        public BaseVariable Variable;
        public event EventHandler<Tuple<Type, BaseVariable>> TypeChanged;

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
        }
    }
}
