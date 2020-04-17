using DarkUI.Forms;
using WolfyEngine.Controls;
using WolfyShared.Engine;
using WolfyShared.Game;

namespace WolfyEngine.Forms
{
    public partial class NewMapForm : DarkForm
    {
        public event MapEventHandler OnMapCreate;

        public NewMapForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void CreateButton_Click(object sender, System.EventArgs e)
        {
            // Create new map here!
            var name = nameTextBox.Text;
            var width = (int) widthBox.Value;
            var height = (int) heightBox.Value;

            var map = new Map(name, new Vector2D(width,height));

            OnMapCreate?.Invoke(map);

            Close();
        }
    }
}
