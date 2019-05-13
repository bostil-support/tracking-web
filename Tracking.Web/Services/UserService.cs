using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tracking.Web.Models;

namespace Tracking.Web.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<TrackingUser> _userManager;
        private readonly RoleManager<TrackingRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<TrackingUser> userManager,
            RoleManager<TrackingRole> roleManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TrackingUser> GetCurrentUserAsync()
        {
            string userName = "";
            try
            {
                userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            }
            catch (Exception e)
            {
                var err = e.Message;
            }
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }
    }
}
