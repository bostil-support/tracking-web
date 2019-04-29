using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Tracking.Web.Models;
using Tracking.Web.Services;

namespace Tracking.DbInitialize
{
    public class ServiceInitialize
    {
        private static ServiceCollection _services;
        private static readonly string connString = "Data Source=.\\SQLEXPRESS2;Initial Catalog=TrackingDB;Integrated Security=True;MultipleActiveResultSets=true";
        public static ServiceProvider ServiceProviderInitialize()
        {
            _services = new ServiceCollection();
            _services.AddDbContext<DbInitializeContext>()
             .AddIdentity<TrackingUser, TrackingRole>()
             .AddEntityFrameworkStores<DbInitializeContext>();

            _services.AddImportExportService(connString);            

            return _services.BuildServiceProvider();
        }
    }
}
