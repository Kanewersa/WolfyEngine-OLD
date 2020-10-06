using System;
using DarkUI.Forms;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyEngine.Forms
{
    public partial class BaseActionForm : WolfyForm
    {
        protected Entity Entity { get; set; }
        public event WolfyActionHandler OnSave;
        public WolfyAction Action { get; protected set; }

        protected BaseActionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the form.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Initialize(Entity entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Loads the existing action to form.
        /// </summary>
        /// <param name="action">Action to load.</param>
        public virtual void LoadAction(WolfyAction action) { throw new Exception("LoadAction was not overridden in " + GetType()); }

        /// <summary>
        /// Creates <see cref="WolfyAction"/>.
        /// </summary>
        /// <returns>New <see cref="WolfyAction"/></returns>
        protected virtual WolfyAction CreateAction() { return null; }

        /// <summary>
        /// Validates inputs in form.
        /// </summary>
        /// <returns>True if all inputs all valid, false otherwise.</returns>
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
