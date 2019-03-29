using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public class WorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<TrackingUser> _userManager;

        public WorkContext(IHttpContextAccessor httpContextAccessor, UserManager<TrackingUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<TrackingUser> GetCurrentUserAsync()
        {
            // to get current user ID
            var userId = _httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value;

            // to get current user info
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

    }
}
