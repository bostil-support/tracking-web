using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracking.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracking.Web.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Tracking.Web.Managers;
using Microsoft.Extensions.Logging;
using Serilog;
using Tracking.Web.Services;
using Microsoft.Extensions.Hosting;
using Tracking.Web.Scheduler;
using Tracking.Web.Logigng;
using Hangfire;

namespace Tracking.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionToAudience = "Server=192.168.13.126,1433;Database=CCB_AuditXOP;User ID=svc_everestech;Password=dBY6V!cF5cZC=KL-";
            string connectionToComliance = "Server=192.168.13.126,1433;Database=CCB_ComplianceXOP;User ID=svc_everestech;Password=dBY6V!cF5cZC=KL-";
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<TrackingUser, TrackingRole>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<SignInManager<TrackingUser>, SignInManager<TrackingUser>>();
            services.AddScoped<UserManager<TrackingUser>, UserManager<TrackingUser>>();
            services.AddScoped<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<SearchRemoteUserEmailService>(x=> new SearchRemoteUserEmailService(connectionToAudience,connectionToComliance));
            services.AddTransient<IInterventionRepository, InterventionRepository>();
            services.AddTransient<IWorkContext, WorkContext>();
            services.AddTransient<CleaningLoggerFileServices>();
            services.AddTransient<IImportExportService, ImportExportService>(provider =>  new ImportExportService(Configuration.GetConnectionString("DefaultConnection")));
            services.AddImportExportService(Configuration.GetConnectionString("DefaultConnection"));
            //services.AddTransient<IImportExportService, ImportExportService>(provider =>  new ImportExportService(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHostedService, ScheduleTask>();

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ILoggerFactory loggerFactory, CleaningLoggerFileServices fileServices)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseHangfireServer();
            RecurringJob.AddOrUpdate(() => fileServices.CleanFile(), Cron.Daily(3));

            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}");
            });

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            loggerFactory.AddFile(Path.Combine(".\\Logigng", "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
        }
    }
}
