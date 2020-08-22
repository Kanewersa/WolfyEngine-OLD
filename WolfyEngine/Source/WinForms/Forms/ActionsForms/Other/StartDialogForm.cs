using DarkUI.Forms;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyEngine.Forms
{
    public partial class StartDialogForm : BaseActionForm
    {
        public StartDialogForm()
        {
            InitializeComponent();
        }

        protected override WolfyAction CreateAction()
        {
            // TODO Player entity should not be used directly.
            return new DialogAction(Entity.Player, TextBox.Text);
        }

        protected override bool ValidateAction()
        {
            return TextBox.Text.Length >= 1;
        }

        public override void LoadAction(WolfyAction action)
        {
            var dialog = (DialogAction)action;

            TextBox.Text = dialog.Content;
        }
    }
}
