using System;
using WolfyCore.Actions;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class ListDisplay : ComponentPanel
    {
        public event WolfyActionHandler OnSelect;

        private ListDisplay() : base()
        {
            InitializeComponent();
        }

        public ListDisplay(Type componentType) : base(componentType)
        {
            InitializeComponent();
        }

        protected void InvokeOnSelect(WolfyAction action)
        {
            OnSelect?.Invoke(action);
        }

        protected void OpenForm(BaseActionForm form)
        {
            using var f = form;
            f.Initialize(Entity);
            f.OnSave += InvokeOnSelect;
            f.ShowDialog();
        }
    }
}
