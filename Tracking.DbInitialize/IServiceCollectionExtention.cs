using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tracking.Web.Services;

namespace Tracking.DbInitialize
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddImportExportService(this IServiceCollection services, string connString)
        {
            services.AddTransient<IImportExportService, ImportExportService>(provider => new ImportExportService(connString));
            return services;
        }
    }
}
