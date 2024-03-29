﻿namespace WolfyEngine.Forms
{
    partial class NewLayerForm
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
            this.nameTitle = new DarkUI.Controls.DarkTitle();
            this.nameTextBox = new DarkUI.Controls.DarkTextBox();
            this.graphicsPreviewBox = new System.Windows.Forms.PictureBox();
            this.createButton = new DarkUI.Controls.DarkButton();
            this.cancelButton = new DarkUI.Controls.DarkButton();
            this.tilesetsListView = new DarkUI.Controls.DarkListView();
            this.tilesetsTitle = new DarkUI.Controls.DarkTitle();
            ((System.ComponentModel.ISupportInitialize)(this.graphicsPreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTitle
            // 
            this.nameTitle.AutoSize = true;
            this.nameTitle.Location = new System.Drawing.Point(12, 44);
            this.nameTitle.Name = "nameTitle";
            this.nameTitle.Size = new System.Drawing.Size(38, 13);
            this.nameTitle.TabIndex = 13;
            this.nameTitle.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nameTextBox.Location = new System.Drawing.Point(12, 60);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(186, 20);
            this.nameTextBox.TabIndex = 12;
            this.nameTextBox.Text = "LayerName";
            // 
            // graphicsPreviewBox
            // 
            this.graphicsPreviewBox.Location = new System.Drawing.Point(407, 35);
            this.graphicsPreviewBox.Margin = new System.Windows.Forms.Padding(0);
            this.graphicsPreviewBox.Name = "graphicsPreviewBox";
            this.graphicsPreviewBox.Size = new System.Drawing.Size(287, 437);
            this.graphicsPreviewBox.TabIndex = 19;
            this.graphicsPreviewBox.TabStop = false;
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createButton.Location = new System.Drawing.Point(15, 446);
            this.createButton.Name = "createButton";
            this.createButton.Padding = new System.Windows.Forms.Padding(5);
            this.createButton.Size = new System.Drawing.Size(86, 23);
            this.createButton.TabIndex = 21;
            this.createButton.Text = "Create layer";
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(114, 446);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.cancelButton.Size = new System.Drawing.Size(84, 23);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tilesetsListView
            // 
            this.tilesetsListView.Location = new System.Drawing.Point(232, 35);
            this.tilesetsListView.Margin = new System.Windows.Forms.Padding(0);
            this.tilesetsListView.Name = "tilesetsListView";
            this.tilesetsListView.Size = new System.Drawing.Size(169, 434);
            this.tilesetsListView.TabIndex = 25;
            this.tilesetsListView.Text = "Tilesets List View";
            this.tilesetsListView.Click += new System.EventHandler(this.tilesetsListView_Click);
            // 
            // tilesetsTitle
            // 
            this.tilesetsTitle.AutoSize = true;
            this.tilesetsTitle.Location = new System.Drawing.Point(229, 9);
            this.tilesetsTitle.Name = "tilesetsTitle";
            this.tilesetsTitle.Size = new System.Drawing.Size(46, 13);
            this.tilesetsTitle.TabIndex = 26;
            this.tilesetsTitle.Text = "Tilesets:";
            // 
            // NewLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 481);
            this.Controls.Add(this.tilesetsTitle);
            this.Controls.Add(this.tilesetsListView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.graphicsPreviewBox);
            this.Controls.Add(this.nameTitle);
            this.Controls.Add(this.nameTextBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NewLayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New layer";
            this.Controls.SetChildIndex(this.nameTextBox, 0);
            this.Controls.SetChildIndex(this.nameTitle, 0);
            this.Controls.SetChildIndex(this.graphicsPreviewBox, 0);
            this.Controls.SetChildIndex(this.createButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.tilesetsListView, 0);
            this.Controls.SetChildIndex(this.tilesetsTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.graphicsPreviewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTitle nameTitle;
        private DarkUI.Controls.DarkTextBox nameTextBox;
        private System.Windows.Forms.PictureBox graphicsPreviewBox;
        private DarkUI.Controls.DarkButton createButton;
        private DarkUI.Controls.DarkButton cancelButton;
        private DarkUI.Controls.DarkListView tilesetsListView;
        private DarkUI.Controls.DarkTitle tilesetsTitle;
    }
}