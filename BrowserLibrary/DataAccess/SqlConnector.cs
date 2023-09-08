using BrowserLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserLibrary.DataAccess
{
    public class SqlConnector
    {
        public static List<ShowModel> LoadShows()
        {
            List<ShowModel> output;
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                output = cnn.Query<ShowModel>("select * from Shows order by Title", new DynamicParameters()).ToList();

                foreach(ShowModel show in output)
                {
                    List<EpisodeModel> allEpisodes = LoadEpisodes(show.Id, cnn);
                    if (allEpisodes.Count > 0)
                    {
                        for (int i = 1; i <= show.NoOfSeasons; i++)
                        {
                            int NoOfEpisodes = cnn.Query<int>($"select Count(*) from Episodes where ParentShowId={show.Id} and SeasonNumber={i}").First();
                            show.Seasons.Add(new List<EpisodeModel>(new EpisodeModel[NoOfEpisodes]));
                        }

                        foreach (EpisodeModel episode in allEpisodes)
                        {
                            if (episode.FilePath != null && !File.Exists(episode.FilePath))
                            {
                                //DeleteEpisodeFile(episode.FileId, cnn);
                                episode.FilePath = null;
                            }
                            if (episode.EpisodeNumber > 0 && episode.SeasonNumber > 0 && show.Seasons[episode.SeasonNumber - 1][episode.EpisodeNumber - 1] == null)
                            {
                                show.Seasons[episode.SeasonNumber - 1][episode.EpisodeNumber - 1] = episode;
                            }
                            else if (episode.FilePath != null)
                            {
                                show.Reserves.Add(episode);
                            }

                            episode.ParentShow = show;
                            if (episode.FilePath == null)
                            {
                                episode.Watched = 0;
                            }
                        }
                    }

                    show.OtherTitles = LoadOtherTitles(show.Id, cnn);
                    List<EpisodeModel> reserves = LoadReserves(show.Id, cnn);
                    foreach (EpisodeModel episode in reserves)
                    {
                        if (episode.FilePath != null && !File.Exists(episode.FilePath))
                        {
                            //DeleteEpisodeFile(episode.FileId, cnn);
                            episode.FilePath = null;
                        }
                        if (episode.FilePath != null)
                        {
                            episode.ParentShow = show;
                            show.Reserves.Add(episode);
                        }
                    }
                    if (show.Type == "TvShow" && show.Reserves.Count > 0 && show.Seasons.Count > 0)
                    {
                        ShowLoader.ArrangeIntoSeasons(show);
                    }
                }
            }
            return output;
        }
        public static List<EpisodeModel> LoadEpisodes(int showId, IDbConnection cnn)
        {
            List<EpisodeModel> output;
            //output = cnn.Query<EpisodeModel>($"select * from Episodes where ParentId = {showId}", new DynamicParameters()).ToList();

            output = cnn.Query<EpisodeModel>(@$"select e.Id, Title, Description, IMDBId, e.ParentShowId, EpisodeNumber, SeasonNumber, FilePath, FileId, Watched
                                            from Episodes e Left Join EpisodeFiles ef 
                                            on e.Id = ef.EpisodeId
                                            where e.ParentShowId = {showId}", new DynamicParameters()).ToList();

            return output;
        }
        public static List<EpisodeModel> LoadReserves(int showId, IDbConnection cnn)
        {
            List<EpisodeModel> output;
            output = cnn.Query<EpisodeModel>(@$"select * from EpisodeFiles 
                                            where ParentShowId = {showId} and EpisodeId = 0", new DynamicParameters()).ToList();

            return output;
        }
        public static List<string> LoadOtherTitles(int showId, IDbConnection cnn)
        {
            List<string> output;
            output = cnn.Query<string>($"select Title from ShowOtherTitles where ShowId = {showId}").ToList();

            return output;
        }
        public static List<string> LoadFolderPaths()
        {
            List<string> output;
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                output = cnn.Query<string>("select FolderPath from FolderPaths").ToList();
            }
            return output;
        }
        public static void CreateShow(ShowModel model)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                model.Id = cnn.Query<int>("insert into Shows (Title, IMDBId, Type, Description, NoOfSeasons) values (@Title, @IMDBId, @Type, @Description, @NoOfSeasons); select last_insert_rowid();", model).First();

            }
        }
        public static void CreateEpisode(EpisodeModel model)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                model.Id = cnn.Query<int>("insert into Episodes (Title, Description, IMDBId, ParentShowId, EpisodeNumber, SeasonNumber) values (@Title, @Description, @IMDBId, @ParentShowId, @EpisodeNumber, @SeasonNumber); select last_insert_rowid();", model).First();
            }
        }
        public static void CreateEpisodeMultiple(List<EpisodeModel> models)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                foreach (EpisodeModel model in models)
                {
                    model.Id = cnn.Query<int>("insert into Episodes (Title, Description, IMDBId, ParentShowId, EpisodeNumber, SeasonNumber) values (@Title, @Description, @IMDBId, @ParentShowId, @EpisodeNumber, @SeasonNumber); select last_insert_rowid();", model).First();
                }
            }
        }

        public static void CreateEpisodeFile(EpisodeModel model)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                model.FileId = cnn.Query<int>($"insert into EpisodeFiles (EpisodeId, ParentShowId, FilePath) values ({model.Id}, {model.ParentShowId}, \"{model.FilePath}\"); select last_insert_rowid();",model).First();
            }
        }
        public static void CreateFolderPath(string folderPath)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into FolderPaths (FolderPath) values (\"{folderPath}\")");
            }
        }
        public static Dictionary<string,int> LoadAllFilePaths()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query("select FilePath, ParentShowId from EpisodeFiles").ToDictionary(
                    row => (string) row.FilePath,
                    row => (int)row.ParentShowId);

                return output;
            }
        } 

        public static void InsertOtherTitle(ShowModel model)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into ShowOtherTitles (ShowId, Title) values ({model.Id}, \"{model.OtherTitles.Last()}\")");
            }
        }

        //private static void DeleteEpisode(int id, IDbConnection cnn)
        //{
        //    cnn.Execute($"delete from Episodes where Id = {id}");
        //}

        private static void DeleteEpisodeFile(int id, IDbConnection cnn)
        {
            cnn.Execute($"delete from EpisodeFiles where FileId = {id}");
        }
        public static void DeleteOtherTitle(ShowModel model, string title)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"delete from ShowOtherTitles where ShowId = {model.Id} and Title = \"{title}\"");
            }
        }
        public static void DeleteFolderPath(string folderPath)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"delete from FolderPaths where FolderPath = \"{folderPath}\"");
            }
        }
        public static void UpdateShow(ShowModel model)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update Shows set Title = \"{model.Title}\", Description = \"{model.Description}\" where Id = {model.Id}");
            }
        }
        public static void UpdateEpisodeFile(EpisodeModel model)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update EpisodeFiles set EpisodeId = {model.Id}, ParentShowId = {model.ParentShowId} where FileId = {model.FileId}");
            }
        }
        public static void UpdateEpisodeWatched(EpisodeModel model)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update Episodes set Watched = {model.Watched} where Id = {model.Id}");
            }
        }

        public static void UpdateEpisodeWatchedMultiple(int watched, int seasonNo, ShowModel parent, List<int> episodeNo)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < episodeNo.Count; i++)
            {
                sb.Append($"{episodeNo[i]}");
                if (i < episodeNo.Count - 1)
                {
                    sb.Append(',');
                }
            }
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update Episodes set Watched = {watched} where ParentShowId = {parent.Id} and SeasonNumber = {seasonNo} and EpisodeNumber in ({sb})");
            }
        }

        public static void UpdateEpisodeWatchedBySeasons(int watched, List<int> seasonNo, ShowModel parent)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < seasonNo.Count; i++)
            {
                sb.Append($"{seasonNo[i]}");
                if (i < seasonNo.Count - 1)
                {
                    sb.Append(',');
                }
            }

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update Episodes set Watched = {watched} where ParentShowId = {parent.Id} and SeasonNumber in ({sb})");
            }
        }


        public static void DeleteEverything()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from sqlite_sequence;delete from EpisodeFiles;delete from FolderPaths;delete from Episodes;delete from ShowOtherTitles;delete from Shows;");
            }
        }
        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Browser"].ConnectionString;
        }
    }
}
