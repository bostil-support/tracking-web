using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    /// <summary>
    /// Represents a block Storico note(Notes)
    /// </summary>
    public class Note : BaseEntity
    {
        // Description of note(Aggiungi nota)
        public string Description { get; set; }
        // Attached pdf file 
        public File File { get; set; }

        // relationship with User
        public int UserId { get; set; }
        public TrackingUser User { get; set; }

        // relationship with Intervantion
        public int InterventionId { get; set; }
        public Intervention Intervention { get; set; }

    }
}
