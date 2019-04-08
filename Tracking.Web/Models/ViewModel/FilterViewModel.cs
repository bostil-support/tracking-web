using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models.ViewModel
{
    public class FilterViewModel
    {
        public List<string> LegalEntities { get; set; }
        public List<string> Owners { get; set; }
        public List<string> Statuses { get; set; }
        public List<string> Severities { get; set; }
    }
}
