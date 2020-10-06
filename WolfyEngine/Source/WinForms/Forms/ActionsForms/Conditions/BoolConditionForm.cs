using WolfyCore.Actions;
using WolfyECS;

namespace WolfyEngine.Forms
{
    public partial class BoolConditionForm : BaseActionForm
    {
        public BoolConditionForm()
        {
            InitializeComponent();
        }

        public override void Initialize(Entity entity)
        {
            base.Initialize(entity);
        }

        protected override WolfyAction CreateAction()
        {
            return base.CreateAction();
        }

        protected override bool ValidateAction()
        {
            return base.ValidateAction();
        }

        public override void LoadAction(WolfyAction action)
        {
            base.LoadAction(action);
        }
    }
}
