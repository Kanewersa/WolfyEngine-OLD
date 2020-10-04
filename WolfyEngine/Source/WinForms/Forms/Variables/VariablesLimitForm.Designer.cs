namespace WolfyEngine.Forms
{
    partial class VariablesLimitForm
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
            this.GroupBox = new DarkUI.Controls.DarkGroupBox();
            this.LimitNumericBox = new DarkUI.Controls.DarkNumericUpDown();
            this.ToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelButton = new System.Windows.Forms.ToolStripButton();
            this.GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LimitNumericBox)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.GroupBox.Controls.Add(this.LimitNumericBox);
            this.GroupBox.Location = new System.Drawing.Point(0, 3);
            this.GroupBox.Margin = new System.Windows.Forms.Padding(1);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(140, 55);
            this.GroupBox.TabIndex = 1;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Variables limit";
            // 
            // LimitNumericBox
            // 
            this.LimitNumericBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LimitNumericBox.Location = new System.Drawing.Point(9, 19);
            this.LimitNumericBox.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.LimitNumericBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LimitNumericBox.Name = "LimitNumericBox";
            this.LimitNumericBox.Size = new System.Drawing.Size(120, 20);
            this.LimitNumericBox.TabIndex = 0;
            this.LimitNumericBox.ThousandsSeparator = true;
            this.LimitNumericBox.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.LimitNumericBox.ValueChanged += new System.EventHandler(this.LimitNumericBox_ValueChanged);
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveButton,
            this.toolStripSeparator1,
            this.CancelButton});
            this.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ToolStrip.Location = new System.Drawing.Point(0, 59);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.ToolStrip.Size = new System.Drawing.Size(140, 28);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "Tool strip";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.SaveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SaveButton.Image = global::WolfyEngine.Icons.plus;
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(51, 20);
            this.SaveButton.Text = "Save";
            this.SaveButton.ToolTipText = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.CancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CancelButton.Image = global::WolfyEngine.Icons.x;
            this.CancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CancelButton.Size = new System.Drawing.Size(63, 20);
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // VariablesLimitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(140, 87);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VariablesLimitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set variables limit";
            this.GroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LimitNumericBox)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CancelButton;
        private DarkUI.Controls.DarkToolStrip ToolStrip;
        private DarkUI.Controls.DarkGroupBox GroupBox;
        private DarkUI.Controls.DarkNumericUpDown LimitNumericBox;
    }
}