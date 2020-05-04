using System;
using System.IO;

namespace WolfyCore
{
    public static class StaticPaths
    {
        public static string Documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static string Main = Path.Combine(Documents, "WolfyEngine");

        public static string LogsFolder = Path.Combine(Main, "Logs");
        public static string ProjectsFolder = Path.Combine(Main, "Projects");
        public static string SettingsFolder = Path.Combine(Main, "Settings");

        public static string ProgramSettings = Path.Combine(SettingsFolder, "settings.xml");
        public static string ProjectsList = Path.Combine(ProjectsFolder, "projects.xml");
    }
}
