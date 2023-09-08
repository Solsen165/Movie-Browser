namespace BrowserUI
{
    partial class WrongShowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WrongShowForm));
            this.newTitleLabel = new System.Windows.Forms.Label();
            this.newTitleValue = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.correctInfoPanel = new System.Windows.Forms.Panel();
            this.newShowsListBox = new System.Windows.Forms.ListBox();
            this.correctDescriptionLabel = new System.Windows.Forms.Label();
            this.correctButton = new System.Windows.Forms.Button();
            this.correctTitleLabel = new System.Windows.Forms.Label();
            this.correctPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.filesListBox = new System.Windows.Forms.CheckedListBox();
            this.progressBarPanel = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.newImdbLinkLabel = new System.Windows.Forms.Label();
            this.newImdbLinkValue = new System.Windows.Forms.TextBox();
            this.orLabel = new System.Windows.Forms.Label();
            this.correctInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.correctPictureBox)).BeginInit();
            this.progressBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // newTitleLabel
            // 
            this.newTitleLabel.AutoSize = true;
            this.newTitleLabel.Location = new System.Drawing.Point(23, 37);
            this.newTitleLabel.Name = "newTitleLabel";
            this.newTitleLabel.Size = new System.Drawing.Size(93, 15);
            this.newTitleLabel.TabIndex = 0;
            this.newTitleLabel.Text = "Search By Name";
            // 
            // newTitleValue
            // 
            this.newTitleValue.Location = new System.Drawing.Point(153, 34);
            this.newTitleValue.Name = "newTitleValue";
            this.newTitleValue.Size = new System.Drawing.Size(280, 23);
            this.newTitleValue.TabIndex = 1;
            this.newTitleValue.TextChanged += new System.EventHandler(this.newTitleValue_TextChanged);
            // 
            // generateButton
            // 
            this.generateButton.AutoSize = true;
            this.generateButton.Location = new System.Drawing.Point(23, 147);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(114, 31);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Search";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // correctInfoPanel
            // 
            this.correctInfoPanel.Controls.Add(this.newShowsListBox);
            this.correctInfoPanel.Controls.Add(this.correctDescriptionLabel);
            this.correctInfoPanel.Controls.Add(this.correctButton);
            this.correctInfoPanel.Controls.Add(this.correctTitleLabel);
            this.correctInfoPanel.Controls.Add(this.correctPictureBox);
            this.correctInfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.correctInfoPanel.Location = new System.Drawing.Point(571, 0);
            this.correctInfoPanel.Name = "correctInfoPanel";
            this.correctInfoPanel.Size = new System.Drawing.Size(345, 621);
            this.correctInfoPanel.TabIndex = 3;
            // 
            // newShowsListBox
            // 
            this.newShowsListBox.FormattingEnabled = true;
            this.newShowsListBox.ItemHeight = 15;
            this.newShowsListBox.Location = new System.Drawing.Point(13, 12);
            this.newShowsListBox.Name = "newShowsListBox";
            this.newShowsListBox.Size = new System.Drawing.Size(320, 109);
            this.newShowsListBox.TabIndex = 4;
            this.newShowsListBox.SelectedIndexChanged += new System.EventHandler(this.newShowsListBox_SelectedIndexChanged);
            // 
            // correctDescriptionLabel
            // 
            this.correctDescriptionLabel.Location = new System.Drawing.Point(17, 478);
            this.correctDescriptionLabel.Name = "correctDescriptionLabel";
            this.correctDescriptionLabel.Size = new System.Drawing.Size(319, 88);
            this.correctDescriptionLabel.TabIndex = 3;
            this.correctDescriptionLabel.Text = "Description";
            // 
            // correctButton
            // 
            this.correctButton.AutoSize = true;
            this.correctButton.Location = new System.Drawing.Point(17, 591);
            this.correctButton.Name = "correctButton";
            this.correctButton.Size = new System.Drawing.Size(75, 25);
            this.correctButton.TabIndex = 2;
            this.correctButton.Text = "Correct";
            this.correctButton.UseVisualStyleBackColor = true;
            this.correctButton.Click += new System.EventHandler(this.correctButton_Click);
            // 
            // correctTitleLabel
            // 
            this.correctTitleLabel.AutoSize = true;
            this.correctTitleLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.correctTitleLabel.Location = new System.Drawing.Point(17, 446);
            this.correctTitleLabel.Name = "correctTitleLabel";
            this.correctTitleLabel.Size = new System.Drawing.Size(38, 20);
            this.correctTitleLabel.TabIndex = 1;
            this.correctTitleLabel.Text = "Title";
            // 
            // correctPictureBox
            // 
            this.correctPictureBox.Location = new System.Drawing.Point(72, 147);
            this.correctPictureBox.Name = "correctPictureBox";
            this.correctPictureBox.Size = new System.Drawing.Size(190, 281);
            this.correctPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.correctPictureBox.TabIndex = 0;
            this.correctPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Which files are not assigned correctly ?";
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(26, 254);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(74, 19);
            this.selectAllCheckBox.TabIndex = 4;
            this.selectAllCheckBox.Text = "Select All";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // filesListBox
            // 
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.HorizontalScrollbar = true;
            this.filesListBox.Location = new System.Drawing.Point(23, 278);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(511, 328);
            this.filesListBox.TabIndex = 3;
            // 
            // progressBarPanel
            // 
            this.progressBarPanel.Controls.Add(this.progressBar);
            this.progressBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarPanel.Location = new System.Drawing.Point(0, 621);
            this.progressBarPanel.Name = "progressBarPanel";
            this.progressBarPanel.Size = new System.Drawing.Size(916, 21);
            this.progressBarPanel.TabIndex = 6;
            this.progressBarPanel.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(916, 21);
            this.progressBar.TabIndex = 0;
            // 
            // newImdbLinkLabel
            // 
            this.newImdbLinkLabel.AutoSize = true;
            this.newImdbLinkLabel.Location = new System.Drawing.Point(23, 115);
            this.newImdbLinkLabel.Name = "newImdbLinkLabel";
            this.newImdbLinkLabel.Size = new System.Drawing.Size(103, 15);
            this.newImdbLinkLabel.TabIndex = 7;
            this.newImdbLinkLabel.Text = "Correct IMDB Link";
            // 
            // newImdbLinkValue
            // 
            this.newImdbLinkValue.Location = new System.Drawing.Point(153, 112);
            this.newImdbLinkValue.Name = "newImdbLinkValue";
            this.newImdbLinkValue.Size = new System.Drawing.Size(280, 23);
            this.newImdbLinkValue.TabIndex = 8;
            this.newImdbLinkValue.TextChanged += new System.EventHandler(this.newImdbValue_TextChanged);
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Location = new System.Drawing.Point(26, 76);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(36, 15);
            this.orLabel.TabIndex = 9;
            this.orLabel.Text = "- Or -";
            // 
            // WrongShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(916, 642);
            this.Controls.Add(this.orLabel);
            this.Controls.Add(this.newImdbLinkValue);
            this.Controls.Add(this.newImdbLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectAllCheckBox);
            this.Controls.Add(this.filesListBox);
            this.Controls.Add(this.correctInfoPanel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.progressBarPanel);
            this.Controls.Add(this.newTitleValue);
            this.Controls.Add(this.newTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WrongShowForm";
            this.Text = "Reidentify Movie or TvShow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditForm_FormClosed);
            this.correctInfoPanel.ResumeLayout(false);
            this.correctInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.correctPictureBox)).EndInit();
            this.progressBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label newTitleLabel;
        private TextBox newTitleValue;
        private Button generateButton;
        private Panel correctInfoPanel;
        private Button correctButton;
        private Label correctTitleLabel;
        private PictureBox correctPictureBox;
        private Label correctDescriptionLabel;
        private Label label1;
        private CheckBox selectAllCheckBox;
        private CheckedListBox filesListBox;
        private Panel progressBarPanel;
        private ProgressBar progressBar;
        private Label newImdbLinkLabel;
        private TextBox newImdbLinkValue;
        private Label orLabel;
        private ListBox newShowsListBox;
    }
}