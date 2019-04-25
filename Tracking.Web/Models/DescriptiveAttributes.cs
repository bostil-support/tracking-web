using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class DescriptiveAttributes : BaseEntity
    {
        public Guid UID_Analisi { get; set; }
        [Column("Id_Rilievo")]
        public  string SurveyId { get; set; }
        public Survey Survey { get; set; }
		public string Processo_Livello_1 { get; set; }
		public string Processo_Livello_2 { get; set; }
		public string Processo_Livello_3 { get; set; }
		public string Normativa_Livello_1 { get; set; }
		public string Normativa_Livello_2 { get; set; }
		public string Normativa_Livello_3 { get; set; }
        [Column("Rischio")]
        public string Risk { get; set; }
    }
}
