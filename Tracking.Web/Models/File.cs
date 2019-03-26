using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class File : BaseEntity
    {
        public File() { }

        public File(string Title, string FilePath)
        {
            this.Title = Title;
            this.FilePath = FilePath;
        }

        public string Title { get; set; }
        public string FilePath { get; set; }
    }
}
