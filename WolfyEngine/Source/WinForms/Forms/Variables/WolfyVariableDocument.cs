using System;
using WolfyCore.Actions;
using WolfyCore.ECS;

namespace WolfyEngine.Forms
{
    public partial class WolfyVariableDocument : VariableDocument
    {
        private new WolfyVariable Variable => base.Variable as WolfyVariable;

        public WolfyVariableDocument() : base()
        {
            InitializeComponent();
        }

        public override void Initialize(BaseVariable variable)
        {
            base.Initialize(variable);

        }
    }
}
