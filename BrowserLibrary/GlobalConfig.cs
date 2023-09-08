using BrowserLibrary.DataAccess;
using BrowserLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrowserLibrary
{
    public class GlobalConfig
    {
        private static string _filePath;
        public static HttpClient httpClient;

        public static List<ShowModel> allShows = new List<ShowModel>();

        public static void SetFilePath(string filePath)
        {
            //ConfigurationManager.AppSettings.Set("filePath", filePath);
            _filePath = filePath;
        }

        public static string GetFilePath()
        {
            //return ConfigurationManager.AppSettings["filePath"];
            return _filePath;
        }

    }
}
