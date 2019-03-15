using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Tracking.Web.Models;

namespace Tracking.DbInitialize
{
    public class ServiceInitialize
    {
        private static ServiceCollection _services;

        public static ServiceProvider ServiceProviderInitialize()
        {
            _services = new ServiceCollection();
            _services.AddDbContext<DbInitializeContext>()
             .AddIdentity<TrackingUser, TrackingRole>()
             .AddEntityFrameworkStores<DbInitializeContext>();

            return _services.BuildServiceProvider();
        }
    }
}
