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
        /// <summary>
        /// One intervention must include surveys 
        /// </summary>
        public List<Survey> Surveys { get; set; }

        public Intervention()
        {
            Surveys = new List<Survey>();
        }
    }
}
