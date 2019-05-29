using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Data;
using Tracking.Web.Services;

/*
 private readonly IServiceScopeFactory scopeFactory;

    public MyHostedService(IServiceScopeFactory scopeFactory)
    {
        this.scopeFactory = scopeFactory;
    }

    public void DoWork()
    {
        using (var scope = scopeFactory.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            …
        }
    }
 */

namespace Tracking.Web.Scheduler
{
    public class ScheduleTask : ScheduledProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IImportExportService _importExportService;
        private readonly ILogger<ScheduleTask> _logger;
        public ScheduleTask(IServiceScopeFactory serviceScopeFactory, 
            IImportExportService importExportService,
            ILogger<ScheduleTask> logger,
            IServiceScopeFactory scopeFactory) 
            : base(serviceScopeFactory)
        {
            _importExportService = importExportService;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override string Schedule => "59 23 * * *"; // runs every day 23:59 minutes
        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            int result, result1, result2;
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                result1 = dbContext.Surveys.Count();
            }

            _logger.LogInformation($"Import started: {DateTime.Now}");
            _importExportService.ImportSurveysAudit();
            _importExportService.ImportDescriptiveAttributes();
            _importExportService.ImportSurveysComplaince();
            _importExportService.ImportDescriptiveAttributesComplaince();
            
            _logger.LogInformation($"Import finished: {DateTime.Now}");

            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                result2 = dbContext.Surveys.Count();
                result = result2 - result1;
            }

            _logger.LogInformation($"Imported: {result} records");

            return Task.CompletedTask;
        }
    }
}
