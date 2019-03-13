using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Tracking.Web.Models
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }

        public Role() : base()
        {
        }

        public Role(string roleName, string description) : base(roleName)
        {
            Description = description;
        }
    }
}
