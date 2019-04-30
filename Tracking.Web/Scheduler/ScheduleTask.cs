using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Tracking.Web.Services;

namespace Tracking.Web.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {
        private readonly IImportExportService _importExportService;
        public ScheduleTask(IServiceScopeFactory serviceScopeFactory, IImportExportService importExportService) 
            : base(serviceScopeFactory)
        {
            _importExportService = importExportService;
        }

        protected override string Schedule => "*/5****"; // runs every 5 minutes
        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            _importExportService.ImportSurveysAudit();
            return Task.CompletedTask;
        }
    }
}
