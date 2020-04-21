using System.Drawing;

namespace WolfyEngine.Forms
{
    partial class AssetManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.foldersTreeView = new DarkUI.Controls.DarkTreeView();
            this.importButton = new DarkUI.Controls.DarkButton();
            this.exportButton = new DarkUI.Controls.DarkButton();
            this.filesListView = new DarkUI.Controls.DarkListView();
            this.RestoreAssetButton = new DarkUI.Controls.DarkButton();
            this.RestoreDirectoryButton = new DarkUI.Controls.DarkButton();
            this.DeleteButton = new DarkUI.Controls.DarkButton();
            this.previewBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // foldersTreeView
            // 
            this.foldersTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.foldersTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.foldersTreeView.Location = new System.Drawing.Point(0, 0);
            this.foldersTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.foldersTreeView.MaxDragChange = 20;
            this.foldersTreeView.Name = "foldersTreeView";
            this.foldersTreeView.Size = new System.Drawing.Size(175, 564);
            this.foldersTreeView.TabIndex = 1;
            this.foldersTreeView.Text = "darkTreeView1";
            this.foldersTreeView.Click += new System.EventHandler(this.FoldersTreeView_Click);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(742, 9);
            this.importButton.Margin = new System.Windows.Forms.Padding(0);
            this.importButton.Name = "importButton";
            this.importButton.Padding = new System.Windows.Forms.Padding(5);
            this.importButton.Size = new System.Drawing.Size(100, 29);
            this.importButton.TabIndex = 4;
            this.importButton.Text = "Import";
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(742, 51);
            this.exportButton.Margin = new System.Windows.Forms.Padding(0);
            this.exportButton.Name = "exportButton";
            this.exportButton.Padding = new System.Windows.Forms.Padding(5);
            this.exportButton.Size = new System.Drawing.Size(100, 29);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export";
            // 
            // filesListView
            // 
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.filesListView.Location = new System.Drawing.Point(175, 0);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(175, 564);
            this.filesListView.TabIndex = 7;
            this.filesListView.Text = "darkListView1";
            this.filesListView.Click += new System.EventHandler(this.filesListView_Click);
            // 
            // RestoreAssetButton
            // 
            this.RestoreAssetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestoreAssetButton.Enabled = false;
            this.RestoreAssetButton.Location = new System.Drawing.Point(742, 135);
            this.RestoreAssetButton.Margin = new System.Windows.Forms.Padding(0);
            this.RestoreAssetButton.Name = "RestoreAssetButton";
            this.RestoreAssetButton.Padding = new System.Windows.Forms.Padding(5);
            this.RestoreAssetButton.Size = new System.Drawing.Size(100, 29);
            this.RestoreAssetButton.TabIndex = 8;
            this.RestoreAssetButton.Text = "Restore asset";
            this.RestoreAssetButton.Click += new System.EventHandler(this.ReloadAssetButton_Click);
            // 
            // RestoreDirectoryButton
            // 
            this.RestoreDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestoreDirectoryButton.Enabled = false;
            this.RestoreDirectoryButton.Location = new System.Drawing.Point(742, 177);
            this.RestoreDirectoryButton.Margin = new System.Windows.Forms.Padding(0);
            this.RestoreDirectoryButton.Name = "RestoreDirectoryButton";
            this.RestoreDirectoryButton.Padding = new System.Windows.Forms.Padding(5);
            this.RestoreDirectoryButton.Size = new System.Drawing.Size(100, 29);
            this.RestoreDirectoryButton.TabIndex = 9;
            this.RestoreDirectoryButton.Text = "Restore directory";
            this.RestoreDirectoryButton.Click += new System.EventHandler(this.ReloadDirectoryButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Enabled = false;
            this.DeleteButton.ImagePadding = 0;
            this.DeleteButton.Location = new System.Drawing.Point(742, 93);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Padding = new System.Windows.Forms.Padding(5);
            this.DeleteButton.Size = new System.Drawing.Size(100, 29);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Location = new System.Drawing.Point(350, 0);
            this.previewBox.Margin = new System.Windows.Forms.Padding(0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(382, 564);
            this.previewBox.TabIndex = 3;
            this.previewBox.TabStop = false;
            // 
            // AssetManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 564);
            this.Controls.Add(this.RestoreDirectoryButton);
            this.Controls.Add(this.RestoreAssetButton);
            this.Controls.Add(this.filesListView);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.foldersTreeView);
            this.Name = "AssetManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AssetManagerForm";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkTreeView foldersTreeView;
        private System.Windows.Forms.PictureBox previewBox;
        private DarkUI.Controls.DarkButton importButton;
        private DarkUI.Controls.DarkButton exportButton;
        private DarkUI.Controls.DarkButton DeleteButton;
        private DarkUI.Controls.DarkListView filesListView;
        private DarkUI.Controls.DarkButton RestoreAssetButton;
        private DarkUI.Controls.DarkButton RestoreDirectoryButton;
    }
}