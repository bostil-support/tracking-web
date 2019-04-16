using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Data;
using Tracking.Web.Models;
using Tracking.Web.Models.ViewModel;

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
            var surv = GetAllSurveys();
            return _context.Interventions.Include(x => x.Surveys).ToList();
        }

        /// <summary>
        /// get surveys
        /// </summary>
        /// <returns></returns>
        public List<Survey> GetAllSurveys()
        {
            var statues = GetAllStatuses();
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
            var files = GetAllFiles();
            var users = GetAllUsers();
            return _context.Notes.Include(x => x.User).Where(p => p.SurveyId == surveyId).ToList();
        }

        public void CreateNote(Note item)
        {
            _context.Notes.Add(item);
            _context.SaveChanges();
        }

        public void CreateFile(File item)
        {
            var file = _context.Files.Add(item);
            _context.SaveChanges();
        }

        public File GetFileByPath(string path)
        {
            var files = _context.Files.ToList();
            return _context.Files.FirstOrDefault(x => x.FilePath == path);
        }

        public List<TrackingUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<File> GetAllFiles()
        {
            return _context.Files.ToList();
        }

        public List<Intervention> Filter(FilterViewModel model)
        {
            var statues = GetAllStatuses();
            var result = _context.Surveys.Include(x => x.LegalEntity).ToList();

            if (model != null)
            {
                if (model.LegalEntities!= null)
                    result = result.Where(x => model.LegalEntities.Contains(x.LegalEntity.Name)).ToList();
                if (model.Owners != null)
                    result = result.Where(x => model.Owners.Contains(x.ActionOwner)).ToList();
                if (model.Statuses != null)
                    result = result.Where(x => model.Statuses.Contains(x.Status.Name)).ToList();
                if (model.Severities != null)
                    result = result.Where(x => model.Severities.Contains(x.SurveySeverity)).ToList();
            }

            var interventions = _context.Interventions.ToList();
            foreach(var item in interventions)
            {
                item.Surveys = item.Surveys.Intersect(result).ToList();
            }

            return interventions.Where(x=>x.Surveys.Count > 0).ToList();
        }

        public  void UpdateSurveyAsync(Survey survey)
        {
            try
            {
                _context.Surveys.Update(survey);
                _context.SaveChanges();
                _context.Dispose();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public Task<Dictionary<int, string>> GetEntityNames()
        {
            return _context.LegalEntities.Where(x => x.Code != null).ToDictionaryAsync(x => x.Id, x => x.Name);
        }

        public async Task<Dictionary<int, string>> GetRisks()
        {
            var risks = await _context.RiskTypes.ToDictionaryAsync(x => x.Id, x => x.Name);
            return risks;
        }
    }
}
