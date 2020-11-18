namespace WolfyEngine.Controls
{
    partial class MapsPanel
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
            this.ToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.newMapButton = new System.Windows.Forms.ToolStripButton();
            this.renameMapButton = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveMapButton = new System.Windows.Forms.ToolStripButton();
            this.refreshTreeButton = new System.Windows.Forms.ToolStripButton();
            this.mapsTree = new DarkUI.Controls.DarkTreeView();
            this.MapContextMenu = new DarkUI.Controls.DarkContextMenu();
            this.EditMapContextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMapContextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip.SuspendLayout();
            this.MapContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip.Enabled = false;
            this.ToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapButton,
            this.renameMapButton,
            this.copyButton,
            this.RemoveMapButton,
            this.refreshTreeButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 428);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.ToolStrip.Size = new System.Drawing.Size(261, 28);
            this.ToolStrip.TabIndex = 2;
            this.ToolStrip.Text = "darkToolStrip1";
            // 
            // newMapButton
            // 
            this.newMapButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newMapButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newMapButton.Image = global::WolfyEngine.Icons.plus;
            this.newMapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newMapButton.Name = "newMapButton";
            this.newMapButton.Size = new System.Drawing.Size(23, 25);
            this.newMapButton.Text = "toolStripButton1";
            this.newMapButton.ToolTipText = "Create new map";
            this.newMapButton.Click += new System.EventHandler(this.NewMapButton_Click);
            // 
            // renameMapButton
            // 
            this.renameMapButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.renameMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameMapButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.renameMapButton.Image = global::WolfyEngine.Icons.edit_2;
            this.renameMapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameMapButton.Name = "renameMapButton";
            this.renameMapButton.Size = new System.Drawing.Size(23, 25);
            this.renameMapButton.Text = "toolStripButton2";
            this.renameMapButton.ToolTipText = "Rename map";
            this.renameMapButton.Click += new System.EventHandler(this.EditMap);
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
            this.copyButton.ToolTipText = "Copy map";
            // 
            // RemoveMapButton
            // 
            this.RemoveMapButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RemoveMapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveMapButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RemoveMapButton.Image = global::WolfyEngine.Icons.x;
            this.RemoveMapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveMapButton.Name = "RemoveMapButton";
            this.RemoveMapButton.Size = new System.Drawing.Size(23, 25);
            this.RemoveMapButton.Text = "toolStripButton6";
            this.RemoveMapButton.ToolTipText = "Remove map";
            this.RemoveMapButton.Click += new System.EventHandler(this.RemoveMap);
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
            // mapsTree
            // 
            this.mapsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapsTree.Location = new System.Drawing.Point(0, 25);
            this.mapsTree.MaxDragChange = 20;
            this.mapsTree.Name = "mapsTree";
            this.mapsTree.Size = new System.Drawing.Size(261, 403);
            this.mapsTree.TabIndex = 3;
            this.mapsTree.Text = "darkTreeView1";
            this.mapsTree.Click += new System.EventHandler(this.TreeViewClicked);
            this.mapsTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TreeViewMouseClicked);
            // 
            // MapContextMenu
            // 
            this.MapContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.MapContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MapContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditMapContextButton,
            this.DeleteMapContextButton});
            this.MapContextMenu.Name = "MapContextMenu";
            this.MapContextMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // EditMapContextButton
            // 
            this.EditMapContextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.EditMapContextButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.EditMapContextButton.Image = global::WolfyEngine.Icons.edit_3;
            this.EditMapContextButton.Name = "EditMapContextButton";
            this.EditMapContextButton.Size = new System.Drawing.Size(107, 22);
            this.EditMapContextButton.Text = "Edit";
            this.EditMapContextButton.Click += new System.EventHandler(this.EditMap);
            // 
            // DeleteMapContextButton
            // 
            this.DeleteMapContextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DeleteMapContextButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DeleteMapContextButton.Image = global::WolfyEngine.Icons.trash_2;
            this.DeleteMapContextButton.Name = "DeleteMapContextButton";
            this.DeleteMapContextButton.Size = new System.Drawing.Size(107, 22);
            this.DeleteMapContextButton.Text = "Delete";
            this.DeleteMapContextButton.Click += new System.EventHandler(this.RemoveMap);
            // 
            // MapsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapsTree);
            this.Controls.Add(this.ToolStrip);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Left;
            this.DockText = "Maps";
            this.Name = "MapsPanel";
            this.Size = new System.Drawing.Size(261, 456);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.MapContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton newMapButton;
        private System.Windows.Forms.ToolStripButton renameMapButton;
        private System.Windows.Forms.ToolStripButton copyButton;
        private System.Windows.Forms.ToolStripButton RemoveMapButton;
        private DarkUI.Controls.DarkTreeView mapsTree;
        private System.Windows.Forms.ToolStripButton refreshTreeButton;
        private DarkUI.Controls.DarkContextMenu MapContextMenu;
        private System.Windows.Forms.ToolStripMenuItem EditMapContextButton;
        private System.Windows.Forms.ToolStripMenuItem DeleteMapContextButton;
    }
}
