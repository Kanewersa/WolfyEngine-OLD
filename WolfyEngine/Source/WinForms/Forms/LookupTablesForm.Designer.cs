namespace WolfyEngine.Forms
{
    partial class LookupTablesForm
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
            this.LookupTablesSection = new DarkUI.Controls.DarkSectionPanel();
            this.LookupTablesListView = new DarkUI.Controls.DarkListView();
            this.ToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.NewLookupButton = new System.Windows.Forms.ToolStripButton();
            this.RenameLookupButton = new System.Windows.Forms.ToolStripButton();
            this.CopyLookupButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveLookupButton = new System.Windows.Forms.ToolStripButton();
            this.LookupDockPanel = new DarkUI.Docking.DarkDockPanel();
            this.LookupTablesSection.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LookupTablesSection
            // 
            this.LookupTablesSection.Controls.Add(this.LookupTablesListView);
            this.LookupTablesSection.Controls.Add(this.ToolStrip);
            this.LookupTablesSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.LookupTablesSection.Location = new System.Drawing.Point(0, 32);
            this.LookupTablesSection.Name = "LookupTablesSection";
            this.LookupTablesSection.SectionHeader = "Lookup tables";
            this.LookupTablesSection.Size = new System.Drawing.Size(218, 536);
            this.LookupTablesSection.TabIndex = 0;
            // 
            // LookupTablesListView
            // 
            this.LookupTablesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LookupTablesListView.Location = new System.Drawing.Point(1, 25);
            this.LookupTablesListView.Name = "LookupTablesListView";
            this.LookupTablesListView.Size = new System.Drawing.Size(216, 482);
            this.LookupTablesListView.TabIndex = 0;
            this.LookupTablesListView.Text = "Lookup tables";
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip.Enabled = false;
            this.ToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewLookupButton,
            this.RenameLookupButton,
            this.CopyLookupButton,
            this.RemoveLookupButton});
            this.ToolStrip.Location = new System.Drawing.Point(1, 507);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.ToolStrip.Size = new System.Drawing.Size(216, 28);
            this.ToolStrip.TabIndex = 3;
            this.ToolStrip.Text = "darkToolStrip1";
            // 
            // NewLookupButton
            // 
            this.NewLookupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NewLookupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewLookupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NewLookupButton.Image = global::WolfyEngine.Icons.plus;
            this.NewLookupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewLookupButton.Name = "NewLookupButton";
            this.NewLookupButton.Size = new System.Drawing.Size(23, 25);
            this.NewLookupButton.Text = "toolStripButton1";
            this.NewLookupButton.ToolTipText = "Create new map";
            // 
            // RenameLookupButton
            // 
            this.RenameLookupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RenameLookupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RenameLookupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RenameLookupButton.Image = global::WolfyEngine.Icons.edit_2;
            this.RenameLookupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RenameLookupButton.Name = "RenameLookupButton";
            this.RenameLookupButton.Size = new System.Drawing.Size(23, 25);
            this.RenameLookupButton.Text = "toolStripButton2";
            this.RenameLookupButton.ToolTipText = "Rename map";
            // 
            // CopyLookupButton
            // 
            this.CopyLookupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.CopyLookupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyLookupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CopyLookupButton.Image = global::WolfyEngine.Icons.copy;
            this.CopyLookupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyLookupButton.Name = "CopyLookupButton";
            this.CopyLookupButton.Size = new System.Drawing.Size(23, 25);
            this.CopyLookupButton.Text = "toolStripButton5";
            this.CopyLookupButton.ToolTipText = "Copy map";
            // 
            // RemoveLookupButton
            // 
            this.RemoveLookupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RemoveLookupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveLookupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RemoveLookupButton.Image = global::WolfyEngine.Icons.x;
            this.RemoveLookupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveLookupButton.Name = "RemoveLookupButton";
            this.RemoveLookupButton.Size = new System.Drawing.Size(23, 25);
            this.RemoveLookupButton.Text = "toolStripButton6";
            this.RemoveLookupButton.ToolTipText = "Remove map";
            // 
            // LookupDockPanel
            // 
            this.LookupDockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.LookupDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LookupDockPanel.Location = new System.Drawing.Point(218, 32);
            this.LookupDockPanel.Name = "LookupDockPanel";
            this.LookupDockPanel.Size = new System.Drawing.Size(581, 536);
            this.LookupDockPanel.TabIndex = 1;
            // 
            // LookupTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 568);
            this.Controls.Add(this.LookupDockPanel);
            this.Controls.Add(this.LookupTablesSection);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LookupTablesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LookupTablesForm";
            this.Controls.SetChildIndex(this.LookupTablesSection, 0);
            this.Controls.SetChildIndex(this.LookupDockPanel, 0);
            this.LookupTablesSection.ResumeLayout(false);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkSectionPanel LookupTablesSection;
        private DarkUI.Controls.DarkListView LookupTablesListView;
        private DarkUI.Controls.DarkToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton NewLookupButton;
        private System.Windows.Forms.ToolStripButton RenameLookupButton;
        private System.Windows.Forms.ToolStripButton CopyLookupButton;
        private System.Windows.Forms.ToolStripButton RemoveLookupButton;
        private DarkUI.Docking.DarkDockPanel LookupDockPanel;
    }
}