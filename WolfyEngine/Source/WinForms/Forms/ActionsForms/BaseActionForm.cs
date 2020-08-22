using System;
using DarkUI.Forms;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyEngine.Forms
{
    public partial class BaseActionForm : DarkForm
    {
        protected Entity Entity { get; set; }
        public event WolfyActionHandler OnSave;
        public WolfyAction Action { get; protected set; }

        protected BaseActionForm()
        {
            InitializeComponent();
        }

        public virtual void Initialize(Entity entity)
        {
            Entity = entity;
        }

        public virtual void LoadAction(WolfyAction action) { throw new Exception("LoadAction was not overridden in " + GetType()); }

        protected virtual WolfyAction CreateAction() { return null; }

        protected virtual bool ValidateAction() { return true; }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateAction())
            {
                DarkMessageBox.ShowWarning("Could not create action. Please fill all required fields before saving.", "Error");
                return;
            }
            Action = CreateAction();
            if (Action == null)
                throw new Exception("Action in " + this + " was not correctly created.");
            
            OnSave?.Invoke(Action);
            Close();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
