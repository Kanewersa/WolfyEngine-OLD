namespace WolfyEngine.Forms
{
    partial class ChangeVariableForm
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.VariablePanel = new System.Windows.Forms.Panel();
            this.VariableValueBox = new DarkUI.Controls.DarkNumericUpDown();
            this.ToTitle2 = new DarkUI.Controls.DarkTitle();
            this.BoolPanel = new System.Windows.Forms.Panel();
            this.TrueButton = new DarkUI.Controls.DarkRadioButton();
            this.ToTitle = new DarkUI.Controls.DarkTitle();
            this.FalseButton = new DarkUI.Controls.DarkRadioButton();
            this.VariableBox = new DarkUI.Controls.DarkComboBox();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.IfTitle = new DarkUI.Controls.DarkTitle();
            this.TopPanel.SuspendLayout();
            this.VariablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableValueBox)).BeginInit();
            this.BoolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.VariablePanel);
            this.TopPanel.Controls.Add(this.BoolPanel);
            this.TopPanel.Controls.Add(this.VariableBox);
            this.TopPanel.Controls.Add(this.darkSeparator1);
            this.TopPanel.Controls.Add(this.IfTitle);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(234, 53);
            this.TopPanel.TabIndex = 5;
            // 
            // VariablePanel
            // 
            this.VariablePanel.Controls.Add(this.VariableValueBox);
            this.VariablePanel.Controls.Add(this.ToTitle2);
            this.VariablePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.VariablePanel.Location = new System.Drawing.Point(0, 0);
            this.VariablePanel.Name = "VariablePanel";
            this.VariablePanel.Size = new System.Drawing.Size(135, 51);
            this.VariablePanel.TabIndex = 8;
            this.VariablePanel.Visible = false;
            // 
            // VariableValueBox
            // 
            this.VariableValueBox.Location = new System.Drawing.Point(32, 17);
            this.VariableValueBox.Name = "VariableValueBox";
            this.VariableValueBox.Size = new System.Drawing.Size(91, 20);
            this.VariableValueBox.TabIndex = 9;
            // 
            // ToTitle2
            // 
            this.ToTitle2.AutoSize = true;
            this.ToTitle2.Location = new System.Drawing.Point(12, 19);
            this.ToTitle2.Name = "ToTitle2";
            this.ToTitle2.Size = new System.Drawing.Size(16, 13);
            this.ToTitle2.TabIndex = 4;
            this.ToTitle2.Text = "to";
            // 
            // BoolPanel
            // 
            this.BoolPanel.Controls.Add(this.TrueButton);
            this.BoolPanel.Controls.Add(this.ToTitle);
            this.BoolPanel.Controls.Add(this.FalseButton);
            this.BoolPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BoolPanel.Location = new System.Drawing.Point(135, 0);
            this.BoolPanel.Name = "BoolPanel";
            this.BoolPanel.Size = new System.Drawing.Size(99, 51);
            this.BoolPanel.TabIndex = 7;
            this.BoolPanel.Visible = false;
            // 
            // TrueButton
            // 
            this.TrueButton.AutoSize = true;
            this.TrueButton.Checked = true;
            this.TrueButton.Location = new System.Drawing.Point(33, 9);
            this.TrueButton.Name = "TrueButton";
            this.TrueButton.Size = new System.Drawing.Size(47, 17);
            this.TrueButton.TabIndex = 4;
            this.TrueButton.TabStop = true;
            this.TrueButton.Text = "True";
            // 
            // ToTitle
            // 
            this.ToTitle.AutoSize = true;
            this.ToTitle.Location = new System.Drawing.Point(12, 19);
            this.ToTitle.Name = "ToTitle";
            this.ToTitle.Size = new System.Drawing.Size(16, 13);
            this.ToTitle.TabIndex = 3;
            this.ToTitle.Text = "to";
            // 
            // FalseButton
            // 
            this.FalseButton.AutoSize = true;
            this.FalseButton.Location = new System.Drawing.Point(33, 27);
            this.FalseButton.Name = "FalseButton";
            this.FalseButton.Size = new System.Drawing.Size(50, 17);
            this.FalseButton.TabIndex = 5;
            this.FalseButton.TabStop = true;
            this.FalseButton.Text = "False";
            // 
            // VariableBox
            // 
            this.VariableBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.VariableBox.FormattingEnabled = true;
            this.VariableBox.Location = new System.Drawing.Point(85, 16);
            this.VariableBox.Name = "VariableBox";
            this.VariableBox.Size = new System.Drawing.Size(148, 21);
            this.VariableBox.TabIndex = 5;
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 51);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(234, 2);
            this.darkSeparator1.TabIndex = 4;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // IfTitle
            // 
            this.IfTitle.AutoSize = true;
            this.IfTitle.Location = new System.Drawing.Point(15, 19);
            this.IfTitle.Name = "IfTitle";
            this.IfTitle.Size = new System.Drawing.Size(63, 13);
            this.IfTitle.TabIndex = 2;
            this.IfTitle.Text = "Set variable";
            // 
            // ChangeVariableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 81);
            this.Controls.Add(this.TopPanel);
            this.Name = "ChangeVariableForm";
            this.Text = "Change variable";
            this.Controls.SetChildIndex(this.TopPanel, 0);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.VariablePanel.ResumeLayout(false);
            this.VariablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableValueBox)).EndInit();
            this.BoolPanel.ResumeLayout(false);
            this.BoolPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel VariablePanel;
        private DarkUI.Controls.DarkNumericUpDown VariableValueBox;
        private DarkUI.Controls.DarkTitle ToTitle2;
        private System.Windows.Forms.Panel BoolPanel;
        private DarkUI.Controls.DarkRadioButton TrueButton;
        private DarkUI.Controls.DarkTitle ToTitle;
        private DarkUI.Controls.DarkRadioButton FalseButton;
        private DarkUI.Controls.DarkComboBox VariableBox;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkTitle IfTitle;
    }
}