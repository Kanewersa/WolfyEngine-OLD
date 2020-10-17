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
            this.ConditionSection = new DarkUI.Controls.DarkSectionPanel();
            this.BoolLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AddConditionButton = new DarkUI.Controls.DarkButton();
            this.SetVariableButton = new DarkUI.Controls.DarkButton();
            this.UnknownButton1 = new DarkUI.Controls.DarkButton();
            this.OtherSection = new DarkUI.Controls.DarkSectionPanel();
            this.VariableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutPanel.SuspendLayout();
            this.ConditionSection.SuspendLayout();
            this.BoolLayout.SuspendLayout();
            this.OtherSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.Controls.Add(this.ConditionSection, 0, 0);
            this.LayoutPanel.Controls.Add(this.OtherSection, 1, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 1;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(364, 462);
            this.LayoutPanel.TabIndex = 2;
            // 
            // ConditionSection
            // 
            this.ConditionSection.Controls.Add(this.BoolLayout);
            this.ConditionSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionSection.Location = new System.Drawing.Point(0, 0);
            this.ConditionSection.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionSection.Name = "ConditionSection";
            this.ConditionSection.SectionHeader = "Conditions";
            this.ConditionSection.Size = new System.Drawing.Size(182, 462);
            this.ConditionSection.TabIndex = 4;
            // 
            // BoolLayout
            // 
            this.BoolLayout.ColumnCount = 1;
            this.BoolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BoolLayout.Controls.Add(this.AddConditionButton, 0, 0);
            this.BoolLayout.Controls.Add(this.SetVariableButton, 0, 1);
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
            this.AddConditionButton.Click += new System.EventHandler(this.AddConditionButton_Click);
            // 
            // SetVariableButton
            // 
            this.SetVariableButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetVariableButton.Location = new System.Drawing.Point(0, 32);
            this.SetVariableButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.SetVariableButton.Name = "SetVariableButton";
            this.SetVariableButton.Padding = new System.Windows.Forms.Padding(5);
            this.SetVariableButton.Size = new System.Drawing.Size(180, 26);
            this.SetVariableButton.TabIndex = 12;
            this.SetVariableButton.Text = "Set variable";
            this.SetVariableButton.Click += new System.EventHandler(this.SetVariableButton_Click);
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
            // OtherSection
            // 
            this.OtherSection.Controls.Add(this.VariableLayout);
            this.OtherSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OtherSection.Location = new System.Drawing.Point(182, 0);
            this.OtherSection.Margin = new System.Windows.Forms.Padding(0);
            this.OtherSection.Name = "OtherSection";
            this.OtherSection.SectionHeader = "Other";
            this.OtherSection.Size = new System.Drawing.Size(182, 462);
            this.OtherSection.TabIndex = 6;
            // 
            // VariableLayout
            // 
            this.VariableLayout.ColumnCount = 1;
            this.VariableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
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
            // NewConditionsListDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.LayoutPanel);
            this.Name = "NewConditionsListDisplay";
            this.Size = new System.Drawing.Size(364, 462);
            this.LayoutPanel.ResumeLayout(false);
            this.ConditionSection.ResumeLayout(false);
            this.BoolLayout.ResumeLayout(false);
            this.OtherSection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private DarkUI.Controls.DarkSectionPanel ConditionSection;
        private DarkUI.Controls.DarkSectionPanel OtherSection;
        private System.Windows.Forms.TableLayoutPanel BoolLayout;
        private DarkUI.Controls.DarkButton UnknownButton1;
        private DarkUI.Controls.DarkButton AddConditionButton;
        private DarkUI.Controls.DarkButton SetVariableButton;
        private System.Windows.Forms.TableLayoutPanel VariableLayout;
    }
}
