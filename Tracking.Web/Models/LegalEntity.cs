using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class LegalEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
        // Cod. Legal Entity
        public string Code { get; set; }
        // has_many interventions
        List<Survey> Surveys { get; set; }
    }
}
