namespace WolfyEngine.Forms
{
    partial class BaseVariableDocument
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
            this.GroupBox = new DarkUI.Controls.DarkGroupBox();
            this.UnavailableButton = new DarkUI.Controls.DarkButton();
            this.ValueButton = new DarkUI.Controls.DarkButton();
            this.BooleanButton = new DarkUI.Controls.DarkButton();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.GroupBox.Controls.Add(this.UnavailableButton);
            this.GroupBox.Controls.Add(this.ValueButton);
            this.GroupBox.Controls.Add(this.BooleanButton);
            this.GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox.Location = new System.Drawing.Point(0, 57);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(463, 418);
            this.GroupBox.TabIndex = 2;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Select variable type";
            // 
            // UnavailableButton
            // 
            this.UnavailableButton.Image = global::WolfyEngine.Icons.help_circle;
            this.UnavailableButton.ImagePadding = 7;
            this.UnavailableButton.Location = new System.Drawing.Point(315, 30);
            this.UnavailableButton.Name = "UnavailableButton";
            this.UnavailableButton.Padding = new System.Windows.Forms.Padding(5);
            this.UnavailableButton.Size = new System.Drawing.Size(128, 128);
            this.UnavailableButton.TabIndex = 10;
            this.UnavailableButton.Text = "Unavailable";
            this.UnavailableButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ValueButton
            // 
            this.ValueButton.Image = global::WolfyEngine.Icons.help_circle;
            this.ValueButton.ImagePadding = 7;
            this.ValueButton.Location = new System.Drawing.Point(165, 30);
            this.ValueButton.Name = "ValueButton";
            this.ValueButton.Padding = new System.Windows.Forms.Padding(5);
            this.ValueButton.Size = new System.Drawing.Size(128, 128);
            this.ValueButton.TabIndex = 9;
            this.ValueButton.Text = "Value";
            this.ValueButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BooleanButton
            // 
            this.BooleanButton.Image = global::WolfyEngine.Icons.toggle_left1;
            this.BooleanButton.ImagePadding = 7;
            this.BooleanButton.Location = new System.Drawing.Point(15, 30);
            this.BooleanButton.Name = "BooleanButton";
            this.BooleanButton.Padding = new System.Windows.Forms.Padding(5);
            this.BooleanButton.Size = new System.Drawing.Size(128, 128);
            this.BooleanButton.TabIndex = 8;
            this.BooleanButton.Text = "Boolean";
            this.BooleanButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BooleanButton.Click += new System.EventHandler(this.BooleanButton_Click);
            this.BooleanButton.MouseEnter += new System.EventHandler(this.HighlightImage);
            this.BooleanButton.MouseLeave += new System.EventHandler(this.RestoreImage);
            // 
            // BaseVariableDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBox);
            this.DockText = "Variable name";
            this.Name = "BaseVariableDocument";
            this.Size = new System.Drawing.Size(463, 475);
            this.Controls.SetChildIndex(this.GroupBox, 0);
            this.GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkGroupBox GroupBox;
        private DarkUI.Controls.DarkButton BooleanButton;
        private DarkUI.Controls.DarkButton ValueButton;
        private DarkUI.Controls.DarkButton UnavailableButton;
    }
}
