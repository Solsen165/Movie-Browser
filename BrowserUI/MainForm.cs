using BrowserLibrary;
using BrowserLibrary.DataAccess;
using BrowserLibrary.Models;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserUI
{
    public partial class MainForm : Form, IEditRequester
    {
        List<string> folderPaths = SqlConnector.LoadFolderPaths();
        List<ShowModel> availableShows;
        List<ShowModel> filteredShows;
        List<ShowModel> selectedShows = new List<ShowModel>();
        List<CheckBox> selectedSeasonsBoxes = new List<CheckBox>();
        List<CheckBox> selectedEpisodesBoxes = new List<CheckBox>();

        ShowModel selectedShow;
        EpisodeModel selectedEpisode;
        public MainForm()
        {
            InitializeComponent();
            HttpClientHandler hch = new HttpClientHandler();
            hch.Proxy = null;
            hch.UseProxy = false;
            GlobalConfig.httpClient = new HttpClient(hch);
            GlobalConfig.allShows = SqlConnector.LoadShows();
            LoadShows();
        }

        public void WireUpList()
        {
            if (movieCheckBox.Checked != tvShowCheckBox.Checked || searchTextBox.Text.Length > 0)
            {
                filterShows();
            }
            else
            {
                filteredShows = availableShows;
            }

            listView.Items.Clear();
            imageList.Images.Clear();
            filteredShows.Sort((p,q)=> p.Title.CompareTo(q.Title));
            foreach(ShowModel show in filteredShows)
            {
                Image img = null;
                img = ShowLoader.LoadPoster(show);
                if (img == null)
                {
                    img = Properties.Resources._default;
                }
                imageList.Images.Add(img);
                
                listView.Items.Add(show.Title, imageList.Images.Count - 1);
            }
            if (listView.Items.Count == 0 && searchTextBox.Text.Length == 0)
            {
                noShowsLabel.Visible = true;
                noShowsLabel.DoubleClick += noShowsLabel_DoubleClick;
            }
            else
            {
                noShowsLabel.Visible = false;
                noShowsLabel.DoubleClick -= noShowsLabel_DoubleClick;
            }

            GlobalConfig.allShows = SqlConnector.LoadShows();
        }
        public void WireUpInfoPanel()
        {
            this.AcceptButton = null;
            ShowInfoPanel.Visible = true;

            if (selectedShows.Count != 1)
            {
                titleLabel.Text = "";
                ShowTypeLabel.Text = "";
                DescriptionLabel.Text = "";
                episodeTitleLabel.Text = "";
                episodeDescriptionLabel.Text = "";
                watchButtonsPanel.Visible = false;
                viewButtonLayout.Visible = false;
                editButton.Visible = false;

                seasonGroupBox.Visible = false;
                episodeGroupBox.Visible = false;

                IMDBLabel.Visible = false;
                IMDBLinkValue.Text = "";
                FilePathLabel.Text = "";

                reservesGroupBox.Visible = false;

                PlayButton.Visible = false;
                populateSeasonsButton.Visible = false;

                selectedShowsListBox.Height = 320;
                selectedShowsListBox.DataSource = null;
                selectedShowsListBox.DataSource = selectedShows;
                selectedShowsListBox.DisplayMember = "Title";
                selectedShowsListBox.ClearSelected();

                if (selectedShows.Any(x => x.Type == "TvShow" && x.Seasons.Count == 0))
                {
                    populateSeasonsButton.Visible = true;
                }
                if (selectedShows.Count == 0)
                {
                    reIdentifyButton.Visible = false;
                    selectedShowsListBox.Visible = false;
                }
                else
                {
                    reIdentifyButton.Visible = true;
                    selectedShowsListBox.Visible = true;
                }
                    
                return;
            }
            PlayButton.Visible = true;
            editButton.Visible = true;
            reIdentifyButton.Visible = true;

            selectedShowsListBox.DataSource = null;
            selectedShowsListBox.Visible = false;
            selectedShowsListBox.Height = 10;

            titleLabel.Text = selectedShow.Title;
            ShowTypeLabel.Text = selectedShow.Type;
            DescriptionLabel.Text = selectedShow.Description;
            episodeTitleLabel.Text = "";
            episodeDescriptionLabel.Text = "";

            watchButtonsPanel.Visible = false;

            bool tvShowVisible = (selectedShow.Seasons.Count > 0);

            viewButtonLayout.Visible = tvShowVisible;
            if (seasonViewButton.Checked)
            {
                episodeGroupBox.Visible = tvShowVisible;
                seasonGroupBox.Visible = tvShowVisible;

                seasonFlowPanel.Controls.Clear();
                episodeFlowPanel.Controls.Clear();
            }
            else
            {
                episodeGroupBox.Visible = false;
                seasonGroupBox.Visible = false;
            }

            if (selectedShow.IMDBId == null)
            {
                IMDBLabel.Visible = false;
                IMDBLinkValue.Text = "";
            }
            else
            {
                IMDBLabel.Visible = true;
                IMDBLinkValue.Text = $"https://www.imdb.com/title/{selectedShow.IMDBId}";
            }

            if (selectedShow.Type == "TvShow" && selectedShow.Seasons.Count == 0)
            {
                populateSeasonsButton.Visible = true;
            }
            else
            {
                populateSeasonsButton.Visible = false;
            }

            if (selectedShow.Seasons.Count > 0 && seasonViewButton.Checked)
            {
                watchButtonsPanel.Visible = true;
                FilePathLabel.Text = "";
                WireUpSeasonFlowPanel();
            }

            if (selectedShow.Seasons.Count == 0 || listViewButton.Checked)
            {
                reservesGroupBox.Visible = true;
                List<EpisodeModel> files = new List<EpisodeModel>();
                if (listViewButton.Checked)
                {
                    foreach (List<EpisodeModel> season in selectedShow.Seasons)
                    {
                        files.AddRange(season.Where(x => x.FilePath != null));
                    }
                }
                files.AddRange(selectedShow.Reserves);
                ReservesDropDown.DataSource = null;
                ReservesDropDown.DataSource = files;
                ReservesDropDown.DisplayMember = "FileName";
            }
            else
            {
                reservesGroupBox.Visible = false;
            }
            //if (selectedShow.Reserves.Count > 0)
            //{
            //    if (selectedShow.Seasons.Count > 0 && seasonViewButton.Checked)
            //    {
            //        reservesGroupBox.Visible = false;
            //    }
            //    else
            //    {
            //        reservesGroupBox.Visible = true;
            //    }
            //    List<EpisodeModel> files = new List<EpisodeModel>();
            //    if (listViewButton.Checked)
            //    {
            //        foreach(List<EpisodeModel> season in selectedShow.Seasons)
            //        {
            //            files.AddRange(season.Where(x => x.FilePath != null));
            //        }
            //    }
            //    files.AddRange(selectedShow.Reserves);
            //    ReservesDropDown.DataSource = null;
            //    ReservesDropDown.DataSource = files;
            //    ReservesDropDown.DisplayMember = "FileName";
            //}
            //else
            //{
            //    reservesGroupBox.Visible = false;
            //}

        }
        public async Task LoadShows()
        {
            LoadingForm frm = new LoadingForm(this, folderPaths);
            frm.ShowDialog();
        }
        public void WireUpSeasonFlowPanel()
        {
            unWatchedButton.Enabled = false;
            watchedButton.Enabled = false;
            watchedBelowButton.Enabled = false;
            selectedSeasonsBoxes.Clear();

            for (int i = 1; i <= selectedShow.NoOfSeasons; i++)
            {
                bool allNull = true;
                bool allWatched = true;
                foreach(EpisodeModel episode in selectedShow.Seasons[i-1])
                {
                    if (episode.FilePath != null)
                    {
                        allNull = false;
                    }
                    if (episode.Watched == 0)
                    {
                        allWatched = false;
                    }
                }
                CheckBox chkb = new CheckBox();
                chkb.Appearance = Appearance.Button;
                chkb.Size = new Size(40, 40);
                chkb.Text = $"{i}";
                chkb.Tag = selectedShow.Seasons[i-1];
                chkb.TextAlign = ContentAlignment.MiddleCenter;
                if (allNull)
                {
                    chkb.BackColor = Color.DarkGray;
                }
                else if (allWatched)
                {
                    chkb.BackColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    chkb.BackColor = Color.DeepSkyBlue;
                }
                chkb.FlatStyle = FlatStyle.Flat;
                chkb.FlatAppearance.BorderSize = 0;
                seasonFlowPanel.Controls.Add(chkb);
                chkb.Click += seasonButton_Click;
            }
            if (selectedShow.Reserves.Count > 0)
            {
                CheckBox chkb = new CheckBox();
                chkb.Appearance = Appearance.Button;
                chkb.Size = new Size(80, 40);
                chkb.Text = "Other Files";
                chkb.TextAlign = ContentAlignment.MiddleCenter;
                chkb.BackColor = Color.DimGray;
                chkb.FlatStyle = FlatStyle.Flat;
                chkb.FlatAppearance.BorderSize = 0;
                seasonFlowPanel.Controls.Add(chkb);
                chkb.Click += seasonButton_Click;
            }
        }
        private void seasonButton_Click(object? sender, EventArgs e)
        {
            unWatchedButton.Enabled = true;
            watchedButton.Enabled = true;
            watchedBelowButton.Enabled = true;
            selectedEpisodesBoxes.Clear();

            CheckBox currCheckBox = (CheckBox)sender;

            if (!ModifierKeys.HasFlag(Keys.Control))
            {
                selectedSeasonsBoxes.Clear();
                foreach (CheckBox checkBox in seasonFlowPanel.Controls)
                {
                    checkBox.Checked = false;
                }
            }
            currCheckBox.Checked = true;
            selectedSeasonsBoxes.Add(currCheckBox);
            episodeTitleLabel.Text = "";
            episodeDescriptionLabel.Text = "";
            FilePathLabel.Text = "";

            if (selectedSeasonsBoxes.Count > 1)
            {
                watchedBelowButton.Enabled = false;
                IMDBLinkValue.Text = "";
                episodeFlowPanel.Controls.Clear();
                return;
            }

            IMDBLinkValue.Text = $"https://www.imdb.com/title/{selectedShow.IMDBId}";
            if (currCheckBox.Text == "Other Files")
            {
                unWatchedButton.Enabled = false;
                watchedButton.Enabled = false;
                watchedBelowButton.Enabled = false;

                episodeGroupBox.Visible = false;
                reservesGroupBox.Visible = true;
                ReservesDropDown.SelectedIndex = 0;
            }
            else
            {
                episodeGroupBox.Visible = true;
                reservesGroupBox.Visible = false;
                WireUpEpisodeFLowPanel(int.Parse(currCheckBox.Text));
            }
        }
        public void WireUpEpisodeFLowPanel(int seasonNo)
        {
            episodeFlowPanel.Controls.Clear();
            for (int i = 1; i <= selectedShow.Seasons[seasonNo-1].Count; i++)
            {
                EpisodeModel episode = selectedShow.Seasons[seasonNo - 1][i - 1];
                CheckBox chkb = new CheckBox();
                chkb.Appearance = Appearance.Button;
                chkb.Size = new Size(40, 40);
                chkb.Text = $"{i}";
                chkb.TextAlign = ContentAlignment.MiddleCenter;
                if (episode.FilePath == null)
                {
                    chkb.BackColor = Color.DarkGray;
                }
                else if (episode.Watched == 1)
                {
                    chkb.BackColor = Color.FromArgb(128, 128, 255);
                }
                else
                {
                    chkb.BackColor = Color.DeepSkyBlue;
                }
                chkb.FlatStyle = FlatStyle.Flat;
                chkb.FlatAppearance.BorderSize = 0;
                episodeFlowPanel.Controls.Add(chkb);
                chkb.Click += episodeButton_Click;
                chkb.Tag = selectedShow.Seasons[seasonNo-1][i - 1];
            }
        }
        private void episodeButton_Click(object? sender, EventArgs e)
        {
            unWatchedButton.Enabled = true;
            watchedButton.Enabled = true;
            watchedBelowButton.Enabled = true;

            CheckBox currCheckBox = (CheckBox)sender;

            if (!ModifierKeys.HasFlag(Keys.Control))
            {
                selectedEpisodesBoxes.Clear();
                foreach (CheckBox checkBox in episodeFlowPanel.Controls)
                {
                    checkBox.Checked = false;
                }
            }
            currCheckBox.Checked = true;
            selectedEpisodesBoxes.Add(currCheckBox);

            if (selectedEpisodesBoxes.Count > 1)
            {
                watchedBelowButton.Enabled = false;
                episodeTitleLabel.Text = "";
                episodeDescriptionLabel.Text = "";
                FilePathLabel.Text = "";
                IMDBLinkValue.Text = "";

                return;
            }

            EpisodeModel episode = (EpisodeModel)currCheckBox.Tag;
            if (episode.FilePath == null)
            {
                watchedButton.Enabled = false;
                unWatchedButton.Enabled = false;
            }
            if (episode == null)
            {
                FilePathLabel.Text = "";
                IMDBLinkValue.Text = $"https://www.imdb.com/title/{selectedShow.IMDBId}";
                return;
            }
            episodeTitleLabel.Text = episode.TitleWithSeasonEpisodeNumber;
            episodeDescriptionLabel.Text = episode.Description;
            FilePathLabel.Text = episode.FilePath;
            IMDBLinkValue.Text = $"https://www.imdb.com/title/{episode.IMDBId}";
            selectedEpisode = episode;
        }
        public void FinishLoadingShows(List<ShowModel> shows)
        {
            availableShows = shows;
            WireUpList();
        }

        private void noShowsLabel_DoubleClick(object? sender, EventArgs e)
        {
            string filePath = "";
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.InitialDirectory = "C:\\";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = folderBrowserDialog.SelectedPath;
                    SqlConnector.CreateFolderPath(filePath);
                    folderPaths.Add(filePath);
                }
                else
                {
                    return;
                }
            }
            LoadShows();
        }

        public void FinishPopulatingSeasons()
        {
            WireUpInfoPanel();
        }
        public void FinishEditingPaths(List<string> paths)
        {
            folderPaths = paths;
            LoadShows();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShows = new List<ShowModel>();
            for (int i = 0; i < listView.SelectedItems.Count; i++)
            {
                selectedShows.Add(filteredShows[listView.SelectedItems[i].Index]);
            }
            //if (listView.SelectedItems.Count < selectedShows.Count)
            //{
            //    selectedShows.Clear();
            //}
            //if (listView.SelectedItems.Count > 0)
            //{
            //    selectedShows.Add(availableShows[listView.SelectedItems[listView.SelectedItems.Count - 1].Index]);
            //}
            //if (listView.SelectedItems.Count == 1)
            //{
            //    ShowInfoPanel.Visible = true;
            //    selectedShow = availableShows[listView.SelectedItems[0].Index];
            //    WireUpInfoPanel();
            //}
            //else
            //{
            //    //ShowInfoPanel.Visible = false;
            //}
            if (listView.SelectedItems.Count == 1)
            {
                selectedShow = selectedShows.First();
            }
            WireUpInfoPanel();

            if (selectedShows.Count == 0)
            {
                listView.ContextMenuStrip = null;
            }
            else
            {
                listView.ContextMenuStrip = showContextMenu;
            }
        }

        private void IMDBLinkValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = IMDBLinkValue.Text;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (selectedShows.Count > 1)
            {
                WrongShowForm frm = new WrongShowForm(selectedShows, this);
                frm.ShowDialog();
            }
            else
            {
                EditForm editForm = new EditForm(selectedShow,this);
                editForm.ShowDialog();
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = FilePathLabel.Text;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
            if (selectedShow.Type == "TvShow" && selectedSeasonsBoxes[0].Text != "Other Files")
            {
                if (selectedEpisode.Watched == 0)
                {
                    selectedEpisode.Watched = 1;
                    SqlConnector.UpdateEpisodeWatched(selectedEpisode);
                    selectedEpisodesBoxes[0].BackColor = Color.FromArgb(128, 128, 255);
                    List<EpisodeModel> season = (List<EpisodeModel>)selectedSeasonsBoxes[0].Tag;
                    if (season.All(x => x.Watched == 1))
                    {
                        selectedSeasonsBoxes[0].BackColor = Color.FromArgb(128, 128, 255);
                    }
                }
            }
        }

        private void FilePathLabel_TextChanged(object sender, EventArgs e)
        {
            if (FilePathLabel.Text == null || FilePathLabel.Text == "")
            {
                PlayButton.Enabled = false;
            }
            else
            {
                PlayButton.Enabled = true;
            }
        }

        public void EditFinish()
        {
            GlobalConfig.allShows = SqlConnector.LoadShows();
            availableShows = GlobalConfig.allShows;
            ShowInfoPanel.Visible = false;
            LoadShows();
        }

        private async void populateSeasonsButton_Click(object sender, EventArgs e)
        {
            LoadingForm frm = new LoadingForm(this,selectedShows);
            frm.ShowDialog();
        }

        private void ReservesDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReservesDropDown.Visible == false)
            {
                return;
            }
            EpisodeModel episode = (EpisodeModel)ReservesDropDown.SelectedItem;
            if (episode == null)
            {
                FilePathLabel.Text = "";
                return;
            }

            FilePathLabel.Text = episode.FilePath;

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            WireUpList();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Focused)
            {
                this.AcceptButton = searchButton;
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderPathsForm frm = new FolderPathsForm(folderPaths, this);
            frm.ShowDialog();
        }

        private void correctShowInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WrongShowForm frm = new WrongShowForm(selectedShows, this);
            frm.ShowDialog();
        }

        private void showContextMenu_Opening(object sender, CancelEventArgs e)
        {
            bool allUnpopulatedTv = true;
            foreach(ShowModel show in selectedShows)
            {
                if (show.Type != "TvShow" || show.Seasons.Count > 0)
                {
                    allUnpopulatedTv = false;
                    break;
                }
            }

            if (allUnpopulatedTv)
            {
                showContextMenu.Items[1].Visible = true;
            }
            else
            {
                showContextMenu.Items[1].Visible = false;
            }
        }

        private void arrangeIntoSeasonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingForm frm = new LoadingForm(this, selectedShows);
            frm.ShowDialog();
        }

        private void resetDatabseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deleteCancel() == false)
            {
                return;
            }
            SqlConnector.DeleteEverything();
            folderPaths = new List<string>();
            GlobalConfig.allShows = new List<ShowModel>();
            availableShows = new List<ShowModel>();
            WireUpList();
            ShowInfoPanel.Visible = false;
        }

        private bool deleteCancel()
        {
            string message = "This action will wipe the data from the database including all movies and shows info, this will not affect the actual files on the computer.\nAre you sure you want to reset the database to its original state?";
            var result = MessageBox.Show(message, "Reset Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void unWatchedButton_Click(object sender, EventArgs e)
        {
            if (selectedEpisodesBoxes.Count > 0)
            {
                List<int> episodeNos = new List<int>();
                int seasonNo = 0;
                foreach (var episodeCh in selectedEpisodesBoxes)
                {
                    EpisodeModel episode = (EpisodeModel)episodeCh.Tag;
                    if (episode.FilePath != null)
                    {
                        if (episode.Watched == 1)
                        {
                            episode.Watched = 0;
                            episodeNos.Add(episode.EpisodeNumber);
                            //SqlConnector.UpdateEpisodeWatched(episode);
                        }
                        episodeCh.BackColor = Color.DeepSkyBlue;
                    }
                    seasonNo = episode.SeasonNumber;
                }

                List<EpisodeModel> season = (List<EpisodeModel>)selectedSeasonsBoxes[0].Tag;
                if (season.Any(e => e.Watched == 0))
                {
                    selectedSeasonsBoxes[0].BackColor = Color.DeepSkyBlue;
                }
                SqlConnector.UpdateEpisodeWatchedMultiple(0, seasonNo, selectedShow, episodeNos);
            }
            else
            {
                List<int> seasonNos = new List<int>();
                foreach (var seasonCh in selectedSeasonsBoxes)
                {
                    if (seasonCh.BackColor == Color.DeepSkyBlue || seasonCh.BackColor == Color.FromArgb(128, 128, 255))
                    {
                        seasonNos.Add(int.Parse(seasonCh.Text));
                        foreach (EpisodeModel episode in (List<EpisodeModel>)seasonCh.Tag)
                        {
                            if (episode.FilePath != null)
                            {
                                if (episode.Watched == 1)
                                {
                                    episode.Watched = 0;
                                    //SqlConnector.UpdateEpisodeWatched(episode);
                                }
                            }
                        }
                        seasonCh.BackColor = Color.DeepSkyBlue;
                    }
                }
                if (episodeFlowPanel.Visible == true && selectedSeasonsBoxes[0].BackColor != Color.DarkGray)
                {
                    foreach (CheckBox episodeCh in episodeFlowPanel.Controls)
                    {
                        episodeCh.BackColor = Color.DeepSkyBlue;
                    }
                }
                SqlConnector.UpdateEpisodeWatchedBySeasons(0, seasonNos, selectedShow);
            }
        }

        private void watchedButton_Click(object sender, EventArgs e)
        {
            if (selectedEpisodesBoxes.Count > 0)
            {
                List<int> episodeNos = new List<int>();
                int seasonNo = 0;
                foreach (var episodeCh in selectedEpisodesBoxes)
                {
                    EpisodeModel episode = (EpisodeModel)episodeCh.Tag;
                    if (episode.FilePath != null)
                    {
                        if (episode.Watched == 0)
                        {
                            episode.Watched = 1;
                            episodeNos.Add(episode.EpisodeNumber);
                            //SqlConnector.UpdateEpisodeWatched(episode);
                        }
                        episodeCh.BackColor = Color.FromArgb(128,128,255);
                    }
                    seasonNo = episode.SeasonNumber;
                }

                List<EpisodeModel> season = (List<EpisodeModel>)selectedSeasonsBoxes[0].Tag;
                if (season.All(e => e.Watched == 1))
                {
                    selectedSeasonsBoxes[0].BackColor = Color.FromArgb(128,128,255);
                }
                SqlConnector.UpdateEpisodeWatchedMultiple(1, seasonNo, selectedShow, episodeNos);
            }
            else
            {
                List<int> seasonNos = new List<int>();
                foreach (var seasonCh in selectedSeasonsBoxes)
                {
                    if (seasonCh.BackColor == Color.DeepSkyBlue || seasonCh.BackColor == Color.FromArgb(128, 128, 255))
                    {
                        seasonNos.Add(int.Parse(seasonCh.Text));
                        foreach (EpisodeModel episode in (List<EpisodeModel>)seasonCh.Tag)
                        {
                            if (episode.FilePath != null)
                            {
                                if (episode.Watched == 0)
                                {
                                    episode.Watched = 1;
                                    //SqlConnector.UpdateEpisodeWatched(episode);
                                }
                            }
                        }
                        seasonCh.BackColor = Color.FromArgb(128,128,255);
                    }
                }
                if (episodeFlowPanel.Visible == true && selectedSeasonsBoxes[0].BackColor != Color.DarkGray)
                {
                    foreach(CheckBox episodeCh in episodeFlowPanel.Controls)
                    {
                        episodeCh.BackColor = Color.FromArgb(128, 128, 255);
                    }
                }
                SqlConnector.UpdateEpisodeWatchedBySeasons(1, seasonNos, selectedShow);
            }
        }

        private void watchedBelowButton_Click(object sender, EventArgs e)
        {
            if (selectedEpisodesBoxes.Count == 1)
            {
                int seasonNo = 0;
                List<int> episodeNos = new List<int>();
                for(int i = 0; i < int.Parse(selectedEpisodesBoxes[0].Text) - 1; i++)
                {
                    EpisodeModel episode = (EpisodeModel)episodeFlowPanel.Controls[i].Tag;
                    if (episode.FilePath != null)
                    {
                        if (episode.Watched == 0)
                        {
                            episode.Watched = 1;
                            //SqlConnector.UpdateEpisodeWatched(episode);
                        }
                        episodeFlowPanel.Controls[i].BackColor = Color.FromArgb(128, 128, 255);
                        seasonNo = episode.SeasonNumber;
                        episodeNos.Add(episode.EpisodeNumber);
                    }
                }
                SqlConnector.UpdateEpisodeWatchedMultiple(1, seasonNo, selectedShow, episodeNos);
            }
            else
            {
                List<int> seasonNos = new List<int>();
                if (selectedSeasonsBoxes[0].Text != "Other Files")
                {
                    for (int i = 0; i < int.Parse(selectedSeasonsBoxes[0].Text) - 1; i++)
                    {
                        seasonNos.Add(i + 1);
                        foreach(EpisodeModel episode in (List<EpisodeModel>)seasonFlowPanel.Controls[i].Tag)
                        {
                            if (episode.FilePath != null)
                            {
                                if (episode.Watched == 0)
                                {
                                    episode.Watched = 1;
                                    //SqlConnector.UpdateEpisodeWatched(episode);
                                }
                            }
                        }
                        if (seasonFlowPanel.Controls[i].BackColor != Color.DarkGray)
                        {
                            seasonFlowPanel.Controls[i].BackColor = Color.FromArgb(128, 128, 255);
                        }
                    }
                }
                SqlConnector.UpdateEpisodeWatchedBySeasons(1, seasonNos, selectedShow);
            }
        }

        private void filterShows()
        {
            if (movieCheckBox.Checked != tvShowCheckBox.Checked)
            {
                if (movieCheckBox.Checked)
                {
                    filteredShows = availableShows.Where(x => x.Type == "Movie").ToList();
                }
                if (tvShowCheckBox.Checked)
                {
                    filteredShows = availableShows.Where(x => x.Type == "TvShow").ToList();
                }
            }
            else
            {
                filteredShows = availableShows;
            }

            string searchText = searchTextBox.Text.ToLower();
            if (searchText != "")
            {
                filteredShows = filteredShows.Where(x => x.Title.ToLower().Contains(searchText)).ToList();
            }
        }

        private void movieCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WireUpList();
        }

        private void tvShowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WireUpList();
        }

        private void listViewButton_CheckedChanged(object sender, EventArgs e)
        {
            WireUpInfoPanel();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            ShowInfoPanel.Visible = false;
        }

        private void reIdentifyButton_Click(object sender, EventArgs e)
        {
            WrongShowForm frm = new WrongShowForm(selectedShows, this);
            frm.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm frm = new HelpForm();
            frm.ShowDialog();
        }
    }
}
