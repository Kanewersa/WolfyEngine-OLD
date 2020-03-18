namespace WolfyEngine.Controls
{
    partial class TilesetPainterPanel
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
            this.tilesetControl = new WolfyEngine.Controls.TilesetControl();
            this.scrollablePanel = new WolfyEngine.Controls.ScrollablePanel();
            this.scrollablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tilesetControl
            // 
            this.tilesetControl.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
            this.tilesetControl.Location = new System.Drawing.Point(0, 0);
            this.tilesetControl.Margin = new System.Windows.Forms.Padding(0);
            this.tilesetControl.Name = "tilesetControl";
            this.tilesetControl.Size = new System.Drawing.Size(142, 240);
            this.tilesetControl.TabIndex = 2;
            this.tilesetControl.Text = "Tileset Control";
            // 
            // scrollablePanel
            // 
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.Controls.Add(this.tilesetControl);
            this.scrollablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollablePanel.Location = new System.Drawing.Point(0, 25);
            this.scrollablePanel.Name = "scrollablePanel";
            this.scrollablePanel.Size = new System.Drawing.Size(256, 340);
            this.scrollablePanel.TabIndex = 3;
            // 
            // TilesetPainterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollablePanel);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Right;
            this.DockText = "Tileset Painter";
            this.Name = "TilesetPainterPanel";
            this.Size = new System.Drawing.Size(256, 365);
            this.scrollablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TilesetControl tilesetControl;
        private ScrollablePanel scrollablePanel;
    }
}
