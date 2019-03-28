using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            var interventions = _rep.GetAllInterventions();
            return View(interventions);
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
                Id = survey.Id,
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
                Notes = surveyNotes,
                LegalEntity = survey.LegalEntity,
                ActionOwner = survey.ActionOwner,
                ActionDescription = survey.ActionDescription
            };

            return View(survyViewModel);
        }

        [HttpPost] 
        public void AddNote(NoteViewModel model)
        {
            if (model.File != null)
            {
                string filePath = "C:\\TrackingFiles\\" + model.File.FileName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }

                _rep.CreateFile(new Models.File(model.File.FileName, filePath));

                var newFile = _rep.GetFileByPath(filePath);
                _rep.CreateNote(new Note(model.Description, model.UserId, model.SurveyId, model.Date, newFile.Id));
            }
            else
            {
                _rep.CreateNote(new Note(model.Description, model.UserId, model.SurveyId, model.Date));
            }
        }

        [HttpGet]
        public IActionResult Notes(int id)
        {
            List<Note> list = new List<Note>();
            list = _rep.GetNotesForSurvey(id);
            return PartialView(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}