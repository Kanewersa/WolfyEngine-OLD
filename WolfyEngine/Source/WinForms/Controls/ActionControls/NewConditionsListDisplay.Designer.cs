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
            this.BoolLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AddBoolButton = new DarkUI.Controls.DarkButton();
            this.darkButton155 = new DarkUI.Controls.DarkButton();
            this.UnknownButton1 = new DarkUI.Controls.DarkButton();
            this.VariableSection = new DarkUI.Controls.DarkSectionPanel();
            this.VariableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AddFloatButton = new DarkUI.Controls.DarkButton();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkButton3 = new DarkUI.Controls.DarkButton();
            this.LayoutPanel.SuspendLayout();
            this.BoolSection.SuspendLayout();
            this.BoolLayout.SuspendLayout();
            this.VariableSection.SuspendLayout();
            this.VariableLayout.SuspendLayout();
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
            // BoolLayout
            // 
            this.BoolLayout.ColumnCount = 1;
            this.BoolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BoolLayout.Controls.Add(this.AddBoolButton, 0, 0);
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
            // AddBoolButton
            // 
            this.AddBoolButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddBoolButton.Location = new System.Drawing.Point(0, 2);
            this.AddBoolButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.AddBoolButton.Name = "AddBoolButton";
            this.AddBoolButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddBoolButton.Size = new System.Drawing.Size(180, 26);
            this.AddBoolButton.TabIndex = 11;
            this.AddBoolButton.Text = "Add bool condition";
            this.AddBoolButton.Click += new System.EventHandler(this.AddBoolButton_Click);
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
            // VariableSection
            // 
            this.VariableSection.Controls.Add(this.VariableLayout);
            this.VariableSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableSection.Location = new System.Drawing.Point(182, 0);
            this.VariableSection.Margin = new System.Windows.Forms.Padding(0);
            this.VariableSection.Name = "VariableSection";
            this.VariableSection.SectionHeader = "Variable";
            this.VariableSection.Size = new System.Drawing.Size(182, 462);
            this.VariableSection.TabIndex = 6;
            // 
            // VariableLayout
            // 
            this.VariableLayout.ColumnCount = 1;
            this.VariableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.VariableLayout.Controls.Add(this.AddFloatButton, 0, 0);
            this.VariableLayout.Controls.Add(this.darkButton2, 0, 1);
            this.VariableLayout.Controls.Add(this.darkButton3, 0, 2);
            this.VariableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableLayout.Location = new System.Drawing.Point(1, 25);
            this.VariableLayout.Name = "VariableLayout";
            this.VariableLayout.RowCount = 8;
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.VariableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.VariableLayout.Size = new System.Drawing.Size(180, 436);
            this.VariableLayout.TabIndex = 2;
            // 
            // AddFloatButton
            // 
            this.AddFloatButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddFloatButton.Location = new System.Drawing.Point(0, 2);
            this.AddFloatButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.AddFloatButton.Name = "AddFloatButton";
            this.AddFloatButton.Padding = new System.Windows.Forms.Padding(5);
            this.AddFloatButton.Size = new System.Drawing.Size(180, 26);
            this.AddFloatButton.TabIndex = 11;
            this.AddFloatButton.Text = "Add float condition";
            this.AddFloatButton.Click += new System.EventHandler(this.AddFloatButton_Click);
            // 
            // darkButton2
            // 
            this.darkButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton2.Enabled = false;
            this.darkButton2.Location = new System.Drawing.Point(0, 32);
            this.darkButton2.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton2.Size = new System.Drawing.Size(180, 26);
            this.darkButton2.TabIndex = 12;
            this.darkButton2.Text = "Unavailable";
            // 
            // darkButton3
            // 
            this.darkButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton3.Enabled = false;
            this.darkButton3.Location = new System.Drawing.Point(0, 62);
            this.darkButton3.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton3.Name = "darkButton3";
            this.darkButton3.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton3.Size = new System.Drawing.Size(180, 26);
            this.darkButton3.TabIndex = 13;
            this.darkButton3.Text = "Unavailable";
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
            this.VariableSection.ResumeLayout(false);
            this.VariableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private DarkUI.Controls.DarkSectionPanel BoolSection;
        private DarkUI.Controls.DarkSectionPanel VariableSection;
        private System.Windows.Forms.TableLayoutPanel BoolLayout;
        private DarkUI.Controls.DarkButton UnknownButton1;
        private DarkUI.Controls.DarkButton AddBoolButton;
        private DarkUI.Controls.DarkButton darkButton155;
        private System.Windows.Forms.TableLayoutPanel VariableLayout;
        private DarkUI.Controls.DarkButton AddFloatButton;
        private DarkUI.Controls.DarkButton darkButton2;
        private DarkUI.Controls.DarkButton darkButton3;
    }
}
