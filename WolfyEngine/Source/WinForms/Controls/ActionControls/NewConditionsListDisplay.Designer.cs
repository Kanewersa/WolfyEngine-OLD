namespace WolfyEngine.Controls
{
    partial class NewConditionsListDisplay
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
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BoolSection = new DarkUI.Controls.DarkSectionPanel();
            this.VariableSection = new DarkUI.Controls.DarkSectionPanel();
            this.BoolLayout = new System.Windows.Forms.TableLayoutPanel();
            this.UnknownButton1 = new DarkUI.Controls.DarkButton();
            this.AddConditionButton = new DarkUI.Controls.DarkButton();
            this.darkButton155 = new DarkUI.Controls.DarkButton();
            this.LayoutPanel.SuspendLayout();
            this.BoolSection.SuspendLayout();
            this.BoolLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.Controls.Add(this.BoolSection, 0, 0);
            this.LayoutPanel.Controls.Add(this.VariableSection, 1, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 1;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(364, 462);
            this.LayoutPanel.TabIndex = 2;
            // 
            // BoolSection
            // 
            this.BoolSection.Controls.Add(this.BoolLayout);
            this.BoolSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoolSection.Location = new System.Drawing.Point(0, 0);
            this.BoolSection.Margin = new System.Windows.Forms.Padding(0);
            this.BoolSection.Name = "BoolSection";
            this.BoolSection.SectionHeader = "Boolean";
            this.BoolSection.Size = new System.Drawing.Size(182, 462);
            this.BoolSection.TabIndex = 4;
            // 
            // VariableSection
            // 
            this.VariableSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableSection.Location = new System.Drawing.Point(182, 0);
            this.VariableSection.Margin = new System.Windows.Forms.Padding(0);
            this.VariableSection.Name = "VariableSection";
            this.VariableSection.SectionHeader = "Variable";
            this.VariableSection.Size = new System.Drawing.Size(182, 462);
            this.VariableSection.TabIndex = 6;
            // 
            // BoolLayout
            // 
            this.BoolLayout.ColumnCount = 1;
            this.BoolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BoolLayout.Controls.Add(this.AddConditionButton, 0, 0);
            this.BoolLayout.Controls.Add(this.darkButton155, 0, 1);
            this.BoolLayout.Controls.Add(this.UnknownButton1, 0, 2);
            this.BoolLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoolLayout.Location = new System.Drawing.Point(1, 25);
            this.BoolLayout.Name = "BoolLayout";
            this.BoolLayout.RowCount = 8;
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.BoolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BoolLayout.Size = new System.Drawing.Size(180, 436);
            this.BoolLayout.TabIndex = 1;
            // 
            // UnknownButton1
            // 
            this.UnknownButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnknownButton1.Enabled = false;
            this.UnknownButton1.Location = new System.Drawing.Point(0, 62);
            this.UnknownButton1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.UnknownButton1.Name = "UnknownButton1";
            this.UnknownButton1.Padding = new System.Windows.Forms.Padding(5);
            this.UnknownButton1.Size = new System.Drawing.Size(180, 26);
            this.UnknownButton1.TabIndex = 13;
            this.UnknownButton1.Text = "Unavailable";
            // 
            // AddConditionButton
            // 
            this.AddConditionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddConditionButton.Location = new System.Drawing.Point(0, 2);
            this.AddConditionButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.AddConditionButton.Name = "AddConditionButton";
            this.AddConditionButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddConditionButton.Size = new System.Drawing.Size(180, 26);
            this.AddConditionButton.TabIndex = 11;
            this.AddConditionButton.Text = "Add condition";
            // 
            // darkButton155
            // 
            this.darkButton155.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton155.Enabled = false;
            this.darkButton155.Location = new System.Drawing.Point(0, 32);
            this.darkButton155.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton155.Name = "darkButton155";
            this.darkButton155.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton155.Size = new System.Drawing.Size(180, 26);
            this.darkButton155.TabIndex = 12;
            this.darkButton155.Text = "Unavailable";
            // 
            // NewConditionsListDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.LayoutPanel);
            this.Name = "NewConditionsListDisplay";
            this.Size = new System.Drawing.Size(364, 462);
            this.LayoutPanel.ResumeLayout(false);
            this.BoolSection.ResumeLayout(false);
            this.BoolLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private DarkUI.Controls.DarkSectionPanel BoolSection;
        private DarkUI.Controls.DarkSectionPanel VariableSection;
        private System.Windows.Forms.TableLayoutPanel BoolLayout;
        private DarkUI.Controls.DarkButton UnknownButton1;
        private DarkUI.Controls.DarkButton AddConditionButton;
        private DarkUI.Controls.DarkButton darkButton155;
    }
}
