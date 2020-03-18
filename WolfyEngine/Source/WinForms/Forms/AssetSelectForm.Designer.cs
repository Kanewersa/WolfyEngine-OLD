namespace WolfyEngine.Forms
{
    partial class AssetSelectForm
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
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.filesTreeView = new DarkUI.Controls.DarkTreeView();
            this.selectButton = new DarkUI.Controls.DarkButton();
            this.cancelButton = new DarkUI.Controls.DarkButton();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Location = new System.Drawing.Point(175, 0);
            this.previewBox.Margin = new System.Windows.Forms.Padding(0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(405, 481);
            this.previewBox.TabIndex = 4;
            this.previewBox.TabStop = false;
            // 
            // filesTreeView
            // 
            this.filesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.filesTreeView.Location = new System.Drawing.Point(0, 0);
            this.filesTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.filesTreeView.MaxDragChange = 20;
            this.filesTreeView.Name = "filesTreeView";
            this.filesTreeView.Size = new System.Drawing.Size(175, 481);
            this.filesTreeView.TabIndex = 5;
            this.filesTreeView.Text = "darkTreeView1";
            this.filesTreeView.Click += new System.EventHandler(this.filesTreeView_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(593, 12);
            this.selectButton.Name = "selectButton";
            this.selectButton.Padding = new System.Windows.Forms.Padding(5);
            this.selectButton.Size = new System.Drawing.Size(89, 29);
            this.selectButton.TabIndex = 6;
            this.selectButton.Text = "Select asset";
            this.selectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(593, 440);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.cancelButton.Size = new System.Drawing.Size(89, 29);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AssetSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 481);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.filesTreeView);
            this.Controls.Add(this.previewBox);
            this.Name = "AssetSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AssetSelectForm";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox previewBox;
        private DarkUI.Controls.DarkTreeView filesTreeView;
        private DarkUI.Controls.DarkButton selectButton;
        private DarkUI.Controls.DarkButton cancelButton;
    }
}