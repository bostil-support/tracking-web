using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracking.Web.Data;
using Tracking.Web.Models;
using Tracking.Web.Models.ViewModel;

namespace Tracking.Web.Controllers
{
    public class HomeController : Controller
    {
        private IInterventionRepository _rep; 
        public HomeController(IInterventionRepository repo)
        {
            _rep = repo;
        }

        [Authorize]
        public IActionResult Index()
        {
            var interventions = _rep.GetInterventionsWithSurveys();
            return View(interventions);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Show(int id)
        {
            var survey = _rep.GetSurveyById(id);
            var currentStatus = _rep.GetStatusById(survey.StatusId);
            var allStatuses = _rep.GetStatusesAsSelectList();
            var allRiskTypes = _rep.GetAllRiskTypes();
            var currentTypeRisk = _rep.GetRiskById(survey.RiskTypeId);
            var surveyNotes = _rep.GetNotesForSurvey(id);


            var survyViewModel = new SurveyViewModel
            {
                Title = survey.Title,
                Description = survey.Description,
                Status = currentStatus.Name,
                Statuses = allStatuses,
                ImportDownloadDate = survey.ImportDownloadDate,
                SurveySeverity = survey.SurveySeverity,
                ValidatorAttribute = survey.ValidatorAttribute,
                UserName = survey.UserName,
                ScrepArea = survey.ScrepArea,
                SrepCluster = survey.SrepCluster,
                RiskType = currentTypeRisk,
                RiskTypes = allRiskTypes,
                Notes = surveyNotes
            };
            
            return View(survyViewModel);
        }
    }
}
