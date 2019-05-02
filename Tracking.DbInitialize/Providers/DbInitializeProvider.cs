using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data;
using Tracking.Web.Data;
using Tracking.Web.Services;
using Tracking.Web.Models;
using Microsoft.AspNetCore.Http;

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
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS2;Initial Catalog=TrackingDB;Integrated Security=True;MultipleActiveResultSets=true");

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
            List<LegalEntity> legEntitiesList = new List<LegalEntity>();
            
            try
            {
                using (var package = new ExcelPackage(_fileInfo))
                {
                    var workSheet = package.Workbook.Worksheets["Interventions"];
                    int totalRows = workSheet.Dimension.Rows;

                    for (int i = 4; i <= totalRows; i++)
                    {
                        legEntitiesList.Add(new LegalEntity
                        {
                            Id = workSheet.Cells[i, 2].Value.ToString(),
                            Name = workSheet.Cells[i, 4].Value.ToString(),
                            Code = workSheet.Cells[i, 2].Value.ToString()
                    });
                    }
                    var uniqueLegEntities = legEntitiesList.GroupBy(b => b.Id)
                        .Select(b => b.First()).ToList();

                    _db.LegalEntities.AddRange(uniqueLegEntities);
                    _db.SaveChanges();
                    Console.Write("Banks imported. Done!\r\n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Import test Statuses(Stato)
        /// </summary>
        public void SetInitializeStatuses()
        {
            var statusList = new List<Status>();
            string[] statuses = new string[6] {
                "accettaccione rischio",
                "da validare",
                "in corso",
                "in ritardo",
                "proposta chiusura",
                "annullamento"};
            try
            {
                for (int i = 0; i < statuses.Length; i++)
                {
                    statusList.Add(new Status
                    {
                        Id = i,
                        Name = statuses[i]
                    });
                }

                _db.Statuses.AddRange(statusList);
                _db.SaveChanges();
                Console.Write("Statuses were imported. Done!\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// import interventions
        /// </summary>
        /// <returns></returns>
        public void SetInitializeInterventions()
        {
            string title;
            int idIntervention;
            // excel collumns
            using (var package = new ExcelPackage(_fileInfo))
            {
                var workSheet = package.Workbook.Worksheets["Interventions"];
                int totalRows = workSheet.Dimension.Rows;
                var tempInterventionList = new List<Intervention>();
                List<Intervention> uniqueInterList;

                List<Intervention> usersList = new List<Intervention>();

                try
                {
                    
                    for (int i = 4; i <= totalRows; i++)
                    {
                        title = workSheet.Cells[i, 7].Value.ToString();
                        idIntervention = Int32.Parse(workSheet.Cells[i, 6].Value.ToString());
                        
                                                    
                        tempInterventionList.Add(new Intervention
                        {
                            Id = idIntervention,
                            Title = title
                        });
                        
                    }
                    uniqueInterList = tempInterventionList.GroupBy(b => b.Id)
                        .Select(b => b.First()).ToList();
                    Console.Write("Interventions were imported. Done!\r\n");

                    _db.Interventions.AddRange(uniqueInterList);
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// import surveys
        /// </summary>
        /// <returns></returns>
        public void SetInitializeSurveys()
        {
            // remove all rows in table
            //_db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Surveys]");
            using (var package = new ExcelPackage(_fileInfo))
            {
                var workSheet = package.Workbook.Worksheets["Interventions"];
                int totalRows = workSheet.Dimension.Rows;
                List<Survey>surveyList = new List<Survey>();

                try
                {
                    for (int i = 4; i <= totalRows; i++)
                    {
                        surveyList.Add(new Survey
                        {
                            Id = workSheet.Cells[i, 16].Value.ToString(),
                            InterventionId = Int32.Parse(workSheet.Cells[i, 6].Value.ToString()),
                          //  LegalEntityId = workSheet.Cells[i, 2].Value.ToString(),
                          //  LegalEntity = _db.LegalEntities.Find(Int32.Parse(workSheet.Cells[i, 2].Value.ToString())),
                            Title = workSheet.Cells[i, 17].Value.ToString(),
                            Description = workSheet.Cells[i, 18].Value.ToString(),
                            SurveySeverity = workSheet.Cells[i, 21].Value.ToString(),
                          //  ValidatorAttribute = workSheet.Cells[i, 25].Value.ToString(),
                            UserName = workSheet.Cells[i, 20].Value.ToString(),
                            //SrepCluster = workSheet.Cells[i, 11].Value.ToString(),
                           // ScrepArea = workSheet.Cells[i, 10].Value.ToString(),
                            ActionOwner = workSheet.Cells[i, 22].Value.ToString(),
                            ActionDescription = workSheet.Cells[i, 22].Value.ToString(),
                            ImportDownloadDate = DateTime.Parse(workSheet.Cells[i, 1].Value.ToString()),
                           // DueDateOriginal = DateTime.Parse(workSheet.Cells[i, 23].Value.ToString()),
                            StatusId = 1
                           // RiskTypeId = 1
                            
                        });
                    }

                    _db.Surveys.AddRange(surveyList);
                    _db.SaveChanges();
                    Console.Write("Surveys were imported. Done!\r\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// import risk types
        /// </summary>
        /// <returns></returns>
        public void SetInitializeRiskTypes()
        {
            using (var package = new ExcelPackage(_fileInfo))
            {
                var workSheet = package.Workbook.Worksheets["Interventions"];
                int totalRows = workSheet.Dimension.Rows;
                List<RiskType> riskTypeList = new List<RiskType>();

                try
                {

                    for (int i = 4; i <= totalRows; i++)
                    {
                        riskTypeList.Add(new RiskType
                        {
                            Id = i - 3,
                            Name = workSheet.Cells[i, 15].Value.ToString()
                        });
                    }

                    var uniqueRisksList = riskTypeList.GroupBy(b => b.Name)
                        .Select(b => b.First()).ToList();

                    _db.RiskTypes.AddRange(uniqueRisksList);
                    _db.SaveChanges();

                    Console.Write("Risk types were imported. Done!\r\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        public void ImportSurveysAudit()
        {
            using (var _serviceScope = ServiceInitialize.ServiceProviderInitialize()
                                        .GetRequiredService<IServiceScopeFactory>()
                                        .CreateScope())
            {
                var importService = _serviceScope.ServiceProvider.GetRequiredService<IImportExportService>();
                importService.ImportSurveysAudit();

                Console.Write("Surveys imported. Done!\r\n");
            }
        }

        public void ImportDescriptiveAttrAudit()
        {
            using (var _serviceScope = ServiceInitialize.ServiceProviderInitialize()
                                        .GetRequiredService<IServiceScopeFactory>()
                                        .CreateScope())
            {
                var importService = _serviceScope.ServiceProvider.GetRequiredService<IImportExportService>();
                importService.ImportDescriptiveAttributes();

                Console.Write("Descriptive attr imported. Done!\r\n");
            }
        }

        public void ImportSurveysComplaince()
        {
            using (var _serviceScope = ServiceInitialize.ServiceProviderInitialize()
                                        .GetRequiredService<IServiceScopeFactory>()
                                        .CreateScope())
            {
                var importService = _serviceScope.ServiceProvider.GetRequiredService<IImportExportService>();
                importService.ImportSurveysComplaince();

                Console.Write("Surveys complaince imported. Done!\r\n");
            }
        }

        public void ImportDescriptiveAttrComplaince()
        {
            using (var _serviceScope = ServiceInitialize.ServiceProviderInitialize()
                                        .GetRequiredService<IServiceScopeFactory>()
                                        .CreateScope())
            {
                var importService = _serviceScope.ServiceProvider.GetRequiredService<IImportExportService>();
                importService.ImportDescriptiveAttributesComplaince();

                Console.Write("Descriptive attr imported. Done!\r\n");
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
