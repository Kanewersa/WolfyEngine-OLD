namespace WolfyEngine.Controls
{
    partial class ActionComponentPanel
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.ActionsListView = new DarkUI.Controls.DarkListView();
            this.ToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.AddActionButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveActionButton = new System.Windows.Forms.ToolStripButton();
            this.darkSectionPanel1.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Controls.Add(this.ToolStrip);
            this.darkSectionPanel1.Controls.Add(this.ActionsListView);
            this.darkSectionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkSectionPanel1.Location = new System.Drawing.Point(0, 0);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Actions";
            this.darkSectionPanel1.Size = new System.Drawing.Size(507, 427);
            this.darkSectionPanel1.TabIndex = 0;
            // 
            // ActionsListView
            // 
            this.ActionsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ActionsListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.ActionsListView.Location = new System.Drawing.Point(1, 25);
            this.ActionsListView.Name = "ActionsListView";
            this.ActionsListView.Size = new System.Drawing.Size(505, 375);
            this.ActionsListView.TabIndex = 0;
            this.ActionsListView.Text = "darkListView1";
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddActionButton,
            this.RemoveActionButton});
            this.ToolStrip.Location = new System.Drawing.Point(1, 400);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.ToolStrip.Size = new System.Drawing.Size(505, 26);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "darkToolStrip1";
            // 
            // AddActionButton
            // 
            this.AddActionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.AddActionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.AddActionButton.Image = global::WolfyEngine.Icons.plus;
            this.AddActionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddActionButton.Name = "AddActionButton";
            this.AddActionButton.Size = new System.Drawing.Size(85, 23);
            this.AddActionButton.Text = "Add action";
            this.AddActionButton.Click += new System.EventHandler(this.AddActionButton_Click);
            // 
            // RemoveActionButton
            // 
            this.RemoveActionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RemoveActionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RemoveActionButton.Image = global::WolfyEngine.Icons.x;
            this.RemoveActionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveActionButton.Name = "RemoveActionButton";
            this.RemoveActionButton.Size = new System.Drawing.Size(106, 23);
            this.RemoveActionButton.Text = "Remove action";
            this.RemoveActionButton.Click += new System.EventHandler(this.RemoveActionButton_Click);
            // 
            // ActionComponentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.darkSectionPanel1);
            this.Name = "ActionComponentPanel";
            this.Size = new System.Drawing.Size(507, 427);
            this.darkSectionPanel1.ResumeLayout(false);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkListView ActionsListView;
        private DarkUI.Controls.DarkToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton AddActionButton;
        private System.Windows.Forms.ToolStripButton RemoveActionButton;
    }
}
