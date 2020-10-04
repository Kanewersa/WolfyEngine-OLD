namespace WolfyEngine.Forms
{
    partial class VariablesForm
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
            this.VariablesSection = new DarkUI.Controls.DarkSectionPanel();
            this.VariablesListView = new DarkUI.Controls.DarkListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SearchTitle = new DarkUI.Controls.DarkTitle();
            this.SearchBox = new DarkUI.Controls.DarkTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.TopSeparator = new DarkUI.Controls.DarkSeparator();
            this.DockPanel = new DarkUI.Docking.DarkDockPanel();
            this.SearchPictureBox = new System.Windows.Forms.PictureBox();
            this.RemoveVariableButton = new DarkUI.Controls.DarkButton();
            this.SetVariablesLimitButton = new DarkUI.Controls.DarkButton();
            this.VariablesSection.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // VariablesSection
            // 
            this.VariablesSection.Controls.Add(this.VariablesListView);
            this.VariablesSection.Controls.Add(this.panel2);
            this.VariablesSection.Controls.Add(this.panel1);
            this.VariablesSection.Controls.Add(this.TopSeparator);
            this.VariablesSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.VariablesSection.Location = new System.Drawing.Point(0, 0);
            this.VariablesSection.Margin = new System.Windows.Forms.Padding(0);
            this.VariablesSection.Name = "VariablesSection";
            this.VariablesSection.SectionHeader = "Variables";
            this.VariablesSection.Size = new System.Drawing.Size(167, 629);
            this.VariablesSection.TabIndex = 0;
            // 
            // VariablesListView
            // 
            this.VariablesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariablesListView.Location = new System.Drawing.Point(1, 88);
            this.VariablesListView.Margin = new System.Windows.Forms.Padding(0);
            this.VariablesListView.Name = "VariablesListView";
            this.VariablesListView.Size = new System.Drawing.Size(165, 467);
            this.VariablesListView.TabIndex = 8;
            this.VariablesListView.Text = "Variables list";
            this.VariablesListView.Click += new System.EventHandler(this.VariablesListView_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SearchPictureBox);
            this.panel2.Controls.Add(this.SearchTitle);
            this.panel2.Controls.Add(this.SearchBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 61);
            this.panel2.TabIndex = 5;
            // 
            // SearchTitle
            // 
            this.SearchTitle.AutoSize = true;
            this.SearchTitle.Location = new System.Drawing.Point(5, 6);
            this.SearchTitle.Name = "SearchTitle";
            this.SearchTitle.Size = new System.Drawing.Size(41, 13);
            this.SearchTitle.TabIndex = 0;
            this.SearchTitle.Text = "Search";
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SearchBox.Location = new System.Drawing.Point(30, 25);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(127, 20);
            this.SearchBox.TabIndex = 3;
            this.SearchBox.TextChanged += new System.EventHandler(this.FilterVariables);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RemoveVariableButton);
            this.panel1.Controls.Add(this.SetVariablesLimitButton);
            this.panel1.Controls.Add(this.darkSeparator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(1, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 73);
            this.panel1.TabIndex = 2;
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 0);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(165, 2);
            this.darkSeparator1.TabIndex = 0;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // TopSeparator
            // 
            this.TopSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopSeparator.Location = new System.Drawing.Point(1, 25);
            this.TopSeparator.Name = "TopSeparator";
            this.TopSeparator.Size = new System.Drawing.Size(165, 2);
            this.TopSeparator.TabIndex = 1;
            this.TopSeparator.Text = "Top separator";
            // 
            // DockPanel
            // 
            this.DockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.Location = new System.Drawing.Point(167, 0);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(456, 629);
            this.DockPanel.TabIndex = 1;
            // 
            // SearchPictureBox
            // 
            this.SearchPictureBox.Image = global::WolfyEngine.Icons.edit_2;
            this.SearchPictureBox.ImageLocation = "";
            this.SearchPictureBox.Location = new System.Drawing.Point(7, 26);
            this.SearchPictureBox.Name = "SearchPictureBox";
            this.SearchPictureBox.Size = new System.Drawing.Size(20, 20);
            this.SearchPictureBox.TabIndex = 6;
            this.SearchPictureBox.TabStop = false;
            // 
            // RemoveVariableButton
            // 
            this.RemoveVariableButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveVariableButton.Image = global::WolfyEngine.Icons.trash_2;
            this.RemoveVariableButton.ImagePadding = 3;
            this.RemoveVariableButton.Location = new System.Drawing.Point(3, 5);
            this.RemoveVariableButton.Name = "RemoveVariableButton";
            this.RemoveVariableButton.Padding = new System.Windows.Forms.Padding(5);
            this.RemoveVariableButton.Size = new System.Drawing.Size(159, 30);
            this.RemoveVariableButton.TabIndex = 3;
            this.RemoveVariableButton.Text = "Remove variable";
            this.RemoveVariableButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // SetVariablesLimitButton
            // 
            this.SetVariablesLimitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SetVariablesLimitButton.Image = global::WolfyEngine.Icons.edit_2;
            this.SetVariablesLimitButton.ImagePadding = 3;
            this.SetVariablesLimitButton.Location = new System.Drawing.Point(3, 39);
            this.SetVariablesLimitButton.Name = "SetVariablesLimitButton";
            this.SetVariablesLimitButton.Padding = new System.Windows.Forms.Padding(5);
            this.SetVariablesLimitButton.Size = new System.Drawing.Size(159, 30);
            this.SetVariablesLimitButton.TabIndex = 1;
            this.SetVariablesLimitButton.Text = "Set variables limit";
            this.SetVariablesLimitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SetVariablesLimitButton.Click += new System.EventHandler(this.SetVariablesLimitButton_Click);
            // 
            // VariablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 629);
            this.Controls.Add(this.DockPanel);
            this.Controls.Add(this.VariablesSection);
            this.Name = "VariablesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variables";
            this.VariablesSection.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkSectionPanel VariablesSection;
        private DarkUI.Controls.DarkSeparator TopSeparator;
        private System.Windows.Forms.Panel panel1;
        private DarkUI.Controls.DarkButton RemoveVariableButton;
        private DarkUI.Controls.DarkButton SetVariablesLimitButton;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Docking.DarkDockPanel DockPanel;
        private DarkUI.Controls.DarkTextBox SearchBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox SearchPictureBox;
        private DarkUI.Controls.DarkTitle SearchTitle;
        private DarkUI.Controls.DarkListView VariablesListView;
    }
}