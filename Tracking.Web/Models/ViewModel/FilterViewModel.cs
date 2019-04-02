using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models.ViewModel
{
    public class FilterViewModel
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Status { get; set; }
        public string Severity { get; set; }
        //List<LegalEntity> LegalEntities { get; set; }
        //List<Status> Statuses { get; set; }
    }
}
