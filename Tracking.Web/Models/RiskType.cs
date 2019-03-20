using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class RiskType : BaseEntity
    {
        public string Name { get; set; }

        public List<Survey> Surveys { get; set; }
    }
}
