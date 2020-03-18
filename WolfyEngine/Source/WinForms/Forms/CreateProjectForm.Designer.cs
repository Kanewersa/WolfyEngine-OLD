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
            this.darkTitle1 = new DarkUI.Controls.DarkTitle();
            this.topPanel1 = new WolfyEngine.Controls.TopPanel();
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
            this.projectNameTextBox.Location = new System.Drawing.Point(11, 92);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(139, 20);
            this.projectNameTextBox.TabIndex = 1;
            // 
            // projectNameTitle
            // 
            this.projectNameTitle.AutoSize = true;
            this.projectNameTitle.Location = new System.Drawing.Point(12, 76);
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
            this.projectPathTextBox.Location = new System.Drawing.Point(11, 148);
            this.projectPathTextBox.Name = "projectPathTextBox";
            this.projectPathTextBox.Size = new System.Drawing.Size(294, 20);
            this.projectPathTextBox.TabIndex = 5;
            // 
            // projectPathTitle
            // 
            this.projectPathTitle.AutoSize = true;
            this.projectPathTitle.Location = new System.Drawing.Point(17, 132);
            this.projectPathTitle.Name = "projectPathTitle";
            this.projectPathTitle.Size = new System.Drawing.Size(67, 13);
            this.projectPathTitle.TabIndex = 4;
            this.projectPathTitle.Text = "Project path:";
            // 
            // darkTitle1
            // 
            this.darkTitle1.AutoSize = true;
            this.darkTitle1.Location = new System.Drawing.Point(9, 38);
            this.darkTitle1.Margin = new System.Windows.Forms.Padding(0);
            this.darkTitle1.Name = "darkTitle1";
            this.darkTitle1.Size = new System.Drawing.Size(96, 13);
            this.darkTitle1.TabIndex = 3;
            this.darkTitle1.Text = "Create new project";
            // 
            // topPanel1
            // 
            this.topPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.topPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel1.Location = new System.Drawing.Point(0, 0);
            this.topPanel1.Name = "topPanel1";
            this.topPanel1.Size = new System.Drawing.Size(321, 32);
            this.topPanel1.TabIndex = 6;
            // 
            // createProjectButton
            // 
            this.createProjectButton.Location = new System.Drawing.Point(20, 343);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Padding = new System.Windows.Forms.Padding(5);
            this.createProjectButton.Size = new System.Drawing.Size(75, 23);
            this.createProjectButton.TabIndex = 7;
            this.createProjectButton.Text = "Create";
            this.createProjectButton.Click += new System.EventHandler(this.createProjectButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(230, 343);
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
            this.tilesSizeComboBox.Location = new System.Drawing.Point(11, 210);
            this.tilesSizeComboBox.Name = "tilesSizeComboBox";
            this.tilesSizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.tilesSizeComboBox.TabIndex = 9;
            // 
            // tileSizeTitle
            // 
            this.tileSizeTitle.AutoSize = true;
            this.tileSizeTitle.Location = new System.Drawing.Point(12, 194);
            this.tileSizeTitle.Name = "tileSizeTitle";
            this.tileSizeTitle.Size = new System.Drawing.Size(53, 13);
            this.tileSizeTitle.TabIndex = 10;
            this.tileSizeTitle.Text = "Tiles size:";
            // 
            // CreateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 378);
            this.Controls.Add(this.tileSizeTitle);
            this.Controls.Add(this.tilesSizeComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.topPanel1);
            this.Controls.Add(this.projectPathTextBox);
            this.Controls.Add(this.projectPathTitle);
            this.Controls.Add(this.darkTitle1);
            this.Controls.Add(this.projectNameTitle);
            this.Controls.Add(this.projectNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTextBox projectNameTextBox;
        private DarkUI.Controls.DarkTitle projectNameTitle;
        private DarkUI.Controls.DarkTitle projectPathTitle;
        private DarkUI.Controls.DarkTitle darkTitle1;
        private DarkUI.Controls.DarkTextBox projectPathTextBox;
        private Controls.TopPanel topPanel1;
        private DarkUI.Controls.DarkButton createProjectButton;
        private DarkUI.Controls.DarkButton cancelButton;
        private DarkUI.Controls.DarkComboBox tilesSizeComboBox;
        private DarkUI.Controls.DarkTitle tileSizeTitle;
    }
}