using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WolfyEngine.Engine;
using WolfyEngine.Forms;
using WolfyCore;
using WolfyCore.Controllers;

namespace WolfyEngine
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            WolfyManager.WolfyInitialize();
            // Load program settings
            if(File.Exists(StaticPaths.ProgramSettings))
                ProjectsController.Instance.Settings = Serialization.XmlDeserialize<ProgramSettings>(StaticPaths.ProgramSettings);
            else
            {
                ProjectsController.Instance.Settings = new ProgramSettings();
                ProjectsController.Instance.Settings.Save();
            }

            // Check running os
            Runtime.IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            // Initialize WolfyEngine
            WolfyManager.WolfyInitialize();

            //Save program settings on application close
            AppDomain.CurrentDomain.ProcessExit += SaveProgramSettings;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void SaveProgramSettings(object sender, EventArgs e)
        {
            ProjectsController.Instance.Settings.FirstStart = false;
            ProjectsController.Instance.Settings.Save();
        }
    }
}
