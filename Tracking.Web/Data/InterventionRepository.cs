using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Get interventions
        /// </summary>
        /// <returns></returns>
        public List<Intervention> GetAllInterventions()
        {
            var statues = GetAllStatuses();
            var surv = GetAllSurveys();
            return _context.Interventions.Include(x => x.Surveys).ToList();
        }

        /// <summary>
        /// get surveys
        /// </summary>
        /// <returns></returns>
        public List<Survey> GetAllSurveys()
        {
            return _context.Surveys.Include(x => x.LegalEntity).ToList();
        }

        /// <summary>
        /// Find survey by id
        /// </summary>
        /// <param name="id">survey id</param>
        /// <returns></returns>
        public Survey GetSurveyById(int id)
        {
            return _context.Surveys.Include(x=>x.LegalEntity).SingleOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Find Status by id
        /// </summary>
        /// <param name="id">status id</param>
        /// <returns></returns>
        public Status GetStatusById(int id)
        {
            return _context.Statuses.Find(id);
        }

        /// <summary>
        /// Find Status by id
        /// </summary>
        /// <param name="id">status id</param>
        /// <returns></returns>
        public List<SelectListItem> GetStatusesAsSelectList()
        {
            return _context.Statuses
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();
        }

        /// <summary>
        /// Get Statuses
        /// </summary>
        /// <returns></returns>
        public List<Status> GetAllStatuses()
        {
            return _context.Statuses.ToList();
        }

        /// <summary>
        /// Find Risk Type by id
        /// </summary>
        /// <param name="id">status id</param>
        /// <returns></returns>
        public RiskType GetRiskById(int id)
        {
            return _context.RiskTypes.Find(id);
        }

        /// <summary>
        /// Get all risk types
        /// </summary>
        /// <returns>List of RiskTypes</returns>
        public List<RiskType> GetAllRiskTypes()
        {
            return _context.RiskTypes.ToList();
        }

        /// <summary>
        /// return saved notes for survey
        /// </summary>
        /// <param name="surveyId">survey id</param>
        /// <returns></returns>
        public List<Note> GetNotesForSurvey(int surveyId)
        {
            return _context.Notes.Where(p => p.SurveyId == surveyId).ToList();
        }
    }
}
