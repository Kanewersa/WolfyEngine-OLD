using DarkUI.Forms;
using WolfyShared.Engine;

namespace WolfyEngine.Forms
{
    public partial class SelectEntityTypeForm : DarkForm
    {
        public event EntityTypeEventHandler OnTypeSelected;

        public SelectEntityTypeForm()
        {
            InitializeComponent();
        }

        private void NPCButton_Click(object sender, System.EventArgs e)
        {
            OnTypeSelected.Invoke(EntityType.Npc);
        }

        private void StaticButton_Click(object sender, System.EventArgs e)
        {
            OnTypeSelected.Invoke(EntityType.Static);
        }

        private void CustomButton_Click(object sender, System.EventArgs e)
        {
            OnTypeSelected.Invoke(EntityType.Custom);
        }
    }
}
