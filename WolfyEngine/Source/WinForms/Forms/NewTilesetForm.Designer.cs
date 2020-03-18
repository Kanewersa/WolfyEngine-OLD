namespace WolfyEngine.Forms
{
    partial class NewTilesetForm
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
            this.cancelButton = new DarkUI.Controls.DarkButton();
            this.createButton = new DarkUI.Controls.DarkButton();
            this.graphicsPreviewBox = new System.Windows.Forms.PictureBox();
            this.darkListView1 = new DarkUI.Controls.DarkListView();
            this.autotilesLabel = new DarkUI.Controls.DarkLabel();
            this.addAutotileButton = new DarkUI.Controls.DarkButton();
            this.removeAutotileButton = new DarkUI.Controls.DarkButton();
            this.selectGraphicsButton = new DarkUI.Controls.DarkButton();
            ((System.ComponentModel.ISupportInitialize)(this.graphicsPreviewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTitle
            // 
            this.nameTitle.AutoSize = true;
            this.nameTitle.Location = new System.Drawing.Point(12, 9);
            this.nameTitle.Name = "nameTitle";
            this.nameTitle.Size = new System.Drawing.Size(38, 13);
            this.nameTitle.TabIndex = 11;
            this.nameTitle.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nameTextBox.Location = new System.Drawing.Point(12, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(186, 20);
            this.nameTextBox.TabIndex = 10;
            this.nameTextBox.Text = "TilesetName";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(114, 446);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.cancelButton.Size = new System.Drawing.Size(84, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createButton.Location = new System.Drawing.Point(10, 446);
            this.createButton.Name = "createButton";
            this.createButton.Padding = new System.Windows.Forms.Padding(5);
            this.createButton.Size = new System.Drawing.Size(86, 23);
            this.createButton.TabIndex = 8;
            this.createButton.Text = "Create tileset";
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // graphicsPreviewBox
            // 
            this.graphicsPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphicsPreviewBox.Location = new System.Drawing.Point(224, 12);
            this.graphicsPreviewBox.Name = "graphicsPreviewBox";
            this.graphicsPreviewBox.Size = new System.Drawing.Size(288, 416);
            this.graphicsPreviewBox.TabIndex = 13;
            this.graphicsPreviewBox.TabStop = false;
            // 
            // darkListView1
            // 
            this.darkListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.darkListView1.Location = new System.Drawing.Point(12, 78);
            this.darkListView1.Name = "darkListView1";
            this.darkListView1.Size = new System.Drawing.Size(183, 265);
            this.darkListView1.TabIndex = 14;
            this.darkListView1.Text = "darkListView1";
            // 
            // autotilesLabel
            // 
            this.autotilesLabel.AutoSize = true;
            this.autotilesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.autotilesLabel.Location = new System.Drawing.Point(9, 62);
            this.autotilesLabel.Name = "autotilesLabel";
            this.autotilesLabel.Size = new System.Drawing.Size(50, 13);
            this.autotilesLabel.TabIndex = 15;
            this.autotilesLabel.Text = "Autotiles:";
            // 
            // addAutotileButton
            // 
            this.addAutotileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAutotileButton.Location = new System.Drawing.Point(12, 349);
            this.addAutotileButton.Name = "addAutotileButton";
            this.addAutotileButton.Padding = new System.Windows.Forms.Padding(5);
            this.addAutotileButton.Size = new System.Drawing.Size(84, 36);
            this.addAutotileButton.TabIndex = 16;
            this.addAutotileButton.Text = "Add Autotile";
            // 
            // removeAutotileButton
            // 
            this.removeAutotileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeAutotileButton.Location = new System.Drawing.Point(114, 349);
            this.removeAutotileButton.Name = "removeAutotileButton";
            this.removeAutotileButton.Padding = new System.Windows.Forms.Padding(5);
            this.removeAutotileButton.Size = new System.Drawing.Size(84, 36);
            this.removeAutotileButton.TabIndex = 17;
            this.removeAutotileButton.Text = "Remove Autotile";
            // 
            // selectGraphicsButton
            // 
            this.selectGraphicsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectGraphicsButton.Location = new System.Drawing.Point(275, 434);
            this.selectGraphicsButton.Name = "selectGraphicsButton";
            this.selectGraphicsButton.Padding = new System.Windows.Forms.Padding(5);
            this.selectGraphicsButton.Size = new System.Drawing.Size(189, 40);
            this.selectGraphicsButton.TabIndex = 18;
            this.selectGraphicsButton.Text = "Select tileset graphics";
            this.selectGraphicsButton.Click += new System.EventHandler(this.SelectGraphicsButton_Click);
            // 
            // NewTilesetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 481);
            this.Controls.Add(this.selectGraphicsButton);
            this.Controls.Add(this.removeAutotileButton);
            this.Controls.Add(this.addAutotileButton);
            this.Controls.Add(this.autotilesLabel);
            this.Controls.Add(this.darkListView1);
            this.Controls.Add(this.graphicsPreviewBox);
            this.Controls.Add(this.nameTitle);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Name = "NewTilesetForm";
            this.Text = "New tileset";
            ((System.ComponentModel.ISupportInitialize)(this.graphicsPreviewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkTitle nameTitle;
        private DarkUI.Controls.DarkTextBox nameTextBox;
        private DarkUI.Controls.DarkButton cancelButton;
        private DarkUI.Controls.DarkButton createButton;
        private System.Windows.Forms.PictureBox graphicsPreviewBox;
        private DarkUI.Controls.DarkListView darkListView1;
        private DarkUI.Controls.DarkLabel autotilesLabel;
        private DarkUI.Controls.DarkButton addAutotileButton;
        private DarkUI.Controls.DarkButton removeAutotileButton;
        private DarkUI.Controls.DarkButton selectGraphicsButton;
    }
}