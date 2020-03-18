using System;
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
            //Runtime.CurrentProject = project;
            CurrentProject = project;
        }

        public void Save(Project project)
        {
            project.Save();
        }

        public void OpenProject(string path)
        {
            // Try to deserialize project from file
            try
            {
                var project = Serialization.ProtoDeserialize<Project>(path);
                project.Load();
                //Runtime.CurrentProject = project;
                CurrentProject = project;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void OpenProject(Project project)
        {
            CurrentProject = project;
            CurrentProject.Load();
        }

        public void SaveCurrentProject()
        {
            //Runtime.CurrentProject.Save();
            CurrentProject.Save();
        }

        public void LoadLastProject()
        {
            CurrentProject = Runtime.ProgramSettings.LastProject;
            CurrentProject?.Load();
        }
    }
}
