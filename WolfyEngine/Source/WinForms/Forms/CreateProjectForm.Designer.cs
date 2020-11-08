namespace WolfyEngine.Forms
{
    partial class CreateProject
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
            this.projectNameTextBox = new DarkUI.Controls.DarkTextBox();
            this.projectNameTitle = new DarkUI.Controls.DarkTitle();
            this.projectPathTextBox = new DarkUI.Controls.DarkTextBox();
            this.projectPathTitle = new DarkUI.Controls.DarkTitle();
            this.createProjectButton = new DarkUI.Controls.DarkButton();
            this.cancelButton = new DarkUI.Controls.DarkButton();
            this.tilesSizeComboBox = new DarkUI.Controls.DarkComboBox();
            this.tileSizeTitle = new DarkUI.Controls.DarkTitle();
            this.SuspendLayout();
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.projectNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectNameTextBox.Location = new System.Drawing.Point(7, 64);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(139, 20);
            this.projectNameTextBox.TabIndex = 1;
            // 
            // projectNameTitle
            // 
            this.projectNameTitle.AutoSize = true;
            this.projectNameTitle.Location = new System.Drawing.Point(8, 48);
            this.projectNameTitle.Name = "projectNameTitle";
            this.projectNameTitle.Size = new System.Drawing.Size(72, 13);
            this.projectNameTitle.TabIndex = 2;
            this.projectNameTitle.Text = "Project name:";
            // 
            // projectPathTextBox
            // 
            this.projectPathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.projectPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectPathTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.projectPathTextBox.Location = new System.Drawing.Point(7, 103);
            this.projectPathTextBox.Name = "projectPathTextBox";
            this.projectPathTextBox.Size = new System.Drawing.Size(197, 20);
            this.projectPathTextBox.TabIndex = 5;
            // 
            // projectPathTitle
            // 
            this.projectPathTitle.AutoSize = true;
            this.projectPathTitle.Location = new System.Drawing.Point(13, 87);
            this.projectPathTitle.Name = "projectPathTitle";
            this.projectPathTitle.Size = new System.Drawing.Size(67, 13);
            this.projectPathTitle.TabIndex = 4;
            this.projectPathTitle.Text = "Project path:";
            // 
            // createProjectButton
            // 
            this.createProjectButton.Location = new System.Drawing.Point(5, 230);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Padding = new System.Windows.Forms.Padding(5);
            this.createProjectButton.Size = new System.Drawing.Size(75, 23);
            this.createProjectButton.TabIndex = 7;
            this.createProjectButton.Text = "Create";
            this.createProjectButton.Click += new System.EventHandler(this.createProjectButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(86, 230);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tilesSizeComboBox
            // 
            this.tilesSizeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.tilesSizeComboBox.FormattingEnabled = true;
            this.tilesSizeComboBox.Items.AddRange(new object[] {
            "16x16",
            "32x32",
            "48x48",
            "64x64",
            "Custom (not available)"});
            this.tilesSizeComboBox.Location = new System.Drawing.Point(7, 152);
            this.tilesSizeComboBox.Name = "tilesSizeComboBox";
            this.tilesSizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.tilesSizeComboBox.TabIndex = 9;
            // 
            // tileSizeTitle
            // 
            this.tileSizeTitle.AutoSize = true;
            this.tileSizeTitle.Location = new System.Drawing.Point(8, 136);
            this.tileSizeTitle.Name = "tileSizeTitle";
            this.tileSizeTitle.Size = new System.Drawing.Size(53, 13);
            this.tileSizeTitle.TabIndex = 10;
            this.tileSizeTitle.Text = "Tiles size:";
            // 
            // CreateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 260);
            this.Controls.Add(this.tileSizeTitle);
            this.Controls.Add(this.tilesSizeComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.projectPathTextBox);
            this.Controls.Add(this.projectPathTitle);
            this.Controls.Add(this.projectNameTitle);
            this.Controls.Add(this.projectNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CreateProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Controls.SetChildIndex(this.projectNameTextBox, 0);
            this.Controls.SetChildIndex(this.projectNameTitle, 0);
            this.Controls.SetChildIndex(this.projectPathTitle, 0);
            this.Controls.SetChildIndex(this.projectPathTextBox, 0);
            this.Controls.SetChildIndex(this.createProjectButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.tilesSizeComboBox, 0);
            this.Controls.SetChildIndex(this.tileSizeTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTextBox projectNameTextBox;
        private DarkUI.Controls.DarkTitle projectNameTitle;
        private DarkUI.Controls.DarkTitle projectPathTitle;
        private DarkUI.Controls.DarkTextBox projectPathTextBox;
        private DarkUI.Controls.DarkButton createProjectButton;
        private DarkUI.Controls.DarkButton cancelButton;
        private DarkUI.Controls.DarkComboBox tilesSizeComboBox;
        private DarkUI.Controls.DarkTitle tileSizeTitle;
    }
}