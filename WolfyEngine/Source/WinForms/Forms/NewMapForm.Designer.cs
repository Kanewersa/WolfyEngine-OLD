using System.Windows.Forms;

namespace WolfyEngine.Forms
{
    partial class NewMapForm
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
            this.createButton = new DarkUI.Controls.DarkButton();
            this.cancelButton = new DarkUI.Controls.DarkButton();
            this.nameTextBox = new DarkUI.Controls.DarkTextBox();
            this.nameTitle = new DarkUI.Controls.DarkTitle();
            this.widthBox = new DarkUI.Controls.DarkNumericUpDown();
            this.heightBox = new DarkUI.Controls.DarkNumericUpDown();
            this.widthTitle = new DarkUI.Controls.DarkTitle();
            this.heightTitle = new DarkUI.Controls.DarkTitle();
            this.AudioSectionPanel = new DarkUI.Controls.DarkSectionPanel();
            this.BGMSelectButton = new DarkUI.Controls.DarkButton();
            this.BackgroundMusicTitle = new DarkUI.Controls.DarkTitle();
            this.BGMTextBox = new DarkUI.Controls.DarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            this.AudioSectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(12, 153);
            this.createButton.Name = "createButton";
            this.createButton.Padding = new System.Windows.Forms.Padding(5);
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(125, 153);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nameTextBox.Location = new System.Drawing.Point(12, 58);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(188, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Text = "MapName";
            // 
            // nameTitle
            // 
            this.nameTitle.AutoSize = true;
            this.nameTitle.Location = new System.Drawing.Point(12, 42);
            this.nameTitle.Name = "nameTitle";
            this.nameTitle.Size = new System.Drawing.Size(38, 13);
            this.nameTitle.TabIndex = 3;
            this.nameTitle.Text = "Name:";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(15, 107);
            this.widthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.widthBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(85, 20);
            this.widthBox.TabIndex = 4;
            this.widthBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(118, 107);
            this.heightBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.heightBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(82, 20);
            this.heightBox.TabIndex = 5;
            this.heightBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // widthTitle
            // 
            this.widthTitle.AutoSize = true;
            this.widthTitle.Location = new System.Drawing.Point(12, 91);
            this.widthTitle.Name = "widthTitle";
            this.widthTitle.Size = new System.Drawing.Size(38, 13);
            this.widthTitle.TabIndex = 6;
            this.widthTitle.Text = "Width:";
            // 
            // heightTitle
            // 
            this.heightTitle.AutoSize = true;
            this.heightTitle.Location = new System.Drawing.Point(115, 91);
            this.heightTitle.Name = "heightTitle";
            this.heightTitle.Size = new System.Drawing.Size(41, 13);
            this.heightTitle.TabIndex = 7;
            this.heightTitle.Text = "Height:";
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
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 191);
            this.Controls.Add(this.AudioSectionPanel);
            this.Controls.Add(this.heightTitle);
            this.Controls.Add(this.widthTitle);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.nameTitle);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NewMapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New map";
            this.Controls.SetChildIndex(this.createButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.nameTextBox, 0);
            this.Controls.SetChildIndex(this.nameTitle, 0);
            this.Controls.SetChildIndex(this.widthBox, 0);
            this.Controls.SetChildIndex(this.heightBox, 0);
            this.Controls.SetChildIndex(this.widthTitle, 0);
            this.Controls.SetChildIndex(this.heightTitle, 0);
            this.Controls.SetChildIndex(this.AudioSectionPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            this.AudioSectionPanel.ResumeLayout(false);
            this.AudioSectionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkButton createButton;
        private DarkUI.Controls.DarkButton cancelButton;
        private DarkUI.Controls.DarkTextBox nameTextBox;
        private DarkUI.Controls.DarkTitle nameTitle;
        private DarkUI.Controls.DarkNumericUpDown widthBox;
        private DarkUI.Controls.DarkNumericUpDown heightBox;
        private DarkUI.Controls.DarkTitle widthTitle;
        private DarkUI.Controls.DarkTitle heightTitle;
        private DarkUI.Controls.DarkSectionPanel AudioSectionPanel;
        private DarkUI.Controls.DarkTitle BackgroundMusicTitle;
        private DarkUI.Controls.DarkButton BGMSelectButton;
        private DarkUI.Controls.DarkTextBox BGMTextBox;
    }
}