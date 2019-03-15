using System;
using Tracking.Web.Data;
using Tracking.Web.Models;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;

namespace Tracking.DbInitialize.Providers
{
    public class DbInitializeProvider
    {
        private ApplicationDbContext _db;
        private readonly string _fileName;
        private readonly FileInfo _fileInfo;
        private string _rootPath; 

        public DbInitializeProvider()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS2;Initial Catalog=Tracking;Integrated Security=True;MultipleActiveResultSets=true");

            _db = new ApplicationDbContext(optionsBuilder.Options);
            _fileName = @"TrackingFields.xlsx";
            _rootPath = GetApplicationRoot();
            _fileInfo = new FileInfo(Path.Combine(_rootPath, _fileName));
        }

        public void SetCreateDatabase()
        {
            Console.WriteLine("Check for database availability: ");
            try
            {
                if (_db.IsDatabaseExist())
                {
                    Console.WriteLine("Done!\r\n");
                }
                else
                {
                    _db.Database.EnsureCreated();
                    Console.WriteLine("Database was created!\r\n");
                }
            }
            catch (DbException error)
            {
                Console.WriteLine(error);
            }
        }

        public async Task SetInitializeRolesAsync()
        {
            // excel collumns
            string name, description, id;
            using (var package = new ExcelPackage(_fileInfo))
            {
                var workSheet = package.Workbook.Worksheets["Roles"];
                int totalRows = workSheet.Dimension.Rows;

                List<TrackingRole> rolesList = new List<TrackingRole>();

                try
                {
                    using (var _serviceScope = ServiceInitialize.ServiceProviderInitialize()
                                                .GetRequiredService<IServiceScopeFactory>()
                                                .CreateScope())
                    {
                        var _roleManager = _serviceScope.ServiceProvider.GetRequiredService<RoleManager<TrackingRole>>();
                        for (int i = 2; i <= totalRows; i++)
                        {
                            id = workSheet.Cells[i, 1].Value.ToString();
                            name = workSheet.Cells[i, 2].Value.ToString();
                            description = workSheet.Cells[i, 3].Value.ToString();

                            if (await _roleManager.FindByNameAsync(name) == null)
                                await _roleManager.CreateAsync(new TrackingRole { Id = id, Name = name, Description = description });
                        }
                        Console.Write("Roles imported. Done!\r\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public async Task SetInitializeUsersAsync()
        {
            // Excel collumns
            string roleId, roleName, userId, userEmail;
            using (var package = new ExcelPackage(_fileInfo))
            {
                var workSheet = package.Workbook.Worksheets["Users"];
                int totalRows = workSheet.Dimension.Rows;

                List<TrackingUser> usersList = new List<TrackingUser>();

                try
                {
                    using (var _serviceScope = ServiceInitialize.ServiceProviderInitialize()
                                                .GetRequiredService<IServiceScopeFactory>()
                                                .CreateScope())
                    {
                        var _userManager = _serviceScope.ServiceProvider.GetRequiredService<UserManager<TrackingUser>>();
                        for (int i = 4; i <= totalRows; i++)
                        {
                            roleId = workSheet.Cells[i, 7].Value.ToString();
                            roleName = workSheet.Cells[i, 8].Value.ToString();
                            userId = workSheet.Cells[i, 9].Value.ToString();
                            userEmail = workSheet.Cells[i, 10].Value.ToString();
                                                        
                            if (await _userManager.FindByEmailAsync(userEmail) == null)
                            {
                                var user = new TrackingUser { Email = userEmail, UserName = userEmail, Id = userId };
                                var result = await _userManager.CreateAsync(user, "Qwerty123!");
                                if (result.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(user, roleName);
                                }
                            }
                        }
                        Console.Write("Users imported. Done!\r\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void SetInitializeBanks()
        {
            // excel collumns
            string bankName, bankABI;
            int bankId = 0;

            using (var package = new ExcelPackage(_fileInfo))
            {
                var workSheet = package.Workbook.Worksheets["Interventions"];
                int totalRows = workSheet.Dimension.Rows;

                List<Bank> bankList = new List<Bank>();

                try
                {
                    for (int i = 4; i <= totalRows; i++)
                    {
                        bankId = Int32.Parse(workSheet.Cells[i, 2].Value.ToString());
                        bankName = workSheet.Cells[i, 4].Value.ToString();
                        bankABI = workSheet.Cells[i, 3].Value.ToString();
                        
                        bankList.Add(new Bank
                        {
                            Id = bankId,
                            Name = bankName,
                            BankABI = bankABI
                        });
                    }
                    List<Bank> uniqueBanks = bankList.GroupBy(b => b.Id)
                        .Select(b => b.First()).ToList();
                    _db.Banks.AddRange(uniqueBanks);
                    _db.SaveChanges();

                    Console.Write("Banks imported. Done!\r\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public async Task SetInitializeInterventionsAsync()
        {
            // excel collumns
            string roleId, roleName, userId, userEmail;
            using (var package = new ExcelPackage(_fileInfo))
            {
                var workSheet = package.Workbook.Worksheets["Users"];
                int totalRows = workSheet.Dimension.Rows;

                List<TrackingUser> usersList = new List<TrackingUser>();

                try
                {
                    using (var _serviceScope = ServiceInitialize.ServiceProviderInitialize()
                                                .GetRequiredService<IServiceScopeFactory>()
                                                .CreateScope())
                    {
                        var _userManager = _serviceScope.ServiceProvider.GetRequiredService<UserManager<TrackingUser>>();
                        for (int i = 4; i <= totalRows; i++)
                        {
                            roleId = workSheet.Cells[i, 7].Value.ToString();
                            roleName = workSheet.Cells[i, 8].Value.ToString();
                            userId = workSheet.Cells[i, 9].Value.ToString();
                            userEmail = workSheet.Cells[i, 10].Value.ToString();

                            if (await _userManager.FindByEmailAsync(userEmail) == null)
                            {
                                var user = new TrackingUser { Email = userEmail, UserName = userEmail, Id = userId };
                                var result = await _userManager.CreateAsync(user, "Qwerty123!");
                                if (result.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(user, roleName);
                                }
                            }
                            /*                            
                            usersList.Add(new TrackingUser
                            {
                                Id = userId,
                                Email = userEmail,
                            });
                            */
                        }
                        Console.Write("Users imported. Done!\r\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                // _db.Roles.AddRange(rolesList);
                // _db.SaveChanges();
            }
        }

        private string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                              .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }
    }
}
