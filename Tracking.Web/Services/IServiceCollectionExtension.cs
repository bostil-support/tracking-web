using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Services
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
