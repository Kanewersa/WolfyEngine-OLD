using DarkUI.Docking;
using WolfyECS;

namespace WolfyEngine.Controls
{
    public partial class ComponentPanel : DarkToolWindow
    {
        public ComponentPanel()
        {
            InitializeComponent();
        }

        public virtual void Initialize(Entity entity) { }

        public virtual void Unload(Entity entity) { }
    }
}
