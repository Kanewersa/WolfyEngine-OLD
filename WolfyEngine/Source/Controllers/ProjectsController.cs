using System;
using System.IO;
using DarkUI.Forms;
using WolfyCore.Engine;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class ProjectsController : IController
    {
        private static ProjectsController _instance;

        public static ProjectsController Instance => _instance ??= new ProjectsController();
        
        private Project _currentProject;

        public ProgramSettings Settings { get; set; }

        public Project CurrentProject
        {
            get => _currentProject;
            set
            {
                _currentProject = value;
                if (_currentProject == null)
                {
                    // TODO Open project creation here
                    /*DarkMessageBox.ShowError(
                        "Selected project is invalid. The application will close.",
                        "Invalid project!");
                    System.Windows.Forms.Application.Exit();
                    throw new Exception("Could not load empty project.");*/
                }
                else
                {
                    SetLastProject();
                    CurrentProject.Initialize();
                    PathsController.Instance.SetMainPath(_currentProject.Path);
                }
                
                OnProjectChanged?.Invoke(CurrentProject);
            }
        }

        public event ProjectEventHandler OnProjectChanged;

        private void SetLastProject()
        {
            Settings.LastProjectPath = Path.Combine(CurrentProject.Path, CurrentProject.Name + ".proj");
            Settings.Save();
        }

        public void Create(string name, string path, string tileSize)
        {
            int.TryParse(tileSize.Substring(0, 2), out var result);
            var project = new Project(name, path, new Vector2D(result, result));
            project.Save();
            CurrentProject = project;
            ImportDefaultAssets(project);
        }

        /// <summary>
        /// Imports some default assets to the project.
        /// TODO: Import defaults assets only during development.
        /// </summary>
        private static void ImportDefaultAssets(Project project)
        {
            var spritesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", "Assets", "Sprites");
            var directory = new DirectoryInfo(spritesPath);
            var files = directory.GetFiles("*");
            Directory.CreateDirectory(PathsController.Instance.SpritesPath);

            foreach (var sprite in files)
            {
                sprite.CopyTo(Path.Combine(PathsController.Instance.SpritesPath, sprite.Name));
            }

            var tilesetsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", "Assets", "Tilesets");
            directory = new DirectoryInfo(tilesetsPath);
            files = directory.GetFiles("*");
            Directory.CreateDirectory(PathsController.Instance.TilesetsGraphicsPath);

            foreach (var tileset in files)
            {
                tileset.CopyTo(Path.Combine(PathsController.Instance.TilesetsGraphicsPath, tileset.Name));
            }
        }

        public void InitializeProject()
        {

        }

        public void OpenProject(string path)
        {
            // Try to deserialize project from file
            try
            {
                var project = Serialization.ProtoDeserialize<Project>(path);
                project.Initialize();
                //Runtime.CurrentProject = project;
                CurrentProject = project;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void ReloadProject()
        {
            OpenProject(Path.Combine(CurrentProject.Path, CurrentProject.Name + ".proj"));
        }

        public void SaveData()
        {
            CurrentProject.Save();
        }

        public void LoadLastProject()
        {
            if (string.IsNullOrEmpty(Settings.LastProjectPath))
            {
                CurrentProject = null;
            }
            else
            {
                if (!File.Exists(Settings.LastProjectPath))
                {
                    DarkMessageBox.ShowError(
                        "Could not find project in " + Settings.LastProjectPath,
                        "Project not found.");
                    CurrentProject = null;
                    return;
                }

                try
                {
                    CurrentProject = Serialization.ProtoDeserialize<Project>(Settings.LastProjectPath);
                }
                catch (Exception e)
                {
                    DarkMessageBox.ShowError(
                        "Could not load project: " + Settings.LastProjectPath +
                        ". Error: " + e,
                        "Project loading failed.");
                }
            }
        }
    }
}
