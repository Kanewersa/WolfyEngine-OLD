using System;
using WolfyCore.Actions;
using WolfyCore.ECS;

namespace WolfyEngine.Forms
{
    public partial class WolfyBoolDocument : VariableDocument
    {
        private new WolfyBool Variable => base.Variable as WolfyBool;

        public WolfyBoolDocument() : base()
        {
            InitializeComponent();
        }

        public override void Initialize(BaseVariable variable)
        {
            base.Initialize(variable);

        }
    }
}
