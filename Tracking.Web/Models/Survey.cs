using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class Survey : BaseEntity
    {
        public string Title { get; set; }

        /// <summary>
        /// Field Descrizione from mockups. It`s from italian means Description
        /// Survey description
        /// </summary>
        [Display(Name = "Descrizione")]
        public string Description { get; set; }

        /// <summary>
        /// This is the date of the latest import on our db
        /// </summary>
        public DateTime ImportDownloadDate { get; set; }

        /// <summary>
        /// Survey severity
        /// In Itallian mockup field Severitta rillievo
        /// </summary>
        [Display(Name = "Severita")]
        public string SurveySeverity { get; set; }

        /// <summary>
        /// Field Validatore from mockups. It`s means from italian Validator
        /// </summary>
        [Display(Name = "Validatore")]
        public string ValidatorAttribute { get; set; }

        /// <summary>
        /// Is the user who made the survey and found the risk.
        /// In italian it is translated as Utente Censimento. 
        /// </summary>
        [Display(Name = "Utente Censimento")]
        public string UserName { get; set; }

        /// <summary>
        /// In itallian mockup field Area normativa
        /// </summary>
        [Display(Name = "Area Normativa")]
        public string SrepCluster { get; set; }
        /// <summary>
        /// In itallian mockup field Macro Requisito Normativo
        /// </summary>
        [Display(Name = "Macro Requisito Normativo")]
        public string ScrepArea { get; set; }
        
        /// <summary>
        /// Bank or another financial institute 
        /// </summary>
        public int LegalEntityId { get; set; }
        public LegalEntity LegalEntity { get; set; }

        /// <summary>
        /// Azione di mitigazione - Owner
        /// </summary>
        [Display(Name = "Owner")]
        public string ActionOwner { get; set; }

        /// <summary>
        /// Azione di mitigazione - Descrizione
        /// </summary>
        [Display(Name = "Descrizione")]
        public string ActionDescription { get; set; }

        /// <summary>
        /// Status. In Itallian mockup field Stato
        /// </summary>
        public int StatusId { get; set; }
        [Display(Name = "Stato")]
        public Status Status { get; set; }

        /// <summary>
        ///  expiry date
        /// </summary>
        [Display(Name = "Skadenza rilievo")]
        public DateTime DueDateOriginal { get; set; }
        
        /// <summary>
        /// New expiry date
        /// </summary>
        [Display(Name = "Nuova Data Scadenza")]
        public DateTime DueDateLocal { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        public List<Note> Notes { get; set; }
        
        /// <summary>
        /// survey is part of intervention
        /// </summary>
        public int InterventionId { get; set; }
        public Intervention Intervention { get; set; }

        /// <summary>
        /// survey musst belongs to different type of risks 
        /// </summary>
        public int RiskTypeId { get; set; }
        public RiskType RiskType { get; set; }
    }
}
