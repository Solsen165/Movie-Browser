using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserLibrary.Models
{
    public class ShowModel
    {
        /// <summary>
        /// Unique Identifier for the show.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the show.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Link to the show's IMDB page.
        /// </summary>
        public string IMDBId { get; set; }

        /// <summary>
        /// Type is either Movie or TvShow.
        /// </summary>
        public string Type { get; set; }
        public string Description { get; set; }
        //public List<int> NoOfEpisodes { get; set; } = new List<int>();
        public int NoOfSeasons { get; set; }
        /// <summary>
        /// List of seasons of the show.
        /// A movie would have only one episode.
        /// </summary>
        public List<List<EpisodeModel>> Seasons { get; set; } = new List<List<EpisodeModel>>();
        /// <summary>
        /// List of extra episodes that may not fit the given format for one reason or another.
        /// </summary>
        public List<EpisodeModel> Reserves { get; set; } = new List<EpisodeModel>();
        /// <summary>
        /// List of other titles for the show found in the file names.
        /// </summary>
        public List<string> OtherTitles { get; set; } = new List<string>();
    }
}
