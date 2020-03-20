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
            this.darkToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.PencilButton = new System.Windows.Forms.ToolStripButton();
            this.FillButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCoordinatesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gameControl = new WolfyEngine.Controls.GameControl();
            this.EntityContextMenu = new WolfyEngine.Controls.EntityContextMenu();
            this.newEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setStartingPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrollablePanel.SuspendLayout();
            this.darkToolStrip.SuspendLayout();
            this.EntityContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrollablePanel
            // 
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.Controls.Add(this.darkToolStrip);
            this.scrollablePanel.Controls.Add(this.gameControl);
            this.scrollablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollablePanel.Location = new System.Drawing.Point(0, 0);
            this.scrollablePanel.Name = "scrollablePanel";
            this.scrollablePanel.Size = new System.Drawing.Size(469, 534);
            this.scrollablePanel.TabIndex = 1;
            // 
            // darkToolStrip
            // 
            this.darkToolStrip.AutoSize = false;
            this.darkToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PencilButton,
            this.FillButton,
            this.toolStripSeparator,
            this.toolStripCoordinatesLabel});
            this.darkToolStrip.Location = new System.Drawing.Point(0, 0);
            this.darkToolStrip.Name = "darkToolStrip";
            this.darkToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.darkToolStrip.Size = new System.Drawing.Size(469, 28);
            this.darkToolStrip.TabIndex = 2;
            this.darkToolStrip.Text = "darkToolStrip1";
            // 
            // PencilButton
            // 
            this.PencilButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.PencilButton.Checked = true;
            this.PencilButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PencilButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.PencilButton.Image = global::WolfyEngine.Icons.edit_3;
            this.PencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PencilButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.PencilButton.Name = "PencilButton";
            this.PencilButton.Size = new System.Drawing.Size(59, 25);
            this.PencilButton.Text = "Pencil";
            this.PencilButton.ToolTipText = "Pencil tool";
            this.PencilButton.Click += new System.EventHandler(this.PencilButton_Click);
            // 
            // FillButton
            // 
            this.FillButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.FillButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.FillButton.Image = global::WolfyEngine.Icons.filter;
            this.FillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FillButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.FillButton.Name = "FillButton";
            this.FillButton.Size = new System.Drawing.Size(42, 25);
            this.FillButton.Text = "Fill";
            this.FillButton.ToolTipText = "Fill tool";
            this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripCoordinatesLabel
            // 
            this.toolStripCoordinatesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripCoordinatesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripCoordinatesLabel.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripCoordinatesLabel.Name = "toolStripCoordinatesLabel";
            this.toolStripCoordinatesLabel.Size = new System.Drawing.Size(74, 28);
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
            this.gameControl.Tool = WolfyEngine.Controls.GameControl.Tools.Pencil;
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
            this.EntityContextMenu.Size = new System.Drawing.Size(165, 77);
            // 
            // newEntityToolStripMenuItem
            // 
            this.newEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newEntityToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newEntityToolStripMenuItem.Name = "newEntityToolStripMenuItem";
            this.newEntityToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.newEntityToolStripMenuItem.Text = "New entity";
            this.newEntityToolStripMenuItem.Click += new System.EventHandler(this.newEntityToolStripMenuItem_Click);
            // 
            // removeEntityToolStripMenuItem
            // 
            this.removeEntityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.removeEntityToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.removeEntityToolStripMenuItem.Name = "removeEntityToolStripMenuItem";
            this.removeEntityToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeEntityToolStripMenuItem.Text = "Remove entity";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // setStartingPointToolStripMenuItem
            // 
            this.setStartingPointToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.setStartingPointToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.setStartingPointToolStripMenuItem.Name = "setStartingPointToolStripMenuItem";
            this.setStartingPointToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setStartingPointToolStripMenuItem.Text = "Set starting point";
            this.setStartingPointToolStripMenuItem.Click += new System.EventHandler(this.setStartingPointToolStripMenuItem_Click);
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
            this.darkToolStrip.ResumeLayout(false);
            this.darkToolStrip.PerformLayout();
            this.EntityContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GameControl gameControl;
        private ScrollablePanel scrollablePanel;
        private EntityContextMenu EntityContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setStartingPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeEntityToolStripMenuItem;
        private DarkUI.Controls.DarkToolStrip darkToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCoordinatesLabel;
        private System.Windows.Forms.ToolStripButton PencilButton;
        private System.Windows.Forms.ToolStripButton FillButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    }
}
