using BrowserLibrary;
using BrowserLibrary.Models;
using HtmlAgilityPack;

namespace Browser.UnitTests
{
    [TestClass]
    public sealed class ShowLoaderTests
    {
        [TestInitialize]
        public void Setup()
        {
            HttpClientHandler hch = new HttpClientHandler();
            hch.Proxy = null;
            hch.UseProxy = false;
            GlobalConfig.httpClient = new HttpClient(hch);
        }

        [TestMethod]
        [DataRow("House - [4x01] - Alone",4,1)]
        [DataRow("The.Office.US.S02E05.EXTENDED.1080p.WEBRip.x265-RARBG",2,5)]
        [DataRow("House MD Season 1 Episode 08 - Poison",1,8)]
        [DataRow("Jujutsu Kaisen 2nd Season Episode 20",2,20)]
        public void SetEpisodeNumberTest(string filename, int seasonNo, int episodeNo)
        {
            EpisodeModel episodeModel = new EpisodeModel();
            episodeModel.FilePath = filename;

            ShowLoader.SetEpisodeNumber(episodeModel);

            bool good = episodeModel.SeasonNumber == seasonNo && episodeModel.EpisodeNumber == episodeNo;
            Assert.IsTrue(good);
        }

        [TestMethod]
        [DataRow("2012.2009.BluRay.1080p.x264.YIFY.mp4","2012 2009")]
        [DataRow("Blade Runner 2049.HDRip.XviD.AC3-EVO.avi","Blade Runner 2049")]
        [DataRow("2001 A Space Odyssey 1968 Remastered 1080p BluRay HEVC x265 5.1 BONE.mkv","2001 A Space Odyssey 1968")]
        public void IdentifyTitleFromFileName_MovieWithYearInTitle(string filename, string answer)
        {
            string testingTitle = ShowLoader.IdentifyTitleFromFileName(filename);
            
            Assert.AreEqual(testingTitle, answer);
        }

        [TestMethod]
        [DataRow("Blade Runner 2049.HDRip.XviD.AC3-EVO.avi", "Blade Runner 2049", "Young Blade Runner K's discovery of a long-buried secret leads him to track down former Blade Runner Rick Deckard, who's been missing for thirty years.", 0)]
        [DataRow("2001 A Space Odyssey 1968 Remastered 1080p BluRay HEVC x265 5.1 BONE.mkv", "2001: A Space Odyssey", "When a mysterious artifact is uncovered on the Moon, a spacecraft manned by two humans and one supercomputer is sent to Jupiter to find its origins.", 0)]
        [DataRow("House - [4x01] - Alone", "House", "Using a crack team of doctors and his wits, an antisocial maverick doctor specializing in diagnostic medicine does whatever it takes to solve puzzling cases that come his way.", 8)]
        [DataRow("The.Office.US.S02E05.EXTENDED.1080p.WEBRip.x265-RARBG", "The Office", "A mockumentary on a group of typical office workers, where the workday consists of ego clashes, inappropriate behavior, tedium and romance.", 9)]
        public async Task LookupInfoTest(string filename, string title, string description, int NoOfSeasons)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            ProgressReportModel progressReportModel = new ProgressReportModel();
            ShowModel show = await ShowLoader.CreateShow(title, progress, progressReportModel);

            Assert.AreEqual(title, show.Title);
            Assert.AreEqual(description, show.Description);
            Assert.AreEqual(NoOfSeasons, show.NoOfSeasons);
        }
    }
}
