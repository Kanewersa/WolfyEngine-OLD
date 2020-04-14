namespace WolfyEngine.Forms
{
    partial class ObjectsManagerForm
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
            this.darkDockPanel = new DarkUI.Docking.DarkDockPanel();
            this.SuspendLayout();
            // 
            // darkDockPanel
            // 
            this.darkDockPanel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (60)))),
                ((int) (((byte) (63)))), ((int) (((byte) (65)))));
            this.darkDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkDockPanel.Location = new System.Drawing.Point(0, 0);
            this.darkDockPanel.Name = "darkDockPanel";
            this.darkDockPanel.Size = new System.Drawing.Size(1051, 668);
            this.darkDockPanel.TabIndex = 2;
            // 
            // ObjectsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 668);
            this.Controls.Add(this.darkDockPanel);
            this.Name = "ObjectsManagerForm";
            this.Text = "Objects Manager";
            this.ResumeLayout(false);
        }

        #endregion

        private DarkUI.Docking.DarkDockPanel darkDockPanel;
    }
}