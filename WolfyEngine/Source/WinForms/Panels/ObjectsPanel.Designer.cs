namespace WolfyEngine.Controls
{
    partial class ObjectsPanel
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
            this.NewCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.RenameCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.CopyCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshTreeButton = new System.Windows.Forms.ToolStripButton();
            this.ObjectsListView = new DarkUI.Controls.DarkListView();
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
            this.NewCategoryButton,
            this.RenameCategoryButton,
            this.CopyCategoryButton,
            this.RemoveCategoryButton,
            this.RefreshTreeButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 472);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(215, 28);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "darkToolStrip1";
            // 
            // NewCategoryButton
            // 
            this.NewCategoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.NewCategoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewCategoryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NewCategoryButton.Image = global::WolfyEngine.Icons.plus;
            this.NewCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewCategoryButton.Name = "NewCategoryButton";
            this.NewCategoryButton.Size = new System.Drawing.Size(23, 25);
            this.NewCategoryButton.Text = "toolStripButton1";
            this.NewCategoryButton.ToolTipText = "Create new tileset";
            // 
            // RenameCategoryButton
            // 
            this.RenameCategoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RenameCategoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RenameCategoryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RenameCategoryButton.Image = global::WolfyEngine.Icons.edit_2;
            this.RenameCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RenameCategoryButton.Name = "RenameCategoryButton";
            this.RenameCategoryButton.Size = new System.Drawing.Size(23, 25);
            this.RenameCategoryButton.Text = "toolStripButton2";
            this.RenameCategoryButton.ToolTipText = "Rename tileset";
            // 
            // CopyCategoryButton
            // 
            this.CopyCategoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.CopyCategoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyCategoryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.CopyCategoryButton.Image = global::WolfyEngine.Icons.copy;
            this.CopyCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyCategoryButton.Name = "CopyCategoryButton";
            this.CopyCategoryButton.Size = new System.Drawing.Size(23, 25);
            this.CopyCategoryButton.Text = "toolStripButton5";
            this.CopyCategoryButton.ToolTipText = "Copy tileset";
            // 
            // RemoveCategoryButton
            // 
            this.RemoveCategoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RemoveCategoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveCategoryButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RemoveCategoryButton.Image = global::WolfyEngine.Icons.x;
            this.RemoveCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveCategoryButton.Name = "RemoveCategoryButton";
            this.RemoveCategoryButton.Size = new System.Drawing.Size(23, 25);
            this.RemoveCategoryButton.Text = "toolStripButton6";
            this.RemoveCategoryButton.ToolTipText = "Remove tileset";
            // 
            // RefreshTreeButton
            // 
            this.RefreshTreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RefreshTreeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshTreeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RefreshTreeButton.Image = global::WolfyEngine.Icons.refresh_cw;
            this.RefreshTreeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshTreeButton.Name = "RefreshTreeButton";
            this.RefreshTreeButton.Size = new System.Drawing.Size(23, 25);
            this.RefreshTreeButton.Text = "toolStripButton1";
            this.RefreshTreeButton.ToolTipText = "Refresh maps";
            // 
            // ObjectsListView
            // 
            this.ObjectsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectsListView.Location = new System.Drawing.Point(0, 25);
            this.ObjectsListView.Name = "ObjectsListView";
            this.ObjectsListView.Size = new System.Drawing.Size(215, 447);
            this.ObjectsListView.TabIndex = 6;
            this.ObjectsListView.Text = "darkListView1";
            // 
            // ObjectsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ObjectsListView);
            this.Controls.Add(this.toolStrip);
            this.DockText = "Categories & Objects";
            this.Name = "ObjectsPanel";
            this.Size = new System.Drawing.Size(215, 500);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton NewCategoryButton;
        private System.Windows.Forms.ToolStripButton RenameCategoryButton;
        private System.Windows.Forms.ToolStripButton CopyCategoryButton;
        private System.Windows.Forms.ToolStripButton RemoveCategoryButton;
        private System.Windows.Forms.ToolStripButton RefreshTreeButton;
        private DarkUI.Controls.DarkListView ObjectsListView;
    }
}
