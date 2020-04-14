namespace WolfyEngine.Controls
{
    partial class TilesetEditorPanel
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
            this.tilesetEditorControl = new WolfyEngine.Controls.TilesetEditorControl();
            this.scrollablePanel = new WolfyEngine.Controls.ScrollablePanel();
            this.darkToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.passageButton = new System.Windows.Forms.ToolStripButton();
            this.BushButton = new System.Windows.Forms.ToolStripButton();
            this.ShadersButton = new System.Windows.Forms.ToolStripButton();
            this.scrollablePanel.SuspendLayout();
            this.darkToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tilesetEditorControl
            // 
            this.tilesetEditorControl.Location = new System.Drawing.Point(0, 0);
            this.tilesetEditorControl.Margin = new System.Windows.Forms.Padding(0);
            this.tilesetEditorControl.Name = "tilesetEditorControl";
            this.tilesetEditorControl.Size = new System.Drawing.Size(225, 269);
            this.tilesetEditorControl.TabIndex = 0;
            this.tilesetEditorControl.Text = "TilesetEditor Control";
            // 
            // scrollablePanel
            // 
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.Controls.Add(this.tilesetEditorControl);
            this.scrollablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollablePanel.Location = new System.Drawing.Point(0, 53);
            this.scrollablePanel.Name = "scrollablePanel";
            this.scrollablePanel.Size = new System.Drawing.Size(493, 494);
            this.scrollablePanel.TabIndex = 1;
            // 
            // darkToolStrip
            // 
            this.darkToolStrip.AutoSize = false;
            this.darkToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.darkToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passageButton,
            this.BushButton,
            this.ShadersButton});
            this.darkToolStrip.Location = new System.Drawing.Point(0, 25);
            this.darkToolStrip.Name = "darkToolStrip";
            this.darkToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.darkToolStrip.Size = new System.Drawing.Size(493, 28);
            this.darkToolStrip.TabIndex = 2;
            this.darkToolStrip.Text = "darkToolStrip";
            // 
            // passageButton
            // 
            this.passageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.passageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.passageButton.Image = global::WolfyEngine.Icons.x_circle;
            this.passageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.passageButton.Name = "passageButton";
            this.passageButton.Size = new System.Drawing.Size(69, 25);
            this.passageButton.Text = "Passage";
            this.passageButton.Click += new System.EventHandler(this.passageButton_Click);
            // 
            // BushButton
            // 
            this.BushButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.BushButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.BushButton.Image = global::WolfyEngine.Icons.bar_chart_2;
            this.BushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BushButton.Name = "BushButton";
            this.BushButton.Size = new System.Drawing.Size(53, 25);
            this.BushButton.Text = "Bush";
            this.BushButton.Click += new System.EventHandler(this.BushButton_Click);
            // 
            // ShadersButton
            // 
            this.ShadersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ShadersButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ShadersButton.Image = global::WolfyEngine.Icons.bar_chart_2;
            this.ShadersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShadersButton.Name = "ShadersButton";
            this.ShadersButton.Size = new System.Drawing.Size(68, 25);
            this.ShadersButton.Text = "Shaders";
            // 
            // TilesetEditorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollablePanel);
            this.Controls.Add(this.darkToolStrip);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Right;
            this.DockText = "Tileset Editor";
            this.Name = "TilesetEditorPanel";
            this.Size = new System.Drawing.Size(493, 547);
            this.scrollablePanel.ResumeLayout(false);
            this.darkToolStrip.ResumeLayout(false);
            this.darkToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TilesetEditorControl tilesetEditorControl;
        private ScrollablePanel scrollablePanel;
        private DarkUI.Controls.DarkToolStrip darkToolStrip;
        private System.Windows.Forms.ToolStripButton passageButton;
        private System.Windows.Forms.ToolStripButton ShadersButton;
        private System.Windows.Forms.ToolStripButton BushButton;
    }
}
