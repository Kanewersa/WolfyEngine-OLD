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
            this.ComponentsListView = new DarkUI.Controls.DarkListView();
            this.EntityNameTitle = new DarkUI.Controls.DarkTitle();
            this.EntityNameTextBox = new DarkUI.Controls.DarkTextBox();
            this.ComponentsStrip = new DarkUI.Controls.DarkMenuStrip();
            this.AddComponentStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.noComponentsAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentContextMenu = new DarkUI.Controls.DarkContextMenu();
            this.RemoveComponentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowComponentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.MainSection.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            this.ComponentsStrip.SuspendLayout();
            this.ComponentContextMenu.SuspendLayout();
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
            this.ComponentsDockPanel.Location = new System.Drawing.Point(175, 32);
            this.ComponentsDockPanel.Name = "ComponentsDockPanel";
            this.ComponentsDockPanel.Size = new System.Drawing.Size(479, 596);
            this.ComponentsDockPanel.TabIndex = 5;
            // 
            // MainSection
            // 
            this.MainSection.Controls.Add(this.TableLayoutPanel);
            this.MainSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainSection.Location = new System.Drawing.Point(0, 32);
            this.MainSection.Name = "MainSection";
            this.MainSection.SectionHeader = "Entity ID | Name";
            this.MainSection.Size = new System.Drawing.Size(175, 596);
            this.MainSection.TabIndex = 6;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.ColumnCount = 1;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Controls.Add(this.ComponentsListView, 0, 4);
            this.TableLayoutPanel.Controls.Add(this.EntityNameTitle, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.EntityNameTextBox, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.ComponentsStrip, 0, 3);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(1, 25);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 5;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.37341F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.464481F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.97997F));
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(173, 570);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // ComponentsListView
            // 
            this.ComponentsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComponentsListView.Location = new System.Drawing.Point(3, 370);
            this.ComponentsListView.Name = "ComponentsListView";
            this.ComponentsListView.Size = new System.Drawing.Size(167, 197);
            this.ComponentsListView.TabIndex = 5;
            this.ComponentsListView.Text = "darkListView1";
            this.ComponentsListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComponentsListClick);
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
            // ComponentsStrip
            // 
            this.ComponentsStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ComponentsStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ComponentsStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ComponentsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddComponentStrip});
            this.ComponentsStrip.Location = new System.Drawing.Point(0, 343);
            this.ComponentsStrip.Name = "ComponentsStrip";
            this.ComponentsStrip.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.ComponentsStrip.Size = new System.Drawing.Size(173, 24);
            this.ComponentsStrip.TabIndex = 6;
            this.ComponentsStrip.Text = "darkMenuStrip1";
            // 
            // AddComponentStrip
            // 
            this.AddComponentStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.AddComponentStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noComponentsAvailableToolStripMenuItem});
            this.AddComponentStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.AddComponentStrip.Image = global::WolfyEngine.Icons.plus;
            this.AddComponentStrip.Name = "AddComponentStrip";
            this.AddComponentStrip.Size = new System.Drawing.Size(122, 20);
            this.AddComponentStrip.Text = "Add component";
            // 
            // noComponentsAvailableToolStripMenuItem
            // 
            this.noComponentsAvailableToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.noComponentsAvailableToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.noComponentsAvailableToolStripMenuItem.Name = "noComponentsAvailableToolStripMenuItem";
            this.noComponentsAvailableToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.noComponentsAvailableToolStripMenuItem.Text = "No components available.";
            // 
            // ComponentContextMenu
            // 
            this.ComponentContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ComponentContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ComponentContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveComponentMenuItem,
            this.ShowComponentMenuItem});
            this.ComponentContextMenu.Name = "ComponentContextMenu";
            this.ComponentContextMenu.Size = new System.Drawing.Size(183, 48);
            // 
            // RemoveComponentMenuItem
            // 
            this.RemoveComponentMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.RemoveComponentMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.RemoveComponentMenuItem.Image = global::WolfyEngine.Icons.x;
            this.RemoveComponentMenuItem.Name = "RemoveComponentMenuItem";
            this.RemoveComponentMenuItem.Size = new System.Drawing.Size(182, 22);
            this.RemoveComponentMenuItem.Text = "Remove component";
            this.RemoveComponentMenuItem.Click += new System.EventHandler(this.RemoveComponentMenuItem_Click);
            // 
            // ShowComponentMenuItem
            // 
            this.ShowComponentMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ShowComponentMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ShowComponentMenuItem.Image = global::WolfyEngine.Icons.refresh_cw;
            this.ShowComponentMenuItem.Name = "ShowComponentMenuItem";
            this.ShowComponentMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ShowComponentMenuItem.Text = "Show component";
            this.ShowComponentMenuItem.Click += new System.EventHandler(this.ShowComponentMenuItem_Click);
            // 
            // EntityEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 663);
            this.Controls.Add(this.ComponentsDockPanel);
            this.Controls.Add(this.MainSection);
            this.Controls.Add(this.panel2);
            this.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip = this.ComponentsStrip;
            this.Name = "EntityEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Entity";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.MainSection, 0);
            this.Controls.SetChildIndex(this.ComponentsDockPanel, 0);
            this.panel2.ResumeLayout(false);
            this.MainSection.ResumeLayout(false);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ComponentsStrip.ResumeLayout(false);
            this.ComponentsStrip.PerformLayout();
            this.ComponentContextMenu.ResumeLayout(false);
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
        private DarkUI.Controls.DarkMenuStrip ComponentsStrip;
        private System.Windows.Forms.ToolStripMenuItem AddComponentStrip;
        private System.Windows.Forms.ToolStripMenuItem noComponentsAvailableToolStripMenuItem;
        private DarkUI.Controls.DarkContextMenu ComponentContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveComponentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowComponentMenuItem;
    }
}