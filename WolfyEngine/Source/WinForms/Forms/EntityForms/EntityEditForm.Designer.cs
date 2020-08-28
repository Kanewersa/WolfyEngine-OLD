namespace WolfyEngine.Forms
{
    partial class EntityEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.CancelButton = new DarkUI.Controls.DarkButton();
            this.SaveButton = new DarkUI.Controls.DarkButton();
            this.ComponentsDockPanel = new DarkUI.Docking.DarkDockPanel();
            this.MainSection = new DarkUI.Controls.DarkSectionPanel();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.EntityNameTitle = new DarkUI.Controls.DarkTitle();
            this.EntityNameTextBox = new DarkUI.Controls.DarkTextBox();
            this.ComponentsListView = new DarkUI.Controls.DarkListView();
            this.panel2.SuspendLayout();
            this.MainSection.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CancelButton);
            this.panel2.Controls.Add(this.SaveButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 628);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 35);
            this.panel2.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(565, 5);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Padding = new System.Windows.Forms.Padding(5);
            this.CancelButton.Size = new System.Drawing.Size(75, 25);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(480, 5);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Padding = new System.Windows.Forms.Padding(5);
            this.SaveButton.Size = new System.Drawing.Size(75, 25);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ComponentsDockPanel
            // 
            this.ComponentsDockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ComponentsDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComponentsDockPanel.Location = new System.Drawing.Point(175, 0);
            this.ComponentsDockPanel.Name = "ComponentsDockPanel";
            this.ComponentsDockPanel.Size = new System.Drawing.Size(479, 628);
            this.ComponentsDockPanel.TabIndex = 5;
            // 
            // MainSection
            // 
            this.MainSection.Controls.Add(this.TableLayoutPanel);
            this.MainSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainSection.Location = new System.Drawing.Point(0, 0);
            this.MainSection.Name = "MainSection";
            this.MainSection.SectionHeader = "Entity ID | Name";
            this.MainSection.Size = new System.Drawing.Size(175, 628);
            this.MainSection.TabIndex = 6;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 1;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Controls.Add(this.EntityNameTitle, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.EntityNameTextBox, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.ComponentsListView, 0, 4);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(1, 25);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 6;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(173, 602);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // EntityNameTitle
            // 
            this.EntityNameTitle.AutoSize = true;
            this.EntityNameTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntityNameTitle.Location = new System.Drawing.Point(10, 10);
            this.EntityNameTitle.Margin = new System.Windows.Forms.Padding(10, 10, 10, 2);
            this.EntityNameTitle.Name = "EntityNameTitle";
            this.EntityNameTitle.Size = new System.Drawing.Size(153, 13);
            this.EntityNameTitle.TabIndex = 1;
            this.EntityNameTitle.Text = "Name";
            // 
            // EntityNameTextBox
            // 
            this.EntityNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.EntityNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntityNameTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EntityNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.EntityNameTextBox.Location = new System.Drawing.Point(4, 27);
            this.EntityNameTextBox.Margin = new System.Windows.Forms.Padding(4, 2, 7, 6);
            this.EntityNameTextBox.Name = "EntityNameTextBox";
            this.EntityNameTextBox.Size = new System.Drawing.Size(162, 20);
            this.EntityNameTextBox.TabIndex = 2;
            this.EntityNameTextBox.TextChanged += new System.EventHandler(this.EntityNameTextBox_TextChanged);
            // 
            // ComponentsListView
            // 
            this.ComponentsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComponentsListView.Location = new System.Drawing.Point(3, 330);
            this.ComponentsListView.Name = "ComponentsListView";
            this.ComponentsListView.Size = new System.Drawing.Size(167, 131);
            this.ComponentsListView.TabIndex = 3;
            this.ComponentsListView.Text = "darkListView1";
            // 
            // EntityEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 663);
            this.Controls.Add(this.ComponentsDockPanel);
            this.Controls.Add(this.MainSection);
            this.Controls.Add(this.panel2);
            this.Name = "EntityEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Entity";
            this.panel2.ResumeLayout(false);
            this.MainSection.ResumeLayout(false);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private DarkUI.Controls.DarkButton CancelButton;
        private DarkUI.Controls.DarkButton SaveButton;
        private DarkUI.Docking.DarkDockPanel ComponentsDockPanel;
        private DarkUI.Controls.DarkSectionPanel MainSection;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private DarkUI.Controls.DarkTitle EntityNameTitle;
        private DarkUI.Controls.DarkTextBox EntityNameTextBox;
        private DarkUI.Controls.DarkListView ComponentsListView;
    }
}