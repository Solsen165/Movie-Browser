using BrowserLibrary.Models;
using BrowserLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BrowserUI
{
    public partial class LoadingForm : Form
    {
        List<ShowModel> shows;
        List<string> folderPaths;
        MainForm caller;
        public LoadingForm(MainForm caller, List<string> folderPaths)
        {
            InitializeComponent();
            this.caller = caller;
            this.folderPaths = folderPaths;
            this.Text = "Loading Shows";
            LoadShows();
        }

        public LoadingForm(MainForm caller, List<ShowModel> shows)
        {
            InitializeComponent();
            this.caller = caller;
            this.shows = shows;
            this.Text = "Downloading Seasons Info";
            PopulateShows(shows);
        }
        private async Task LoadShows()
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;
            shows = await ShowLoader.LoadShowsFromFolderParallel(folderPaths, progress);

            caller.FinishLoadingShows(shows);
            this.Close();
        }

        private async Task PopulateShows(List<ShowModel> shows)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;
            shows = shows.Where(x => x.Seasons.Count == 0).ToList();
            await ShowLoader.PopulateSeasonsParallel(shows, progress);
            await Task.Run(() =>
            {
                foreach(ShowModel show in shows)
                {
                    ShowLoader.ArrangeIntoSeasons(show);
                }
            });

            caller.FinishPopulatingSeasons();
            this.Close();
        }

        private void Progress_ProgressChanged(object? sender, ProgressReportModel e)
        {
            showProgressBar.Value = Math.Max(e.percentage,showProgressBar.Value);
            if (e.currOperation != null && e.currOperation != "")
            {
                if (progressListBox.Items.Count == 0 || e.currOperation != (string)progressListBox.Items[progressListBox.Items.Count - 1])
                progressListBox.Items.Add(e.currOperation);
            }

            if (e.currOperation == "Saving shows in the database...")
            {
                e.currOperation = "";
            }
            progressListBox.TopIndex = progressListBox.Items.Count - 1;
        }

    }
}
