using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Data;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public class InterventionRepository : IInterventionRepository
    {
        private ApplicationDbContext _context;

        public InterventionRepository(ApplicationDbContext con)
        {
            _context = con;
        }

        public List<Intervention> GetInterventionsWithSurveys()
        {
            return _context.Interventions.Include(x => x.Surveys).ToList();
        }

        public Survey GetSurveyById(int id)
        {
            return _context.Surveys.SingleOrDefault(p => p.Id == id);
        }
    }
}
