namespace ImgToTextClientApp
{
    partial class FormImageInput
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
            this.btnSelectImg = new System.Windows.Forms.Button();
            this.btnGetText = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectImg
            // 
            this.btnSelectImg.Location = new System.Drawing.Point(239, 109);
            this.btnSelectImg.Name = "btnSelectImg";
            this.btnSelectImg.Size = new System.Drawing.Size(131, 38);
            this.btnSelectImg.TabIndex = 1;
            this.btnSelectImg.Text = "Select Image";
            this.btnSelectImg.UseVisualStyleBackColor = true;
            this.btnSelectImg.Click += new System.EventHandler(this.btnSelectImg_Click);
            // 
            // btnGetText
            // 
            this.btnGetText.Enabled = false;
            this.btnGetText.Location = new System.Drawing.Point(397, 109);
            this.btnGetText.Name = "btnGetText";
            this.btnGetText.Size = new System.Drawing.Size(131, 38);
            this.btnGetText.TabIndex = 2;
            this.btnGetText.Text = "Get text";
            this.btnGetText.UseVisualStyleBackColor = true;
            this.btnGetText.Click += new System.EventHandler(this.btnGetText_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(60, 175);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(685, 317);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // FormImageInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.btnGetText);
            this.Controls.Add(this.btnSelectImg);
            this.Controls.Add(this.pictureBox);
            this.Name = "FormImageInput";
            this.Sizable = false;
            this.Text = "Image To Text App";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnSelectImg;
        private System.Windows.Forms.Button btnGetText;
    }
}

