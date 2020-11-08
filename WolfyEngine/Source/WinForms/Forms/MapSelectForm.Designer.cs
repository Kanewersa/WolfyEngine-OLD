namespace WolfyEngine.Forms
{
    partial class MapSelectForm
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
            this.DarkDockPanel = new DarkUI.Docking.DarkDockPanel();
            this.SelectButton = new DarkUI.Controls.DarkButton();
            this.CancelButton = new DarkUI.Controls.DarkButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DarkDockPanel
            // 
            this.DarkDockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DarkDockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DarkDockPanel.Location = new System.Drawing.Point(0, 35);
            this.DarkDockPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DarkDockPanel.Name = "DarkDockPanel";
            this.DarkDockPanel.Size = new System.Drawing.Size(674, 438);
            this.DarkDockPanel.TabIndex = 1;
            // 
            // SelectButton
            // 
            this.SelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectButton.Location = new System.Drawing.Point(6, 3);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Padding = new System.Windows.Forms.Padding(5);
            this.SelectButton.Size = new System.Drawing.Size(76, 38);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "Select Tile";
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(6, 47);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.CancelButton.Size = new System.Drawing.Size(76, 38);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SelectButton);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(674, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 441);
            this.panel1.TabIndex = 4;
            // 
            // MapSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 473);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DarkDockPanel);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MapSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MapSelectForm";
            this.Controls.SetChildIndex(this.DarkDockPanel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Docking.DarkDockPanel DarkDockPanel;
        private DarkUI.Controls.DarkButton SelectButton;
        private DarkUI.Controls.DarkButton CancelButton;
        private System.Windows.Forms.Panel panel1;
    }
}