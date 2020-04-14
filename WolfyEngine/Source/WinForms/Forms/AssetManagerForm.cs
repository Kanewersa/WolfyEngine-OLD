using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyShared.Controllers;

namespace WolfyEngine.Forms
{
    public partial class AssetManagerForm : DarkForm
    {
        public AssetManagerForm()
        {
            InitializeComponent();

            InitializeFolderTree();
        }

        private void InitializeFolderTree()
        {
            var mainNode = new DarkTreeNode(ProjectsController.Instance.CurrentProject.Name) {IsRoot = true};
            foldersTreeView.Nodes.Add(mainNode);

            //Define main folders
            var audio = new DarkTreeNode("Audio");
            mainNode.Nodes.Add(audio);

            var data = new DarkTreeNode("Data");
            mainNode.Nodes.Add(data);

            var fonts = new DarkTreeNode("Fonts");
            mainNode.Nodes.Add(fonts);

            var graphics = new DarkTreeNode("Graphics");
            mainNode.Nodes.Add(graphics);

            //Define sub folders
            var tilesets = new DarkTreeNode("Tilesets");
            graphics.Nodes.Add(tilesets);

            var sprites = new DarkTreeNode("Sprites");
            graphics.Nodes.Add(sprites);

            //Collapse root
            mainNode.Expanded = true;
        }

        private void FoldersTreeView_Click(object sender, System.EventArgs e)
        {
            if(foldersTreeView.SelectedNodes.Count < 1 || foldersTreeView.SelectedNodes[0] == null)
                return;

            previewBox.Image = null;
            InitializeFilesTree();
        }

        private string FormattedPath(string path)
        {
            var i = path.IndexOf("\\", StringComparison.Ordinal)+1;
            var str = path.Substring(i);
            str = str.Replace("\\", "/");
            return Path.Combine(ProjectsController.Instance.CurrentProject.Path, str);
        }

        private void InitializeFilesTree()
        {
            filesTreeView.Nodes.Clear();
            DisplayFiles(FormattedPath(foldersTreeView.SelectedNodes[0].FullPath));
        }

        private void DisplayFiles(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var directory = new DirectoryInfo(folderPath);

            var files = directory.GetFiles("*.png");

            //Clear files tree view
            filesTreeView.Refresh();

            //Fill files tree view with files
            foreach (var file in files)
                filesTreeView.Nodes.Add(new DarkTreeNode(file.Name));
        }

        private void filesTreeView_Click(object sender, EventArgs e)
        {
            if(filesTreeView.SelectedNodes.Count < 1 || filesTreeView.SelectedNodes[0] == null) return;
            PreviewFile(
                Path.Combine(
                    FormattedPath(foldersTreeView.SelectedNodes[0].FullPath),
                    filesTreeView.SelectedNodes[0].Text));
        }

        private void PreviewFile(string path)
        {
            var extension = Path.GetExtension(path);

            using (var temp = new Bitmap(path))
            {
                var img = new Bitmap(temp);
                previewBox.Image = extension == ".png" ? img : null;
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select asset", Filter = "png files (*.png)|*.png|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            //Copy file to appropriate path
            var source = dialog.FileName;
            var destination = Path.Combine(FormattedPath(foldersTreeView.SelectedNodes[0].FullPath),
                dialog.SafeFileName);

            File.Copy(source, destination);
            InitializeFilesTree();
        }
    }
}
