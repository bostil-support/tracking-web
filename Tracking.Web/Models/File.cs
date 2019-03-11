using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class File : BaseEntity
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
    }
}
