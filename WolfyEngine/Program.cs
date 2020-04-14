using System;
using System.IO;
using System.Windows.Forms;
using WolfyEngine.Engine;
using WolfyEngine.Forms;
using WolfyShared;

namespace WolfyEngine
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Load program settings
            if(File.Exists(StaticPaths.ProgramSettings))
                Runtime.ProgramSettings = Serialization.XmlDeserialize<ProgramSettings>(StaticPaths.ProgramSettings);
            else
            {
                Runtime.ProgramSettings = new ProgramSettings();
                Runtime.ProgramSettings.Save();
            }

            // Initialize protobuf
            Serialization.ProtoInitialize();

            //Save program settings on application close
            AppDomain.CurrentDomain.ProcessExit += SaveProgramSettings;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void SaveProgramSettings(object sender, EventArgs e)
        {
            Runtime.ProgramSettings.FirstStart = false;
            Runtime.ProgramSettings.Save();
        }
    }
}
