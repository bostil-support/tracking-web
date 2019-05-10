using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Models;

namespace Tracking.Web.Models.ViewModel
{
    public class SurveyViewModel
    {
        /// <summary>
        /// survey id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// current status
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// statuses list, we use for select tag values
        /// </summary>
        public List<SelectListItem> Statuses { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Survey title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Field Descrizione from mockups. It`s from italian means Description
        /// Survey description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This is the date of the latest import on our db
        /// </summary>
        public DateTime ImportDownloadDate { get; set; }

        /// <summary>
        /// Survey severity
        /// In Itallian mockup field Severitta rillievo
        /// </summary>
        public string SurveySeverity { get; set; }

        /// <summary>
        /// Field Validatore from mockups. It`s means from italian Validator
        /// </summary>
        public string ValidatorAttribute { get; set; }

        /// <summary>
        /// Is the user who made the survey and found the risk.
        /// In italian it is translated as Utente Censimento. 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// In itallian mockup field Area normativa
        /// </summary>
        public string SrepCluster { get; set; }
        /// <summary>
        /// In itallian mockup field Macro Requisito Normativo
        /// </summary>
        public string ScrepArea { get; set; }

        /// <summary>
        /// Bank or another financial institute 
        /// </summary>
        public string Cod_ABI { get; set; }

        public string LegalEntityName { get; set; }

        /// <summary>
        /// Azione di mitigazione - Owner
        /// </summary>
        public string ActionOwner { get; set; }

        /// <summary>
        /// Azione di mitigazione - Descrizione
        /// </summary>
        public string ActionDescription { get; set; }

        /// <summary>
        ///  expiry date
        /// </summary>
        //public DateTime DueDateOriginal { get; set; }

        /// <summary>
        /// New expiry date
        /// </summary>
        public string DueDateLocal { get; set; }

        /// <summary>
        /// New note 
        /// </summary>
        public Note Note { get; set; }

        /// <summary>
        /// Notes list of survey
        /// </summary>
        public List<Note> Notes { get; set; }

        /// <summary>
        /// Intervention id
        /// survey is part of intervention
        /// </summary>
        public int InterventionId { get; set; }

        /// <summary>
        /// List all risks. It will be used for select tag
        /// </summary>
        public List<RiskType> RiskTypes { get; set; }

        /// <summary>
        /// User role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Titolo Intervento
        /// </summary>
        public string InterventionName { get; set; }

        /// <summary>
        /// Ogetto_Valutato
        /// </summary>
        public string EvaluatedObject { get; set; }

        public DescriptiveAttributes DescriptiveAttributes { get; set; }

        public bool IsChanged { get; set; }
    }
}
