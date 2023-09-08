namespace BrowserUI
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.titleValue = new System.Windows.Forms.TextBox();
            this.descriptionValue = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.correctButton = new System.Windows.Forms.Button();
            this.changePhotoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(84, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(190, 281);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // titleValue
            // 
            this.titleValue.Location = new System.Drawing.Point(84, 307);
            this.titleValue.Margin = new System.Windows.Forms.Padding(2);
            this.titleValue.Name = "titleValue";
            this.titleValue.Size = new System.Drawing.Size(255, 23);
            this.titleValue.TabIndex = 1;
            // 
            // descriptionValue
            // 
            this.descriptionValue.Location = new System.Drawing.Point(84, 345);
            this.descriptionValue.Margin = new System.Windows.Forms.Padding(2);
            this.descriptionValue.Multiline = true;
            this.descriptionValue.Name = "descriptionValue";
            this.descriptionValue.Size = new System.Drawing.Size(363, 159);
            this.descriptionValue.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(32, 310);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(29, 15);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Title";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 348);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(67, 15);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Description";
            // 
            // confirmButton
            // 
            this.confirmButton.AutoSize = true;
            this.confirmButton.Location = new System.Drawing.Point(473, 480);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 25);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // correctButton
            // 
            this.correctButton.AutoSize = true;
            this.correctButton.Location = new System.Drawing.Point(432, 12);
            this.correctButton.Name = "correctButton";
            this.correctButton.Size = new System.Drawing.Size(122, 34);
            this.correctButton.TabIndex = 6;
            this.correctButton.Text = "ReIdentify the Show";
            this.correctButton.UseVisualStyleBackColor = true;
            this.correctButton.Click += new System.EventHandler(this.correctButton_Click);
            // 
            // changePhotoButton
            // 
            this.changePhotoButton.FlatAppearance.BorderSize = 0;
            this.changePhotoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePhotoButton.Image = global::BrowserUI.Properties.Resources.ImageButton;
            this.changePhotoButton.Location = new System.Drawing.Point(54, 12);
            this.changePhotoButton.Name = "changePhotoButton";
            this.changePhotoButton.Size = new System.Drawing.Size(24, 23);
            this.changePhotoButton.TabIndex = 7;
            this.changePhotoButton.UseVisualStyleBackColor = true;
            this.changePhotoButton.Click += new System.EventHandler(this.changePhotoButton_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(573, 515);
            this.Controls.Add(this.changePhotoButton);
            this.Controls.Add(this.correctButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.descriptionValue);
            this.Controls.Add(this.titleValue);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditForm";
            this.Text = "Edit Show Info";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private TextBox titleValue;
        private TextBox descriptionValue;
        private Label titleLabel;
        private Label descriptionLabel;
        private Button confirmButton;
        private Button correctButton;
        private Button changePhotoButton;
    }
}