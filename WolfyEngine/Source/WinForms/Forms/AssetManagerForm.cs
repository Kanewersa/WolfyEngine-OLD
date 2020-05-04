using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyCore;
using WolfyCore.Controllers;

namespace WolfyEngine.Forms
{
    public partial class AssetManagerForm : DarkForm
    {
        private string SelectedFolder { get; set; }
        private string SelectedFile { get; set; }

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
            if(foldersTreeView.SelectedNodes.Count < 1)
                return;

            if(foldersTreeView.SelectedNodes[0] == null)
            {
                SelectedFolder = null;
                RefreshButtons();
                return;
            }

            var previousFolder = SelectedFile;
            SelectedFolder = FormattedPath(foldersTreeView.SelectedNodes[0].FullPath);

            if (previousFolder != SelectedFolder)
                SelectedFile = null;

            previewBox.Image = null;
            InitializeFilesList();
            RefreshButtons();
        }

        private string FormattedPath(string path)
        {
            var i = path.IndexOf("\\", StringComparison.Ordinal)+1;
            var str = path.Substring(i);
            if(!Runtime.IsWindows)
                str = str.Replace("\\", "/");
            return Path.Combine(ProjectsController.Instance.CurrentProject.Path, str);
        }

        private void InitializeFilesList()
        {
            filesListView.Items.Clear();
            DisplayFiles(SelectedFolder);
        }

        private void DisplayFiles(string folderPath)
        {
            Directory.CreateDirectory(folderPath);

            var extension = "*.png";

            foreach (var file in Directory.EnumerateFiles(folderPath, extension, SearchOption.TopDirectoryOnly))
            {
                var compiled = "{name}.xnb";
                var found = folderPath + "\\" + compiled.Replace("{name}", Path.GetFileNameWithoutExtension(file));

                if (File.Exists(found))
                    filesListView.Items.Add(new DarkListItem(Path.GetFileName(file)));
                else
                {
                    var item = new DarkListItem(Path.GetFileName(file)) { TextColor = Color.IndianRed };

                    filesListView.Items.Add(item);
                }
            }

            //Clear files tree view
            filesListView.Refresh();
        }

        private void filesListView_Click(object sender, EventArgs e)
        {
            if (filesListView.SelectedIndices.Count < 1) return;
            SelectedFile = Path.Combine(
                SelectedFolder,
                filesListView.Items[filesListView.SelectedIndices[0]].Text);
            PreviewFile(SelectedFile);
            RefreshButtons();
        }

        private void PreviewFile(string path)
        {
            if (!File.Exists(path))
            {
                DarkMessageBox.ShowError(
                    "Could not find file: " + path,
                    "File not found.");
                SelectedFile = null;
                return;
            }

            var extension = Path.GetExtension(path);

            using (var temp = new Bitmap(path))
            {
                var img = new Bitmap(temp);
                previewBox.Image = extension == ".png" ? img : null;
            }
        }

        private void RefreshButtons()
        {
            importButton.Enabled = SelectedFolder != null;
            RestoreDirectoryButton.Enabled = SelectedFolder != null;
            OpenDirectoryButton.Enabled = SelectedFolder != null;

            exportButton.Enabled = SelectedFile != null;
            DeleteButton.Enabled = SelectedFile != null;
            RestoreAssetButton.Enabled = SelectedFile != null;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (SelectedFolder == null)
                return;

            using var dialog = new OpenFileDialog
            {
                Title = "Select asset",
                Filter = "png files (*.png)|*.png|All files (*.*)|*.*",
                Multiselect = true
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            var files = dialog.FileNames;

            // Build content
            BuildContent(files);
        }

        private async void BuildContent(string[] files)
        {
            await ContentBuilder.Instance.BuildContent(files);
            MoveBuiltContent(files);
        }

        private void MoveBuiltContent(string[] source)
        {
            // Move pre-built files to proper folder

            foreach (var file in source)
            {
                var info = new FileInfo(file);
                info.CopyTo(SelectedFolder + "\\" + info.Name);
            }

            // Move all built to proper folder
            var builtFiles = Directory.GetFiles(
                Path.Combine(Application.StartupPath, "output"),
                "*.*",
                SearchOption.TopDirectoryOnly);

            if (builtFiles.Length == 0)
            {
                DarkMessageBox.ShowError(
                    "Could not find files in working directory.",
                    "No files found.");
                return;
            }

            foreach (var file in builtFiles)
            {
                var info = new FileInfo(file);
                var path = SelectedFolder + "\\" + info.Name;

                if (File.Exists(path))
                    File.Delete(path);
                
                info.MoveTo(path);
            }

            InitializeFilesList();
        }

        private void ReloadAssetButton_Click(object sender, EventArgs e)
        {
            if (SelectedFile == null) return;

            BuildContent(new [] { SelectedFile });

        }

        private void ReloadDirectoryButton_Click(object sender, EventArgs e)
        {
            if (SelectedFolder == null) return;

            var files = Directory.GetFiles(SelectedFolder)
                .Where(x => Path.GetExtension(x) != ".xnb").ToArray();

            BuildContent(files);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var box = DarkMessageBox.ShowWarning(
                "Are you sure you want to delete this file?",
                "Confirm prompt",
                DarkDialogButton.YesNo);

            if (box != DialogResult.Yes) return;

            if(File.Exists(SelectedFile))
                File.Delete(SelectedFile);

            var counterpart = Path.ChangeExtension(SelectedFile, ".xnb");
            
            if(File.Exists(counterpart))
                File.Delete(counterpart);

            SelectedFile = null;

            InitializeFilesList();
        }

        private void OpenDirectoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(SelectedFolder))
                {
                    var startInfo = new ProcessStartInfo
                    {
                        Arguments = SelectedFolder,
                        FileName = "explorer.exe"
                    };

                    Process.Start(startInfo);
                }
                else
                {
                    DarkMessageBox.ShowError(
                        "Selected directory doesn't exist.",
                        "Could not find directory.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
