using System.Threading.Tasks;
using DarkUI.Forms;

namespace WolfyEngine.Forms
{
    public class FormHelper
    {
        private static FormHelper _instance;
        public static FormHelper Instance => _instance ??= new FormHelper();

        public async void FadeIn(DarkForm f, int interval = 10)
        {
            while (f.Opacity < 1.0)
            {
                await Task.Delay(interval);
                f.Opacity += 0.08;
            }

            f.Opacity = 1;
        }

        public async void FadeOut(DarkForm f, bool close = false, int interval = 10)
        {
            while (f.Opacity > 0.0)
            {
                await Task.Delay(interval);
                f.Opacity -= 0.08;
            }

            f.Opacity = 0;
            if (close)
            {
                f.Close();
            }
        }
    }
}
