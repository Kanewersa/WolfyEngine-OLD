namespace WolfyEngine.Forms
{
    partial class SelectEntityTypeForm
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
            this.CustomButton = new DarkUI.Controls.DarkButton();
            this.StaticButton = new DarkUI.Controls.DarkButton();
            this.NPCButton = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // CustomButton
            // 
            this.CustomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.CustomButton.Image = global::WolfyEngine.Icons.github32x32;
            this.CustomButton.ImagePadding = 50;
            this.CustomButton.Location = new System.Drawing.Point(364, 14);
            this.CustomButton.Name = "CustomButton";
            this.CustomButton.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.CustomButton.Size = new System.Drawing.Size(166, 267);
            this.CustomButton.TabIndex = 2;
            this.CustomButton.Text = "Custom";
            this.CustomButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CustomButton.Click += new System.EventHandler(this.CustomButton_Click);
            // 
            // StaticButton
            // 
            this.StaticButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.StaticButton.Image = global::WolfyEngine.Icons.square32x32;
            this.StaticButton.ImagePadding = 50;
            this.StaticButton.Location = new System.Drawing.Point(189, 14);
            this.StaticButton.Name = "StaticButton";
            this.StaticButton.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.StaticButton.Size = new System.Drawing.Size(166, 267);
            this.StaticButton.TabIndex = 1;
            this.StaticButton.Text = "Static";
            this.StaticButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StaticButton.Click += new System.EventHandler(this.StaticButton_Click);
            // 
            // NPCButton
            // 
            this.NPCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.NPCButton.Image = global::WolfyEngine.Icons.user32x32;
            this.NPCButton.ImagePadding = 50;
            this.NPCButton.Location = new System.Drawing.Point(14, 14);
            this.NPCButton.Name = "NPCButton";
            this.NPCButton.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.NPCButton.Size = new System.Drawing.Size(166, 267);
            this.NPCButton.TabIndex = 0;
            this.NPCButton.Text = "NPC";
            this.NPCButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NPCButton.Click += new System.EventHandler(this.NPCButton_Click);
            // 
            // SelectEntityTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 294);
            this.Controls.Add(this.CustomButton);
            this.Controls.Add(this.StaticButton);
            this.Controls.Add(this.NPCButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SelectEntityTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select entity type";
            this.ResumeLayout(false);
        }

        #endregion

        private DarkUI.Controls.DarkButton NPCButton;
        private DarkUI.Controls.DarkButton StaticButton;
        private DarkUI.Controls.DarkButton CustomButton;
    }
}