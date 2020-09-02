namespace WolfyEngine.Forms
{
    partial class ChangeBGMActionForm
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
            this.SelectSongTitle = new DarkUI.Controls.DarkTitle();
            this.AssetTextBox = new DarkUI.Controls.DarkTextBox();
            this.SelectButton = new DarkUI.Controls.DarkButton();
            this.VolumeBox = new DarkUI.Controls.DarkNumericUpDown();
            this.VolumeTitle = new DarkUI.Controls.DarkTitle();
            this.RepeatCheckBox = new DarkUI.Controls.DarkCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectSongTitle
            // 
            this.SelectSongTitle.AutoSize = true;
            this.SelectSongTitle.Location = new System.Drawing.Point(10, 11);
            this.SelectSongTitle.Name = "SelectSongTitle";
            this.SelectSongTitle.Size = new System.Drawing.Size(66, 13);
            this.SelectSongTitle.TabIndex = 2;
            this.SelectSongTitle.Text = "Select song:";
            // 
            // AssetTextBox
            // 
            this.AssetTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.AssetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssetTextBox.Enabled = false;
            this.AssetTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.AssetTextBox.Location = new System.Drawing.Point(11, 29);
            this.AssetTextBox.Name = "AssetTextBox";
            this.AssetTextBox.Size = new System.Drawing.Size(174, 20);
            this.AssetTextBox.TabIndex = 3;
            this.AssetTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AssetTextBox_MouseDoubleClick);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(184, 29);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Padding = new System.Windows.Forms.Padding(5);
            this.SelectButton.Size = new System.Drawing.Size(75, 20);
            this.SelectButton.TabIndex = 4;
            this.SelectButton.Text = "Select";
            this.SelectButton.Click += new System.EventHandler(this.OpenAssetSelectionForm);
            // 
            // VolumeBox
            // 
            this.VolumeBox.Location = new System.Drawing.Point(14, 78);
            this.VolumeBox.Name = "VolumeBox";
            this.VolumeBox.Size = new System.Drawing.Size(120, 20);
            this.VolumeBox.TabIndex = 5;
            this.VolumeBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // VolumeTitle
            // 
            this.VolumeTitle.AutoSize = true;
            this.VolumeTitle.Location = new System.Drawing.Point(11, 62);
            this.VolumeTitle.Name = "VolumeTitle";
            this.VolumeTitle.Size = new System.Drawing.Size(45, 13);
            this.VolumeTitle.TabIndex = 6;
            this.VolumeTitle.Text = "Volume:";
            // 
            // RepeatCheckBox
            // 
            this.RepeatCheckBox.AutoSize = true;
            this.RepeatCheckBox.Checked = true;
            this.RepeatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RepeatCheckBox.Location = new System.Drawing.Point(163, 79);
            this.RepeatCheckBox.Name = "RepeatCheckBox";
            this.RepeatCheckBox.Size = new System.Drawing.Size(87, 17);
            this.RepeatCheckBox.TabIndex = 7;
            this.RepeatCheckBox.Text = "Is repeating?";
            // 
            // ChangeBGMActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 145);
            this.Controls.Add(this.RepeatCheckBox);
            this.Controls.Add(this.VolumeTitle);
            this.Controls.Add(this.VolumeBox);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.AssetTextBox);
            this.Controls.Add(this.SelectSongTitle);
            this.Name = "ChangeBGMActionForm";
            this.Text = "Change BGM";
            this.Controls.SetChildIndex(this.SelectSongTitle, 0);
            this.Controls.SetChildIndex(this.AssetTextBox, 0);
            this.Controls.SetChildIndex(this.SelectButton, 0);
            this.Controls.SetChildIndex(this.VolumeBox, 0);
            this.Controls.SetChildIndex(this.VolumeTitle, 0);
            this.Controls.SetChildIndex(this.RepeatCheckBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTitle SelectSongTitle;
        private DarkUI.Controls.DarkTextBox AssetTextBox;
        private DarkUI.Controls.DarkButton SelectButton;
        private DarkUI.Controls.DarkNumericUpDown VolumeBox;
        private DarkUI.Controls.DarkTitle VolumeTitle;
        private DarkUI.Controls.DarkCheckBox RepeatCheckBox;
    }
}