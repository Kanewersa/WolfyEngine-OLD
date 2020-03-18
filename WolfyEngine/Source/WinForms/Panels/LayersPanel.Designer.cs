namespace WolfyEngine.Controls
{
    partial class LayersPanel
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
            this.layersTree = new DarkUI.Controls.DarkTreeView();
            this.toolStrip = new DarkUI.Controls.DarkToolStrip();
            this.newLayerButton = new System.Windows.Forms.ToolStripButton();
            this.renameLayerButton = new System.Windows.Forms.ToolStripButton();
            this.moveUpButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownButton = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.removeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // layersTree
            // 
            this.layersTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersTree.Location = new System.Drawing.Point(0, 25);
            this.layersTree.MaxDragChange = 20;
            this.layersTree.Name = "layersTree";
            this.layersTree.Size = new System.Drawing.Size(270, 307);
            this.layersTree.TabIndex = 0;
            this.layersTree.Text = "darkTreeView1";
            this.layersTree.Click += new System.EventHandler(this.LayersTree_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Enabled = false;
            this.toolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLayerButton,
            this.renameLayerButton,
            this.moveUpButton,
            this.moveDownButton,
            this.copyButton,
            this.removeButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 332);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(270, 28);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "darkToolStrip1";
            // 
            // newLayerButton
            // 
            this.newLayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.newLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newLayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.newLayerButton.Image = global::WolfyEngine.Icons.plus;
            this.newLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newLayerButton.Name = "newLayerButton";
            this.newLayerButton.Size = new System.Drawing.Size(23, 25);
            this.newLayerButton.Text = "toolStripButton1";
            this.newLayerButton.ToolTipText = "Create new layer";
            this.newLayerButton.Click += new System.EventHandler(this.NewLayerButton_Click);
            // 
            // renameLayerButton
            // 
            this.renameLayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.renameLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameLayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.renameLayerButton.Image = global::WolfyEngine.Icons.edit_2;
            this.renameLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameLayerButton.Name = "renameLayerButton";
            this.renameLayerButton.Size = new System.Drawing.Size(23, 25);
            this.renameLayerButton.Text = "toolStripButton2";
            this.renameLayerButton.ToolTipText = "Rename layer";
            // 
            // moveUpButton
            // 
            this.moveUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.moveUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.moveUpButton.Image = global::WolfyEngine.Icons.arrow_up;
            this.moveUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(23, 25);
            this.moveUpButton.Text = "toolStripButton3";
            this.moveUpButton.ToolTipText = "Move layer up";
            this.moveUpButton.Click += new System.EventHandler(this.MoveLayerUp);
            // 
            // moveDownButton
            // 
            this.moveDownButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.moveDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.moveDownButton.Image = global::WolfyEngine.Icons.arrow_down;
            this.moveDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(23, 25);
            this.moveDownButton.Text = "toolStripButton4";
            this.moveDownButton.ToolTipText = "Move layer down";
            this.moveDownButton.Click += new System.EventHandler(this.MoveLayerDown);
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
            this.copyButton.ToolTipText = "Copy layer";
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
            this.removeButton.ToolTipText = "Remove layer";
            this.removeButton.Click += new System.EventHandler(this.RemoveSelectedLayer);
            // 
            // LayersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layersTree);
            this.Controls.Add(this.toolStrip);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Right;
            this.DockText = "Layers";
            this.Name = "LayersPanel";
            this.Size = new System.Drawing.Size(270, 360);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkTreeView layersTree;
        private DarkUI.Controls.DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newLayerButton;
        private System.Windows.Forms.ToolStripButton renameLayerButton;
        private System.Windows.Forms.ToolStripButton moveUpButton;
        private System.Windows.Forms.ToolStripButton moveDownButton;
        private System.Windows.Forms.ToolStripButton copyButton;
        private System.Windows.Forms.ToolStripButton removeButton;
    }
}
