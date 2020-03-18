namespace WolfyEngine.Controls
{
    partial class TopPanel
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
            this.ExitButton = new DarkUI.Controls.DarkButton();
            this.MinimizeButton = new DarkUI.Controls.DarkButton();
            this.draggablePanel = new WolfyEngine.Controls.DraggablePanel();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(445, 4);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Padding = new System.Windows.Forms.Padding(5);
            this.ExitButton.Size = new System.Drawing.Size(52, 23);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.TabStop = false;
            this.ExitButton.Text = "X";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.Location = new System.Drawing.Point(385, 4);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Padding = new System.Windows.Forms.Padding(5);
            this.MinimizeButton.Size = new System.Drawing.Size(52, 23);
            this.MinimizeButton.TabIndex = 8;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Text = "-";
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // draggablePanel
            // 
            this.draggablePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.draggablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.draggablePanel.Location = new System.Drawing.Point(0, 0);
            this.draggablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.draggablePanel.Name = "draggablePanel";
            this.draggablePanel.Size = new System.Drawing.Size(500, 32);
            this.draggablePanel.TabIndex = 9;
            // 
            // TopPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.draggablePanel);
            this.Name = "TopPanel";
            this.Size = new System.Drawing.Size(500, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkButton ExitButton;
        private DarkUI.Controls.DarkButton MinimizeButton;
        private DraggablePanel draggablePanel;
    }
}
