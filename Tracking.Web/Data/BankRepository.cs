using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public class BankRepository
    {
        private readonly ApplicationDbContext _context;

        public BankRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public void Add(Bank bank)
        {
            if (bank.Id == 0)
            {
                _context.Banks.Add(bank);
            }
            else
            {
                var result = _context.Banks
                    .FirstOrDefault(b => b.Id == bank.Id);
                if (result == null)
                    _context.Banks.Add(bank);
            }
            _context.SaveChanges();
        }
    }
}
