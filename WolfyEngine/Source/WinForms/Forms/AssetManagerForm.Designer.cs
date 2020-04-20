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
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.importButton = new DarkUI.Controls.DarkButton();
            this.exportButton = new DarkUI.Controls.DarkButton();
            this.deleteButton = new DarkUI.Controls.DarkButton();
            this.filesListView = new DarkUI.Controls.DarkListView();
            this.ReloadAssetButton = new DarkUI.Controls.DarkButton();
            this.ReloadDirectoryButton = new DarkUI.Controls.DarkButton();
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
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Location = new System.Drawing.Point(350, 0);
            this.previewBox.Margin = new System.Windows.Forms.Padding(0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(377, 564);
            this.previewBox.TabIndex = 3;
            this.previewBox.TabStop = false;
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(733, 9);
            this.importButton.Margin = new System.Windows.Forms.Padding(0);
            this.importButton.Name = "importButton";
            this.importButton.Padding = new System.Windows.Forms.Padding(5);
            this.importButton.Size = new System.Drawing.Size(108, 32);
            this.importButton.TabIndex = 4;
            this.importButton.Text = "Import";
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(733, 51);
            this.exportButton.Margin = new System.Windows.Forms.Padding(0);
            this.exportButton.Name = "exportButton";
            this.exportButton.Padding = new System.Windows.Forms.Padding(5);
            this.exportButton.Size = new System.Drawing.Size(108, 32);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(733, 93);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Padding = new System.Windows.Forms.Padding(5);
            this.deleteButton.Size = new System.Drawing.Size(108, 32);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete";
            // 
            // filesListView
            // 
            this.filesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.filesListView.Location = new System.Drawing.Point(175, 0);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(175, 564);
            this.filesListView.TabIndex = 7;
            this.filesListView.Text = "darkListView1";
            this.filesListView.Click += new System.EventHandler(this.filesListView_Click);
            // 
            // ReloadAssetButton
            // 
            this.ReloadAssetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadAssetButton.Enabled = false;
            this.ReloadAssetButton.Location = new System.Drawing.Point(733, 135);
            this.ReloadAssetButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReloadAssetButton.Name = "ReloadAssetButton";
            this.ReloadAssetButton.Padding = new System.Windows.Forms.Padding(5);
            this.ReloadAssetButton.Size = new System.Drawing.Size(108, 32);
            this.ReloadAssetButton.TabIndex = 8;
            this.ReloadAssetButton.Text = "Reload asset";
            this.ReloadAssetButton.Click += new System.EventHandler(this.ReloadAssetButton_Click);
            // 
            // ReloadDirectoryButton
            // 
            this.ReloadDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadDirectoryButton.Enabled = false;
            this.ReloadDirectoryButton.Location = new System.Drawing.Point(733, 177);
            this.ReloadDirectoryButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReloadDirectoryButton.Name = "ReloadDirectoryButton";
            this.ReloadDirectoryButton.Padding = new System.Windows.Forms.Padding(5);
            this.ReloadDirectoryButton.Size = new System.Drawing.Size(108, 32);
            this.ReloadDirectoryButton.TabIndex = 9;
            this.ReloadDirectoryButton.Text = "Reload directory";
            this.ReloadDirectoryButton.Click += new System.EventHandler(this.ReloadDirectoryButton_Click);
            // 
            // AssetManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 564);
            this.Controls.Add(this.ReloadDirectoryButton);
            this.Controls.Add(this.ReloadAssetButton);
            this.Controls.Add(this.filesListView);
            this.Controls.Add(this.deleteButton);
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
        private DarkUI.Controls.DarkButton deleteButton;
        private DarkUI.Controls.DarkListView filesListView;
        private DarkUI.Controls.DarkButton ReloadAssetButton;
        private DarkUI.Controls.DarkButton ReloadDirectoryButton;
    }
}