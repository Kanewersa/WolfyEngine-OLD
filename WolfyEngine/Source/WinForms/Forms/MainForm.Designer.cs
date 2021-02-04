namespace WolfyEngine.Forms
{
    partial class MainForm
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.assetManagerButton = new DarkUI.Controls.DarkButton();
            this.darkDockPanel = new DarkUI.Docking.DarkDockPanel();
            this.darkMenuStrip = new DarkUI.Controls.DarkMenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new DarkUI.Controls.DarkStatusStrip();
            this.currentProjectLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.springLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.memoryUsageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.OpacityTimer = new System.Windows.Forms.Timer(this.components);
            this.lookupTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // assetManagerButton
            // 
            this.assetManagerButton.Location = new System.Drawing.Point(319, 38);
            this.assetManagerButton.Name = "assetManagerButton";
            this.assetManagerButton.Padding = new System.Windows.Forms.Padding(5);
            this.assetManagerButton.Size = new System.Drawing.Size(98, 23);
            this.assetManagerButton.TabIndex = 12;
            this.assetManagerButton.Text = "Asset Manager";
            this.assetManagerButton.Click += new System.EventHandler(this.AssetManagerButton_Click);
            // 
            // darkDockPanel
            // 
            this.darkDockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkDockPanel.Location = new System.Drawing.Point(0, 32);
            this.darkDockPanel.Name = "darkDockPanel";
            this.darkDockPanel.Size = new System.Drawing.Size(1340, 815);
            this.darkDockPanel.TabIndex = 19;
            // 
            // darkMenuStrip
            // 
            this.darkMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.darkMenuStrip.Location = new System.Drawing.Point(0, 32);
            this.darkMenuStrip.Name = "darkMenuStrip";
            this.darkMenuStrip.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.darkMenuStrip.Size = new System.Drawing.Size(1340, 24);
            this.darkMenuStrip.TabIndex = 21;
            this.darkMenuStrip.Text = "darkMenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectMenuItem,
            this.openProjectMenuItem,
            this.saveProjectMenuItem,
            this.toolStripSeparator1});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectMenuItem
            // 
            this.newProjectMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newProjectMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newProjectMenuItem.Name = "newProjectMenuItem";
            this.newProjectMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newProjectMenuItem.Text = "New project";
            this.newProjectMenuItem.Click += new System.EventHandler(this.NewProjectMenuItem_Click);
            // 
            // openProjectMenuItem
            // 
            this.openProjectMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.openProjectMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.openProjectMenuItem.Name = "openProjectMenuItem";
            this.openProjectMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openProjectMenuItem.Text = "Open project";
            // 
            // saveProjectMenuItem
            // 
            this.saveProjectMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.saveProjectMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveProjectMenuItem.Name = "saveProjectMenuItem";
            this.saveProjectMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveProjectMenuItem.Text = "Save project";
            this.saveProjectMenuItem.Click += new System.EventHandler(this.SaveProjectMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameEditorToolStripMenuItem,
            this.tilesetEditorToolStripMenuItem,
            this.layersToolStripMenuItem,
            this.mapsToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // gameEditorToolStripMenuItem
            // 
            this.gameEditorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.gameEditorToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.gameEditorToolStripMenuItem.Name = "gameEditorToolStripMenuItem";
            this.gameEditorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.gameEditorToolStripMenuItem.Text = "Game Editor";
            this.gameEditorToolStripMenuItem.Click += new System.EventHandler(this.GameEditorToolStripMenuItem_Click);
            // 
            // tilesetEditorToolStripMenuItem
            // 
            this.tilesetEditorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.tilesetEditorToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tilesetEditorToolStripMenuItem.Name = "tilesetEditorToolStripMenuItem";
            this.tilesetEditorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.tilesetEditorToolStripMenuItem.Text = "Tileset Editor";
            this.tilesetEditorToolStripMenuItem.Click += new System.EventHandler(this.TilesetEditorToolStripMenuItem_Click);
            // 
            // layersToolStripMenuItem
            // 
            this.layersToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.layersToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
            this.layersToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.layersToolStripMenuItem.Text = "Layers";
            this.layersToolStripMenuItem.Click += new System.EventHandler(this.LayersToolStripMenuItem_Click);
            // 
            // mapsToolStripMenuItem
            // 
            this.mapsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.mapsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mapsToolStripMenuItem.Name = "mapsToolStripMenuItem";
            this.mapsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.mapsToolStripMenuItem.Text = "Maps";
            this.mapsToolStripMenuItem.Click += new System.EventHandler(this.MapsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripMenuItem,
            this.variablesToolStripMenuItem,
            this.lookupTablesToolStripMenuItem});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.playerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.playerToolStripMenuItem.Text = "Player";
            this.playerToolStripMenuItem.Click += new System.EventHandler(this.PlayerToolStripMenuItem_Click);
            // 
            // variablesToolStripMenuItem
            // 
            this.variablesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.variablesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.variablesToolStripMenuItem.Name = "variablesToolStripMenuItem";
            this.variablesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.variablesToolStripMenuItem.Text = "Variables";
            this.variablesToolStripMenuItem.Click += new System.EventHandler(this.variablesToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.statusStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentProjectLabel,
            this.statusLabel,
            this.springLabel,
            this.memoryUsageLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 847);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.statusStrip.Size = new System.Drawing.Size(1340, 24);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 22;
            this.statusStrip.Text = "darkStatusStrip1";
            // 
            // currentProjectLabel
            // 
            this.currentProjectLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.currentProjectLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.currentProjectLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.currentProjectLabel.Name = "currentProjectLabel";
            this.currentProjectLabel.Size = new System.Drawing.Size(126, 16);
            this.currentProjectLabel.Text = "Current project: None";
            // 
            // statusLabel
            // 
            this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(77, 16);
            this.statusLabel.Text = "Status: Ready";
            // 
            // springLabel
            // 
            this.springLabel.Margin = new System.Windows.Forms.Padding(0);
            this.springLabel.Name = "springLabel";
            this.springLabel.Size = new System.Drawing.Size(1076, 16);
            this.springLabel.Spring = true;
            // 
            // memoryUsageLabel
            // 
            this.memoryUsageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.memoryUsageLabel.Name = "memoryUsageLabel";
            this.memoryUsageLabel.Size = new System.Drawing.Size(58, 16);
            this.memoryUsageLabel.Text = "Memory: ";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(444, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lookupTablesToolStripMenuItem
            // 
            this.lookupTablesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lookupTablesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lookupTablesToolStripMenuItem.Name = "lookupTablesToolStripMenuItem";
            this.lookupTablesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lookupTablesToolStripMenuItem.Text = "Lookup tables";
            this.lookupTablesToolStripMenuItem.Click += new System.EventHandler(this.lookupTablesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 871);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.assetManagerButton);
            this.Controls.Add(this.darkMenuStrip);
            this.Controls.Add(this.darkDockPanel);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.Text = "Wolfy Editor";
            this.Controls.SetChildIndex(this.statusStrip, 0);
            this.Controls.SetChildIndex(this.darkDockPanel, 0);
            this.Controls.SetChildIndex(this.darkMenuStrip, 0);
            this.Controls.SetChildIndex(this.assetManagerButton, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.darkMenuStrip.ResumeLayout(false);
            this.darkMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkButton assetManagerButton;
        private DarkUI.Docking.DarkDockPanel darkDockPanel;
        private DarkUI.Controls.DarkMenuStrip darkMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private DarkUI.Controls.DarkStatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel springLabel;
        private System.Windows.Forms.ToolStripStatusLabel memoryUsageLabel;
        private System.Windows.Forms.ToolStripStatusLabel currentProjectLabel;
        private System.Windows.Forms.ToolStripMenuItem gameEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesetEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.Timer OpacityTimer;
        private System.Windows.Forms.ToolStripMenuItem variablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lookupTablesToolStripMenuItem;
    }
}

