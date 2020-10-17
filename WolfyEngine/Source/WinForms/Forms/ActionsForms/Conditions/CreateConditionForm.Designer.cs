using System.Windows.Forms;

namespace WolfyEngine.Forms
{
    partial class CreateConditionForm
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
            this.IfTitle = new DarkUI.Controls.DarkTitle();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.VariablePanel = new System.Windows.Forms.Panel();
            this.VariableValueBox = new DarkUI.Controls.DarkNumericUpDown();
            this.SmallerButton = new DarkUI.Controls.DarkRadioButton();
            this.GreaterButton = new DarkUI.Controls.DarkRadioButton();
            this.IsTitle2 = new DarkUI.Controls.DarkTitle();
            this.EqualButton = new DarkUI.Controls.DarkRadioButton();
            this.BoolPanel = new System.Windows.Forms.Panel();
            this.TrueButton = new DarkUI.Controls.DarkRadioButton();
            this.IsTitle = new DarkUI.Controls.DarkTitle();
            this.FalseButton = new DarkUI.Controls.DarkRadioButton();
            this.VariableBox = new DarkUI.Controls.DarkComboBox();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.TopPanel.SuspendLayout();
            this.VariablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableValueBox)).BeginInit();
            this.BoolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IfTitle
            // 
            this.IfTitle.AutoSize = true;
            this.IfTitle.Location = new System.Drawing.Point(15, 19);
            this.IfTitle.Name = "IfTitle";
            this.IfTitle.Size = new System.Drawing.Size(53, 13);
            this.IfTitle.TabIndex = 2;
            this.IfTitle.Text = "If variable";
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
            this.TopPanel.TabIndex = 4;
            // 
            // VariablePanel
            // 
            this.VariablePanel.Controls.Add(this.VariableValueBox);
            this.VariablePanel.Controls.Add(this.SmallerButton);
            this.VariablePanel.Controls.Add(this.GreaterButton);
            this.VariablePanel.Controls.Add(this.IsTitle2);
            this.VariablePanel.Controls.Add(this.EqualButton);
            this.VariablePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.VariablePanel.Location = new System.Drawing.Point(-75, 0);
            this.VariablePanel.Name = "VariablePanel";
            this.VariablePanel.Size = new System.Drawing.Size(210, 51);
            this.VariablePanel.TabIndex = 8;
            this.VariablePanel.Visible = false;
            // 
            // VariableValueBox
            // 
            this.VariableValueBox.Location = new System.Drawing.Point(116, 16);
            this.VariableValueBox.Name = "VariableValueBox";
            this.VariableValueBox.Size = new System.Drawing.Size(91, 20);
            this.VariableValueBox.TabIndex = 9;
            // 
            // SmallerButton
            // 
            this.SmallerButton.AutoSize = true;
            this.SmallerButton.Location = new System.Drawing.Point(26, 17);
            this.SmallerButton.Name = "SmallerButton";
            this.SmallerButton.Size = new System.Drawing.Size(83, 17);
            this.SmallerButton.TabIndex = 8;
            this.SmallerButton.TabStop = true;
            this.SmallerButton.Text = "Smaller than";
            // 
            // GreaterButton
            // 
            this.GreaterButton.AutoSize = true;
            this.GreaterButton.Checked = true;
            this.GreaterButton.Location = new System.Drawing.Point(26, 0);
            this.GreaterButton.Name = "GreaterButton";
            this.GreaterButton.Size = new System.Drawing.Size(84, 17);
            this.GreaterButton.TabIndex = 7;
            this.GreaterButton.TabStop = true;
            this.GreaterButton.Text = "Greater than";
            // 
            // IsTitle2
            // 
            this.IsTitle2.AutoSize = true;
            this.IsTitle2.Location = new System.Drawing.Point(12, 19);
            this.IsTitle2.Name = "IsTitle2";
            this.IsTitle2.Size = new System.Drawing.Size(14, 13);
            this.IsTitle2.TabIndex = 4;
            this.IsTitle2.Text = "is";
            // 
            // EqualButton
            // 
            this.EqualButton.AutoSize = true;
            this.EqualButton.Location = new System.Drawing.Point(26, 34);
            this.EqualButton.Name = "EqualButton";
            this.EqualButton.Size = new System.Drawing.Size(52, 17);
            this.EqualButton.TabIndex = 6;
            this.EqualButton.TabStop = true;
            this.EqualButton.Text = "Equal";
            // 
            // BoolPanel
            // 
            this.BoolPanel.Controls.Add(this.TrueButton);
            this.BoolPanel.Controls.Add(this.IsTitle);
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
            // IsTitle
            // 
            this.IsTitle.AutoSize = true;
            this.IsTitle.Location = new System.Drawing.Point(12, 19);
            this.IsTitle.Name = "IsTitle";
            this.IsTitle.Size = new System.Drawing.Size(14, 13);
            this.IsTitle.TabIndex = 3;
            this.IsTitle.Text = "is";
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
            this.VariableBox.Location = new System.Drawing.Point(74, 16);
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
            // CreateConditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 81);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateConditionForm";
            this.Text = "Create condition 250x120";
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

        private DarkUI.Controls.DarkTitle IfTitle;
        private System.Windows.Forms.Panel TopPanel;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkComboBox VariableBox;
        private DarkUI.Controls.DarkTitle IsTitle;
        private DarkUI.Controls.DarkRadioButton FalseButton;
        private DarkUI.Controls.DarkRadioButton TrueButton;
        private DarkUI.Controls.DarkRadioButton EqualButton;
        private Panel BoolPanel;
        private Panel VariablePanel;
        private DarkUI.Controls.DarkRadioButton GreaterButton;
        private DarkUI.Controls.DarkTitle IsTitle2;
        private DarkUI.Controls.DarkRadioButton SmallerButton;
        private DarkUI.Controls.DarkNumericUpDown VariableValueBox;
    }
}