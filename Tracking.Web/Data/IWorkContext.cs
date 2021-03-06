﻿using System.Threading.Tasks;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public interface IWorkContext
    {
        /// <summary>
        /// Gets the current customer
        /// </summary>
        Task<TrackingUser> GetCurrentUserAsync();

        /// <summary>
        /// Gets the current user role
        /// </summary>
        string GetCurrentUserRole();
    }
}
