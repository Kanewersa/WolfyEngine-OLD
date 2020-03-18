﻿namespace WolfyEngine.Forms
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
            this.filesTreeView = new DarkUI.Controls.DarkTreeView();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.importButton = new DarkUI.Controls.DarkButton();
            this.exportButton = new DarkUI.Controls.DarkButton();
            this.deleteButton = new DarkUI.Controls.DarkButton();
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
            // filesTreeView
            // 
            this.filesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.filesTreeView.Location = new System.Drawing.Point(175, 0);
            this.filesTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.filesTreeView.MaxDragChange = 20;
            this.filesTreeView.Name = "filesTreeView";
            this.filesTreeView.Size = new System.Drawing.Size(175, 564);
            this.filesTreeView.TabIndex = 2;
            this.filesTreeView.Text = "darkTreeView1";
            this.filesTreeView.Click += new System.EventHandler(this.filesTreeView_Click);
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
            // AssetManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 564);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.filesTreeView);
            this.Controls.Add(this.foldersTreeView);
            this.Name = "AssetManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AssetManagerForm";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkTreeView foldersTreeView;
        private DarkUI.Controls.DarkTreeView filesTreeView;
        private System.Windows.Forms.PictureBox previewBox;
        private DarkUI.Controls.DarkButton importButton;
        private DarkUI.Controls.DarkButton exportButton;
        private DarkUI.Controls.DarkButton deleteButton;
    }
}