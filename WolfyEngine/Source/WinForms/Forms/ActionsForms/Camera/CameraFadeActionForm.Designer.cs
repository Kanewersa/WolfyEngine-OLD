namespace WolfyEngine.Forms
{
    partial class CameraFadeActionForm
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
            this.FadeInButton = new DarkUI.Controls.DarkRadioButton();
            this.FadeTypeTitle = new DarkUI.Controls.DarkTitle();
            this.FadeOutButton = new DarkUI.Controls.DarkRadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FadeDurationBox = new DarkUI.Controls.DarkNumericUpDown();
            this.FadeDurationTitle = new DarkUI.Controls.DarkTitle();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FadeDurationBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FadeInButton
            // 
            this.FadeInButton.AutoSize = true;
            this.FadeInButton.Checked = true;
            this.FadeInButton.Location = new System.Drawing.Point(12, 36);
            this.FadeInButton.Name = "FadeInButton";
            this.FadeInButton.Size = new System.Drawing.Size(60, 17);
            this.FadeInButton.TabIndex = 8;
            this.FadeInButton.TabStop = true;
            this.FadeInButton.Text = "Fade in";
            // 
            // FadeTypeTitle
            // 
            this.FadeTypeTitle.AutoSize = true;
            this.FadeTypeTitle.Location = new System.Drawing.Point(12, 15);
            this.FadeTypeTitle.Name = "FadeTypeTitle";
            this.FadeTypeTitle.Size = new System.Drawing.Size(57, 13);
            this.FadeTypeTitle.TabIndex = 9;
            this.FadeTypeTitle.Text = "Fade type:";
            // 
            // FadeOutButton
            // 
            this.FadeOutButton.AutoSize = true;
            this.FadeOutButton.Location = new System.Drawing.Point(94, 36);
            this.FadeOutButton.Name = "FadeOutButton";
            this.FadeOutButton.Size = new System.Drawing.Size(67, 17);
            this.FadeOutButton.TabIndex = 10;
            this.FadeOutButton.Text = "Fade out";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FadeDurationBox);
            this.panel1.Controls.Add(this.FadeDurationTitle);
            this.panel1.Controls.Add(this.darkSeparator1);
            this.panel1.Controls.Add(this.FadeOutButton);
            this.panel1.Controls.Add(this.FadeTypeTitle);
            this.panel1.Controls.Add(this.FadeInButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 123);
            this.panel1.TabIndex = 11;
            // 
            // FadeDurationBox
            // 
            this.FadeDurationBox.DecimalPlaces = 1;
            this.FadeDurationBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.FadeDurationBox.Location = new System.Drawing.Point(12, 91);
            this.FadeDurationBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.FadeDurationBox.Name = "FadeDurationBox";
            this.FadeDurationBox.Size = new System.Drawing.Size(135, 20);
            this.FadeDurationBox.TabIndex = 12;
            // 
            // FadeDurationTitle
            // 
            this.FadeDurationTitle.AutoSize = true;
            this.FadeDurationTitle.Location = new System.Drawing.Point(12, 70);
            this.FadeDurationTitle.Name = "FadeDurationTitle";
            this.FadeDurationTitle.Size = new System.Drawing.Size(135, 13);
            this.FadeDurationTitle.TabIndex = 11;
            this.FadeDurationTitle.Text = "Fade duration (in seconds):";
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 0);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(209, 2);
            this.darkSeparator1.TabIndex = 6;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // CameraFadeActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 153);
            this.Controls.Add(this.panel1);
            this.Name = "CameraFadeActionForm";
            this.Text = "Fade camera";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FadeDurationBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkRadioButton FadeInButton;
        private DarkUI.Controls.DarkTitle FadeTypeTitle;
        private DarkUI.Controls.DarkRadioButton FadeOutButton;
        private System.Windows.Forms.Panel panel1;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkTitle FadeDurationTitle;
        private DarkUI.Controls.DarkNumericUpDown FadeDurationBox;
    }
}