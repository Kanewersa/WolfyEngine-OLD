using WolfyCore.Actions;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class ListDisplay : ComponentPanel
    {
        public event WolfyActionHandler OnSelect;

        public ListDisplay()
        {
            InitializeComponent();
        }

        protected void InvokeOnSelect(WolfyAction action)
        {
            OnSelect?.Invoke(action);
        }
    }
}
