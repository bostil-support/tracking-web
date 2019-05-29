using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tracking.Web.Data;
using Tracking.Web.Loging;
using Tracking.Web.Models;

namespace Tracking.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            /*
            using (var scope = host.Services.CreateScope())
            {
                Task task;
                var services = scope.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<TrackingUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    task = RoleInitializer.InitializeAsync(userManager, roleManager);
                    task.Wait();
                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            */
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    //logging.AddConsole();
                    //logging.AddDebug();
                    logging.AddProvider(new FileLoggerProvider(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt")));
                    logging.SetMinimumLevel(LogLevel.None);
                })
                .UseStartup<Startup>();
    }
}
