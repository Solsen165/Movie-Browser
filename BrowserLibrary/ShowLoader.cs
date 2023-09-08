using BrowserLibrary.DataAccess;
using BrowserLibrary.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BrowserLibrary
{
    public static class ShowLoader
    {
        public static string RemoveSpecialCharacters(this string title)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in title)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(' ');
                }
            }
            return sb.ToString();
        }
        public static async Task<List<ShowModel>> LoadShowsFromFolderParallel(List<string> folderPaths, IProgress<ProgressReportModel> progress)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            List<ShowModel> availableShows = new List<ShowModel>();

            string[] extensions = { ".mkv", ".mp4", ".flv", ".avi" };
            List<string> files = new List<string>();
            foreach(string folderPath in folderPaths)
            {
                if (Directory.Exists(folderPath))
                {
                    List<string> temp = Directory.GetFiles(folderPath, "*.*", new EnumerationOptions() { IgnoreInaccessible = true, RecurseSubdirectories = true }).Where(file => extensions.Any(file.ToLower().EndsWith)).ToList();
                    files.AddRange(temp);
                }
            }
            files = files.Distinct().ToList();
            Dictionary<string, int> allFiles = SqlConnector.LoadAllFilePaths();
            List<string> newFiles = new List<string>();
            List<string> newShowFiles = new List<string>();

            foreach (string file in files)
            {
                ShowModel? show;
                if (allFiles.ContainsKey(file))
                {
                    int id = allFiles[file];
                    show = GlobalConfig.allShows.Where(x => x.Id == id).FirstOrDefault();
                    if (show != null && !availableShows.Contains(show))
                    {
                        availableShows.Add(show);
                    }
                }
                else
                {
                    newFiles.Add(file);
                    show = GlobalConfig.allShows.Where(x => x.OtherTitles.Contains(file.IdentifyTitleFromFileName())).FirstOrDefault();
                    if (show != null && !availableShows.Contains(show))
                    {
                        availableShows.Add(show);
                    }
                    if (show == null)
                    {
                        newShowFiles.Add(file);
                    }
                }
            }

            files = files.Where(file => allFiles.ContainsKey(file) == false).ToList();

            List<ShowModel> shows = await CreateShowsParallel(newShowFiles, progress);

            shows = await FilterShowsParallel(shows);

            ProgressReportModel progressReportModel = new ProgressReportModel();
            progressReportModel.currOperation = "Saving shows in the database...";
            progress.Report(progressReportModel);
            List<ShowModel> showsToArrangeSeasons = new List<ShowModel>();
            await Task.Run(() =>
            {
                foreach(string file in newFiles)
                {
                    EpisodeModel newEpisode = new EpisodeModel();
                    newEpisode.FilePath = file;
                    ShowModel? parent = shows.Where(x => x.OtherTitles.Contains(file.IdentifyTitleFromFileName())).FirstOrDefault();
                    if (parent == null)
                    {
                        parent = availableShows.Where(x => x.OtherTitles.Contains(file.IdentifyTitleFromFileName())).First();
                    }
                    newEpisode.ParentShow = parent;
                    newEpisode.ParentShowId = parent.Id;
                    if (!availableShows.Contains(parent))
                    {
                        availableShows.Add(parent);
                    }

                    parent.Reserves.Add(newEpisode);
                    if (parent.Type == "TvShow" && parent.Seasons.Count > 0 && !showsToArrangeSeasons.Contains(parent))
                    {
                        showsToArrangeSeasons.Add(parent);
                    }
                    SqlConnector.CreateEpisodeFile(newEpisode);
                    progressReportModel.filesLoaded++;
                    progressReportModel.percentage = 75 + (progressReportModel.filesLoaded * 25) / files.Count;
                    progress.Report(progressReportModel);
                }
                foreach(ShowModel show in showsToArrangeSeasons)
                {
                    ArrangeIntoSeasons(show);
                }
            });

            watch.Stop();
            var time = watch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine($"Elapsed Time : {time}");

            return availableShows;
        }

        private static async Task<List<ShowModel>> CreateShowsParallel(List<string> files, IProgress<ProgressReportModel> progress)
        {
            List<string> titlesFromFiles = new List<string>();
            List<Task<ShowModel>> createShowTasks = new List<Task<ShowModel>>();

            ProgressReportModel progressReportModel = new ProgressReportModel();
            progressReportModel.totalFiles = files.Count;

            int i = 1;
            foreach(string file in files)
            {
                string parentShowTitle = file.IdentifyTitleFromFileName();
                bool unique = false;

                if (!titlesFromFiles.Contains(parentShowTitle))
                {
                    titlesFromFiles.Add(parentShowTitle);
                    unique = true;
                    i++;
                }
                if (unique)
                {
                    if (i % 10 == 0)
                    {
                        await Task.Delay(5000);
                    }
                    createShowTasks.Add(CreateShow(parentShowTitle, progress, progressReportModel));
                }
            }
            progressReportModel.totalFiles = i;

            List<ShowModel> output = new List<ShowModel>(await Task.WhenAll(createShowTasks));
            return output;
        }

        private static async Task<List<ShowModel>> FilterShowsParallel(List<ShowModel> shows)
        {
            List<string> ids = new List<string>();
            List<ShowModel> output = new List<ShowModel>();

            foreach(ShowModel show in shows)
            {
                string id = show.IMDBId;
                bool unique = false;
                
                if (id == null || !ids.Contains(id))
                {
                    ShowModel? existingShow = null;
                    if (id != null)
                    {
                        ids.Add(id);
                        existingShow = GlobalConfig.allShows.Where(x => x.IMDBId == id).FirstOrDefault();
                    }
                    if (existingShow != null)
                    {
                        existingShow.OtherTitles.Add(show.OtherTitles.First());
                        SqlConnector.InsertOtherTitle(existingShow);
                        output.Add(existingShow);
                        continue;
                    }
                    unique = true;
                    SqlConnector.CreateShow(show);
                    SqlConnector.InsertOtherTitle(show);
                }
                
                if (unique)
                {
                    output.Add(show);
                }
                else
                {
                    ShowModel temp = output.Where(x => x.IMDBId == id).First();
                    temp.OtherTitles.Add(show.OtherTitles.First());
                    SqlConnector.InsertOtherTitle(temp);
                }
            }

            return output;
        }

        //public static async Task CorrectShowOld(ShowModel oldShow, ShowModel newShow, List<string> files, IProgress<ProgressReportModel> progress)
        //{
        //    ShowModel? temp = GlobalConfig.allShows.Where(x => x.IMDBId == newShow.IMDBId).FirstOrDefault();
        //    if (temp == null)
        //    {
        //        SqlConnector.CreateShow(newShow);
        //        //if (newShow.Type == "TvShow")
        //        //{
        //        //    await PopulateSeasonsParallel(newShow);
        //        //}
        //        GlobalConfig.allShows.Add(newShow);
        //    }
        //    else
        //    {
        //        newShow = temp;
        //    }


        //    int filesLoaded = -1;
        //    ProgressReportModel progressReport = new ProgressReportModel();
        //    foreach (string file in files)
        //    {
        //        filesLoaded++;
        //        progressReport.percentage = (filesLoaded * 100) / files.Count;
        //        progressReport.currOperation = file;
        //        progress.Report(progressReport);


        //        EpisodeModel newEpisode = new EpisodeModel();
        //        newEpisode.FilePath = file;
        //        string parentShowTitle = IdentifyTitleFromFileName(file);

        //        if (oldShow.OtherTitles.Contains(parentShowTitle))
        //        {
        //            oldShow.OtherTitles.Remove(parentShowTitle);
        //            newShow.OtherTitles.Add(parentShowTitle);
        //            SqlConnector.DeleteOtherTitle(oldShow, parentShowTitle);
        //            SqlConnector.InsertOtherTitle(newShow);

        //        }

        //        newEpisode.ParentShow = newShow;
        //        newEpisode.ParentShowId = newShow.Id;

        //        if (newShow.Type == "TvShow")
        //        {
        //            newEpisode.SetEpisodeNumber();
        //            if (newEpisode.SeasonNumber <= newShow.Seasons.Count && newEpisode.EpisodeNumber <= newShow.Seasons[newEpisode.SeasonNumber - 1].Count)
        //            {
        //                if (newShow.Seasons[newEpisode.SeasonNumber - 1][newEpisode.EpisodeNumber - 1].FilePath != null)
        //                {
        //                    newShow.Reserves.Add(newEpisode);
        //                }
        //                else
        //                {
        //                    newShow.Seasons[newEpisode.SeasonNumber - 1][newEpisode.EpisodeNumber - 1].FilePath = newEpisode.FilePath;
        //                    newEpisode.Id = newShow.Seasons[newEpisode.SeasonNumber - 1][newEpisode.EpisodeNumber - 1].Id;
        //                }
        //            }
        //            else
        //            {
        //                newShow.Reserves.Add(newEpisode);
        //            }
        //        }
        //        else
        //        {
        //            newEpisode.EpisodeNumber = 1;
        //            newEpisode.SeasonNumber = 1;

        //            if (newShow.Seasons[0][0].FilePath != null)
        //            {
        //                newEpisode.Id = 0;
        //                newEpisode.EpisodeNumber = 0;
        //                newEpisode.SeasonNumber = 0;
        //                newShow.Reserves.Add(newEpisode);
        //            }
        //            else
        //            {
        //                SqlConnector.CreateEpisode(newEpisode);
        //                newShow.Seasons[0][0].FilePath = newEpisode.FilePath;
        //            }
        //        }
        //        SqlConnector.UpdateEpisodeFile(newEpisode);
        //    }

        //}
        public static async Task CorrectShow(ShowModel newShow, List<EpisodeModel> files, IProgress<ProgressReportModel> progress)
        {
            ShowModel? temp = GlobalConfig.allShows.Where(x => x.IMDBId == newShow.IMDBId).FirstOrDefault();
            if (temp == null)
            {
                SqlConnector.CreateShow(newShow);
                GlobalConfig.allShows.Add(newShow);
            }
            else
            {
                newShow = temp;
            }


            int filesLoaded = -1;
            ProgressReportModel progressReport = new ProgressReportModel();
            foreach (EpisodeModel file in files)
            {
                filesLoaded++;
                progressReport.percentage = (filesLoaded * 100) / files.Count;
                progressReport.currOperation = file.FilePath;
                progress.Report(progressReport);
                ShowModel oldShow = file.ParentShow;

                EpisodeModel newEpisode = new EpisodeModel();
                newEpisode.FilePath = file.FilePath;
                newEpisode.FileId = file.FileId;
                string parentShowTitle = IdentifyTitleFromFileName(file.FilePath);

                if (oldShow.OtherTitles.Contains(parentShowTitle))
                {
                    oldShow.OtherTitles.Remove(parentShowTitle);
                    newShow.OtherTitles.Add(parentShowTitle);
                    SqlConnector.DeleteOtherTitle(oldShow, parentShowTitle);
                    SqlConnector.InsertOtherTitle(newShow);
                }

                newEpisode.ParentShow = newShow;
                newEpisode.ParentShowId = newShow.Id;

                if (newShow.Seasons.Count > 0)
                {
                    if (newEpisode.EpisodeNumber == 0 || newEpisode.SeasonNumber == 0)
                    {
                        newEpisode.SetEpisodeNumber();
                    }
                    if (newEpisode.SeasonNumber > 0 && newEpisode.EpisodeNumber > 0 && newEpisode.SeasonNumber <= newShow.Seasons.Count && newEpisode.EpisodeNumber <= newShow.Seasons[newEpisode.SeasonNumber - 1].Count)
                    {
                        if (newShow.Seasons[newEpisode.SeasonNumber - 1][newEpisode.EpisodeNumber - 1].FilePath != null)
                        {
                            newShow.Reserves.Add(newEpisode);
                        }
                        else
                        {
                            newShow.Seasons[newEpisode.SeasonNumber - 1][newEpisode.EpisodeNumber - 1].FilePath = newEpisode.FilePath;
                            newEpisode.Id = newShow.Seasons[newEpisode.SeasonNumber - 1][newEpisode.EpisodeNumber - 1].Id;
                        }
                    }
                    else
                    {
                        newShow.Reserves.Add(newEpisode);
                    }
                }
                else
                {
                    newShow.Reserves.Add(newEpisode);
                }
                SqlConnector.UpdateEpisodeFile(newEpisode);
            }

        }

        public static Image LoadPoster(ShowModel show)
        {
            Image poster = null;

            if (show.IMDBId != null && System.IO.File.Exists($"./Database/Posters/{show.IMDBId}.jpg"))
            {
                poster = Image.FromFile($"./Database/Posters/{show.IMDBId}.jpg");
            }
            else if (System.IO.File.Exists($"./Database/Posters/{show.Id}.jpg"))
            {
                poster = Image.FromFile($"./Database/Posters/{show.Id}.jpg");
            }
            else if (System.IO.File.Exists($"./Database/Posters/defaults.jpg"))
            {
                poster = Image.FromFile($"./Database/Posters/default.jpg");
                
            }

            return poster;
        }

        private static void SetEpisodeNumber(this EpisodeModel model)
        {
            string[] segments = Path.GetFileName(model.FilePath).RemoveSpecialCharacters().Split(' ');
            int n = segments.Length;
            int episodeNo = 0, seasonNo = 0;

            for (int i = 0; i < n; i++)
            {
                if (segments[i] == "")
                {
                    continue;
                }

                string currSegment = segments[i].ToLower();
                if (i < n - 1 
                    && (currSegment == "episode" || currSegment == "season" || currSegment == "e" || currSegment == "ep" ||currSegment == "s") 
                    && segments[i + 1].IsNumber())
                {
                    if (currSegment == "episode" || currSegment == "e" || currSegment == "ep")
                    {
                        episodeNo = int.Parse(segments[i + 1]);
                    }
                    if (currSegment == "season" || currSegment == "s")
                    {
                        seasonNo = int.Parse(segments[i + 1]);
                    }
                }
                if (i > 0
                    && (currSegment == "episode" || currSegment == "season" || currSegment == "e" || currSegment == "ep" || currSegment == "s")
                    && segments[i - 1].IsOrdinal() != -1)
                {
                    if (currSegment == "episode" || currSegment == "e" || currSegment == "ep")
                    {
                        episodeNo = segments[i - 1].IsOrdinal();
                    }
                    if (currSegment == "season" || currSegment == "s")
                    {
                        seasonNo = segments[i - 1].IsOrdinal();
                    }
                }

                List<int> SeasonEpisode = segments[i].IsShortFormSeasonMarker();
                if (SeasonEpisode != null)
                {
                    if (SeasonEpisode[0] != 0)
                    {
                        seasonNo = SeasonEpisode[0];
                    }
                    if (SeasonEpisode[1] != 0)
                    {
                        episodeNo = SeasonEpisode[1];
                    }
                    break;
                }
            }

            model.EpisodeNumber = episodeNo;
            model.SeasonNumber = seasonNo;
        }
        public static async Task<ShowModel> CreateShow(string title, IProgress<ProgressReportModel> progress, ProgressReportModel progressReportModel, string link = "")
        {
            ShowModel model = new ShowModel();
            if (link == "")
            {
                HtmlNode searchResult = await LookUpShow(title,1);
                if (searchResult == null)
                {
                    model.Title = title;
                    model.Type = "Movie";
                    model.IMDBId = null;
                    model.OtherTitles.Add(title);
                    return model;
                }
                model.IMDBId = IMDBIdFromLink(searchResult.GetAttributeValue("href", ""));
            }
            else
            {
                model.IMDBId = IMDBIdFromLink(link);
            }

            HtmlDocument htmlDocument = await DownloadShowPageAsync(model.IMDBId);
            if (htmlDocument == null)
            {
                model.Title = title;
                model.Type = "Movie";
                model.IMDBId = null;
                model.OtherTitles.Add(title);
                return model;
            }

            System.Diagnostics.Debug.WriteLine("Download Show Page Complete");

            model.Title = TitleFromPage(htmlDocument);

            progressReportModel.currOperation = $"Download {model.Title} Show Page Complete";
            progress.Report(progressReportModel);

            DownloadPoster(htmlDocument, model.IMDBId);
            model.Description = DescriptionFromPage(htmlDocument);

            System.Diagnostics.Debug.WriteLine("Download Poster Complete");
            progressReportModel.currOperation = $"Download {model.Title} Poster Complete";
            progressReportModel.filesLoaded++;
            progressReportModel.percentage = (progressReportModel.filesLoaded * 75) / progressReportModel.totalFiles;
            progress.Report(progressReportModel);


            if (IsTvShow(htmlDocument))
            {
                model.Type = "TvShow";
                model.NoOfSeasons = SeasonNumberFromPage(htmlDocument);
            }
            else
            {
                model.Type = "Movie";
            }
            model.OtherTitles.Add(title);
            return model;
        }

        private static int SeasonNumberFromPage(HtmlDocument htmlDocument)
        {
            var seasonNode = htmlDocument.DocumentNode.SelectSingleNode("//select[@id='browse-episodes-season']");
            if (seasonNode == null)
            {
                return 1;
            }
            return seasonNode.ChildNodes.Count - 2;
        }

        private static void DownloadPoster(HtmlDocument htmlDocument, string id)
        {
            string imageLink;
            var imageNode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"__next\"]/main/div/section[1]/section/div[3]/section/section/div[3]/div[1]/div[1]/div/div[1]/img");
            if (imageNode == null)
            {
                return;
            }
            imageLink = imageNode.GetAttributeValue("src", "");

            if (imageLink != "")
            {
                if (!System.IO.Directory.Exists("./Database/Posters"))
                {
                    System.IO.Directory.CreateDirectory("./Database/Posters");
                }
                using (var client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(imageLink, $"./Database/Posters/{id}.jpg");

                    }
                    catch (System.Net.WebException)
                    {

                        return;
                    }          
                }
            }
        }
        private static async Task PopulateSeasons(ShowModel model)
        {
            for (int seasonNo = 1; ;seasonNo++)
            {

                HtmlDocument htmlDocument = await DownloadSeasonPageAsync(model.IMDBId, seasonNo);
                System.Diagnostics.Debug.WriteLine($"Download Season {seasonNo} Page Complete");

                var episodeNodes = htmlDocument.DocumentNode.SelectNodes("//h4");

                if (episodeNodes == null || episodeNodes.Count == 0)
                {
                    break;
                }

                // wierd fix for incosistent data
                while (episodeNodes[0].InnerHtml == "TV")
                {
                    GlobalConfig.httpClient = new HttpClient();
                    htmlDocument = await DownloadSeasonPageAsync(model.IMDBId, seasonNo);
                    episodeNodes = htmlDocument.DocumentNode.SelectNodes("//h4");
                }


                List<EpisodeModel> currSeason = new List<EpisodeModel>();
                int episodeNo = 1;
                foreach (var episodeNode in episodeNodes)
                {
                    string episodeLink = episodeNode.ChildNodes.First().GetAttributeValue("href", "");
                    string innerHtml = episodeNode.ChildNodes.First().InnerHtml;


                    EpisodeModel newEpisode = new EpisodeModel();
                    newEpisode.IMDBId = IMDBIdFromLink(episodeLink);
                    newEpisode.Title = EpisodeTitleFromHtml(innerHtml);
                    newEpisode.EpisodeNumber = episodeNo++;
                    newEpisode.SeasonNumber = seasonNo;
                    newEpisode.ParentShow = model;
                    newEpisode.ParentShowId = model.Id;

                    currSeason.Add(newEpisode);

                    SqlConnector.CreateEpisode(newEpisode);
                }
                model.Seasons.Add(currSeason);
            }
        }

        public static async Task PopulateSeasonsParallel(List<ShowModel> models, IProgress<ProgressReportModel> progress)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            ProgressReportModel progressReportModel = new ProgressReportModel();
            progressReportModel.totalFiles = 0;
            foreach(ShowModel model in models)
            {
                progressReportModel.totalFiles += model.NoOfSeasons;
            }

            int i = 1;
            foreach(ShowModel model in models)
            {
                List<Task<List<EpisodeModel>>> seasonTasks = new List<Task<List<EpisodeModel>>>();
                for (int seasonNo = 1; seasonNo <= model.NoOfSeasons ; seasonNo++)
                {
                    i++;
                    if (i % 10 == 0)
                    {
                        await Task.Delay(5000);
                    }
                    seasonTasks.Add(ParallelSeasons(model, seasonNo, progress, progressReportModel));
                }
                var seasons = await Task.WhenAll(seasonTasks);
                model.Seasons = new List<List<EpisodeModel>>(seasons);
            }
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine($"Time is {time}");
        }
        private static async Task<List<EpisodeModel>> ParallelSeasons(ShowModel model, int seasonNo, IProgress<ProgressReportModel> progress, ProgressReportModel progressReportModel)
        {
            HtmlDocument htmlDocument = await DownloadSeasonPageAsync(model.IMDBId, seasonNo);
            System.Diagnostics.Debug.WriteLine($"Download Season {seasonNo} Page Complete");

            var episodeNodes = htmlDocument.DocumentNode.SelectNodes("//h4");

            // wierd fix for inconsistent data
            while (episodeNodes[0].InnerHtml == "TV")
            {
                HttpClientHandler hch = new HttpClientHandler();
                hch.Proxy = null;
                hch.UseProxy = false;
                GlobalConfig.httpClient = new HttpClient(hch);

                htmlDocument = await DownloadSeasonPageAsync(model.IMDBId, seasonNo);
                episodeNodes = htmlDocument.DocumentNode.SelectNodes("//h4");
            }


            List<EpisodeModel> currSeason = new List<EpisodeModel>();
            int episodeNo = 1;
            await Task.Run(() =>
            {
                foreach (var episodeNode in episodeNodes)
                {
                    string episodeLink = episodeNode.ChildNodes.First().GetAttributeValue("href", "");
                    string innerHtml = episodeNode.ChildNodes.First().InnerHtml;

                    EpisodeModel newEpisode = new EpisodeModel();
                    newEpisode.IMDBId = IMDBIdFromLink(episodeLink);
                    newEpisode.Title = EpisodeTitleFromHtml(innerHtml);
                    newEpisode.Description = EpisodeDescriptionFromHtml(episodeNode);
                    newEpisode.EpisodeNumber = episodeNo++;
                    newEpisode.SeasonNumber = seasonNo;
                    newEpisode.ParentShow = model;
                    newEpisode.ParentShowId = model.Id;

                    currSeason.Add(newEpisode);
                }
            });

            //foreach(EpisodeModel episode in currSeason)
            //{
            //    SqlConnector.CreateEpisode(episode);
            //}
            SqlConnector.CreateEpisodeMultiple(currSeason);

            progressReportModel.filesLoaded++;
            progressReportModel.percentage = (progressReportModel.filesLoaded * 90) / progressReportModel.totalFiles;
            progressReportModel.currOperation = $"{model.Title} Season {seasonNo} Info Downloaded";
            progress.Report(progressReportModel);

            System.Diagnostics.Debug.WriteLine($"Season {seasonNo} Complete");
            return currSeason;
        }
        public static void ArrangeIntoSeasons(ShowModel model)
        {
            List<EpisodeModel> episodes = new List<EpisodeModel>();
            foreach(List<EpisodeModel> season in model.Seasons)
            {
                episodes.AddRange(season);
            }
            episodes.AddRange(model.Reserves);

            List<EpisodeModel> newReserves = new List<EpisodeModel>();
            foreach(EpisodeModel episode in model.Reserves)
            {
                if (episode.EpisodeNumber == 0 || episode.SeasonNumber == 0)
                {
                    episode.SetEpisodeNumber();
                }
                if (episode.SeasonNumber > 0 && episode.EpisodeNumber > 0 && episode.SeasonNumber <= model.Seasons.Count && episode.EpisodeNumber <= model.Seasons[episode.SeasonNumber-1].Count)
                {
                    EpisodeModel episodeShell = model.Seasons[episode.SeasonNumber - 1][episode.EpisodeNumber - 1];
                    if (episodeShell.FilePath == null)
                    {
                        episodeShell.FilePath = episode.FilePath;
                        episodeShell.FileId = episode.FileId;
                        SqlConnector.UpdateEpisodeFile(episodeShell);
                    }
                    else
                    {
                        newReserves.Add(episode);
                    }
                }
                else
                {
                    newReserves.Add(episode);
                }
            }
            model.Reserves = newReserves;
        }
        public static void SetAllEpisodeNumbers(ShowModel model)
        {
            List<EpisodeModel> episodes = new List<EpisodeModel>();
            foreach (List<EpisodeModel> season in model.Seasons)
            {
                episodes.AddRange(season);
            }
            episodes.AddRange(model.Reserves);

            foreach(EpisodeModel episode in episodes)
            {
                SetEpisodeNumber(episode);
            }
        }
        private static string EpisodeTitleFromHtml(string episodeName)
        {
            // Example:
            // S1.E2 ∙ Paternity
            int index = 0;
            while (index < episodeName.Length && episodeName[index] != '∙')
            {
                index++;
            }
            index+=2;
            StringBuilder title = new StringBuilder();
            while(index < episodeName.Length)
            {
                title.Append(episodeName[index]);
                index++;
            }
            return title.ToString().Replace("&#39;", "'").Replace("&#x27;", "'");
        }
        private static string EpisodeDescriptionFromHtml(HtmlNode episodeNode)
        { 
            var descriptionNode = episodeNode.SelectSingleNode("..//..//div[@class='ipc-html-content-inner-div']");
            if (descriptionNode == null)
            {
                return null;
            }
            return descriptionNode.InnerHtml.Replace("&#39;","'").Replace("&#x27;","'");
        }
        private static bool IsTvShow(HtmlDocument htmlDocument)
        {
            string episodeGuide = "";
            var tempNode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"__next\"]/main/div/section[1]/section/div[3]/section/section/div[1]/div/div[1]/a/span[1]");
            if (tempNode == null || tempNode.InnerHtml != "Episode guide")
            {
                return false;
            }
            return true;

        }
        private static async Task<HtmlDocument> DownloadShowPageAsync(string IMDBId)
        {
            string url = $"https://www.imdb.com/title/{IMDBId}";
            HtmlDocument htmlDocument = new HtmlDocument();
            //Thread.Sleep(2);
            try
            {
                htmlDocument.LoadHtml(await GlobalConfig.httpClient.GetStringAsync(url));

            }
            catch (HttpRequestException)
            {
                return null;
            }            

            return htmlDocument;
        }
        private static async Task<HtmlDocument> DownloadSeasonPageAsync(string IMDBId, int seasonNo)
        {
            string url = $"https://www.imdb.com/title/{IMDBId}/episodes/?season={seasonNo}";

            HtmlDocument htmlDocument = new HtmlDocument();
            //Thread.Sleep(2);
            htmlDocument.LoadHtml(await GlobalConfig.httpClient.GetStringAsync(url));

            return htmlDocument;
        }
        private static async Task<HtmlNode> LookUpShow(string title, int searchIndex)
        {
            string url = $"https://www.imdb.com/find/?q={title.Replace(" ", "%20")}";
            HtmlDocument htmlDocument = new HtmlDocument();

            //Thread.Sleep(2);
            try
            {
                htmlDocument.LoadHtml(await GlobalConfig.httpClient.GetStringAsync(url));

            }
            catch (System.Net.Http.HttpRequestException)
            {
                return null;
            }            
            var sectionNode = htmlDocument.DocumentNode.SelectSingleNode("//section[@data-testid='find-results-section-title']");
            if (sectionNode == null)
            {
                return null;
            }
            var firstSearchResult = sectionNode.SelectSingleNode($".//div[2]/ul/li[{searchIndex}]/div[2]/div/a");
            if (firstSearchResult == null)
            {
                return null;
            }

            return firstSearchResult;
        }
        public static async Task<List<string>> LookUpTopFiveShows(string title)
        {
            List<string> links = new List<string>();
            List<Task<HtmlNode>> tasks = new List<Task<HtmlNode>>();
            for(int i = 1; i <= 5; i++)
            {
                tasks.Add(LookUpShow(title, i));
                //if (searchResult != null)
                //{
                //    links.Add(searchResult.GetAttributeValue("href", ""));
                //}
            }
            var temps = await Task.WhenAll(tasks);
            foreach (HtmlNode node in temps)
            {
                if (node != null)
                {
                    links.Add(node.GetAttributeValue("href", ""));
                }
            }
            return links;
        }
        private static string TitleFromPage(HtmlDocument htmlDocument)
        {
            string output = "";
            var node = htmlDocument.DocumentNode.SelectSingleNode("//h1[@data-testid='hero__pageTitle']");
            output = node.ChildNodes[0].InnerHtml;
            return output.Replace("&#39;", "'").Replace("&#x27;", "'");
        }
        private static string DescriptionFromPage(HtmlDocument htmlDocument)
        {
            string output = "";
            var node = htmlDocument.DocumentNode.SelectSingleNode("//p[@data-testid='plot']");
            output = node.ChildNodes.Last().InnerText;
            return output.Replace("&#39;", "'").Replace("&#x27;", "'");
        }
        private static string IMDBIdFromLink(string link)
        {
            // /title/tt0144084/?ref_=fn_al_tt_1
            // https://www.imdb.com/title/tt2359704/?ref_=fn_al_tt_1
            if (link.Length < 2 || link[1] != 't')
            {
                return null;
            }
            StringBuilder id = new StringBuilder();
            for (int i = 7; i < link.Length; i++)
            {
                if (link[i] == '/')
                    break;
                id.Append(link[i]);
            }


            return id.ToString();
        }
        public static string IdentifyTitleFromFileName(this string fileName)
        {
            string[] extensions = { "mkv", "mp4", "flv", "avi" };

            StringBuilder title = new StringBuilder();

            string[] segments = Path.GetFileName(fileName).RemoveSpecialCharacters().Split(' ');
            int n = segments.Length;

            // The last year mentioned in the filename.
            string lastYear = LastYearInFileName(Path.GetFileName(fileName).RemoveSpecialCharacters());
            for (int i = 0; i < n; i++)
            {
                if (segments[i] == "")
                {
                    continue;
                }
                string currSegment = segments[i].ToLower();
                if (i < n - 1 && 
                    (currSegment == "episode" || currSegment == "season" || currSegment == "e" || currSegment == "ep" || currSegment == "s") 
                    && segments[i+1].IsNumber())
                {
                    break;
                }
                if (i > 0 &&
                    (currSegment == "episode" || currSegment == "season" || currSegment == "e" || currSegment == "ep" || currSegment == "s")
                    && segments[i - 1].IsOrdinal() != -1)
                {
                    break;
                }
                if (segments[i].IsShortFormSeasonMarker() != null)
                {
                    break;
                }
                if (segments[i] == lastYear)
                {
                    title.Append(' ');
                    title.Append(segments[i]);
                    break;
                }
                if (extensions.Contains(currSegment))
                {
                    break;
                }
                if (currSegment == "360p" || currSegment == "480p" || currSegment == "720p" || currSegment == "1080p" || currSegment == "1440p")
                {
                    break;
                }
                if (title.Length > 0)
                {
                    title.Append(' ');
                }
                title.Append(segments[i]);
            }
            return title.ToString();
        }
        private static string LastYearInFileName(string fileName)
        {
            string[] segments = fileName.Split(' ');
            string output = "";
            foreach(string segment in segments)
            {
                int year = 0;
                int.TryParse(segment, out year);
                if (year > 1080 && year < 9999)
                {
                    output = segment;
                }
            }

            return output;
        }
        private static List<int> IsShortFormSeasonMarker(this string s)
        {
            // Check for formats like: ( S01E12 ), ( 01x12 ), (S01Ep12)

            StringBuilder sb = new StringBuilder();
            int num = 0;
            int episode = 0;
            int season = 0;
            for (int i = 0; i < s.Length; i++)
            {
                bool isNumber = false;
                num = 0;
                while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                {
                    isNumber = true;
                    num = num * 10 + (s[i] - '0');
                    i++;
                }
                if (!isNumber)
                {
                    sb.Append(s[i]);
                }
                else
                {
                    if (season == 0)
                    {
                        season = num;
                    }
                    else
                    {
                        episode = num;
                    }
                    sb.Append('.');
                    i--;
                }
            }
            List<int> output = new List<int>();
            output.Add(season);
            output.Add(episode);

            string result = sb.ToString().ToLower();
            if (result == "s.e." || result == ".x." || result == "s.ep.")
            {
                return output;
            }

            // Check for format like (s2 ep4)
            if (result == "s." || result == ".s")
            {
                return output;
            }
            if (result == "e." || result == ".e" || result == "ep." || result == ".ep")
            {
                output[1] = output[0];
                output[0] = 0;
                return output;
            }
            return null;
        }
        private static bool IsNumber(this string s)
        {
            int num = 0;
            if (int.TryParse(s, out num))
            {
                return true;
            }
            return false;
        }
        private static int IsOrdinal(this string s)
        {
            int num = 0;
            int i = 0;
            int n = s.Length;
            while (i < n && s[i] >= '0' && s[i] <= '9')
            {
                num = num * 10 + (s[i] - '0');
                i++;
            }
            string suffix = s.Substring(i);
            if ((num % 10 == 1 && (num / 10) % 10 != 1 && suffix == "st")
                || (num % 10 == 2 && (num / 10) % 10 != 1 && suffix == "nd")
                || (num % 10 == 3 && (num / 10) % 10 != 1 && suffix == "rd"))
            {
                return num;
            }
            else if (num != 0 && suffix == "th")
            {
                return num;
            }
            else
            {
                return -1;
            }
        }
        public static string SearchByTitle(string title)
        {
            // https://www.imdb.com/find/?q=house
            string url = $"https://www.imdb.com/find/?q={title.Replace(" ", "%20")}";

            throw new NotImplementedException();
        }
    }
}
