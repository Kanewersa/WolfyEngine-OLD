using DarkUI.Controls;
using DarkUI.Docking;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyCore.Engine;

namespace WolfyEngine.Forms
{
    public partial class LookupSetPanel : DarkToolWindow
    {
        private LookupSet Set { get; set; }
        public LookupSetPanel()
        {
            InitializeComponent();
        }

        private void CreateEventButton_Click(object sender, System.EventArgs e)
        {
            var action = new ChangeLUTAction(Entities.LUTTime, "", 0);
        }

        public void LoadSet(LookupSet set)
        {
            Set = set;

            LoadTimeEvents();
        }

        private void LoadTimeEvents()
        {
            foreach (var pair in Set.Assets)
            {
                var text = pair.Key.AsString(false);
                EventsList.Items.Add(new DarkListItem(text));
            }
        }
    }
}
