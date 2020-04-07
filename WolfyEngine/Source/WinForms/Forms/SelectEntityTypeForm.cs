using System;
using DarkUI.Forms;
using WolfyShared.Engine;

namespace WolfyEngine.Forms
{
    public partial class SelectEntityTypeForm : DarkForm
    {
        public event EntitySchemeHandler OnTypeSelected;
        private SchemeManager _schemeManager;
        public SelectEntityTypeForm()
        {
            InitializeComponent();
        }
        public void Initialize(SchemeManager manager)
        {
            _schemeManager = manager;
        }

        private void NPCButton_Click(object sender, System.EventArgs e)
        {
            var scheme = _schemeManager.Schemes[0];
            OnTypeSelected?.Invoke(scheme);
        }

        private void StaticButton_Click(object sender, System.EventArgs e)
        {
            var scheme = _schemeManager.Schemes[1];
            OnTypeSelected?.Invoke(scheme);
        }

        private void CustomButton_Click(object sender, System.EventArgs e)
        {
            throw new Exception("Custom entity scheme is not yet implemented.");
            //OnTypeSelected?.Invoke(null);
        }
    }
}
