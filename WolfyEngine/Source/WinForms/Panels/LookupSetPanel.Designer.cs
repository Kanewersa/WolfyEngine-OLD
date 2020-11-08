namespace WolfyEngine.Forms
{
    partial class LookupSetPanel
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
            this.SelectImageButton = new DarkUI.Controls.DarkButton();
            this.GraphicsSection = new DarkUI.Controls.DarkSectionPanel();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.EventsList = new DarkUI.Controls.DarkListView();
            this.ListSectionPanel = new DarkUI.Controls.DarkSectionPanel();
            this.darkToolStrip1 = new DarkUI.Controls.DarkToolStrip();
            this.CreateEventButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveEventButton = new System.Windows.Forms.ToolStripButton();
            this.GraphicsSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.ListSectionPanel.SuspendLayout();
            this.darkToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectImageButton.Location = new System.Drawing.Point(366, 465);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Padding = new System.Windows.Forms.Padding(5);
            this.SelectImageButton.Size = new System.Drawing.Size(215, 31);
            this.SelectImageButton.TabIndex = 12;
            this.SelectImageButton.Text = "Select image";
            // 
            // GraphicsSection
            // 
            this.GraphicsSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GraphicsSection.Controls.Add(this.ImagePictureBox);
            this.GraphicsSection.Location = new System.Drawing.Point(365, 42);
            this.GraphicsSection.Name = "GraphicsSection";
            this.GraphicsSection.SectionHeader = "Graphics";
            this.GraphicsSection.Size = new System.Drawing.Size(216, 418);
            this.GraphicsSection.TabIndex = 11;
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePictureBox.Location = new System.Drawing.Point(1, 25);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(214, 392);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // EventsList
            // 
            this.EventsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventsList.Location = new System.Drawing.Point(1, 25);
            this.EventsList.Name = "EventsList";
            this.EventsList.Size = new System.Drawing.Size(214, 428);
            this.EventsList.TabIndex = 13;
            this.EventsList.Text = "darkListView1";
            // 
            // ListSectionPanel
            // 
            this.ListSectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListSectionPanel.Controls.Add(this.EventsList);
            this.ListSectionPanel.Controls.Add(this.darkToolStrip1);
            this.ListSectionPanel.Location = new System.Drawing.Point(10, 34);
            this.ListSectionPanel.Name = "ListSectionPanel";
            this.ListSectionPanel.SectionHeader = "Time events";
            this.ListSectionPanel.Size = new System.Drawing.Size(216, 482);
            this.ListSectionPanel.TabIndex = 14;
            // 
            // darkToolStrip1
            // 
            this.darkToolStrip1.AutoSize = false;
            this.darkToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.darkToolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateEventButton,
            this.RemoveEventButton});
            this.darkToolStrip1.Location = new System.Drawing.Point(1, 453);
            this.darkToolStrip1.Name = "darkToolStrip1";
            this.darkToolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.darkToolStrip1.Size = new System.Drawing.Size(214, 28);
            this.darkToolStrip1.TabIndex = 16;
            this.darkToolStrip1.Text = "darkToolStrip1";
            // 
            // CreateEventButton
            // 
            this.CreateEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.CreateEventButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CreateEventButton.Image = global::WolfyEngine.Icons.plus;
            this.CreateEventButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateEventButton.Name = "CreateEventButton";
            this.CreateEventButton.Size = new System.Drawing.Size(49, 25);
            this.CreateEventButton.Text = "Add";
            // 
            // RemoveEventButton
            // 
            this.RemoveEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RemoveEventButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RemoveEventButton.Image = global::WolfyEngine.Icons.x;
            this.RemoveEventButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveEventButton.Name = "RemoveEventButton";
            this.RemoveEventButton.Size = new System.Drawing.Size(70, 25);
            this.RemoveEventButton.Text = "Remove";
            // 
            // LookupSetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListSectionPanel);
            this.Controls.Add(this.SelectImageButton);
            this.Controls.Add(this.GraphicsSection);
            this.DockText = "Lookup set";
            this.Name = "LookupSetPanel";
            this.Size = new System.Drawing.Size(624, 527);
            this.GraphicsSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ListSectionPanel.ResumeLayout(false);
            this.darkToolStrip1.ResumeLayout(false);
            this.darkToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkButton SelectImageButton;
        private DarkUI.Controls.DarkSectionPanel GraphicsSection;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private DarkUI.Controls.DarkListView EventsList;
        private DarkUI.Controls.DarkSectionPanel ListSectionPanel;
        private DarkUI.Controls.DarkToolStrip darkToolStrip1;
        private System.Windows.Forms.ToolStripButton CreateEventButton;
        private System.Windows.Forms.ToolStripButton RemoveEventButton;
    }
}
