using System;
using DarkUI.Forms;
using WolfyEngine.Engine;
using WolfyShared.Engine;

namespace WolfyShared.Controllers
{
    public class ProjectsController
    {
        private static ProjectsController _instance;

        public static ProjectsController Instance => _instance ??= new ProjectsController();
        
        private Project _currentProject;

        public Project CurrentProject
        {
            get => _currentProject;
            set
            {
                _currentProject = value;
                if (_currentProject == null)
                {
                    DarkMessageBox.ShowError(
                        "Selected project is invalid. The application will close.",
                        "Invalid project!");
                    System.Windows.Forms.Application.Exit();
                }
                SetLastProject();
                PathsController.Instance.SetMainPath(_currentProject.Path);
                OnProjectChanged?.Invoke(CurrentProject);
            }
        }

        public event ProjectEventHandler OnProjectChanged;

        private void SetLastProject()
        {
            Runtime.ProgramSettings.LastProject = CurrentProject;
            Runtime.ProgramSettings.Save();
        }

        public void Create(string name, string path, string tileSize)
        {
            int.TryParse(tileSize.Substring(0, 2), out var result);
            var project = new Project(name, path, new Vector2D(result, result));
            project.Save();
            CurrentProject = project;
        }

        public void OpenProject(string path)
        {
            // Try to deserialize project from file
            try
            {
                var project = Serialization.XmlDeserialize<Project>(path);
                project.Initialize();
                //Runtime.CurrentProject = project;
                CurrentProject = project;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void OpenProject(Project project)
        {
            CurrentProject = project;
            CurrentProject.Initialize();
        }

        public void SaveCurrentProject()
        {
            //Runtime.CurrentProject.Save();
            CurrentProject.Save();
        }

        public void LoadLastProject()
        {
            CurrentProject = Runtime.ProgramSettings.LastProject;
            CurrentProject?.Initialize();
        }
    }
}
