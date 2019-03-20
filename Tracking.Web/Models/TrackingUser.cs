using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Tracking.Web.Models
{
    public class TrackingUser : IdentityUser
    {
        public List<Intervention> UsersInterventions { get; set; }
    }
}
