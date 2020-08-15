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
            this.ToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.AddActionButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveActionButton = new System.Windows.Forms.ToolStripButton();
            this.ActionsListView = new DarkUI.Controls.DarkListView();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddActionButton,
            this.RemoveActionButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 473);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.ToolStrip.Size = new System.Drawing.Size(606, 26);
            this.ToolStrip.TabIndex = 3;
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
            // ActionsListView
            // 
            this.ActionsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ActionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionsListView.Location = new System.Drawing.Point(0, 0);
            this.ActionsListView.Name = "ActionsListView";
            this.ActionsListView.Size = new System.Drawing.Size(606, 499);
            this.ActionsListView.TabIndex = 2;
            this.ActionsListView.Text = "Action";
            // 
            // ActionComponentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.ActionsListView);
            this.DockText = "Action";
            this.Name = "ActionComponentPanel";
            this.Size = new System.Drawing.Size(606, 499);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton AddActionButton;
        private System.Windows.Forms.ToolStripButton RemoveActionButton;
        private DarkUI.Controls.DarkListView ActionsListView;
    }
}
