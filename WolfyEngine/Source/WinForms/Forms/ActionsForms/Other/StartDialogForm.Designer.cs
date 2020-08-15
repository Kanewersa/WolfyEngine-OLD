namespace WolfyEngine.Forms
{
    partial class StartDialogForm
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
            this.DialogPanel = new System.Windows.Forms.Panel();
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.TextTitle = new DarkUI.Controls.DarkTitle();
            this.DialogPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DialogPanel
            // 
            this.DialogPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.DialogPanel.Controls.Add(this.TextBox);
            this.DialogPanel.Location = new System.Drawing.Point(10, 28);
            this.DialogPanel.Margin = new System.Windows.Forms.Padding(1);
            this.DialogPanel.Name = "DialogPanel";
            this.DialogPanel.Size = new System.Drawing.Size(336, 144);
            this.DialogPanel.TabIndex = 3;
            // 
            // TextBox
            // 
            this.TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.TextBox.Location = new System.Drawing.Point(2, 2);
            this.TextBox.MaxLength = 300;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(332, 140);
            this.TextBox.TabIndex = 2;
            this.TextBox.Text = "";
            // 
            // TextTitle
            // 
            this.TextTitle.AutoSize = true;
            this.TextTitle.Location = new System.Drawing.Point(9, 9);
            this.TextTitle.Name = "TextTitle";
            this.TextTitle.Size = new System.Drawing.Size(79, 13);
            this.TextTitle.TabIndex = 7;
            this.TextTitle.Text = "Dialog content:";
            // 
            // StartDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 213);
            this.Controls.Add(this.TextTitle);
            this.Controls.Add(this.DialogPanel);
            this.Name = "StartDialogForm";
            this.Text = "Create dialog";
            this.Controls.SetChildIndex(this.DialogPanel, 0);
            this.Controls.SetChildIndex(this.TextTitle, 0);
            this.DialogPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DialogPanel;
        private System.Windows.Forms.RichTextBox TextBox;
        private DarkUI.Controls.DarkTitle TextTitle;
    }
}