using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    /// <summary>
    /// Represents a block Storico note(Notes)
    /// </summary>
    public class Note : BaseEntity
    {
        /// <summary>
        /// Description of note(Aggiungi nota)
        /// </summary>
        [Display(Name = "Aggiungi nota")]
        public string Description { get; set; }
        /// <summary>
        /// Attached file
        /// </summary>        
        public File File { get; set; }

        /// <summary>
        /// User of new note
        /// </summary>
        public int UserId { get; set; }
        public TrackingUser User { get; set; }

        /// <summary>
        /// relationship with Survey
        /// </summary>
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
    }
}
