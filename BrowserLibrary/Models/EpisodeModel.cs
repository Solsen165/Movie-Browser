using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserLibrary.Models
{
    public class EpisodeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IMDBId { get; set; }
        public ShowModel ParentShow { get; set; }
        public int ParentShowId { get; set; }
        public int EpisodeNumber { get; set; }
        public int SeasonNumber { get; set; }
        public string FilePath { get; set; }
        public int FileId { get; set; }
        public int Watched { get; set; }
        public string TitleWithEpisodeNumber
        {
            get { return $"{EpisodeNumber} - {Title}"; }
        }
        public string TitleWithSeasonEpisodeNumber
        {
            get { return $"S{SeasonNumber}E{EpisodeNumber} - {Title}"; }
        }
        public string FileName
        {
            get { return Path.GetFileName(FilePath); }
        }
    }
}
