using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class Intervention : BaseEntity
    {
        public string Title { get; set; }
        // Descrizione
        public string Description { get; set; }

        // Validatore 
        public string ValidatorId { get; set; }
        public User Validator { get; set; }

        public int LegalEntityId { get; set; }
        public LegalEntity LegalEntity { get; set; }

        // Area normativa
        public string RegulatoryArea { get; set; }
        // Macro Requisito Normativo
        public string MacroRegulatoryRequiment { get; set; }

        // relationship Status
        public int StatusId { get; set; }
        public Status Status { get; set; }

        // relationship with Note
        public List<Note> Notes { get; set; }



    }
}
