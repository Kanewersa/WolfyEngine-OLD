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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookupSetPanel));
            this.EventsList = new DarkUI.Controls.DarkListView();
            this.ListSectionPanel = new DarkUI.Controls.DarkSectionPanel();
            this.darkToolStrip1 = new DarkUI.Controls.DarkToolStrip();
            this.CreateEventButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveEventButton = new System.Windows.Forms.ToolStripButton();
            this.SelectedEventSection = new DarkUI.Controls.DarkSectionPanel();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AssetSection = new DarkUI.Controls.DarkSectionPanel();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.SelectImageButton = new DarkUI.Controls.DarkButton();
            this.SettingsSection = new DarkUI.Controls.DarkSectionPanel();
            this.TransitionTimeNumericUpDown = new DarkUI.Controls.DarkNumericUpDown();
            this.TransitionTimeTitle = new DarkUI.Controls.DarkTitle();
            this.TransitionTimeTooltip = new DarkUI.Controls.ToolTipButton();
            this.ListSectionPanel.SuspendLayout();
            this.darkToolStrip1.SuspendLayout();
            this.SelectedEventSection.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            this.AssetSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.SettingsSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransitionTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
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
            this.CreateEventButton.Click += new System.EventHandler(this.CreateEventButton_Click);
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
            // SelectedEventSection
            // 
            this.SelectedEventSection.Controls.Add(this.TableLayoutPanel);
            this.SelectedEventSection.Location = new System.Drawing.Point(232, 34);
            this.SelectedEventSection.Name = "SelectedEventSection";
            this.SelectedEventSection.SectionHeader = "Event";
            this.SelectedEventSection.Size = new System.Drawing.Size(376, 481);
            this.SelectedEventSection.TabIndex = 17;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 2;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.TableLayoutPanel.Controls.Add(this.SettingsSection, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.AssetSection, 0, 0);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel.Location = new System.Drawing.Point(1, 25);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 1;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(374, 452);
            this.TableLayoutPanel.TabIndex = 19;
            // 
            // AssetSection
            // 
            this.AssetSection.Controls.Add(this.ImagePictureBox);
            this.AssetSection.Controls.Add(this.SelectImageButton);
            this.AssetSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetSection.Location = new System.Drawing.Point(3, 3);
            this.AssetSection.Name = "AssetSection";
            this.AssetSection.SectionHeader = "Asset";
            this.AssetSection.Size = new System.Drawing.Size(199, 446);
            this.AssetSection.TabIndex = 19;
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePictureBox.Location = new System.Drawing.Point(1, 25);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(197, 389);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SelectImageButton.Location = new System.Drawing.Point(1, 414);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Padding = new System.Windows.Forms.Padding(5);
            this.SelectImageButton.Size = new System.Drawing.Size(197, 31);
            this.SelectImageButton.TabIndex = 12;
            this.SelectImageButton.Text = "Select image";
            // 
            // SettingsSection
            // 
            this.SettingsSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SettingsSection.Controls.Add(this.TransitionTimeTooltip);
            this.SettingsSection.Controls.Add(this.TransitionTimeTitle);
            this.SettingsSection.Controls.Add(this.TransitionTimeNumericUpDown);
            this.SettingsSection.Location = new System.Drawing.Point(208, 3);
            this.SettingsSection.Name = "SettingsSection";
            this.SettingsSection.SectionHeader = "Settings";
            this.SettingsSection.Size = new System.Drawing.Size(162, 446);
            this.SettingsSection.TabIndex = 20;
            // 
            // TransitionTimeNumericUpDown
            // 
            this.TransitionTimeNumericUpDown.Location = new System.Drawing.Point(6, 53);
            this.TransitionTimeNumericUpDown.Name = "TransitionTimeNumericUpDown";
            this.TransitionTimeNumericUpDown.Size = new System.Drawing.Size(150, 20);
            this.TransitionTimeNumericUpDown.TabIndex = 15;
            // 
            // TransitionTimeTitle
            // 
            this.TransitionTimeTitle.AutoSize = true;
            this.TransitionTimeTitle.Location = new System.Drawing.Point(8, 34);
            this.TransitionTimeTitle.Name = "TransitionTimeTitle";
            this.TransitionTimeTitle.Size = new System.Drawing.Size(75, 13);
            this.TransitionTimeTitle.TabIndex = 16;
            this.TransitionTimeTitle.Text = "Transition time";
            // 
            // TransitionTimeTooltip
            // 
            this.TransitionTimeTooltip.BackColor = System.Drawing.Color.Transparent;
            this.TransitionTimeTooltip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TransitionTimeTooltip.BackgroundImage")));
            this.TransitionTimeTooltip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TransitionTimeTooltip.Location = new System.Drawing.Point(87, 32);
            this.TransitionTimeTooltip.Name = "TransitionTimeTooltip";
            this.TransitionTimeTooltip.Size = new System.Drawing.Size(16, 16);
            this.TransitionTimeTooltip.TabIndex = 17;
            this.TransitionTimeTooltip.ToolTipText = "Transitiom time (in seconds) between selected and previos event.";
            // 
            // LookupSetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectedEventSection);
            this.Controls.Add(this.ListSectionPanel);
            this.DockText = "Lookup set";
            this.Name = "LookupSetPanel";
            this.Size = new System.Drawing.Size(624, 527);
            this.ListSectionPanel.ResumeLayout(false);
            this.darkToolStrip1.ResumeLayout(false);
            this.darkToolStrip1.PerformLayout();
            this.SelectedEventSection.ResumeLayout(false);
            this.TableLayoutPanel.ResumeLayout(false);
            this.AssetSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.SettingsSection.ResumeLayout(false);
            this.SettingsSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransitionTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkListView EventsList;
        private DarkUI.Controls.DarkSectionPanel ListSectionPanel;
        private DarkUI.Controls.DarkToolStrip darkToolStrip1;
        private System.Windows.Forms.ToolStripButton CreateEventButton;
        private System.Windows.Forms.ToolStripButton RemoveEventButton;
        private DarkUI.Controls.DarkSectionPanel SelectedEventSection;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private DarkUI.Controls.DarkSectionPanel SettingsSection;
        private DarkUI.Controls.DarkNumericUpDown TransitionTimeNumericUpDown;
        private DarkUI.Controls.DarkSectionPanel AssetSection;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private DarkUI.Controls.DarkButton SelectImageButton;
        private DarkUI.Controls.DarkTitle TransitionTimeTitle;
        private DarkUI.Controls.ToolTipButton TransitionTimeTooltip;
    }
}
