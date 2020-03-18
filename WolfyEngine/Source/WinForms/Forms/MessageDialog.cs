using DarkUI.Forms;

namespace WolfyEngine.Forms
{
    public partial class MessageDialog : DarkDialog
    {
        public MessageDialog(string message, string caption)
        {
            InitializeComponent();
            DarkMessageBox.ShowInformation(message, caption);
        }
    }
}
