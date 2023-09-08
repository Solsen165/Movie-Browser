using BrowserLibrary;
using BrowserLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserUI
{
    public partial class WrongShowForm : Form
    {
        List<ShowModel> newShows = new List<ShowModel>();
        ShowModel newShow = new ShowModel();
        List<EpisodeModel> files = new List<EpisodeModel>();
        List<EpisodeModel> selectedFiles = new List<EpisodeModel>();
        IEditRequester caller;
        bool refreshNeeded;
        public WrongShowForm(ShowModel show, IEditRequester caller)
        {
            InitializeComponent();
            //oldShow = show;
            this.caller = caller;
            FillUpList(new List<ShowModel>(){ show });
            InitializeControls();
            refreshNeeded = false;
        }

        public WrongShowForm(List<ShowModel> shows, IEditRequester caller)
        {
            InitializeComponent();
            this.caller = caller;
            FillUpList(shows);
            InitializeControls();
        }
        private void FillUpList(List<ShowModel> shows)
        {
            foreach(ShowModel oldShow in shows)
            {
                foreach (List<EpisodeModel> season in oldShow.Seasons)
                {
                    foreach (EpisodeModel episode in season)
                    {
                        if (!String.IsNullOrEmpty(episode.FilePath))
                        {
                            files.Add(episode);
                        }
                    }
                }
                foreach (EpisodeModel episode in oldShow.Reserves)
                {
                    if (!String.IsNullOrEmpty(episode.FilePath))
                    {
                        files.Add(episode);
                    }
                }
            }
        }

        private void InitializeControls()
        {
            newTitleValue.Text = "";
            newImdbLinkValue.Text = "";
            correctPictureBox.Image = null;
            correctTitleLabel.Text = "";
            correctDescriptionLabel.Text = "";

            filesListBox.SelectionMode = SelectionMode.None;
            filesListBox.DataSource = null;
            filesListBox.DataSource = files;
            filesListBox.DisplayMember = "FilePath";
            filesListBox.SelectionMode = SelectionMode.One;

            selectAllCheckBox.Checked = true;
            filesListBox.CheckOnClick = true;
            //selectAllCheckBox.Enabled = false;
            //filesListBox.Enabled = false;
            label1.Visible = false;
            correctTitleLabel.Text = "";
            correctDescriptionLabel.Text = "";
            correctButton.Enabled = false;
            newShowsListBox.Visible = false;

            //correctPictureBox.Image = ShowLoader.LoadPoster(oldShow);
            //correctTitleLabel.Text = oldShow.Title;
            //correctDescriptionLabel.Text = oldShow.Description;

        }

        private async void generateButton_Click(object sender, EventArgs e)
        {
            string newTitle = newTitleValue.Text;
            string newLink = trimLink(newImdbLinkValue.Text);
            if (newImdbLinkValue.Text.Length > 0 && newLink == "")
            {
                MessageBox.Show("Please input a valid IMDB link");
                return;
            }
            if (newTitle.Length == 0 && newLink.Length == 0)
            {
                return;
            }

            label1.Visible = false;
            correctTitleLabel.Text = "";
            correctDescriptionLabel.Text = "";
            correctButton.Enabled = false;
            generateButton.Enabled = false;
            newShowsListBox.Visible = false;
            correctPictureBox.Image = null;

            newShows = new List<ShowModel>();

            List<string> newLinks = new List<string>();

            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            ProgressReportModel progressReportModel = new ProgressReportModel();

            if (newTitle.Length > 0)
            {
                newLinks = await ShowLoader.LookUpTopFiveShows(newTitle);
            }
            else
            {
                newLinks.Add(newLink);
            }


            List<Task<ShowModel>> tasks = new List<Task<ShowModel>>();
            foreach(string link in newLinks)
            {
                tasks.Add(ShowLoader.CreateShow("", progress, progressReportModel, link));
            }
            var temps = await Task.WhenAll(tasks);
            newShows = temps.Where(x => x.Title.Length > 0).ToList();

            ShowModel? existingShow = GlobalConfig.allShows.Where(x => x.OtherTitles.Contains(newTitle)).FirstOrDefault();

            if (existingShow != null && newShows.Where(x => x.IMDBId == existingShow.IMDBId).FirstOrDefault() == null)
            {
                newShows.Add(existingShow);
            }

            //ShowModel emptyShell = new ShowModel() { Title = newTitle, Type = "Movie", IMDBId = null };
            //emptyShell.OtherTitles.Add(newTitle);
            //newShows.Add(emptyShell);
            
            newShowsListBox.DataSource = null;
            newShowsListBox.DataSource = newShows;
            newShowsListBox.DisplayMember = "Title";
            newShowsListBox.Visible = true;

            generateButton.Enabled = true;

        }

        private string trimLink(string link)
        {
            string output = "";
            if (link.StartsWith("https://www.imdb.com/title/"))
            {
                output = link.Substring(20);
            }
            else if (link.StartsWith("www.imdb.com/title/"))
            {
                output = link.Substring(12);
            }
            else if (link.StartsWith("imdb.com/title/"))
            {
                output = link.Substring(8);
            }
            return output;

        }

        private void correctButton_Click(object sender, EventArgs e)
        {
            refreshNeeded = true;
            selectedFiles = new List<EpisodeModel>();
            foreach (var file in filesListBox.CheckedItems)
            {
                selectedFiles.Add((EpisodeModel)file);
            }
            FinishUp();

        }

        public async Task FinishUp()
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;
            progressBarPanel.Visible = true;
            await ShowLoader.CorrectShow(newShow, selectedFiles, progress);
            progressBarPanel.Visible = false;

            if (selectedFiles.Count == filesListBox.Items.Count)
            {
                this.Close();
            }
            else
            {
                foreach(var file in filesListBox.CheckedItems)
                {
                    files.Remove((EpisodeModel)file);
                }
                //InitializeControls();
                filesListBox.SelectionMode = SelectionMode.None;
                filesListBox.DataSource = null;
                filesListBox.DataSource = files;
                filesListBox.DisplayMember = "FilePath";
                filesListBox.SelectionMode = SelectionMode.One;
            }
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Checked == true)
            {
                for (int i = 0; i < filesListBox.Items.Count; i++)
                {
                    filesListBox.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < filesListBox.Items.Count; i++)
                {
                    filesListBox.SetItemChecked(i, false);
                }
            }
        }

        private void Progress_ProgressChanged(object? sender, ProgressReportModel e)
        {
            progressBar.Value = e.percentage;
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (refreshNeeded)
            {
                caller.EditFinish();
            }
        }

        private void newTitleValue_TextChanged(object sender, EventArgs e)
        {
            if (newTitleValue.Text.Length > 0)
            {
                newImdbLinkValue.Text = "";
            }
        }

        private void newImdbValue_TextChanged(object sender, EventArgs e)
        {
            if (newImdbLinkValue.Text.Length > 0)
            {
                newTitleValue.Text = "";
            }
        }

        private void newShowsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowModel newShow = (ShowModel)newShowsListBox.SelectedItem;
            if (newShow == null)
            {
                return;
            }
            this.newShow = newShow;
            if (newShow.IMDBId == null)
            {
                correctPictureBox.Image = null;
                correctTitleLabel.Text = "Not Found";
                correctDescriptionLabel.Text = "";

                label1.Text = "";
                selectAllCheckBox.Enabled = false;
                filesListBox.Enabled = false;
                label1.Visible = false;
                correctButton.Enabled = false;
                generateButton.Enabled = true;
            }
            else
            {
                correctPictureBox.Image = ShowLoader.LoadPoster(newShow);
                if (correctPictureBox.Image == null)
                {
                    correctPictureBox.Image = Properties.Resources._default;
                }
                correctTitleLabel.Text = newShow.Title;
                correctDescriptionLabel.Text = newShow.Description;

                label1.Text = $"Which files belong to {newShow.Title} ?";
                selectAllCheckBox.Enabled = true;
                filesListBox.Enabled = true;
                label1.Visible = true;
                correctButton.Enabled = true;
                generateButton.Enabled = true;
            }

        }
    }
}
