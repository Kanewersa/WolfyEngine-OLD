namespace WolfyEngine.Forms
{
    partial class VariableDocument
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
            this.NameTextBox = new DarkUI.Controls.DarkTextBox();
            this.NameGroupBox = new DarkUI.Controls.DarkGroupBox();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.NameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.NameTextBox.Location = new System.Drawing.Point(14, 24);
            this.NameTextBox.MaxLength = 50;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(132, 20);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // NameGroupBox
            // 
            this.NameGroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.NameGroupBox.Controls.Add(this.NameTextBox);
            this.NameGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameGroupBox.Location = new System.Drawing.Point(0, 0);
            this.NameGroupBox.Name = "NameGroupBox";
            this.NameGroupBox.Size = new System.Drawing.Size(452, 57);
            this.NameGroupBox.TabIndex = 0;
            this.NameGroupBox.TabStop = false;
            this.NameGroupBox.Text = "Variable name";
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 57);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(452, 2);
            this.darkSeparator1.TabIndex = 1;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // VariableDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.darkSeparator1);
            this.Controls.Add(this.NameGroupBox);
            this.Name = "VariableDocument";
            this.Size = new System.Drawing.Size(452, 355);
            this.NameGroupBox.ResumeLayout(false);
            this.NameGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkTextBox NameTextBox;
        private DarkUI.Controls.DarkGroupBox NameGroupBox;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
    }
}
