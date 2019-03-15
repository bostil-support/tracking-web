using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<TrackingUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string complianceEmail = "compliance@tracking.com";
            string businessEmail = "business@tracking.com";
            string password = "Qwerty123!";
            if (await roleManager.FindByNameAsync("compliance") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("compliance"));
            }
            if (await roleManager.FindByNameAsync("business") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("business"));
            }

            if (await userManager.FindByNameAsync(complianceEmail) == null)
            {
                TrackingUser user = new TrackingUser { Email = complianceEmail, UserName = complianceEmail };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "compliance");
                }
            }

            if (await userManager.FindByNameAsync(businessEmail) == null)
            {
                TrackingUser user = new TrackingUser { Email = businessEmail, UserName = businessEmail };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "business");
                }
            }
        }
    }
}
