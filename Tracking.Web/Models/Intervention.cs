using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class Intervention
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // Descrizione
        public string Description { get; set; }

        // Validatore 
        public int ValidatorId { get; set; }

        [ForeignKey("TeamInfoKey")]
        public User User { get; set; }

        public int LegalEntityId { get; set; }
        public LegalEntity LegalEntity { get; set; }

        
    }
}
