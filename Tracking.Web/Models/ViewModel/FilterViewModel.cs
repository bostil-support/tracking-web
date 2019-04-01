using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models.ViewModel
{
    public class FilterViewModel
    {
        List<LegalEntity> LegalEntities { get; set; }
        List<Status> Statuses { get; set; }
    }
}
