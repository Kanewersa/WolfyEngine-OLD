using System.ComponentModel;
using System.Windows.Forms;
using DarkUI.Forms;
using WolfyCore.Controllers;

namespace WolfyEngine.Forms
{
    public partial class WolfyForm : DarkForm
    {
        protected WolfyForm()
        {
            InitializeComponent();

            // Don't load animations in design mode.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            
            if (ProjectsController.Instance.Settings.SmoothForms)
            {
                Opacity = 0;
                FormHelper.Instance.FadeIn(this);

                FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    if (Opacity != 0)
                    {
                        e.Cancel = true;
                        FormHelper.Instance.FadeOut(this, true);
                    }
                };
            }
        }
    }
}
