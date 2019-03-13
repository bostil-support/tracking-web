using System;
using Tracking.Web.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Tracking.DbInitialize.Providers
{
    public class DbInitializeProvider
    {
        private ApplicationDbContext _db;

        public DbInitializeProvider()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS2;Initial Catalog=Tracking;Integrated Security=True;MultipleActiveResultSets=true");

            _db = new ApplicationDbContext(optionsBuilder.Options);
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
    }
}
