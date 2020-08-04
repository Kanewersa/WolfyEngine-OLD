using System.Windows.Forms;
using DarkUI.Forms;
using WolfyEngine.Controls;

namespace WolfyEngine.Forms
{
    public partial class NewActionForm : DarkForm
    {
        public UserControl ListDisplay { get; private set; }
        public NewActionForm()
        {
            InitializeComponent();
        }

        private void ActionsTabButton_Click(object sender, System.EventArgs e)
        {
            ActionsTabButton.Checked = true;
            ConditionsTabButton.Checked = false;
            SetDisplay(new NewActionsListDisplay());
        }

        private void ConditionsTabButton_Click(object sender, System.EventArgs e)
        {
            ActionsTabButton.Checked = false;
            ConditionsTabButton.Checked = true;
            SetDisplay(new NewConditionsListDisplay());
        }

        private void SetDisplay(UserControl listDisplay)
        {
            if (ListDisplay != null)
                ListDisplay.Dispose();

            ListDisplay = listDisplay;
            ListDisplay.Dock = DockStyle.Fill;
            Controls.Add(ListDisplay);
            ListDisplay.Show();
        }
    }
}
