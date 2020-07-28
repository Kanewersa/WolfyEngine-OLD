using WolfyCore.ECS;
using WolfyECS;

namespace WolfyEngine.Controls
{
    public partial class ActionComponentPanel : ComponentPanel
    {
        public ActionComponentPanel()
        {
            InitializeComponent();
        }

        public override void Initialize(Entity entity)
        {
            Entity = entity;

            if (entity.HasComponent<ActionComponent>())
            {
                
            }
            else
            {
                
            }
        }

        public override void Save()
        {

        }

        private void SelectAction(object sender, System.EventArgs e)
        {

        }
    }
}
