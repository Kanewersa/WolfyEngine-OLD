using System;
using WolfyCore.Engine;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MovementTypeBox = new DarkUI.Controls.DarkComboBox();
            this.MovementTypeLabel = new DarkUI.Controls.DarkLabel();
            this.FrequencyLabel = new DarkUI.Controls.DarkLabel();
            this.FrequencyNumericUpDown = new DarkUI.Controls.DarkNumericUpDown();
            this.SpeedLabel = new DarkUI.Controls.DarkLabel();
            this.SpeedNumericUpDown = new DarkUI.Controls.DarkNumericUpDown();
            this.FollowRangeNumericUpDown = new DarkUI.Controls.DarkNumericUpDown();
            this.FollowRangeLabel = new DarkUI.Controls.DarkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FollowRangeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MovementTypeBox
            // 
            this.MovementTypeBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MovementTypeBox.FormattingEnabled = true;
            this.MovementTypeBox.Items.AddRange(new object[] {
            WolfyCore.Engine.MovementType.Fixed,
            WolfyCore.Engine.MovementType.Random,
            WolfyCore.Engine.MovementType.Follow});
            this.MovementTypeBox.Location = new System.Drawing.Point(11, 31);
            this.MovementTypeBox.Name = "MovementTypeBox";
            this.MovementTypeBox.Size = new System.Drawing.Size(84, 21);
            this.MovementTypeBox.TabIndex = 0;
            this.MovementTypeBox.SelectedIndexChanged += new System.EventHandler(this.MovementTypeBox_SelectedIndexChanged);
            // 
            // MovementTypeLabel
            // 
            this.MovementTypeLabel.AutoSize = true;
            this.MovementTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MovementTypeLabel.Location = new System.Drawing.Point(11, 12);
            this.MovementTypeLabel.Name = "MovementTypeLabel";
            this.MovementTypeLabel.Size = new System.Drawing.Size(87, 13);
            this.MovementTypeLabel.TabIndex = 1;
            this.MovementTypeLabel.Text = "Movement Type:";
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.FrequencyLabel.Location = new System.Drawing.Point(11, 66);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(57, 13);
            this.FrequencyLabel.TabIndex = 2;
            this.FrequencyLabel.Text = "Frequency";
            // 
            // FrequencyNumericUpDown
            // 
            this.FrequencyNumericUpDown.Location = new System.Drawing.Point(14, 83);
            this.FrequencyNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FrequencyNumericUpDown.Name = "FrequencyNumericUpDown";
            this.FrequencyNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.FrequencyNumericUpDown.TabIndex = 3;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.SpeedLabel.Location = new System.Drawing.Point(11, 122);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(38, 13);
            this.SpeedLabel.TabIndex = 4;
            this.SpeedLabel.Text = "Speed";
            // 
            // SpeedNumericUpDown
            // 
            this.SpeedNumericUpDown.Location = new System.Drawing.Point(14, 139);
            this.SpeedNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpeedNumericUpDown.Name = "SpeedNumericUpDown";
            this.SpeedNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.SpeedNumericUpDown.TabIndex = 5;
            // 
            // FollowRangeNumericUpDown
            // 
            this.FollowRangeNumericUpDown.Location = new System.Drawing.Point(14, 197);
            this.FollowRangeNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.FollowRangeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.FollowRangeNumericUpDown.Name = "FollowRangeNumericUpDown";
            this.FollowRangeNumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.FollowRangeNumericUpDown.TabIndex = 7;
            // 
            // FollowRangeLabel
            // 
            this.FollowRangeLabel.AutoSize = true;
            this.FollowRangeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.FollowRangeLabel.Location = new System.Drawing.Point(11, 180);
            this.FollowRangeLabel.Name = "FollowRangeLabel";
            this.FollowRangeLabel.Size = new System.Drawing.Size(67, 13);
            this.FollowRangeLabel.TabIndex = 6;
            this.FollowRangeLabel.Text = "Follow range";
            // 
            // MovementComponentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.FollowRangeNumericUpDown);
            this.Controls.Add(this.FollowRangeLabel);
            this.Controls.Add(this.SpeedNumericUpDown);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.FrequencyNumericUpDown);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.MovementTypeLabel);
            this.Controls.Add(this.MovementTypeBox);
            this.DockText = "Movement";
            this.Name = "MovementComponentPanel";
            this.Size = new System.Drawing.Size(481, 337);
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FollowRangeNumericUpDown)).EndInit();
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
        private DarkUI.Controls.DarkNumericUpDown FollowRangeNumericUpDown;
        private DarkUI.Controls.DarkLabel FollowRangeLabel;
    }
}
