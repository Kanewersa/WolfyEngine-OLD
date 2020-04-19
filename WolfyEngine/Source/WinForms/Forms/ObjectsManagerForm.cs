using System.Collections.Generic;
using DarkUI.Docking;
using DarkUI.Forms;
using WolfyEngine.Controls;

namespace WolfyEngine.Forms
{
    public partial class ObjectsManagerForm : DarkForm
    {
        private List<DarkDockContent> _toolWindows = new List<DarkDockContent>();


        private TilesetsPanel TilesetsPanel { get; set; }
        public ObjectsManagerForm()
        {
            InitializeComponent();

            _toolWindows.Add(TilesetsPanel = new TilesetsPanel());

            foreach(var window in _toolWindows)
                darkDockPanel.AddContent(window);
        }
    }
}
