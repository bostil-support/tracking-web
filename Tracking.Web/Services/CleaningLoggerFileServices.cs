using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Services
{
    public class CleaningLoggerFileServices
    {
        public void CleanFile()
        {
            string path = Path.Combine(".\\Logigng", "logger.txt");
            File.WriteAllText(path,String.Empty);
        }
    }
}
