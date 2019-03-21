using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Data;
using Tracking.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Tracking.Web.Data
{
    public class InterventionRepository : IInterventionRepository
    {
        private ApplicationDbContext _context;

        public InterventionRepository(ApplicationDbContext con)
        {
            _context = con;
        }

        public List<Intervention> GetAll()
        {
            //return _context.Surveys.Include(x => x.Intervention).Include(x => x.Status).ToList();
            return _context.Interventions.Include(x => x.Surveys).ToList();
        }

        public Survey GetSurveyById(int id)
        {
            return _context.Surveys.SingleOrDefault(p => p.Id == id);
        }
    }
}
