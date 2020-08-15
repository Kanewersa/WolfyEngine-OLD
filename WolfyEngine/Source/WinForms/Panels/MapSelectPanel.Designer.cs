namespace WolfyEngine.Controls
{
    partial class MapSelectPanel
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
            WolfyEngine.Utils.Selector selector2 = new WolfyEngine.Utils.Selector();
            this.MapControl = new WolfyEngine.Controls.MapSelectControl();
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.GridRenderer = null;
            this.MapControl.Location = new System.Drawing.Point(0, 25);
            this.MapControl.Map = null;
            this.MapControl.Name = "MapControl";
            selector2.Enabled = true;
            this.MapControl.Selector = selector2;
            this.MapControl.Size = new System.Drawing.Size(452, 336);
            this.MapControl.TabIndex = 0;
            this.MapControl.Text = "Map select control";
            // 
            // MapSelectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MapControl);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            this.DockText = "Map";
            this.Name = "MapSelectPanel";
            this.Size = new System.Drawing.Size(452, 361);
            this.ResumeLayout(false);

        }

        #endregion

        private MapSelectControl MapControl;
    }
}
