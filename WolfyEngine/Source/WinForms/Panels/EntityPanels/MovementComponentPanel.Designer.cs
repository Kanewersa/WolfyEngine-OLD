﻿using System;
using WolfyShared.Engine;

namespace WolfyEngine.Controls
{
    partial class MovementComponentPanel
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
            this.MovementTypeBox = new DarkUI.Controls.DarkComboBox();
            this.MovementTypeLabel = new DarkUI.Controls.DarkLabel();
            this.FrequencyLabel = new DarkUI.Controls.DarkLabel();
            this.FrequencyNumericUpDown = new DarkUI.Controls.DarkNumericUpDown();
            this.SpeedLabel = new DarkUI.Controls.DarkLabel();
            this.SpeedNumericUpDown = new DarkUI.Controls.DarkNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MovementTypeBox
            // 
            this.MovementTypeBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MovementTypeBox.FormattingEnabled = true;
            this.MovementTypeBox.Items.AddRange(new object[] {
            WolfyShared.Engine.MovementType.Fixed,
            WolfyShared.Engine.MovementType.Random,
            WolfyShared.Engine.MovementType.Follow});
            this.MovementTypeBox.Location = new System.Drawing.Point(11, 57);
            this.MovementTypeBox.Name = "MovementTypeBox";
            this.MovementTypeBox.Size = new System.Drawing.Size(84, 21);
            this.MovementTypeBox.TabIndex = 0;
            this.MovementTypeBox.SelectedIndexChanged += new System.EventHandler(this.MovementTypeBox_SelectedIndexChanged);
            // 
            // MovementTypeLabel
            // 
            this.MovementTypeLabel.AutoSize = true;
            this.MovementTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MovementTypeLabel.Location = new System.Drawing.Point(11, 38);
            this.MovementTypeLabel.Name = "MovementTypeLabel";
            this.MovementTypeLabel.Size = new System.Drawing.Size(87, 13);
            this.MovementTypeLabel.TabIndex = 1;
            this.MovementTypeLabel.Text = "Movement Type:";
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.FrequencyLabel.Location = new System.Drawing.Point(11, 92);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(57, 13);
            this.FrequencyLabel.TabIndex = 2;
            this.FrequencyLabel.Text = "Frequency";
            // 
            // FrequencyNumericUpDown
            // 
            this.FrequencyNumericUpDown.Location = new System.Drawing.Point(14, 109);
            this.FrequencyNumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.FrequencyNumericUpDown.Name = "FrequencyNumericUpDown";
            this.FrequencyNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.FrequencyNumericUpDown.TabIndex = 3;
            this.FrequencyNumericUpDown.ValueChanged += new System.EventHandler(this.FrequencyNumericUpDown_ValueChanged);
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SpeedLabel.Location = new System.Drawing.Point(11, 148);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(38, 13);
            this.SpeedLabel.TabIndex = 4;
            this.SpeedLabel.Text = "Speed";
            // 
            // SpeedNumericUpDown
            // 
            this.SpeedNumericUpDown.Location = new System.Drawing.Point(14, 165);
            this.SpeedNumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.SpeedNumericUpDown.Name = "SpeedNumericUpDown";
            this.SpeedNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.SpeedNumericUpDown.TabIndex = 5;
            this.SpeedNumericUpDown.ValueChanged += new System.EventHandler(this.SpeedNumericUpDown_ValueChanged);
            // 
            // MovementComponentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SpeedNumericUpDown);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.FrequencyNumericUpDown);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.MovementTypeLabel);
            this.Controls.Add(this.MovementTypeBox);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Document;
            this.DockText = "Movement";
            this.Name = "MovementComponentPanel";
            this.Size = new System.Drawing.Size(481, 337);
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkComboBox MovementTypeBox;
        private DarkUI.Controls.DarkLabel MovementTypeLabel;
        private DarkUI.Controls.DarkLabel FrequencyLabel;
        private DarkUI.Controls.DarkNumericUpDown FrequencyNumericUpDown;
        private DarkUI.Controls.DarkLabel SpeedLabel;
        private DarkUI.Controls.DarkNumericUpDown SpeedNumericUpDown;
    }
}