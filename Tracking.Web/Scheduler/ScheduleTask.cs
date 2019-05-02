using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Tracking.Web.Logigng;
using Tracking.Web.Services;

namespace Tracking.Web.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {
        private readonly IImportExportService _importExportService;
        private readonly ILogger<ScheduleTask> _logger;
        public ScheduleTask(IServiceScopeFactory serviceScopeFactory, IImportExportService importExportService) 
            : base(serviceScopeFactory)
        {
            _importExportService = importExportService;
        }

        protected override string Schedule => "59 23 * * *"; // runs every day 23:59 minutes
        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            _importExportService.ImportSurveysAudit();
            _importExportService.ImportDescriptiveAttributes();
            _importExportService.ImportSurveysComplaince();
            _importExportService.ImportDescriptiveAttributesComplaince();
            
            return Task.CompletedTask;
        }
    }
}
