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
            this.darkSectionPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkSectionPanel1
            // 
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
            this.ActionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionsListView.Location = new System.Drawing.Point(1, 25);
            this.ActionsListView.Name = "ActionsListView";
            this.ActionsListView.Size = new System.Drawing.Size(505, 401);
            this.ActionsListView.TabIndex = 0;
            this.ActionsListView.Text = "darkListView1";
            this.ActionsListView.DoubleClick += new System.EventHandler(this.SelectAction);
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
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkListView ActionsListView;
    }
}
