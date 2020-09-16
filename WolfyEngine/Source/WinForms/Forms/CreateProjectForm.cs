using System;
using System.IO;
using DarkUI.Forms;
using WolfyCore;
using WolfyCore.Controllers;

// ReSharper disable LocalizableElement

namespace WolfyEngine.Forms
{
    public partial class CreateProject : WolfyForm
    {
        public CreateProject()
        {
            InitializeComponent();
            projectNameTextBox.Text = "newProject";
            projectPathTextBox.Text = StaticPaths.ProjectsFolder;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            var name = projectNameTextBox.Text;
            var path = Path.Combine(projectPathTextBox.Text,  name);
            var tileSize = tilesSizeComboBox.Text;
            //Check if given values are correct
            if (name.Length < 0) return;
            if (path.Length < 0) return;
            if (tileSize.Length < 0) return;

            ProjectsController.Instance.Create(name, path, tileSize);

            Close();
        }


    }
}
