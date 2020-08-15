using System.Windows.Forms;
using WolfyECS;
using WolfyEngine.Forms;

namespace WolfyEngine.Controls
{
    public partial class NewConditionsListDisplay : ListDisplay
    {
        public new event WolfyActionHandler OnSelect;

        public NewConditionsListDisplay()
        {
            InitializeComponent();
        }
    }
}
