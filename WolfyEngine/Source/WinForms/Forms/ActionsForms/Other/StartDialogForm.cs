using DarkUI.Forms;
using WolfyCore.Actions;
using WolfyCore.ECS;
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
            return new DialogAction(Entities.Player, TextBox.Text);
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
