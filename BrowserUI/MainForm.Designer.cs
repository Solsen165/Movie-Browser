namespace BrowserUI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.listViewPanel = new System.Windows.Forms.Panel();
            this.noShowsLabel = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.progressBarPanel = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolPanel = new System.Windows.Forms.Panel();
            this.movieCheckBox = new System.Windows.Forms.CheckBox();
            this.tvShowCheckBox = new System.Windows.Forms.CheckBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.ShowInfoPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.settingButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.reIdentifyButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.reservesGroupBox = new System.Windows.Forms.GroupBox();
            this.ReservesDropDown = new System.Windows.Forms.ComboBox();
            this.viewButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.listViewButton = new System.Windows.Forms.RadioButton();
            this.seasonViewButton = new System.Windows.Forms.RadioButton();
            this.IMDBLinkValue = new System.Windows.Forms.LinkLabel();
            this.PlayButton = new System.Windows.Forms.Button();
            this.IMDBLabel = new System.Windows.Forms.Label();
            this.seasonGroupBox = new System.Windows.Forms.GroupBox();
            this.seasonFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.populateSeasonsButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.ShowTypeLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.episodeTitleLabel = new System.Windows.Forms.Label();
            this.episodeDescriptionLabel = new System.Windows.Forms.Label();
            this.episodeGroupBox = new System.Windows.Forms.GroupBox();
            this.episodeFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.watchButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.watchedBelowButton = new System.Windows.Forms.Button();
            this.watchedButton = new System.Windows.Forms.Button();
            this.unWatchedButton = new System.Windows.Forms.Button();
            this.selectedShowsListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.correctShowInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIntoSeasonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.listViewPanel.SuspendLayout();
            this.progressBarPanel.SuspendLayout();
            this.toolPanel.SuspendLayout();
            this.ShowInfoPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.settingButtonLayout.SuspendLayout();
            this.reservesGroupBox.SuspendLayout();
            this.viewButtonLayout.SuspendLayout();
            this.seasonGroupBox.SuspendLayout();
            this.episodeGroupBox.SuspendLayout();
            this.watchButtonsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.showContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.White;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listViewPanel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.progressBarPanel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolPanel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ShowInfoPanel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1024, 694);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1024, 718);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // listViewPanel
            // 
            this.listViewPanel.Controls.Add(this.noShowsLabel);
            this.listViewPanel.Controls.Add(this.listView);
            this.listViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPanel.Location = new System.Drawing.Point(0, 25);
            this.listViewPanel.Name = "listViewPanel";
            this.listViewPanel.Size = new System.Drawing.Size(590, 641);
            this.listViewPanel.TabIndex = 3;
            // 
            // noShowsLabel
            // 
            this.noShowsLabel.AutoSize = true;
            this.noShowsLabel.Location = new System.Drawing.Point(12, 18);
            this.noShowsLabel.Name = "noShowsLabel";
            this.noShowsLabel.Size = new System.Drawing.Size(320, 15);
            this.noShowsLabel.TabIndex = 1;
            this.noShowsLabel.Text = "Double click here to browse to the Movies / TvShows Folder";
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(590, 641);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(173, 256);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // progressBarPanel
            // 
            this.progressBarPanel.Controls.Add(this.progressBar);
            this.progressBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarPanel.Location = new System.Drawing.Point(0, 666);
            this.progressBarPanel.Name = "progressBarPanel";
            this.progressBarPanel.Size = new System.Drawing.Size(590, 28);
            this.progressBarPanel.TabIndex = 1;
            this.progressBarPanel.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(590, 28);
            this.progressBar.TabIndex = 0;
            // 
            // toolPanel
            // 
            this.toolPanel.BackColor = System.Drawing.Color.White;
            this.toolPanel.Controls.Add(this.movieCheckBox);
            this.toolPanel.Controls.Add(this.tvShowCheckBox);
            this.toolPanel.Controls.Add(this.searchTextBox);
            this.toolPanel.Controls.Add(this.searchButton);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolPanel.Location = new System.Drawing.Point(0, 0);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(590, 25);
            this.toolPanel.TabIndex = 3;
            // 
            // movieCheckBox
            // 
            this.movieCheckBox.AutoSize = true;
            this.movieCheckBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.movieCheckBox.Location = new System.Drawing.Point(205, 0);
            this.movieCheckBox.Name = "movieCheckBox";
            this.movieCheckBox.Size = new System.Drawing.Size(64, 25);
            this.movieCheckBox.TabIndex = 4;
            this.movieCheckBox.Text = "Movies";
            this.movieCheckBox.UseVisualStyleBackColor = true;
            this.movieCheckBox.CheckedChanged += new System.EventHandler(this.movieCheckBox_CheckedChanged);
            // 
            // tvShowCheckBox
            // 
            this.tvShowCheckBox.AutoSize = true;
            this.tvShowCheckBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.tvShowCheckBox.Location = new System.Drawing.Point(269, 0);
            this.tvShowCheckBox.Name = "tvShowCheckBox";
            this.tvShowCheckBox.Size = new System.Drawing.Size(76, 25);
            this.tvShowCheckBox.TabIndex = 3;
            this.tvShowCheckBox.Text = "TV Shows";
            this.tvShowCheckBox.UseVisualStyleBackColor = true;
            this.tvShowCheckBox.CheckedChanged += new System.EventHandler(this.tvShowCheckBox_CheckedChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchTextBox.Location = new System.Drawing.Point(345, 0);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(221, 25);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Image = global::BrowserUI.Properties.Resources.Search1;
            this.searchButton.Location = new System.Drawing.Point(566, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(24, 25);
            this.searchButton.TabIndex = 2;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // ShowInfoPanel
            // 
            this.ShowInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShowInfoPanel.Controls.Add(this.tableLayoutPanel1);
            this.ShowInfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShowInfoPanel.Location = new System.Drawing.Point(590, 0);
            this.ShowInfoPanel.Name = "ShowInfoPanel";
            this.ShowInfoPanel.Size = new System.Drawing.Size(434, 694);
            this.ShowInfoPanel.TabIndex = 2;
            this.ShowInfoPanel.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.settingButtonLayout, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.reservesGroupBox, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.viewButtonLayout, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.IMDBLinkValue, 2, 18);
            this.tableLayoutPanel1.Controls.Add(this.PlayButton, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.IMDBLabel, 1, 18);
            this.tableLayoutPanel1.Controls.Add(this.seasonGroupBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.FilePathLabel, 1, 19);
            this.tableLayoutPanel1.Controls.Add(this.populateSeasonsButton, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ShowTypeLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionLabel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.episodeTitleLabel, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.episodeDescriptionLabel, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.episodeGroupBox, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.watchButtonsPanel, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.selectedShowsListBox, 1, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 21;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263108F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.21057F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(432, 692);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // settingButtonLayout
            // 
            this.settingButtonLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingButtonLayout.ColumnCount = 3;
            this.settingButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.settingButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.settingButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.settingButtonLayout.Controls.Add(this.reIdentifyButton, 1, 0);
            this.settingButtonLayout.Controls.Add(this.closeButton, 2, 0);
            this.settingButtonLayout.Controls.Add(this.editButton, 0, 0);
            this.settingButtonLayout.Location = new System.Drawing.Point(333, 13);
            this.settingButtonLayout.Name = "settingButtonLayout";
            this.settingButtonLayout.RowCount = 1;
            this.settingButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.settingButtonLayout.Size = new System.Drawing.Size(86, 29);
            this.settingButtonLayout.TabIndex = 2;
            // 
            // reIdentifyButton
            // 
            this.reIdentifyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reIdentifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reIdentifyButton.Image = global::BrowserUI.Properties.Resources.Refresh;
            this.reIdentifyButton.Location = new System.Drawing.Point(31, 3);
            this.reIdentifyButton.Name = "reIdentifyButton";
            this.reIdentifyButton.Size = new System.Drawing.Size(22, 23);
            this.reIdentifyButton.TabIndex = 14;
            this.toolTip1.SetToolTip(this.reIdentifyButton, "ReIdentify Show");
            this.reIdentifyButton.UseVisualStyleBackColor = true;
            this.reIdentifyButton.Click += new System.EventHandler(this.reIdentifyButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::BrowserUI.Properties.Resources.Cancel;
            this.closeButton.Location = new System.Drawing.Point(59, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(23, 23);
            this.closeButton.TabIndex = 13;
            this.toolTip1.SetToolTip(this.closeButton, "Close Panel");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // editButton
            // 
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Image = global::BrowserUI.Properties.Resources.Settings;
            this.editButton.Location = new System.Drawing.Point(3, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(22, 23);
            this.editButton.TabIndex = 12;
            this.toolTip1.SetToolTip(this.editButton, "Edit Show Info");
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // reservesGroupBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.reservesGroupBox, 3);
            this.reservesGroupBox.Controls.Add(this.ReservesDropDown);
            this.reservesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reservesGroupBox.Location = new System.Drawing.Point(13, 516);
            this.reservesGroupBox.Name = "reservesGroupBox";
            this.reservesGroupBox.Size = new System.Drawing.Size(406, 54);
            this.reservesGroupBox.TabIndex = 2;
            this.reservesGroupBox.TabStop = false;
            this.reservesGroupBox.Text = "Files";
            // 
            // ReservesDropDown
            // 
            this.ReservesDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReservesDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReservesDropDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReservesDropDown.FormattingEnabled = true;
            this.ReservesDropDown.Location = new System.Drawing.Point(3, 19);
            this.ReservesDropDown.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ReservesDropDown.Name = "ReservesDropDown";
            this.ReservesDropDown.Size = new System.Drawing.Size(400, 29);
            this.ReservesDropDown.TabIndex = 11;
            this.ReservesDropDown.SelectedIndexChanged += new System.EventHandler(this.ReservesDropDown_SelectedIndexChanged);
            this.ReservesDropDown.VisibleChanged += new System.EventHandler(this.ReservesDropDown_SelectedIndexChanged);
            // 
            // viewButtonLayout
            // 
            this.viewButtonLayout.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.viewButtonLayout, 2);
            this.viewButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.viewButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.viewButtonLayout.Controls.Add(this.listViewButton, 1, 0);
            this.viewButtonLayout.Controls.Add(this.seasonViewButton, 0, 0);
            this.viewButtonLayout.Location = new System.Drawing.Point(13, 94);
            this.viewButtonLayout.Name = "viewButtonLayout";
            this.viewButtonLayout.RowCount = 1;
            this.viewButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.viewButtonLayout.Size = new System.Drawing.Size(162, 32);
            this.viewButtonLayout.TabIndex = 24;
            // 
            // listViewButton
            // 
            this.listViewButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.listViewButton.AutoSize = true;
            this.listViewButton.BackColor = System.Drawing.Color.LightGray;
            this.listViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.listViewButton.Location = new System.Drawing.Point(96, 3);
            this.listViewButton.Name = "listViewButton";
            this.listViewButton.Size = new System.Drawing.Size(63, 25);
            this.listViewButton.TabIndex = 23;
            this.listViewButton.Text = "List View";
            this.listViewButton.UseVisualStyleBackColor = false;
            this.listViewButton.CheckedChanged += new System.EventHandler(this.listViewButton_CheckedChanged);
            // 
            // seasonViewButton
            // 
            this.seasonViewButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.seasonViewButton.AutoSize = true;
            this.seasonViewButton.BackColor = System.Drawing.Color.LightGray;
            this.seasonViewButton.Checked = true;
            this.seasonViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seasonViewButton.Location = new System.Drawing.Point(3, 3);
            this.seasonViewButton.Name = "seasonViewButton";
            this.seasonViewButton.Size = new System.Drawing.Size(87, 25);
            this.seasonViewButton.TabIndex = 24;
            this.seasonViewButton.TabStop = true;
            this.seasonViewButton.Text = "Seasons View";
            this.seasonViewButton.UseVisualStyleBackColor = false;
            // 
            // IMDBLinkValue
            // 
            this.IMDBLinkValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IMDBLinkValue.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.IMDBLinkValue, 2);
            this.IMDBLinkValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IMDBLinkValue.Location = new System.Drawing.Point(116, 672);
            this.IMDBLinkValue.Name = "IMDBLinkValue";
            this.IMDBLinkValue.Size = new System.Drawing.Size(61, 17);
            this.IMDBLinkValue.TabIndex = 9;
            this.IMDBLinkValue.TabStop = true;
            this.IMDBLinkValue.Text = "IMDBLink";
            this.IMDBLinkValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IMDBLinkValue_LinkClicked);
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.AutoSize = true;
            this.PlayButton.BackColor = System.Drawing.SystemColors.Control;
            this.PlayButton.Enabled = false;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PlayButton.Location = new System.Drawing.Point(123, 634);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(10);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(186, 31);
            this.PlayButton.TabIndex = 13;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // IMDBLabel
            // 
            this.IMDBLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IMDBLabel.AutoSize = true;
            this.IMDBLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IMDBLabel.Location = new System.Drawing.Point(13, 672);
            this.IMDBLabel.Name = "IMDBLabel";
            this.IMDBLabel.Size = new System.Drawing.Size(69, 17);
            this.IMDBLabel.TabIndex = 8;
            this.IMDBLabel.Text = "More Info:";
            // 
            // seasonGroupBox
            // 
            this.seasonGroupBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.seasonGroupBox, 3);
            this.seasonGroupBox.Controls.Add(this.seasonFlowPanel);
            this.seasonGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seasonGroupBox.Location = new System.Drawing.Point(13, 132);
            this.seasonGroupBox.MinimumSize = new System.Drawing.Size(0, 86);
            this.seasonGroupBox.Name = "seasonGroupBox";
            this.seasonGroupBox.Size = new System.Drawing.Size(406, 86);
            this.seasonGroupBox.TabIndex = 17;
            this.seasonGroupBox.TabStop = false;
            this.seasonGroupBox.Text = "Seasons";
            // 
            // seasonFlowPanel
            // 
            this.seasonFlowPanel.AutoScroll = true;
            this.seasonFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seasonFlowPanel.Location = new System.Drawing.Point(3, 19);
            this.seasonFlowPanel.Name = "seasonFlowPanel";
            this.seasonFlowPanel.Size = new System.Drawing.Size(400, 64);
            this.seasonFlowPanel.TabIndex = 15;
            this.seasonFlowPanel.WrapContents = false;
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FilePathLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.FilePathLabel, 3);
            this.FilePathLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilePathLabel.Location = new System.Drawing.Point(13, 694);
            this.FilePathLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(52, 17);
            this.FilePathLabel.TabIndex = 2;
            this.FilePathLabel.Text = "FilePath";
            this.FilePathLabel.TextChanged += new System.EventHandler(this.FilePathLabel_TextChanged);
            // 
            // populateSeasonsButton
            // 
            this.populateSeasonsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.populateSeasonsButton.AutoSize = true;
            this.populateSeasonsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.populateSeasonsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.populateSeasonsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.populateSeasonsButton.Location = new System.Drawing.Point(116, 259);
            this.populateSeasonsButton.Name = "populateSeasonsButton";
            this.populateSeasonsButton.Size = new System.Drawing.Size(200, 38);
            this.populateSeasonsButton.TabIndex = 14;
            this.populateSeasonsButton.Text = "Arrange Into Seasons";
            this.populateSeasonsButton.UseVisualStyleBackColor = false;
            this.populateSeasonsButton.Visible = false;
            this.populateSeasonsButton.Click += new System.EventHandler(this.populateSeasonsButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.titleLabel, 2);
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(13, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(61, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // ShowTypeLabel
            // 
            this.ShowTypeLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ShowTypeLabel, 3);
            this.ShowTypeLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowTypeLabel.Location = new System.Drawing.Point(13, 45);
            this.ShowTypeLabel.Name = "ShowTypeLabel";
            this.ShowTypeLabel.Size = new System.Drawing.Size(51, 25);
            this.ShowTypeLabel.TabIndex = 3;
            this.ShowTypeLabel.Text = "Type";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.DescriptionLabel, 3);
            this.DescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DescriptionLabel.Location = new System.Drawing.Point(13, 70);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(89, 21);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Description";
            // 
            // episodeTitleLabel
            // 
            this.episodeTitleLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.episodeTitleLabel, 3);
            this.episodeTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.episodeTitleLabel.Location = new System.Drawing.Point(13, 573);
            this.episodeTitleLabel.Name = "episodeTitleLabel";
            this.episodeTitleLabel.Size = new System.Drawing.Size(129, 30);
            this.episodeTitleLabel.TabIndex = 1;
            this.episodeTitleLabel.Text = "EpisodeTitle";
            this.episodeTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // episodeDescriptionLabel
            // 
            this.episodeDescriptionLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.episodeDescriptionLabel, 3);
            this.episodeDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.episodeDescriptionLabel.Location = new System.Drawing.Point(13, 603);
            this.episodeDescriptionLabel.Name = "episodeDescriptionLabel";
            this.episodeDescriptionLabel.Size = new System.Drawing.Size(143, 21);
            this.episodeDescriptionLabel.TabIndex = 19;
            this.episodeDescriptionLabel.Text = "EpisodeDescription";
            // 
            // episodeGroupBox
            // 
            this.episodeGroupBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.episodeGroupBox, 3);
            this.episodeGroupBox.Controls.Add(this.episodeFlowPanel);
            this.episodeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.episodeGroupBox.Location = new System.Drawing.Point(13, 303);
            this.episodeGroupBox.MaximumSize = new System.Drawing.Size(0, 200);
            this.episodeGroupBox.MinimumSize = new System.Drawing.Size(0, 64);
            this.episodeGroupBox.Name = "episodeGroupBox";
            this.episodeGroupBox.Size = new System.Drawing.Size(406, 172);
            this.episodeGroupBox.TabIndex = 18;
            this.episodeGroupBox.TabStop = false;
            this.episodeGroupBox.Text = "Episodes";
            // 
            // episodeFlowPanel
            // 
            this.episodeFlowPanel.AutoScroll = true;
            this.episodeFlowPanel.AutoSize = true;
            this.episodeFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.episodeFlowPanel.Location = new System.Drawing.Point(3, 19);
            this.episodeFlowPanel.MaximumSize = new System.Drawing.Size(0, 200);
            this.episodeFlowPanel.MinimumSize = new System.Drawing.Size(0, 150);
            this.episodeFlowPanel.Name = "episodeFlowPanel";
            this.episodeFlowPanel.Size = new System.Drawing.Size(400, 150);
            this.episodeFlowPanel.TabIndex = 16;
            // 
            // watchButtonsPanel
            // 
            this.watchButtonsPanel.AutoSize = true;
            this.watchButtonsPanel.ColumnCount = 3;
            this.watchButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.watchButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.watchButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.watchButtonsPanel.Controls.Add(this.watchedBelowButton, 2, 0);
            this.watchButtonsPanel.Controls.Add(this.watchedButton, 1, 0);
            this.watchButtonsPanel.Controls.Add(this.unWatchedButton, 0, 0);
            this.watchButtonsPanel.Location = new System.Drawing.Point(322, 481);
            this.watchButtonsPanel.Name = "watchButtonsPanel";
            this.watchButtonsPanel.RowCount = 1;
            this.watchButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.watchButtonsPanel.Size = new System.Drawing.Size(87, 29);
            this.watchButtonsPanel.TabIndex = 21;
            // 
            // watchedBelowButton
            // 
            this.watchedBelowButton.FlatAppearance.BorderSize = 0;
            this.watchedBelowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.watchedBelowButton.Image = global::BrowserUI.Properties.Resources.watchedAllBelow;
            this.watchedBelowButton.Location = new System.Drawing.Point(61, 3);
            this.watchedBelowButton.Name = "watchedBelowButton";
            this.watchedBelowButton.Size = new System.Drawing.Size(23, 23);
            this.watchedBelowButton.TabIndex = 22;
            this.toolTip1.SetToolTip(this.watchedBelowButton, "Mark all below as watched");
            this.watchedBelowButton.UseVisualStyleBackColor = true;
            this.watchedBelowButton.Click += new System.EventHandler(this.watchedBelowButton_Click);
            // 
            // watchedButton
            // 
            this.watchedButton.FlatAppearance.BorderSize = 0;
            this.watchedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.watchedButton.Image = global::BrowserUI.Properties.Resources.watched;
            this.watchedButton.Location = new System.Drawing.Point(32, 3);
            this.watchedButton.Name = "watchedButton";
            this.watchedButton.Size = new System.Drawing.Size(23, 23);
            this.watchedButton.TabIndex = 21;
            this.toolTip1.SetToolTip(this.watchedButton, "Mark as watched");
            this.watchedButton.UseVisualStyleBackColor = true;
            this.watchedButton.Click += new System.EventHandler(this.watchedButton_Click);
            // 
            // unWatchedButton
            // 
            this.unWatchedButton.FlatAppearance.BorderSize = 0;
            this.unWatchedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unWatchedButton.Image = global::BrowserUI.Properties.Resources.unWatched;
            this.unWatchedButton.Location = new System.Drawing.Point(3, 3);
            this.unWatchedButton.Name = "unWatchedButton";
            this.unWatchedButton.Size = new System.Drawing.Size(23, 23);
            this.unWatchedButton.TabIndex = 20;
            this.toolTip1.SetToolTip(this.unWatchedButton, "Mark as unwatched");
            this.unWatchedButton.UseVisualStyleBackColor = true;
            this.unWatchedButton.Click += new System.EventHandler(this.unWatchedButton_Click);
            // 
            // selectedShowsListBox
            // 
            this.selectedShowsListBox.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.selectedShowsListBox, 3);
            this.selectedShowsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedShowsListBox.FormattingEnabled = true;
            this.selectedShowsListBox.ItemHeight = 15;
            this.selectedShowsListBox.Location = new System.Drawing.Point(13, 224);
            this.selectedShowsListBox.Name = "selectedShowsListBox";
            this.selectedShowsListBox.Size = new System.Drawing.Size(406, 29);
            this.selectedShowsListBox.TabIndex = 22;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.fileToolStripMenuItem.Text = "Movie Directories";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAllDataToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // deleteAllDataToolStripMenuItem
            // 
            this.deleteAllDataToolStripMenuItem.Name = "deleteAllDataToolStripMenuItem";
            this.deleteAllDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteAllDataToolStripMenuItem.Text = "Reset database";
            this.deleteAllDataToolStripMenuItem.Click += new System.EventHandler(this.resetDatabseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // showContextMenu
            // 
            this.showContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.correctShowInfoToolStripMenuItem,
            this.arrangeIntoSeasonsToolStripMenuItem});
            this.showContextMenu.Name = "showContextMenu";
            this.showContextMenu.Size = new System.Drawing.Size(186, 48);
            this.showContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.showContextMenu_Opening);
            // 
            // correctShowInfoToolStripMenuItem
            // 
            this.correctShowInfoToolStripMenuItem.Name = "correctShowInfoToolStripMenuItem";
            this.correctShowInfoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.correctShowInfoToolStripMenuItem.Text = "ReIdentify Show";
            this.correctShowInfoToolStripMenuItem.Click += new System.EventHandler(this.correctShowInfoToolStripMenuItem_Click);
            // 
            // arrangeIntoSeasonsToolStripMenuItem
            // 
            this.arrangeIntoSeasonsToolStripMenuItem.Name = "arrangeIntoSeasonsToolStripMenuItem";
            this.arrangeIntoSeasonsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.arrangeIntoSeasonsToolStripMenuItem.Text = "Arrange Into Seasons";
            this.arrangeIntoSeasonsToolStripMenuItem.Click += new System.EventHandler(this.arrangeIntoSeasonsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 718);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Movie Browser";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.listViewPanel.ResumeLayout(false);
            this.listViewPanel.PerformLayout();
            this.progressBarPanel.ResumeLayout(false);
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            this.ShowInfoPanel.ResumeLayout(false);
            this.ShowInfoPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.settingButtonLayout.ResumeLayout(false);
            this.reservesGroupBox.ResumeLayout(false);
            this.viewButtonLayout.ResumeLayout(false);
            this.viewButtonLayout.PerformLayout();
            this.seasonGroupBox.ResumeLayout(false);
            this.episodeGroupBox.ResumeLayout(false);
            this.episodeGroupBox.PerformLayout();
            this.watchButtonsPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.showContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Panel ShowInfoPanel;
        private Label FilePathLabel;
        private Label DescriptionLabel;
        private Label titleLabel;
        private Label ShowTypeLabel;
        private LinkLabel IMDBLinkValue;
        private Label IMDBLabel;
        private ComboBox ReservesDropDown;
        private Button editButton;
        private Button PlayButton;
        private Button populateSeasonsButton;
        private Panel listViewPanel;
        private FlowLayoutPanel seasonFlowPanel;
        private FlowLayoutPanel episodeFlowPanel;
        private GroupBox episodeGroupBox;
        private GroupBox seasonGroupBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label episodeTitleLabel;
        private Label episodeDescriptionLabel;
        private ListView listView;
        private ImageList imageList;
        private TextBox searchTextBox;
        private Panel toolPanel;
        private Button searchButton;
        private Panel progressBarPanel;
        private ProgressBar progressBar;
        private ContextMenuStrip showContextMenu;
        private ToolStripMenuItem correctShowInfoToolStripMenuItem;
        private ToolStripMenuItem arrangeIntoSeasonsToolStripMenuItem;
        private Label noShowsLabel;
        private TableLayoutPanel watchButtonsPanel;
        private Button watchedBelowButton;
        private Button watchedButton;
        private Button unWatchedButton;
        private ListBox selectedShowsListBox;
        private CheckBox movieCheckBox;
        private CheckBox tvShowCheckBox;
        private ToolStripMenuItem databaseToolStripMenuItem;
        private ToolStripMenuItem deleteAllDataToolStripMenuItem;
        private TableLayoutPanel viewButtonLayout;
        private RadioButton listViewButton;
        private RadioButton seasonViewButton;
        private GroupBox reservesGroupBox;
        private TableLayoutPanel settingButtonLayout;
        private Button closeButton;
        private Button reIdentifyButton;
        private ToolTip toolTip1;
        private ToolStripMenuItem helpToolStripMenuItem;
    }
}