﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using WolfyCore.Controllers;
using WolfyCore.Engine;

namespace WolfyEngine.Forms
{
    public partial class AssetSelectForm : WolfyForm
    {
        private string AssetsPath { get; set; }
        private bool HideExtension { get; set; }

        public event AssetPathHandler OnAssetSelected;

        private static readonly DarkListItem NoneNode = new DarkListItem("[None]");

        public AssetSelectForm(string assetsPath, bool hideExtension = false)
        {
            InitializeComponent();
            AssetsPath = assetsPath;
            HideExtension = hideExtension;
            LoadAssetsFromPath(assetsPath);
        }

        private void LoadAssetsFromPath(string path)
        {
            Directory.CreateDirectory(path);

            var extension = AssetManagerForm.GetAssetExtension(path);
            //Clear files tree view
            FilesListView.Items.Clear();
            FilesListView.Refresh();

            FilesListView.Items.Add(NoneNode);

            foreach (var file in Directory.EnumerateFiles(path, extension, SearchOption.TopDirectoryOnly))
            {
                var compiled = "{name}.xnb";
                var found = path + "\\" + compiled.Replace("{name}", Path.GetFileNameWithoutExtension(file));

                if (File.Exists(found))
                    FilesListView.Items.Add(new DarkListItem(Path.GetFileName(file)));
                else
                {
                    var item = new DarkListItem(Path.GetFileName(file)) { TextColor = Color.IndianRed };
                    FilesListView.Items.Add(item);
                }
            }
        }

        private void PreviewFile(string path)
        {
            if (!File.Exists(path))
            {
                DarkMessageBox.ShowError(
                    "Could not find file: " + path,
                    "File not found.");
                return;
            }

            var extension = Path.GetExtension(path);

            if (extension == ".png")
            {
                using (var temp = new Bitmap(path))
                {
                    previewBox.Image = new Bitmap(temp);
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            // Return if no asset was selected
            if (!FilesListView.SelectedIndices.Any())
            {
                DarkMessageBox.ShowWarning(
                    "Select the asset in the tree view first.",
                    "No asset selected.");
                return;
            }

            if (FilesListView.Items[FilesListView.SelectedIndices[0]] == NoneNode)
            {
                OnAssetSelected?.Invoke(null, null, null, null);
                Close();
                return;
            }

            var assetName = FilesListView.Items[FilesListView.SelectedIndices[0]].Text;
            var fullPath = Path.Combine(AssetsPath, assetName);
            
            var projectPath = PathsController.Instance.MainPath;
            if (!fullPath.StartsWith(projectPath))
                throw new Exception("Asset's absolute path didn't start with project's path.");

            var relativePath = fullPath.Substring(projectPath.Length).TrimStart(Path.DirectorySeparatorChar);
            if (Path.HasExtension(relativePath))
            {
                relativePath = Path.ChangeExtension(relativePath, null);
            }
            var extension = Path.GetExtension(fullPath);

            if (!File.Exists(Path.ChangeExtension(fullPath, ".xnb")))
            {
                DarkMessageBox.ShowWarning(
                    "The possible reason is that your asset was added to the project manually. " +
                    "Restore the asset using Asset Manager.",
                    "Selected asset was not compiled by Asset Manager.");
                return;
            }
            
            OnAssetSelected?.Invoke(assetName, fullPath, relativePath, extension);
            Close();
        }

        private void FilesListView_Click(object sender, EventArgs e)
        {
            if (!FilesListView.SelectedIndices.Any())
                return;

            if (FilesListView.Items[FilesListView.SelectedIndices[0]] == NoneNode)
                return;

            PreviewFile(
                Path.Combine(AssetsPath, FilesListView.Items[FilesListView.SelectedIndices[0]].Text));
        }

        private void FilesListView_DoubleClick(object sender, EventArgs e)
        {
            if (!FilesListView.SelectedIndices.Any()) return;
            SelectButton_Click(sender, e);
        }

        private void AssetManagerButton_Click(object sender, EventArgs e)
        {
            using var assetForm = new AssetManagerForm();
            assetForm.Closed += delegate
            {
                LoadAssetsFromPath(AssetsPath);
            };
            assetForm.ShowDialog();
        }
    }
}
