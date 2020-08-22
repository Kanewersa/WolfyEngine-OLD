namespace WolfyEngine.Forms
{
    partial class TeleportActionForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.CoordinatesTitle = new DarkUI.Controls.DarkTitle();
            this.MapTitle = new DarkUI.Controls.DarkTitle();
            this.CoordinatesBox = new DarkUI.Controls.DarkTextBox();
            this.MapBox = new DarkUI.Controls.DarkTextBox();
            this.SelectDestinationButton = new DarkUI.Controls.DarkButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.DirectionTitle = new DarkUI.Controls.DarkTitle();
            this.DirectionBox = new DarkUI.Controls.DarkComboBox();
            this.MapBorderBox = new DarkUI.Controls.DarkCheckBox();
            this.TeleportPlayerButton = new DarkUI.Controls.DarkRadioButton();
            this.ThisEntityButton = new DarkUI.Controls.DarkRadioButton();
            this.TeleportTargetLabel = new DarkUI.Controls.DarkTitle();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CoordinatesTitle);
            this.panel2.Controls.Add(this.MapTitle);
            this.panel2.Controls.Add(this.CoordinatesBox);
            this.panel2.Controls.Add(this.MapBox);
            this.panel2.Controls.Add(this.SelectDestinationButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 147);
            this.panel2.TabIndex = 7;
            // 
            // CoordinatesTitle
            // 
            this.CoordinatesTitle.AutoSize = true;
            this.CoordinatesTitle.Location = new System.Drawing.Point(113, 13);
            this.CoordinatesTitle.Name = "CoordinatesTitle";
            this.CoordinatesTitle.Size = new System.Drawing.Size(66, 13);
            this.CoordinatesTitle.TabIndex = 7;
            this.CoordinatesTitle.Text = "Coordinates:";
            // 
            // MapTitle
            // 
            this.MapTitle.AutoSize = true;
            this.MapTitle.Location = new System.Drawing.Point(7, 13);
            this.MapTitle.Name = "MapTitle";
            this.MapTitle.Size = new System.Drawing.Size(31, 13);
            this.MapTitle.TabIndex = 6;
            this.MapTitle.Text = "Map:";
            // 
            // CoordinatesBox
            // 
            this.CoordinatesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.CoordinatesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CoordinatesBox.Enabled = false;
            this.CoordinatesBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CoordinatesBox.Location = new System.Drawing.Point(116, 29);
            this.CoordinatesBox.Name = "CoordinatesBox";
            this.CoordinatesBox.Size = new System.Drawing.Size(93, 20);
            this.CoordinatesBox.TabIndex = 2;
            this.CoordinatesBox.Text = "Not selected";
            // 
            // MapBox
            // 
            this.MapBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.MapBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapBox.Enabled = false;
            this.MapBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MapBox.Location = new System.Drawing.Point(10, 29);
            this.MapBox.Name = "MapBox";
            this.MapBox.Size = new System.Drawing.Size(93, 20);
            this.MapBox.TabIndex = 1;
            this.MapBox.Text = "Not Selected";
            // 
            // SelectDestinationButton
            // 
            this.SelectDestinationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SelectDestinationButton.Location = new System.Drawing.Point(53, 54);
            this.SelectDestinationButton.Name = "SelectDestinationButton";
            this.SelectDestinationButton.Padding = new System.Windows.Forms.Padding(5);
            this.SelectDestinationButton.Size = new System.Drawing.Size(112, 29);
            this.SelectDestinationButton.TabIndex = 0;
            this.SelectDestinationButton.Text = "Select destination";
            this.SelectDestinationButton.Click += new System.EventHandler(this.SelectDestinationButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TeleportTargetLabel);
            this.panel1.Controls.Add(this.TeleportPlayerButton);
            this.panel1.Controls.Add(this.ThisEntityButton);
            this.panel1.Controls.Add(this.darkSeparator1);
            this.panel1.Controls.Add(this.DirectionTitle);
            this.panel1.Controls.Add(this.DirectionBox);
            this.panel1.Controls.Add(this.MapBorderBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 102);
            this.panel1.TabIndex = 6;
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 0);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(224, 2);
            this.darkSeparator1.TabIndex = 6;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // DirectionTitle
            // 
            this.DirectionTitle.AutoSize = true;
            this.DirectionTitle.Location = new System.Drawing.Point(113, 4);
            this.DirectionTitle.Name = "DirectionTitle";
            this.DirectionTitle.Size = new System.Drawing.Size(52, 13);
            this.DirectionTitle.TabIndex = 5;
            this.DirectionTitle.Text = "Direction:";
            // 
            // DirectionBox
            // 
            this.DirectionBox.DisplayMember = "Left";
            this.DirectionBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DirectionBox.Enabled = false;
            this.DirectionBox.FormattingEnabled = true;
            this.DirectionBox.Items.AddRange(new object[] {
            "Bottom",
            "Left",
            "Right",
            "Top"});
            this.DirectionBox.Location = new System.Drawing.Point(112, 22);
            this.DirectionBox.Name = "DirectionBox";
            this.DirectionBox.Size = new System.Drawing.Size(100, 21);
            this.DirectionBox.TabIndex = 4;
            // 
            // MapBorderBox
            // 
            this.MapBorderBox.AutoSize = true;
            this.MapBorderBox.Location = new System.Drawing.Point(10, 23);
            this.MapBorderBox.Name = "MapBorderBox";
            this.MapBorderBox.Size = new System.Drawing.Size(80, 17);
            this.MapBorderBox.TabIndex = 3;
            this.MapBorderBox.Text = "Map border";
            this.MapBorderBox.CheckedChanged += new System.EventHandler(this.MapBorderBox_CheckedChanged);
            // 
            // TeleportPlayerButton
            // 
            this.TeleportPlayerButton.AutoSize = true;
            this.TeleportPlayerButton.Location = new System.Drawing.Point(115, 71);
            this.TeleportPlayerButton.Name = "TeleportPlayerButton";
            this.TeleportPlayerButton.Size = new System.Drawing.Size(54, 17);
            this.TeleportPlayerButton.TabIndex = 8;
            this.TeleportPlayerButton.Text = "Player";
            // 
            // ThisEntityButton
            // 
            this.ThisEntityButton.AutoSize = true;
            this.ThisEntityButton.Checked = true;
            this.ThisEntityButton.Location = new System.Drawing.Point(16, 71);
            this.ThisEntityButton.Name = "ThisEntityButton";
            this.ThisEntityButton.Size = new System.Drawing.Size(73, 17);
            this.ThisEntityButton.TabIndex = 7;
            this.ThisEntityButton.TabStop = true;
            this.ThisEntityButton.Text = "This entity";
            // 
            // TeleportTargetLabel
            // 
            this.TeleportTargetLabel.AutoSize = true;
            this.TeleportTargetLabel.Location = new System.Drawing.Point(12, 52);
            this.TeleportTargetLabel.Name = "TeleportTargetLabel";
            this.TeleportTargetLabel.Size = new System.Drawing.Size(86, 13);
            this.TeleportTargetLabel.TabIndex = 9;
            this.TeleportTargetLabel.Text = "Entity to teleport:";
            // 
            // TeleportActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 279);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TeleportActionForm";
            this.Text = "Teleport Entity";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DarkUI.Controls.DarkTitle CoordinatesTitle;
        private DarkUI.Controls.DarkTitle MapTitle;
        private DarkUI.Controls.DarkTextBox CoordinatesBox;
        private DarkUI.Controls.DarkTextBox MapBox;
        private DarkUI.Controls.DarkButton SelectDestinationButton;
        private System.Windows.Forms.Panel panel1;
        private DarkUI.Controls.DarkTitle DirectionTitle;
        private DarkUI.Controls.DarkComboBox DirectionBox;
        private DarkUI.Controls.DarkCheckBox MapBorderBox;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkTitle TeleportTargetLabel;
        private DarkUI.Controls.DarkRadioButton TeleportPlayerButton;
        private DarkUI.Controls.DarkRadioButton ThisEntityButton;
    }
}