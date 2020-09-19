using System;
using WolfyCore.Actions;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class ListDisplay : ComponentPanel
    {
        public event WolfyActionHandler OnSelect;

        public ListDisplay(Type componentType) : base(componentType)
        {
            InitializeComponent();
        }

        protected void InvokeOnSelect(WolfyAction action)
        {
            OnSelect?.Invoke(action);
        }
    }
}
