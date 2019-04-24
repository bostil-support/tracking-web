using Microsoft.EntityFrameworkCore;
using Tracking.Web.Data;

namespace Tracking.DbInitialize
{
    public class DbInitializeContext : ApplicationDbContext
    {
        public DbInitializeContext(DbContextOptions 
            options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS2;Initial Catalog=TrackingDB;Integrated Security=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
