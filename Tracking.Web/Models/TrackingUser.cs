using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Tracking.Web.Models
{
    public class TrackingUser : IdentityUser
    {
        public string ReturnUrl { get; set; }
        public List<Intervention> UsersInterventions { get; set; }
        [Column("Legal_Entity")]
        public string LegalEntityName { get; set; }
        [Column("Cod_ABI")]
        public string CodeABI { get; set; }
    }
}
