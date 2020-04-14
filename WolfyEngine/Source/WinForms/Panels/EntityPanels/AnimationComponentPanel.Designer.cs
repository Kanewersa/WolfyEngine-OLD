namespace WolfyEngine.Controls
{
    partial class AnimationComponentPanel
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
            this.GraphicsSection = new DarkUI.Controls.DarkSectionPanel();
            this.GraphicsPictureBox = new System.Windows.Forms.PictureBox();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FrameCountTitle = new DarkUI.Controls.DarkTitle();
            this.FrameCountNumericUpDown = new DarkUI.Controls.DarkNumericUpDown();
            this.darkTitle1 = new DarkUI.Controls.DarkTitle();
            this.DirectionsCountNumericUpDown = new DarkUI.Controls.DarkNumericUpDown();
            this.SelectGraphicsButton = new DarkUI.Controls.DarkButton();
            this.GraphicsSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsPictureBox)).BeginInit();
            this.darkSectionPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrameCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DirectionsCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphicsSection
            // 
            this.GraphicsSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GraphicsSection.Controls.Add(this.GraphicsPictureBox);
            this.GraphicsSection.Location = new System.Drawing.Point(3, 28);
            this.GraphicsSection.Name = "GraphicsSection";
            this.GraphicsSection.SectionHeader = "Graphics";
            this.GraphicsSection.Size = new System.Drawing.Size(216, 407);
            this.GraphicsSection.TabIndex = 0;
            // 
            // GraphicsPictureBox
            // 
            this.GraphicsPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphicsPictureBox.Location = new System.Drawing.Point(1, 25);
            this.GraphicsPictureBox.Name = "GraphicsPictureBox";
            this.GraphicsPictureBox.Size = new System.Drawing.Size(214, 381);
            this.GraphicsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.GraphicsPictureBox.TabIndex = 0;
            this.GraphicsPictureBox.TabStop = false;
            this.GraphicsPictureBox.DoubleClick += new System.EventHandler(this.GraphicsPictureBox_DoubleClick);
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.darkSectionPanel1.Controls.Add(this.tableLayoutPanel1);
            this.darkSectionPanel1.Location = new System.Drawing.Point(225, 28);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Graphics settings";
            this.darkSectionPanel1.Size = new System.Drawing.Size(353, 248);
            this.darkSectionPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DirectionsCountNumericUpDown, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.darkTitle1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.FrameCountTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FrameCountNumericUpDown, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(351, 222);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FrameCountTitle
            // 
            this.FrameCountTitle.AutoSize = true;
            this.FrameCountTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrameCountTitle.Location = new System.Drawing.Point(10, 10);
            this.FrameCountTitle.Margin = new System.Windows.Forms.Padding(10, 10, 10, 2);
            this.FrameCountTitle.Name = "FrameCountTitle";
            this.FrameCountTitle.Size = new System.Drawing.Size(331, 13);
            this.FrameCountTitle.TabIndex = 0;
            this.FrameCountTitle.Text = "Frame count";
            // 
            // FrameCountNumericUpDown
            // 
            this.FrameCountNumericUpDown.Location = new System.Drawing.Point(4, 27);
            this.FrameCountNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 2, 7, 6);
            this.FrameCountNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.FrameCountNumericUpDown.Name = "FrameCountNumericUpDown";
            this.FrameCountNumericUpDown.Size = new System.Drawing.Size(102, 20);
            this.FrameCountNumericUpDown.TabIndex = 2;
            this.FrameCountNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // darkTitle1
            // 
            this.darkTitle1.AutoSize = true;
            this.darkTitle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkTitle1.Location = new System.Drawing.Point(10, 63);
            this.darkTitle1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 2);
            this.darkTitle1.Name = "darkTitle1";
            this.darkTitle1.Size = new System.Drawing.Size(331, 13);
            this.darkTitle1.TabIndex = 3;
            this.darkTitle1.Text = "Directions count";
            // 
            // DirectionsCountNumericUpDown
            // 
            this.DirectionsCountNumericUpDown.Location = new System.Drawing.Point(4, 80);
            this.DirectionsCountNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 2, 7, 6);
            this.DirectionsCountNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.DirectionsCountNumericUpDown.Name = "DirectionsCountNumericUpDown";
            this.DirectionsCountNumericUpDown.Size = new System.Drawing.Size(102, 20);
            this.DirectionsCountNumericUpDown.TabIndex = 4;
            this.DirectionsCountNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // SelectGraphicsButton
            // 
            this.SelectGraphicsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectGraphicsButton.Location = new System.Drawing.Point(4, 441);
            this.SelectGraphicsButton.Name = "SelectGraphicsButton";
            this.SelectGraphicsButton.Padding = new System.Windows.Forms.Padding(5);
            this.SelectGraphicsButton.Size = new System.Drawing.Size(215, 30);
            this.SelectGraphicsButton.TabIndex = 8;
            this.SelectGraphicsButton.Text = "Select graphics";
            this.SelectGraphicsButton.Click += new System.EventHandler(this.SelectGraphicsButton_Click);
            // 
            // AnimationComponentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectGraphicsButton);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.GraphicsSection);
            this.DockText = "Animation";
            this.Name = "AnimationComponentPanel";
            this.Size = new System.Drawing.Size(581, 474);
            this.GraphicsSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsPictureBox)).EndInit();
            this.darkSectionPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrameCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DirectionsCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkSectionPanel GraphicsSection;
        private System.Windows.Forms.PictureBox GraphicsPictureBox;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DarkUI.Controls.DarkNumericUpDown DirectionsCountNumericUpDown;
        private DarkUI.Controls.DarkTitle darkTitle1;
        private DarkUI.Controls.DarkTitle FrameCountTitle;
        private DarkUI.Controls.DarkNumericUpDown FrameCountNumericUpDown;
        private DarkUI.Controls.DarkButton SelectGraphicsButton;
    }
}
