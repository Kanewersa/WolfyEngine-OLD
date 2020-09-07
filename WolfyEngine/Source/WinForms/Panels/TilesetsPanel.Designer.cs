namespace WolfyEngine.Controls
{
    partial class TilesetsPanel
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
            this.toolStrip = new DarkUI.Controls.DarkToolStrip();
            this.newTilesetButton = new System.Windows.Forms.ToolStripButton();
            this.renameTilesetButton = new System.Windows.Forms.ToolStripButton();
            this.moveUpButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownButton = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.removeButton = new System.Windows.Forms.ToolStripButton();
            this.refreshTreeButton = new System.Windows.Forms.ToolStripButton();
            this.tilesetsTree = new DarkUI.Controls.DarkTreeView();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTilesetButton,
            this.renameTilesetButton,
            this.moveUpButton,
            this.moveDownButton,
            this.copyButton,
            this.removeButton,
            this.refreshTreeButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 332);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(270, 28);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "darkToolStrip1";
            // 
            // newTilesetButton
            // 
            this.newTilesetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newTilesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTilesetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newTilesetButton.Image = global::WolfyEngine.Icons.plus;
            this.newTilesetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newTilesetButton.Name = "newTilesetButton";
            this.newTilesetButton.Size = new System.Drawing.Size(23, 25);
            this.newTilesetButton.Text = "toolStripButton1";
            this.newTilesetButton.ToolTipText = "Create new tileset";
            this.newTilesetButton.Click += new System.EventHandler(this.NewTilesetButton_Click);
            // 
            // renameTilesetButton
            // 
            this.renameTilesetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.renameTilesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameTilesetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.renameTilesetButton.Image = global::WolfyEngine.Icons.edit_2;
            this.renameTilesetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameTilesetButton.Name = "renameTilesetButton";
            this.renameTilesetButton.Size = new System.Drawing.Size(23, 25);
            this.renameTilesetButton.Text = "toolStripButton2";
            this.renameTilesetButton.ToolTipText = "Rename tileset";
            // 
            // moveUpButton
            // 
            this.moveUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.moveUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpButton.Enabled = false;
            this.moveUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.moveUpButton.Image = global::WolfyEngine.Icons.arrow_up;
            this.moveUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(23, 25);
            this.moveUpButton.Text = "toolStripButton3";
            this.moveUpButton.ToolTipText = "Disabled";
            // 
            // moveDownButton
            // 
            this.moveDownButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.moveDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownButton.Enabled = false;
            this.moveDownButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.moveDownButton.Image = global::WolfyEngine.Icons.arrow_down;
            this.moveDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(23, 25);
            this.moveDownButton.Text = "toolStripButton4";
            this.moveDownButton.ToolTipText = "Disabled";
            // 
            // copyButton
            // 
            this.copyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.copyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.copyButton.Image = global::WolfyEngine.Icons.copy;
            this.copyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(23, 25);
            this.copyButton.Text = "toolStripButton5";
            this.copyButton.ToolTipText = "Copy tileset";
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.removeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.removeButton.Image = global::WolfyEngine.Icons.x;
            this.removeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(23, 25);
            this.removeButton.Text = "toolStripButton6";
            this.removeButton.ToolTipText = "Remove tileset";
            // 
            // refreshTreeButton
            // 
            this.refreshTreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.refreshTreeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshTreeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.refreshTreeButton.Image = global::WolfyEngine.Icons.refresh_cw;
            this.refreshTreeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshTreeButton.Name = "refreshTreeButton";
            this.refreshTreeButton.Size = new System.Drawing.Size(23, 25);
            this.refreshTreeButton.Text = "toolStripButton1";
            this.refreshTreeButton.ToolTipText = "Refresh maps";
            this.refreshTreeButton.Click += new System.EventHandler(this.RefreshTreeButton_Click);
            // 
            // tilesetsTree
            // 
            this.tilesetsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilesetsTree.Location = new System.Drawing.Point(0, 25);
            this.tilesetsTree.MaxDragChange = 20;
            this.tilesetsTree.Name = "tilesetsTree";
            this.tilesetsTree.Size = new System.Drawing.Size(270, 307);
            this.tilesetsTree.TabIndex = 3;
            this.tilesetsTree.Text = "darkTreeView1";
            this.tilesetsTree.Click += new System.EventHandler(this.TreeViewClicked);
            // 
            // TilesetsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tilesetsTree);
            this.Controls.Add(this.toolStrip);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Right;
            this.DockText = "Tilesets";
            this.Name = "TilesetsPanel";
            this.Size = new System.Drawing.Size(270, 360);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newTilesetButton;
        private System.Windows.Forms.ToolStripButton renameTilesetButton;
        private System.Windows.Forms.ToolStripButton copyButton;
        private System.Windows.Forms.ToolStripButton removeButton;
        private System.Windows.Forms.ToolStripButton moveUpButton;
        private System.Windows.Forms.ToolStripButton moveDownButton;
        private DarkUI.Controls.DarkTreeView tilesetsTree;
        private System.Windows.Forms.ToolStripButton refreshTreeButton;
    }
}
