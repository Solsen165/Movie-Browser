namespace BrowserUI
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.showProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showProgressBar
            // 
            this.showProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.showProgressBar.Location = new System.Drawing.Point(12, 272);
            this.showProgressBar.Name = "showProgressBar";
            this.showProgressBar.Size = new System.Drawing.Size(453, 25);
            this.showProgressBar.TabIndex = 0;
            // 
            // progressListBox
            // 
            this.progressListBox.FormattingEnabled = true;
            this.progressListBox.ItemHeight = 15;
            this.progressListBox.Location = new System.Drawing.Point(12, 30);
            this.progressListBox.Name = "progressListBox";
            this.progressListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.progressListBox.Size = new System.Drawing.Size(453, 229);
            this.progressListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "This may take some time...";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 308);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressListBox);
            this.Controls.Add(this.showProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoadingForm";
            this.Text = "Loading Shows";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ProgressBar showProgressBar;
        private ListBox progressListBox;
        private Label label1;
    }
}