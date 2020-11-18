using System.Windows.Forms;

namespace WolfyEngine.Forms
{
    partial class SetupMapForm
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
            this.SaveButton = new DarkUI.Controls.DarkButton();
            this.CancelButton = new DarkUI.Controls.DarkButton();
            this.NameTextBox = new DarkUI.Controls.DarkTextBox();
            this.NameTitle = new DarkUI.Controls.DarkTitle();
            this.WidthBox = new DarkUI.Controls.DarkNumericUpDown();
            this.HeightBox = new DarkUI.Controls.DarkNumericUpDown();
            this.WidthTitle = new DarkUI.Controls.DarkTitle();
            this.HeightTitle = new DarkUI.Controls.DarkTitle();
            this.AudioSectionPanel = new DarkUI.Controls.DarkSectionPanel();
            this.BGMSelectButton = new DarkUI.Controls.DarkButton();
            this.BackgroundMusicTitle = new DarkUI.Controls.DarkTitle();
            this.BGMTextBox = new DarkUI.Controls.DarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBox)).BeginInit();
            this.AudioSectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 153);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(5);
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save map";
            this.SaveButton.Click += new System.EventHandler(this.SaveMap);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(125, 153);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NameTextBox.Location = new System.Drawing.Point(12, 58);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(188, 20);
            this.NameTextBox.TabIndex = 2;
            this.NameTextBox.Text = "MapName";
            // 
            // NameTitle
            // 
            this.NameTitle.AutoSize = true;
            this.NameTitle.Location = new System.Drawing.Point(12, 42);
            this.NameTitle.Name = "NameTitle";
            this.NameTitle.Size = new System.Drawing.Size(38, 13);
            this.NameTitle.TabIndex = 3;
            this.NameTitle.Text = "Name:";
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(15, 107);
            this.WidthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(85, 20);
            this.WidthBox.TabIndex = 4;
            this.WidthBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(118, 107);
            this.HeightBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HeightBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(82, 20);
            this.HeightBox.TabIndex = 5;
            this.HeightBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // WidthTitle
            // 
            this.WidthTitle.AutoSize = true;
            this.WidthTitle.Location = new System.Drawing.Point(12, 91);
            this.WidthTitle.Name = "WidthTitle";
            this.WidthTitle.Size = new System.Drawing.Size(38, 13);
            this.WidthTitle.TabIndex = 6;
            this.WidthTitle.Text = "Width:";
            // 
            // HeightTitle
            // 
            this.HeightTitle.AutoSize = true;
            this.HeightTitle.Location = new System.Drawing.Point(115, 91);
            this.HeightTitle.Name = "HeightTitle";
            this.HeightTitle.Size = new System.Drawing.Size(41, 13);
            this.HeightTitle.TabIndex = 7;
            this.HeightTitle.Text = "Height:";
            // 
            // AudioSectionPanel
            // 
            this.AudioSectionPanel.Controls.Add(this.BGMSelectButton);
            this.AudioSectionPanel.Controls.Add(this.BackgroundMusicTitle);
            this.AudioSectionPanel.Controls.Add(this.BGMTextBox);
            this.AudioSectionPanel.Location = new System.Drawing.Point(227, 42);
            this.AudioSectionPanel.Name = "AudioSectionPanel";
            this.AudioSectionPanel.SectionHeader = "Audio";
            this.AudioSectionPanel.Size = new System.Drawing.Size(221, 134);
            this.AudioSectionPanel.TabIndex = 8;
            // 
            // BGMSelectButton
            // 
            this.BGMSelectButton.Location = new System.Drawing.Point(168, 47);
            this.BGMSelectButton.Name = "BGMSelectButton";
            this.BGMSelectButton.Padding = new System.Windows.Forms.Padding(5);
            this.BGMSelectButton.Size = new System.Drawing.Size(30, 20);
            this.BGMSelectButton.TabIndex = 2;
            this.BGMSelectButton.Text = "<<";
            this.BGMSelectButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectBGMAsset);
            // 
            // BackgroundMusicTitle
            // 
            this.BackgroundMusicTitle.AutoSize = true;
            this.BackgroundMusicTitle.Location = new System.Drawing.Point(10, 29);
            this.BackgroundMusicTitle.Name = "BackgroundMusicTitle";
            this.BackgroundMusicTitle.Size = new System.Drawing.Size(95, 13);
            this.BackgroundMusicTitle.TabIndex = 1;
            this.BackgroundMusicTitle.Text = "Background music";
            // 
            // BGMTextBox
            // 
            this.BGMTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.BGMTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BGMTextBox.Enabled = false;
            this.BGMTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.BGMTextBox.Location = new System.Drawing.Point(10, 47);
            this.BGMTextBox.Name = "BGMTextBox";
            this.BGMTextBox.Size = new System.Drawing.Size(188, 20);
            this.BGMTextBox.TabIndex = 0;
            this.BGMTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SelectBGMAsset);
            // 
            // SetupMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 191);
            this.Controls.Add(this.AudioSectionPanel);
            this.Controls.Add(this.HeightTitle);
            this.Controls.Add(this.WidthTitle);
            this.Controls.Add(this.HeightBox);
            this.Controls.Add(this.WidthBox);
            this.Controls.Add(this.NameTitle);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SetupMapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New map";
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CancelButton, 0);
            this.Controls.SetChildIndex(this.NameTextBox, 0);
            this.Controls.SetChildIndex(this.NameTitle, 0);
            this.Controls.SetChildIndex(this.WidthBox, 0);
            this.Controls.SetChildIndex(this.HeightBox, 0);
            this.Controls.SetChildIndex(this.WidthTitle, 0);
            this.Controls.SetChildIndex(this.HeightTitle, 0);
            this.Controls.SetChildIndex(this.AudioSectionPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBox)).EndInit();
            this.AudioSectionPanel.ResumeLayout(false);
            this.AudioSectionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkButton SaveButton;
        private DarkUI.Controls.DarkButton CancelButton;
        private DarkUI.Controls.DarkTextBox NameTextBox;
        private DarkUI.Controls.DarkTitle NameTitle;
        private DarkUI.Controls.DarkNumericUpDown WidthBox;
        private DarkUI.Controls.DarkNumericUpDown HeightBox;
        private DarkUI.Controls.DarkTitle WidthTitle;
        private DarkUI.Controls.DarkTitle HeightTitle;
        private DarkUI.Controls.DarkSectionPanel AudioSectionPanel;
        private DarkUI.Controls.DarkTitle BackgroundMusicTitle;
        private DarkUI.Controls.DarkButton BGMSelectButton;
        private DarkUI.Controls.DarkTextBox BGMTextBox;
    }
}