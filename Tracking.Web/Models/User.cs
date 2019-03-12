using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Tracking.Web.Models
{
    public class User : IdentityUser
    {
        public List<Intervention> Interventions { get; set; }
        public List<Intervention> UsersInterventions { get; set; }
    }
}
