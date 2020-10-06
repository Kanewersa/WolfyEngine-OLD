namespace WolfyEngine.Forms
{
    partial class WolfyVariableDocument
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VariableSectionPanel = new DarkUI.Controls.DarkSectionPanel();
            this.SuspendLayout();
            // 
            // VariableSectionPanel
            // 
            this.VariableSectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableSectionPanel.Location = new System.Drawing.Point(0, 59);
            this.VariableSectionPanel.Name = "VariableSectionPanel";
            this.VariableSectionPanel.SectionHeader = "Variable setup";
            this.VariableSectionPanel.Size = new System.Drawing.Size(352, 359);
            this.VariableSectionPanel.TabIndex = 2;
            // 
            // WolfyVariableDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VariableSectionPanel);
            this.Name = "WolfyVariableDocument";
            this.Size = new System.Drawing.Size(352, 418);
            this.Controls.SetChildIndex(this.VariableSectionPanel, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkSectionPanel VariableSectionPanel;
    }
}
