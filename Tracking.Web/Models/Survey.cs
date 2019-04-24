using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class Survey
    {
        public string Id { get; set; }

        [Column("Titolo_Rilievo")]
        public string Title { get; set; }

        /// <summary>
        /// Field Descrizione from mockups. It`s from italian means Description
        /// Survey description
        /// </summary>
        [Display(Name = "Descrizione")]
        [Column("Descrizione_Rilievo")]
        public string Description { get; set; }

        /// <summary>
        /// This is the date of the latest import on our db
        /// </summary>
        [Display(Name = "Data inserimento")]
        public DateTime ImportDownloadDate { get; set; }

        /// <summary>
        /// Survey severity
        /// In Itallian mockup field Severitta rillievo
        /// </summary>
        [Display(Name = "Severita")]
        [Column("Severita_Rilievo")]
        public string SurveySeverity { get; set; }

        /// <summary>
        /// Field Validatore from mockups. It`s means from italian Validator
        /// </summary>
        //[Display(Name = "Validatore")]
        //public string ValidatorAttribute { get; set; }

        /// <summary>
        /// Is the user who made the survey and found the risk.
        /// In italian it is translated as Utente Censimento. 
        /// </summary>
        [Display(Name = "Utente Censimento")]
        [Column("Utente_Censimento")]
        public string UserName { get; set; }

        /// <summary>
        ///// In itallian mockup field Area normativa
        ///// </summary>
        //[Display(Name = "Area Normativa")]
        //public string SrepCluster { get; set; }///////////////////////////////

        ///// <summary>
        ///// In itallian mockup field Macro Requisito Normativo
        ///// </summary>
        //[Display(Name = "Macro Requisito Normativo")]
        //public string ScrepArea { get; set; }////////////////////////

        /// <summary>
        /// Bank or another financial institute 
        /// </summary>
        [Column("Id_Banca")]
        public int LegalEntityId { get; set; }

        /// <summary>
        /// Bank`s code 
        /// </summary>
        public string Cod_ABI { get; set; }

        /// <summary>
        /// Bank`s name
        /// </summary>
        [Column("Legal_Entity")]
        public string LegalEntityName { get; set; }

        /// <summary>
        /// Owner Azione di mitigazione
        /// </summary>
        [Display(Name = "Owner Azione di Mitigazione")]
        [Column("Owner_Azione_di_Mitigazione")]
        public string ActionOwner { get; set; }

        /// <summary>
        /// Azione di mitigazione - Descrizione
        /// </summary>
        [Display(Name = "Descrizione")]
        [Column("Azione_di_Mitigazione")]
        public string ActionDescription { get; set; }

        /// <summary>
        /// Status. In Itallian mockup field Stato
        /// </summary>
        public int? StatusId { get; set; }
        [Display(Name = "Stato")]////////////////////////////////////////////////
        public Status Status { get; set; }

        /// <summary>
        /// New expiry date
        /// </summary>
        [Display(Name = "Scandeza Rilievo")]
        [Column("Data_Scadenza")]
        public DateTime? DueDateLocal { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        public List<Note> Notes { get; set; }

        /// <summary>
        /// Intervention
        /// </summary>
        [Column("Id_Intervento")]
        public int InterventionId { get; set; }

        [Column("Titolo_Intervento")]
        public string InterventionName { get; set; }

        /// <summary>
        /// survey musst belongs to different type of risks 
        /// </summary>
        //public int? RiskTypeId { get; set; }
        //public RiskType RiskType { get; set; }

        /// <summary>
        /// This field is different in the versions of the Audit and Compliance DB  
        /// </summary>
        [Column("Oggetto_Valutato")]
        public string EvaluatedObject { get; set; }

        [Column("Id_Oggetto_Valutato")]
        public int EvaluatedObjectId { get; set; }
    }
}
