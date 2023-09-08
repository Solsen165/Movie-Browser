using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserLibrary.Models
{
    public class ProgressReportModel
    {
        public int percentage;
        public string currOperation;
        public int filesLoaded;
        public int totalFiles = int.MaxValue;
    }
}
