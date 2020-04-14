namespace WolfyEngine.Controls
{
    partial class CollisionComponentPanel
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
            this.IsColliderCheckBox = new DarkUI.Controls.DarkCheckBox();
            this.SuspendLayout();
            // 
            // IsColliderCheckBox
            // 
            this.IsColliderCheckBox.AutoSize = true;
            this.IsColliderCheckBox.Checked = true;
            this.IsColliderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsColliderCheckBox.Location = new System.Drawing.Point(14, 39);
            this.IsColliderCheckBox.Name = "IsColliderCheckBox";
            this.IsColliderCheckBox.Size = new System.Drawing.Size(76, 17);
            this.IsColliderCheckBox.TabIndex = 0;
            this.IsColliderCheckBox.Text = "Is collider?";
            // 
            // CollisionComponentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IsColliderCheckBox);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            this.DockText = "Collision";
            this.Name = "CollisionComponentPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkCheckBox IsColliderCheckBox;
    }
}
