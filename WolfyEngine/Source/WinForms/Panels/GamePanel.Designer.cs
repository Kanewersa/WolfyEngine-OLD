namespace WolfyEngine.Controls
{
    partial class GamePanel
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
            this.scrollablePanel = new WolfyEngine.Controls.ScrollablePanel();
            this.darkStatusStrip = new DarkUI.Controls.DarkStatusStrip();
            this.toolStripCoordinatesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gameControl = new WolfyEngine.Controls.GameControl();
            this.EntityContextMenu = new DarkUI.Controls.DarkContextMenu();
            this.newEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setStartingPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrollablePanel.SuspendLayout();
            this.darkStatusStrip.SuspendLayout();
            this.EntityContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrollablePanel
            // 
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.Controls.Add(this.darkStatusStrip);
            this.scrollablePanel.Controls.Add(this.gameControl);
            this.scrollablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollablePanel.Location = new System.Drawing.Point(0, 0);
            this.scrollablePanel.Name = "scrollablePanel";
            this.scrollablePanel.Size = new System.Drawing.Size(469, 534);
            this.scrollablePanel.TabIndex = 1;
            // 
            // darkStatusStrip
            // 
            this.darkStatusStrip.AutoSize = false;
            this.darkStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkStatusStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkStatusStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCoordinatesLabel});
            this.darkStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.darkStatusStrip.Name = "darkStatusStrip";
            this.darkStatusStrip.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.darkStatusStrip.Size = new System.Drawing.Size(469, 24);
            this.darkStatusStrip.SizingGrip = false;
            this.darkStatusStrip.TabIndex = 1;
            this.darkStatusStrip.Text = "darkStatusStrip1";
            // 
            // toolStripCoordinatesLabel
            // 
            this.toolStripCoordinatesLabel.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripCoordinatesLabel.Name = "toolStripCoordinatesLabel";
            this.toolStripCoordinatesLabel.Size = new System.Drawing.Size(74, 16);
            this.toolStripCoordinatesLabel.Text = "Coordinates:";
            // 
            // gameControl
            // 
            this.gameControl.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
            this.gameControl.Location = new System.Drawing.Point(0, 24);
            this.gameControl.Margin = new System.Windows.Forms.Padding(0);
            this.gameControl.Name = "gameControl";
            this.gameControl.Paused = false;
            this.gameControl.Size = new System.Drawing.Size(195, 258);
            this.gameControl.TabIndex = 0;
            this.gameControl.Text = "Game control";
            // 
            // EntityContextMenu
            // 
            this.EntityContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.EntityContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.EntityContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEntityToolStripMenuItem,
            this.removeEntityToolStripMenuItem,
            this.toolStripSeparator1,
            this.setStartingPointToolStripMenuItem});
            this.EntityContextMenu.Name = "EntityContextMenu";
            this.EntityContextMenu.Size = new System.Drawing.Size(181, 99);
            // 
            // newEntityToolStripMenuItem
            // 
            this.newEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newEntityToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newEntityToolStripMenuItem.Name = "newEntityToolStripMenuItem";
            this.newEntityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newEntityToolStripMenuItem.Text = "New entity";
            this.newEntityToolStripMenuItem.Click += new System.EventHandler(this.newEntityToolStripMenuItem_Click);
            // 
            // removeEntityToolStripMenuItem
            // 
            this.removeEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.removeEntityToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.removeEntityToolStripMenuItem.Name = "removeEntityToolStripMenuItem";
            this.removeEntityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeEntityToolStripMenuItem.Text = "Remove entity";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // setStartingPointToolStripMenuItem
            // 
            this.setStartingPointToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.setStartingPointToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.setStartingPointToolStripMenuItem.Name = "setStartingPointToolStripMenuItem";
            this.setStartingPointToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setStartingPointToolStripMenuItem.Text = "Set starting point";
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollablePanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DockText = "Game Editor";
            this.Name = "GamePanel";
            this.Size = new System.Drawing.Size(469, 534);
            this.scrollablePanel.ResumeLayout(false);
            this.darkStatusStrip.ResumeLayout(false);
            this.darkStatusStrip.PerformLayout();
            this.EntityContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GameControl gameControl;
        private ScrollablePanel scrollablePanel;
        private DarkUI.Controls.DarkStatusStrip darkStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCoordinatesLabel;
        private DarkUI.Controls.DarkContextMenu EntityContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setStartingPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeEntityToolStripMenuItem;
    }
}
