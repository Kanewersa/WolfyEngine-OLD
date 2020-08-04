namespace WolfyEngine.Forms
{
    partial class NewActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewActionForm));
            this.TabsToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.ActionsTabButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ConditionsTabButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator = new DarkUI.Controls.DarkSeparator();
            this.TabsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabsToolStrip
            // 
            this.TabsToolStrip.AutoSize = false;
            this.TabsToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.TabsToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.TabsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionsTabButton,
            this.toolStripSeparator1,
            this.ConditionsTabButton});
            this.TabsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.TabsToolStrip.Name = "TabsToolStrip";
            this.TabsToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.TabsToolStrip.Size = new System.Drawing.Size(522, 28);
            this.TabsToolStrip.TabIndex = 0;
            this.TabsToolStrip.Text = "darkToolStrip1";
            // 
            // ActionsTabButton
            // 
            this.ActionsTabButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ActionsTabButton.Checked = true;
            this.ActionsTabButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ActionsTabButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ActionsTabButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ActionsTabButton.Image = ((System.Drawing.Image)(resources.GetObject("ActionsTabButton.Image")));
            this.ActionsTabButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActionsTabButton.Name = "ActionsTabButton";
            this.ActionsTabButton.Size = new System.Drawing.Size(51, 25);
            this.ActionsTabButton.Text = "Actions";
            this.ActionsTabButton.Click += new System.EventHandler(this.ActionsTabButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // ConditionsTabButton
            // 
            this.ConditionsTabButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ConditionsTabButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ConditionsTabButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ConditionsTabButton.Image = ((System.Drawing.Image)(resources.GetObject("ConditionsTabButton.Image")));
            this.ConditionsTabButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConditionsTabButton.Name = "ConditionsTabButton";
            this.ConditionsTabButton.Size = new System.Drawing.Size(69, 25);
            this.ConditionsTabButton.Text = "Conditions";
            this.ConditionsTabButton.Click += new System.EventHandler(this.ConditionsTabButton_Click);
            // 
            // ToolStripSeparator
            // 
            this.ToolStripSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolStripSeparator.Location = new System.Drawing.Point(0, 28);
            this.ToolStripSeparator.Name = "ToolStripSeparator";
            this.ToolStripSeparator.Size = new System.Drawing.Size(522, 2);
            this.ToolStripSeparator.TabIndex = 1;
            this.ToolStripSeparator.Text = "darkSeparator1";
            // 
            // NewActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 628);
            this.Controls.Add(this.ToolStripSeparator);
            this.Controls.Add(this.TabsToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewActionForm";
            this.Text = "Create new action";
            this.TabsToolStrip.ResumeLayout(false);
            this.TabsToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkToolStrip TabsToolStrip;
        private DarkUI.Controls.DarkSeparator ToolStripSeparator;
        private System.Windows.Forms.ToolStripButton ActionsTabButton;
        private System.Windows.Forms.ToolStripButton ConditionsTabButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}