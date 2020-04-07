namespace WolfyEngine.Forms
{
    partial class EntityEditForm
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
            this.CancelButton = new DarkUI.Controls.DarkButton();
            this.SaveButton = new DarkUI.Controls.DarkButton();
            this.GraphicsSectionPanel = new DarkUI.Controls.DarkSectionPanel();
            this.GraphicsBox = new System.Windows.Forms.PictureBox();
            this.ComponentsDockPanel = new DarkUI.Docking.DarkDockPanel();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NameTitle = new DarkUI.Controls.DarkTitle();
            this.darkTextBox1 = new DarkUI.Controls.DarkTextBox();
            this.panel2.SuspendLayout();
            this.GraphicsSectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsBox)).BeginInit();
            this.darkSectionPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CancelButton);
            this.panel2.Controls.Add(this.SaveButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 626);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 35);
            this.panel2.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(609, 5);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.CancelButton.Size = new System.Drawing.Size(75, 25);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(524, 5);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(5);
            this.SaveButton.Size = new System.Drawing.Size(75, 25);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            // 
            // GraphicsSectionPanel
            // 
            this.GraphicsSectionPanel.Controls.Add(this.GraphicsBox);
            this.GraphicsSectionPanel.Location = new System.Drawing.Point(12, 12);
            this.GraphicsSectionPanel.Name = "GraphicsSectionPanel";
            this.GraphicsSectionPanel.SectionHeader = "Graphics";
            this.GraphicsSectionPanel.Size = new System.Drawing.Size(224, 315);
            this.GraphicsSectionPanel.TabIndex = 4;
            // 
            // GraphicsBox
            // 
            this.GraphicsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphicsBox.Location = new System.Drawing.Point(1, 25);
            this.GraphicsBox.Name = "GraphicsBox";
            this.GraphicsBox.Size = new System.Drawing.Size(222, 289);
            this.GraphicsBox.TabIndex = 0;
            this.GraphicsBox.TabStop = false;
            // 
            // ComponentsDockPanel
            // 
            this.ComponentsDockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ComponentsDockPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ComponentsDockPanel.Location = new System.Drawing.Point(0, 333);
            this.ComponentsDockPanel.Name = "ComponentsDockPanel";
            this.ComponentsDockPanel.Size = new System.Drawing.Size(698, 293);
            this.ComponentsDockPanel.TabIndex = 5;
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Controls.Add(this.tableLayoutPanel1);
            this.darkSectionPanel1.Location = new System.Drawing.Point(242, 12);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Common settings";
            this.darkSectionPanel1.Size = new System.Drawing.Size(442, 315);
            this.darkSectionPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.NameTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.darkTextBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 289);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // NameTitle
            // 
            this.NameTitle.AutoSize = true;
            this.NameTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameTitle.Location = new System.Drawing.Point(10, 10);
            this.NameTitle.Margin = new System.Windows.Forms.Padding(10, 10, 10, 2);
            this.NameTitle.Name = "NameTitle";
            this.NameTitle.Size = new System.Drawing.Size(420, 13);
            this.NameTitle.TabIndex = 0;
            this.NameTitle.Text = "Entity name";
            // 
            // darkTextBox1
            // 
            this.darkTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox1.Location = new System.Drawing.Point(4, 27);
            this.darkTextBox1.Margin = new System.Windows.Forms.Padding(4, 2, 7, 6);
            this.darkTextBox1.Name = "darkTextBox1";
            this.darkTextBox1.Size = new System.Drawing.Size(429, 20);
            this.darkTextBox1.TabIndex = 1;
            // 
            // EntityEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 661);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.ComponentsDockPanel);
            this.Controls.Add(this.GraphicsSectionPanel);
            this.Controls.Add(this.panel2);
            this.Name = "EntityEditForm";
            this.Text = "Edit Entity: ID";
            this.panel2.ResumeLayout(false);
            this.GraphicsSectionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsBox)).EndInit();
            this.darkSectionPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private DarkUI.Controls.DarkButton CancelButton;
        private DarkUI.Controls.DarkButton SaveButton;
        private DarkUI.Controls.DarkSectionPanel GraphicsSectionPanel;
        private System.Windows.Forms.PictureBox GraphicsBox;
        private DarkUI.Docking.DarkDockPanel ComponentsDockPanel;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DarkUI.Controls.DarkTitle NameTitle;
        private DarkUI.Controls.DarkTextBox darkTextBox1;
    }
}