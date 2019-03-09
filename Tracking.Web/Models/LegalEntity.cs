using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class LegalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // has_many interventions
        List<Intervention> Interventions { get; set; }
    }
}
