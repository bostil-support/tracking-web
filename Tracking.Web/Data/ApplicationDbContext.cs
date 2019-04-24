using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<TrackingUser, TrackingRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<DescriptiveAttributes> SurveyDescriptiveAttributes { get; set; }
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<Survey> Surveys { get; set; }

        public bool IsDatabaseExist()
        {
            return (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();
        }
    }
}
