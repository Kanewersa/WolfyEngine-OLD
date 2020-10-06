namespace WolfyEngine.Forms
{
    partial class WolfyBoolDocument
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
            this.OnChangeBox = new DarkUI.Controls.DarkGroupBox();
            this.ActionsListView = new DarkUI.Controls.DarkListView();
            this.ValueGroupBox = new DarkUI.Controls.DarkGroupBox();
            this.TrueValueButton = new DarkUI.Controls.DarkRadioButton();
            this.FalseValueButton = new DarkUI.Controls.DarkRadioButton();
            this.VariableSectionPanel.SuspendLayout();
            this.OnChangeBox.SuspendLayout();
            this.ValueGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // VariableSectionPanel
            // 
            this.VariableSectionPanel.Controls.Add(this.OnChangeBox);
            this.VariableSectionPanel.Controls.Add(this.ValueGroupBox);
            this.VariableSectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableSectionPanel.Location = new System.Drawing.Point(0, 59);
            this.VariableSectionPanel.Name = "VariableSectionPanel";
            this.VariableSectionPanel.SectionHeader = "Variable setup";
            this.VariableSectionPanel.Size = new System.Drawing.Size(452, 296);
            this.VariableSectionPanel.TabIndex = 1;
            // 
            // OnChangeBox
            // 
            this.OnChangeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OnChangeBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.OnChangeBox.Controls.Add(this.ActionsListView);
            this.OnChangeBox.Location = new System.Drawing.Point(236, 35);
            this.OnChangeBox.Name = "OnChangeBox";
            this.OnChangeBox.Size = new System.Drawing.Size(200, 251);
            this.OnChangeBox.TabIndex = 3;
            this.OnChangeBox.TabStop = false;
            this.OnChangeBox.Text = "On value change";
            // 
            // ActionsListView
            // 
            this.ActionsListView.Location = new System.Drawing.Point(6, 19);
            this.ActionsListView.Name = "ActionsListView";
            this.ActionsListView.Size = new System.Drawing.Size(188, 226);
            this.ActionsListView.TabIndex = 0;
            this.ActionsListView.Text = "Actions";
            // 
            // ValueGroupBox
            // 
            this.ValueGroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ValueGroupBox.Controls.Add(this.TrueValueButton);
            this.ValueGroupBox.Controls.Add(this.FalseValueButton);
            this.ValueGroupBox.Location = new System.Drawing.Point(14, 40);
            this.ValueGroupBox.Name = "ValueGroupBox";
            this.ValueGroupBox.Size = new System.Drawing.Size(62, 71);
            this.ValueGroupBox.TabIndex = 2;
            this.ValueGroupBox.TabStop = false;
            this.ValueGroupBox.Text = "Value";
            // 
            // TrueValueButton
            // 
            this.TrueValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrueValueButton.AutoSize = true;
            this.TrueValueButton.Location = new System.Drawing.Point(6, 19);
            this.TrueValueButton.Name = "TrueValueButton";
            this.TrueValueButton.Size = new System.Drawing.Size(47, 17);
            this.TrueValueButton.TabIndex = 0;
            this.TrueValueButton.Text = "True";
            this.TrueValueButton.CheckedChanged += new System.EventHandler(this.TrueValueButton_CheckedChanged);
            // 
            // FalseValueButton
            // 
            this.FalseValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FalseValueButton.AutoSize = true;
            this.FalseValueButton.Checked = true;
            this.FalseValueButton.Location = new System.Drawing.Point(6, 44);
            this.FalseValueButton.Name = "FalseValueButton";
            this.FalseValueButton.Size = new System.Drawing.Size(50, 17);
            this.FalseValueButton.TabIndex = 1;
            this.FalseValueButton.TabStop = true;
            this.FalseValueButton.Text = "False";
            // 
            // WolfyBoolDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VariableSectionPanel);
            this.Name = "WolfyBoolDocument";
            this.Controls.SetChildIndex(this.VariableSectionPanel, 0);
            this.VariableSectionPanel.ResumeLayout(false);
            this.OnChangeBox.ResumeLayout(false);
            this.ValueGroupBox.ResumeLayout(false);
            this.ValueGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkSectionPanel VariableSectionPanel;
        private DarkUI.Controls.DarkRadioButton TrueValueButton;
        private DarkUI.Controls.DarkRadioButton FalseValueButton;
        private DarkUI.Controls.DarkGroupBox ValueGroupBox;
        private DarkUI.Controls.DarkGroupBox OnChangeBox;
        private DarkUI.Controls.DarkListView ActionsListView;
    }
}
