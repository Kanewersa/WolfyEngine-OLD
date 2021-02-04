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
            this.OffsetPanel = new System.Windows.Forms.Panel();
            this.DockPanel = new DarkUI.Docking.DarkDockPanel();
            this.LookupSetsSection = new DarkUI.Controls.DarkSectionPanel();
            this.LookupTablesListView = new DarkUI.Controls.DarkListView();
            this.ToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.NewLookupButton = new System.Windows.Forms.ToolStripButton();
            this.RenameLookupButton = new System.Windows.Forms.ToolStripButton();
            this.CopyLookupButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveLookupButton = new System.Windows.Forms.ToolStripButton();
            this.OffsetPanel.SuspendLayout();
            this.LookupSetsSection.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OffsetPanel
            // 
            this.OffsetPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OffsetPanel.Controls.Add(this.DockPanel);
            this.OffsetPanel.Controls.Add(this.LookupSetsSection);
            this.OffsetPanel.Location = new System.Drawing.Point(5, 37);
            this.OffsetPanel.Name = "OffsetPanel";
            this.OffsetPanel.Size = new System.Drawing.Size(790, 558);
            this.OffsetPanel.TabIndex = 5;
            // 
            // DockPanel
            // 
            this.DockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.Location = new System.Drawing.Point(125, 0);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(665, 558);
            this.DockPanel.TabIndex = 6;
            // 
            // LookupSetsSection
            // 
            this.LookupSetsSection.Controls.Add(this.LookupTablesListView);
            this.LookupSetsSection.Controls.Add(this.ToolStrip);
            this.LookupSetsSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.LookupSetsSection.Location = new System.Drawing.Point(0, 0);
            this.LookupSetsSection.Name = "LookupSetsSection";
            this.LookupSetsSection.SectionHeader = "Lookup sets";
            this.LookupSetsSection.Size = new System.Drawing.Size(125, 558);
            this.LookupSetsSection.TabIndex = 5;
            // 
            // LookupTablesListView
            // 
            this.LookupTablesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LookupTablesListView.Location = new System.Drawing.Point(1, 25);
            this.LookupTablesListView.Name = "LookupTablesListView";
            this.LookupTablesListView.Size = new System.Drawing.Size(123, 504);
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
            this.ToolStrip.Location = new System.Drawing.Point(1, 529);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.ToolStrip.Size = new System.Drawing.Size(123, 28);
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
            this.NewLookupButton.Click += new System.EventHandler(this.NewLookupButton_Click);
            // 
            // RenameLookupButton
            // 
            this.RenameLookupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RenameLookupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RenameLookupButton.Enabled = false;
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
            this.CopyLookupButton.Enabled = false;
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
            this.RemoveLookupButton.Click += new System.EventHandler(this.RemoveLookupButton_Click);
            // 
            // LookupTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.OffsetPanel);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LookupTablesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LookupTablesForm";
            this.Controls.SetChildIndex(this.OffsetPanel, 0);
            this.OffsetPanel.ResumeLayout(false);
            this.LookupSetsSection.ResumeLayout(false);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel OffsetPanel;
        private DarkUI.Docking.DarkDockPanel DockPanel;
        private DarkUI.Controls.DarkSectionPanel LookupSetsSection;
        private DarkUI.Controls.DarkListView LookupTablesListView;
        private DarkUI.Controls.DarkToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton NewLookupButton;
        private System.Windows.Forms.ToolStripButton RenameLookupButton;
        private System.Windows.Forms.ToolStripButton CopyLookupButton;
        private System.Windows.Forms.ToolStripButton RemoveLookupButton;
    }
}