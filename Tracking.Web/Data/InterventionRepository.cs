using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Data;
using Tracking.Web.Models;
using Tracking.Web.Models.ViewModel;
using Tracking.Web.Services;
using Microsoft.AspNetCore.Identity;

namespace Tracking.Web.Data
{
    public class InterventionRepository : IInterventionRepository
    {
        private ApplicationDbContext _context;
        private ISurveysService _surveysService;
        private readonly UserManager<TrackingUser> _userManager;
        
        public InterventionRepository(ApplicationDbContext con, 
            ISurveysService surveysService,
            UserManager<TrackingUser> userManager)
        {
            _context = con;
            _surveysService = surveysService;
            _userManager = userManager;
        }

        /// <summary>
        /// Get interventions
        /// </summary>
        /// <returns></returns>
        public List<Intervention> GetAllInterventions()
        {
            return _context.Interventions.Include(x => x.Surveys).ToList();
        }
              
        /// <summary>
        /// get surveys by interventionId
        /// </summary>
        /// <returns></returns>
        public async Task<List<IGrouping<string, Survey>>> GroupSurveyByIntervId(TrackingUser user)
        {
            IList<Survey> surveys = new List<Survey>();
            var statuses = _context.Statuses.ToList();
            //var surv = _context.Surveys.ToList();

            var userRoles = await _userManager.GetRolesAsync(user);

            //foreach (var role in userRoles)
            //{
            if (userRoles[0] == "Compliance")
            {
                surveys = _surveysService.GetSurveysComplainceByUserEmail(user.Email);

            }
            else
            {
                surveys = _surveysService.GetSurveysAuditorByUserEmail(user.Email);
            }
            //}

            var groupSurv = surveys.GroupBy(x => x.InterventionName).ToList();
            return groupSurv;
        }

        public async Task<List<IGrouping<Guid, Survey>>> GroupSurveyByUidAnalisi(TrackingUser user)
        {
            IList<Survey> surveys = new List<Survey>();
            var statuses = _context.Statuses.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles[0] == "Compliance")
            {
                surveys = _surveysService.GetSurveysComplainceByUserEmail(user.Email);
            }
            else
            {
                surveys = _surveysService.GetSurveysAuditorByUserEmail(user.Email);
            }

            var groupSurv = surveys.GroupBy(x => x.UIdAnalisi).ToList();
            return groupSurv;
        }

        /// <summary>
        /// Find survey by id
        /// </summary>
        /// <param name="id">survey id</param>
        /// <returns></returns>
        public Survey GetSurveyById(string id)
        {
            return _context.Surveys.SingleOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Find Status by id
        /// </summary>
        /// <param name="id">status id</param>
        /// <returns></returns>
        public Status GetStatusById(int? id)
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
        public string GetSurveyRisk(string SurveyId)
        {
            return _context.SurveyDescriptiveAttributes.Where(x => x.SurveyId == SurveyId).Select(x => x.Risk).ToString();
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
        public List<Note> GetNotesForSurvey(string surveyId)
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



        public List<IGrouping<Guid, Survey>> Filter(FilterViewModel model,TrackingUser user)
        {
            var statues = GetAllStatuses();
            var userRoles =  _userManager.GetRolesAsync(user).Result;
            IList<Survey> result = null; 
            if (userRoles[0] == "Compliance")
            {
               result = _surveysService.GetSurveysComplainceByUserEmail(user.Email);

            }
            else
            {
               result = _surveysService.GetSurveysAuditorByUserEmail(user.Email);
            }
            
            //var result = _context.Surveys.ToList();

            if (model != null)
            {
                if (model.LegalEntities!= null)
                    result = result.Where(x => model.LegalEntities.Contains(x.LegalEntityName)).ToList();
                if (model.Owners != null)
                    result = result.Where(x => model.Owners.Contains(x.ActionOwner)).ToList();
                if (model.Statuses != null)
                    result = result.Where(x => model.Statuses.Contains(x.Status.Name)).ToList();
                if (model.Severities != null)
                    result = result.Where(x => model.Severities.Contains(x.SurveySeverity)).ToList();
            }

            return result.GroupBy(x => x.UIdAnalisi).ToList();
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

        public Task<Dictionary<string, string>> GetEntityNames()
        {
            var bankNames = _context.Surveys.GroupBy(x => x.Cod_ABI).Select(x => x.FirstOrDefault()).ToDictionaryAsync(x=>x.Cod_ABI, x=>x.LegalEntityName);
            return bankNames;
        }

        public async Task<Dictionary<int, string>> GetRisks()
        {
            var risks = await _context.RiskTypes.ToDictionaryAsync(x => x.Id, x => x.Name);
            return risks;
        }

        public List<string> GetBankNames()
        {
            var banks = _context.Surveys
                .Where(x => x.LegalEntityName != null)
                .Select(x => x.LegalEntityName)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            return banks;                
        }

        public List<string> GetOwners()
        {
            var banks = _context.Surveys.Where(x => x.ActionOwner !=null).Select(x => x.ActionOwner).Distinct().ToList();
            return banks;
        }

        public List<string> GetSeverities()
        {
            var banks = _context.Surveys.Where(x => x.SurveySeverity != null).Select(x => x.SurveySeverity).Distinct().ToList();
            return banks;
        }

        /// <summary>
        /// Get Statuses Name
        /// </summary>
        /// <returns></returns>
        public List<string> GetStatusesName()
        {
            return _context.Statuses.Where(x => x.Surveys != null).Select(x => x.Name).Distinct().ToList();
        }
    }
}
