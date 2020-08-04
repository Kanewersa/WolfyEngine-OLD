﻿namespace WolfyEngine.Controls
{
    partial class NewActionsListDisplay
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
            this.WorldSection = new DarkUI.Controls.DarkSectionPanel();
            this.CameraSection = new DarkUI.Controls.DarkSectionPanel();
            this.MovementSection = new DarkUI.Controls.DarkSectionPanel();
            this.PlayerSection = new DarkUI.Controls.DarkSectionPanel();
            this.MovementLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TeleportButton = new DarkUI.Controls.DarkButton();
            this.MoveEntityButton = new DarkUI.Controls.DarkButton();
            this.UnknownButton1 = new DarkUI.Controls.DarkButton();
            this.UnknownButton2 = new DarkUI.Controls.DarkButton();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkButton3 = new DarkUI.Controls.DarkButton();
            this.PlayerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.darkButton4 = new DarkUI.Controls.DarkButton();
            this.darkButton5 = new DarkUI.Controls.DarkButton();
            this.darkButton6 = new DarkUI.Controls.DarkButton();
            this.darkButton10 = new DarkUI.Controls.DarkButton();
            this.CameraTargetButton = new DarkUI.Controls.DarkButton();
            this.ZoomButton = new DarkUI.Controls.DarkButton();
            this.CameraOverlayButton = new DarkUI.Controls.DarkButton();
            this.LayoutPanel.SuspendLayout();
            this.CameraSection.SuspendLayout();
            this.MovementSection.SuspendLayout();
            this.MovementLayout.SuspendLayout();
            this.PlayerLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.Controls.Add(this.WorldSection, 1, 1);
            this.LayoutPanel.Controls.Add(this.CameraSection, 0, 1);
            this.LayoutPanel.Controls.Add(this.MovementSection, 0, 0);
            this.LayoutPanel.Controls.Add(this.PlayerSection, 1, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 2;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(409, 545);
            this.LayoutPanel.TabIndex = 1;
            // 
            // WorldSection
            // 
            this.WorldSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldSection.Location = new System.Drawing.Point(204, 272);
            this.WorldSection.Margin = new System.Windows.Forms.Padding(0);
            this.WorldSection.Name = "WorldSection";
            this.WorldSection.SectionHeader = "World";
            this.WorldSection.Size = new System.Drawing.Size(205, 273);
            this.WorldSection.TabIndex = 7;
            // 
            // CameraSection
            // 
            this.CameraSection.Controls.Add(this.PlayerLayout);
            this.CameraSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraSection.Location = new System.Drawing.Point(0, 272);
            this.CameraSection.Margin = new System.Windows.Forms.Padding(0);
            this.CameraSection.Name = "CameraSection";
            this.CameraSection.SectionHeader = "Camera";
            this.CameraSection.Size = new System.Drawing.Size(204, 273);
            this.CameraSection.TabIndex = 5;
            // 
            // MovementSection
            // 
            this.MovementSection.Controls.Add(this.MovementLayout);
            this.MovementSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MovementSection.Location = new System.Drawing.Point(0, 0);
            this.MovementSection.Margin = new System.Windows.Forms.Padding(0);
            this.MovementSection.Name = "MovementSection";
            this.MovementSection.SectionHeader = "Movement";
            this.MovementSection.Size = new System.Drawing.Size(204, 272);
            this.MovementSection.TabIndex = 4;
            // 
            // PlayerSection
            // 
            this.PlayerSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerSection.Location = new System.Drawing.Point(204, 0);
            this.PlayerSection.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerSection.Name = "PlayerSection";
            this.PlayerSection.SectionHeader = "Player";
            this.PlayerSection.Size = new System.Drawing.Size(205, 272);
            this.PlayerSection.TabIndex = 6;
            // 
            // MovementLayout
            // 
            this.MovementLayout.ColumnCount = 1;
            this.MovementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MovementLayout.Controls.Add(this.darkButton3, 0, 6);
            this.MovementLayout.Controls.Add(this.darkButton2, 0, 5);
            this.MovementLayout.Controls.Add(this.darkButton1, 0, 4);
            this.MovementLayout.Controls.Add(this.TeleportButton, 0, 0);
            this.MovementLayout.Controls.Add(this.MoveEntityButton, 0, 1);
            this.MovementLayout.Controls.Add(this.UnknownButton1, 0, 2);
            this.MovementLayout.Controls.Add(this.UnknownButton2, 0, 3);
            this.MovementLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MovementLayout.Location = new System.Drawing.Point(1, 25);
            this.MovementLayout.Name = "MovementLayout";
            this.MovementLayout.RowCount = 8;
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MovementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MovementLayout.Size = new System.Drawing.Size(202, 246);
            this.MovementLayout.TabIndex = 0;
            // 
            // TeleportButton
            // 
            this.TeleportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeleportButton.Location = new System.Drawing.Point(0, 2);
            this.TeleportButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.TeleportButton.Name = "TeleportButton";
            this.TeleportButton.Padding = new System.Windows.Forms.Padding(5);
            this.TeleportButton.Size = new System.Drawing.Size(202, 26);
            this.TeleportButton.TabIndex = 11;
            this.TeleportButton.Text = "Teleport entity";
            // 
            // MoveEntityButton
            // 
            this.MoveEntityButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoveEntityButton.Location = new System.Drawing.Point(0, 32);
            this.MoveEntityButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.MoveEntityButton.Name = "MoveEntityButton";
            this.MoveEntityButton.Padding = new System.Windows.Forms.Padding(5);
            this.MoveEntityButton.Size = new System.Drawing.Size(202, 26);
            this.MoveEntityButton.TabIndex = 12;
            this.MoveEntityButton.Text = "Move Entity";
            // 
            // UnknownButton1
            // 
            this.UnknownButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnknownButton1.Enabled = false;
            this.UnknownButton1.Location = new System.Drawing.Point(0, 62);
            this.UnknownButton1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.UnknownButton1.Name = "UnknownButton1";
            this.UnknownButton1.Padding = new System.Windows.Forms.Padding(5);
            this.UnknownButton1.Size = new System.Drawing.Size(202, 26);
            this.UnknownButton1.TabIndex = 13;
            this.UnknownButton1.Text = "Unavailable";
            // 
            // UnknownButton2
            // 
            this.UnknownButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnknownButton2.Enabled = false;
            this.UnknownButton2.Location = new System.Drawing.Point(0, 92);
            this.UnknownButton2.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.UnknownButton2.Name = "UnknownButton2";
            this.UnknownButton2.Padding = new System.Windows.Forms.Padding(5);
            this.UnknownButton2.Size = new System.Drawing.Size(202, 26);
            this.UnknownButton2.TabIndex = 14;
            this.UnknownButton2.Text = "Unavailable";
            // 
            // darkButton1
            // 
            this.darkButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton1.Enabled = false;
            this.darkButton1.Location = new System.Drawing.Point(0, 122);
            this.darkButton1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton1.Size = new System.Drawing.Size(202, 26);
            this.darkButton1.TabIndex = 15;
            this.darkButton1.Text = "Unavailable";
            // 
            // darkButton2
            // 
            this.darkButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton2.Enabled = false;
            this.darkButton2.Location = new System.Drawing.Point(0, 152);
            this.darkButton2.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton2.Size = new System.Drawing.Size(202, 26);
            this.darkButton2.TabIndex = 16;
            this.darkButton2.Text = "Unavailable";
            // 
            // darkButton3
            // 
            this.darkButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton3.Enabled = false;
            this.darkButton3.Location = new System.Drawing.Point(0, 182);
            this.darkButton3.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton3.Name = "darkButton3";
            this.darkButton3.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton3.Size = new System.Drawing.Size(202, 26);
            this.darkButton3.TabIndex = 17;
            this.darkButton3.Text = "Unavailable";
            // 
            // PlayerLayout
            // 
            this.PlayerLayout.ColumnCount = 1;
            this.PlayerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PlayerLayout.Controls.Add(this.darkButton4, 0, 6);
            this.PlayerLayout.Controls.Add(this.darkButton5, 0, 5);
            this.PlayerLayout.Controls.Add(this.darkButton6, 0, 4);
            this.PlayerLayout.Controls.Add(this.darkButton10, 0, 3);
            this.PlayerLayout.Controls.Add(this.CameraTargetButton, 0, 0);
            this.PlayerLayout.Controls.Add(this.ZoomButton, 0, 1);
            this.PlayerLayout.Controls.Add(this.CameraOverlayButton, 0, 2);
            this.PlayerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerLayout.Location = new System.Drawing.Point(1, 25);
            this.PlayerLayout.Name = "PlayerLayout";
            this.PlayerLayout.RowCount = 8;
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PlayerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PlayerLayout.Size = new System.Drawing.Size(202, 247);
            this.PlayerLayout.TabIndex = 2;
            // 
            // darkButton4
            // 
            this.darkButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton4.Enabled = false;
            this.darkButton4.Location = new System.Drawing.Point(0, 182);
            this.darkButton4.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton4.Name = "darkButton4";
            this.darkButton4.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton4.Size = new System.Drawing.Size(202, 26);
            this.darkButton4.TabIndex = 17;
            this.darkButton4.Text = "Unavailable";
            // 
            // darkButton5
            // 
            this.darkButton5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton5.Enabled = false;
            this.darkButton5.Location = new System.Drawing.Point(0, 152);
            this.darkButton5.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton5.Name = "darkButton5";
            this.darkButton5.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton5.Size = new System.Drawing.Size(202, 26);
            this.darkButton5.TabIndex = 16;
            this.darkButton5.Text = "Unavailable";
            // 
            // darkButton6
            // 
            this.darkButton6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton6.Enabled = false;
            this.darkButton6.Location = new System.Drawing.Point(0, 122);
            this.darkButton6.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton6.Name = "darkButton6";
            this.darkButton6.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton6.Size = new System.Drawing.Size(202, 26);
            this.darkButton6.TabIndex = 15;
            this.darkButton6.Text = "Unavailable";
            // 
            // darkButton10
            // 
            this.darkButton10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton10.Enabled = false;
            this.darkButton10.Location = new System.Drawing.Point(0, 92);
            this.darkButton10.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.darkButton10.Name = "darkButton10";
            this.darkButton10.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton10.Size = new System.Drawing.Size(202, 26);
            this.darkButton10.TabIndex = 14;
            this.darkButton10.Text = "Unavailable";
            // 
            // CameraTargetButton
            // 
            this.CameraTargetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraTargetButton.Location = new System.Drawing.Point(0, 2);
            this.CameraTargetButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.CameraTargetButton.Name = "CameraTargetButton";
            this.CameraTargetButton.Padding = new System.Windows.Forms.Padding(5);
            this.CameraTargetButton.Size = new System.Drawing.Size(202, 26);
            this.CameraTargetButton.TabIndex = 18;
            this.CameraTargetButton.Text = "Camera follow target";
            // 
            // ZoomButton
            // 
            this.ZoomButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZoomButton.Location = new System.Drawing.Point(0, 32);
            this.ZoomButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ZoomButton.Name = "ZoomButton";
            this.ZoomButton.Padding = new System.Windows.Forms.Padding(5);
            this.ZoomButton.Size = new System.Drawing.Size(202, 26);
            this.ZoomButton.TabIndex = 19;
            this.ZoomButton.Text = "Change zoom";
            // 
            // CameraOverlayButton
            // 
            this.CameraOverlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraOverlayButton.Location = new System.Drawing.Point(0, 62);
            this.CameraOverlayButton.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.CameraOverlayButton.Name = "CameraOverlayButton";
            this.CameraOverlayButton.Padding = new System.Windows.Forms.Padding(5);
            this.CameraOverlayButton.Size = new System.Drawing.Size(202, 26);
            this.CameraOverlayButton.TabIndex = 20;
            this.CameraOverlayButton.Text = "Change overlay";
            // 
            // NewActionsListDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.LayoutPanel);
            this.Name = "NewActionsListDisplay";
            this.Size = new System.Drawing.Size(409, 545);
            this.LayoutPanel.ResumeLayout(false);
            this.CameraSection.ResumeLayout(false);
            this.MovementSection.ResumeLayout(false);
            this.MovementLayout.ResumeLayout(false);
            this.PlayerLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private DarkUI.Controls.DarkSectionPanel CameraSection;
        private DarkUI.Controls.DarkSectionPanel MovementSection;
        private DarkUI.Controls.DarkSectionPanel PlayerSection;
        private DarkUI.Controls.DarkSectionPanel WorldSection;
        private System.Windows.Forms.TableLayoutPanel MovementLayout;
        private DarkUI.Controls.DarkButton TeleportButton;
        private DarkUI.Controls.DarkButton MoveEntityButton;
        private DarkUI.Controls.DarkButton UnknownButton1;
        private DarkUI.Controls.DarkButton UnknownButton2;
        private DarkUI.Controls.DarkButton darkButton3;
        private DarkUI.Controls.DarkButton darkButton2;
        private DarkUI.Controls.DarkButton darkButton1;
        private System.Windows.Forms.TableLayoutPanel PlayerLayout;
        private DarkUI.Controls.DarkButton darkButton4;
        private DarkUI.Controls.DarkButton darkButton5;
        private DarkUI.Controls.DarkButton darkButton6;
        private DarkUI.Controls.DarkButton darkButton10;
        private DarkUI.Controls.DarkButton CameraTargetButton;
        private DarkUI.Controls.DarkButton ZoomButton;
        private DarkUI.Controls.DarkButton CameraOverlayButton;
    }
}
