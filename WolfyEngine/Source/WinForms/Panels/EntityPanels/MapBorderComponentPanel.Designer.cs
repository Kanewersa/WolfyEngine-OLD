namespace WolfyEngine.Controls
{
    partial class MapBorderComponentPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CoordinatesTitle = new DarkUI.Controls.DarkTitle();
            this.MapTitle = new DarkUI.Controls.DarkTitle();
            this.CoordinatesBox = new DarkUI.Controls.DarkTextBox();
            this.MapBox = new DarkUI.Controls.DarkTextBox();
            this.SelectDestinationButton = new DarkUI.Controls.DarkButton();
            this.DirectionGroupBox = new DarkUI.Controls.DarkGroupBox();
            this.AfterDirectionBox = new DarkUI.Controls.DarkComboBox();
            this.darkTitle2 = new DarkUI.Controls.DarkTitle();
            this.darkTitle1 = new DarkUI.Controls.DarkTitle();
            this.BeforeDirectionBox = new DarkUI.Controls.DarkComboBox();
            this.BothWaysCheckBox = new DarkUI.Controls.DarkCheckBox();
            this.DirectionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CoordinatesTitle
            // 
            this.CoordinatesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CoordinatesTitle.AutoSize = true;
            this.CoordinatesTitle.Location = new System.Drawing.Point(159, 11);
            this.CoordinatesTitle.Name = "CoordinatesTitle";
            this.CoordinatesTitle.Size = new System.Drawing.Size(61, 13);
            this.CoordinatesTitle.TabIndex = 12;
            this.CoordinatesTitle.Text = "Teleport to:";
            // 
            // MapTitle
            // 
            this.MapTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MapTitle.AutoSize = true;
            this.MapTitle.Location = new System.Drawing.Point(10, 11);
            this.MapTitle.Name = "MapTitle";
            this.MapTitle.Size = new System.Drawing.Size(78, 13);
            this.MapTitle.TabIndex = 11;
            this.MapTitle.Text = "Bordering map:";
            // 
            // CoordinatesBox
            // 
            this.CoordinatesBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CoordinatesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.CoordinatesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CoordinatesBox.Enabled = false;
            this.CoordinatesBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CoordinatesBox.Location = new System.Drawing.Point(162, 28);
            this.CoordinatesBox.Name = "CoordinatesBox";
            this.CoordinatesBox.Size = new System.Drawing.Size(93, 20);
            this.CoordinatesBox.TabIndex = 10;
            this.CoordinatesBox.Text = "Not selected";
            // 
            // MapBox
            // 
            this.MapBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MapBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.MapBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapBox.Enabled = false;
            this.MapBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MapBox.Location = new System.Drawing.Point(13, 28);
            this.MapBox.Name = "MapBox";
            this.MapBox.Size = new System.Drawing.Size(93, 20);
            this.MapBox.TabIndex = 9;
            this.MapBox.Text = "Not Selected";
            // 
            // SelectDestinationButton
            // 
            this.SelectDestinationButton.Location = new System.Drawing.Point(13, 68);
            this.SelectDestinationButton.Name = "SelectDestinationButton";
            this.SelectDestinationButton.Padding = new System.Windows.Forms.Padding(5);
            this.SelectDestinationButton.Size = new System.Drawing.Size(242, 40);
            this.SelectDestinationButton.TabIndex = 8;
            this.SelectDestinationButton.Text = "Select destination";
            this.SelectDestinationButton.Click += new System.EventHandler(this.SelectDestinationButton_Click);
            // 
            // DirectionGroupBox
            // 
            this.DirectionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectionGroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DirectionGroupBox.Controls.Add(this.AfterDirectionBox);
            this.DirectionGroupBox.Controls.Add(this.darkTitle2);
            this.DirectionGroupBox.Controls.Add(this.darkTitle1);
            this.DirectionGroupBox.Controls.Add(this.BeforeDirectionBox);
            this.DirectionGroupBox.Location = new System.Drawing.Point(0, 173);
            this.DirectionGroupBox.Name = "DirectionGroupBox";
            this.DirectionGroupBox.Size = new System.Drawing.Size(276, 80);
            this.DirectionGroupBox.TabIndex = 16;
            this.DirectionGroupBox.TabStop = false;
            this.DirectionGroupBox.Text = "Direction";
            // 
            // AfterDirectionBox
            // 
            this.AfterDirectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AfterDirectionBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.AfterDirectionBox.FormattingEnabled = true;
            this.AfterDirectionBox.Items.AddRange(new object[] {
            "Bottom",
            "Left",
            "Right",
            "Top"});
            this.AfterDirectionBox.Location = new System.Drawing.Point(167, 45);
            this.AfterDirectionBox.Name = "AfterDirectionBox";
            this.AfterDirectionBox.Size = new System.Drawing.Size(100, 21);
            this.AfterDirectionBox.TabIndex = 22;
            this.AfterDirectionBox.SelectedIndexChanged += new System.EventHandler(this.AfterDirectionBox_SelectedIndexChanged);
            // 
            // darkTitle2
            // 
            this.darkTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.darkTitle2.AutoSize = true;
            this.darkTitle2.Location = new System.Drawing.Point(164, 26);
            this.darkTitle2.Name = "darkTitle2";
            this.darkTitle2.Size = new System.Drawing.Size(93, 13);
            this.darkTitle2.TabIndex = 21;
            this.darkTitle2.Text = "After teleportation:";
            // 
            // darkTitle1
            // 
            this.darkTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.darkTitle1.AutoSize = true;
            this.darkTitle1.Location = new System.Drawing.Point(9, 27);
            this.darkTitle1.Name = "darkTitle1";
            this.darkTitle1.Size = new System.Drawing.Size(102, 13);
            this.darkTitle1.TabIndex = 20;
            this.darkTitle1.Text = "Before teleportation:";
            // 
            // BeforeDirectionBox
            // 
            this.BeforeDirectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BeforeDirectionBox.DisplayMember = "Left";
            this.BeforeDirectionBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.BeforeDirectionBox.FormattingEnabled = true;
            this.BeforeDirectionBox.Items.AddRange(new object[] {
            "Bottom",
            "Left",
            "Right",
            "Top"});
            this.BeforeDirectionBox.Location = new System.Drawing.Point(12, 46);
            this.BeforeDirectionBox.Name = "BeforeDirectionBox";
            this.BeforeDirectionBox.Size = new System.Drawing.Size(100, 21);
            this.BeforeDirectionBox.TabIndex = 19;
            this.BeforeDirectionBox.SelectedIndexChanged += new System.EventHandler(this.BeforeDirectionBox_SelectedIndexChanged);
            // 
            // BothWaysCheckBox
            // 
            this.BothWaysCheckBox.AutoSize = true;
            this.BothWaysCheckBox.Location = new System.Drawing.Point(12, 133);
            this.BothWaysCheckBox.Name = "BothWaysCheckBox";
            this.BothWaysCheckBox.Size = new System.Drawing.Size(114, 17);
            this.BothWaysCheckBox.TabIndex = 17;
            this.BothWaysCheckBox.Text = "Works both ways?";
            this.BothWaysCheckBox.CheckedChanged += new System.EventHandler(this.BothWaysCheckBox_CheckedChanged);
            // 
            // MapBorderComponentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.BothWaysCheckBox);
            this.Controls.Add(this.DirectionGroupBox);
            this.Controls.Add(this.CoordinatesTitle);
            this.Controls.Add(this.MapTitle);
            this.Controls.Add(this.CoordinatesBox);
            this.Controls.Add(this.MapBox);
            this.Controls.Add(this.SelectDestinationButton);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            this.DockText = "Map border";
            this.Name = "MapBorderComponentPanel";
            this.Size = new System.Drawing.Size(276, 254);
            this.DirectionGroupBox.ResumeLayout(false);
            this.DirectionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTitle CoordinatesTitle;
        private DarkUI.Controls.DarkTitle MapTitle;
        private DarkUI.Controls.DarkTextBox CoordinatesBox;
        private DarkUI.Controls.DarkTextBox MapBox;
        private DarkUI.Controls.DarkButton SelectDestinationButton;
        private DarkUI.Controls.DarkGroupBox DirectionGroupBox;
        private DarkUI.Controls.DarkComboBox AfterDirectionBox;
        private DarkUI.Controls.DarkTitle darkTitle2;
        private DarkUI.Controls.DarkTitle darkTitle1;
        private DarkUI.Controls.DarkComboBox BeforeDirectionBox;
        private DarkUI.Controls.DarkCheckBox BothWaysCheckBox;
    }
}
