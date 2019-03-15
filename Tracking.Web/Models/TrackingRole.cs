using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Tracking.Web.Models
{
    public class TrackingRole : IdentityRole
    {
        public string Description { get; set; }

        /*
        public TrackingRole() : base()
        {
        }
        
        public TrackingRole(string roleName, string description) : base(roleName)
        {
            Description = description;
        }
        */
    }
}
