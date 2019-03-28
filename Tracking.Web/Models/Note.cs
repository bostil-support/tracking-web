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
        public int? FileId { get; set; }
        public File File { get; set; }

        /// <summary>
        /// User of new note
        /// </summary>
        public string UserId { get; set; }
        public TrackingUser User { get; set; }

        /// <summary>
        /// relationship with Survey
        /// </summary>
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        
        /// <summary>
        /// Date of notice
        /// </summary>
        public DateTime Date { get; set; }

        public Note() { }

        public Note(string Description, string UserId, int SurveyId, DateTime Date, int?FileId = null)
        {
            this.Description = Description;
            this.FileId = FileId;
            this.UserId = UserId;
            this.SurveyId = SurveyId;
            this.Date = Date;
        }
    }
}
