using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracking.Web.Data;
using Tracking.Web.Models;
using Tracking.Web.Models.ViewModel;
using System.Globalization;
using Tracking.Web.Services;
using Microsoft.AspNetCore.Http.Extensions;

namespace Tracking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInterventionRepository _rep;
        private readonly IWorkContext _workContext;
        private readonly IImportExportService _service;

        public HomeController(IInterventionRepository repo, IWorkContext workContext, IImportExportService service)
        {
            _rep = repo;
            _workContext = workContext;
            _service = service;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetSurveys()
        {
            var surveys = _rep.GroupSurveyByIntervId();
            return PartialView("_InterventionSummary", surveys);
        }

        [HttpGet]
        public IActionResult Filter(FilterViewModel model)
        {
            var surveys = _rep.Filter(model);
            return PartialView("_InterventionSummary", surveys);
        }


        public IActionResult Show(string id)
        {
            var url = Request.QueryString;
            var survey = _rep.GetSurveyById(id);
            var currentStatus = _rep.GetStatusById(survey.StatusId);
            var allStatuses = _rep.GetStatusesAsSelectList();
            var currentTypeRisk = _rep.GetSurveyRisk(survey.Id);
            var surveyNotes = _rep.GetNotesForSurvey(id);
            var currentUserRole = _workContext.GetCurrentUserRole();

            var survyViewModel = new SurveyViewModel
            {
                Id = survey.Id,
                Title = survey.Title,
                Description = survey.Description,
                Status = currentStatus.Name,
                Statuses = allStatuses,
                StatusId = survey.StatusId,
                ImportDownloadDate = survey.ImportDownloadDate,
                InterventionName = survey.InterventionName,
                EvaluatedObject = survey.EvaluatedObject,
                SurveySeverity = survey.SurveySeverity,
                DescriptiveAttributes = survey.DescriptiveAttributes,
                //ValidatorAttribute = survey.ValidatorAttribute,
                UserName = survey.UserName,
                //ScrepArea = survey.ScrepArea,
                //SrepCluster = survey.SrepCluster,
                Notes = surveyNotes,
                LegalEntityName = survey.LegalEntityName,
                Cod_ABI = survey.Cod_ABI,
                ActionOwner = survey.ActionOwner,
                ActionDescription = survey.ActionDescription,
                DueDateLocal = survey.DueDateLocal?.ToString("dd.MM.yyyy"),
                Role = currentUserRole
            };

            return View(survyViewModel);
        }

        /// <summary>
        /// Add new note on page Survey
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNote(NoteViewModel model)
        {
            var currentUser = _workContext.GetCurrentUserAsync().Result;

            if (model.File != null)
            {
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    model.File.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }

                var file = new Tracking.Web.Models.File(model.File.FileName, path);
                _rep.CreateFile(file);

                var note = new Note
                {
                    Description = model.Description,
                    UserId = currentUser.Id,
                    SurveyId = model.SurveyId,
                    Date = DateTime.Now,
                    FileId = file.Id
                };

                _rep.CreateNote(note);
                return Content("file was downloaded");
            }
            else
            {
                var note = new Note
                {
                    Description = model.Description,
                    UserId = currentUser.Id,
                    SurveyId = model.SurveyId,
                    Date = DateTime.Now,
                };

                _rep.CreateNote(note);
                return Content("file not selected");
            }
        }

        /// <summary>
        /// Display all notes of survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Notes(string id)
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

        [HttpPost]
        public async Task<IActionResult> EditSurvey(SurveyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var survey = _rep.GetSurveyById(model.Id);
                survey.Title = model.Title;
                survey.SurveySeverity = model.SurveySeverity;
                survey.UserName = model.UserName;
                // survey.ValidatorAttribute = model.ValidatorAttribute;
                survey.Description = model.Description;
                survey.Cod_ABI = model.Cod_ABI;
                survey.LegalEntityName = model.LegalEntityName;
                survey.InterventionName = model.InterventionName;
                survey.EvaluatedObject = model.EvaluatedObject;
                //survey.SrepCluster = model.SrepCluster;
                //survey.ScrepArea = model.ScrepArea != null ? model.ScrepArea : survey.ScrepArea;
                survey.ActionDescription = model.ActionDescription;
                survey.ActionOwner = model.ActionOwner;
                survey.StatusId = model.StatusId;
                //survey.RiskTypeId = model.RiskType.Id != 0 ? model.RiskType.Id : survey.RiskTypeId;
                survey.DueDateLocal = DateTime.ParseExact(model?.DueDateLocal, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                _rep.UpdateSurveyAsync(survey);
            }
            var url =  Request.GetDisplayUrl();
            return Ok(url);
        }

        [HttpGet]
        public async Task<Dictionary<string, string>> GetEntityNames()
        {
            var legalEntites = await _rep.GetEntityNames();
            return legalEntites;
        }

        [HttpGet]
        public string GerUserRole()
        {
            var currentUserRole = _workContext.GetCurrentUserRole();
            return currentUserRole;
        }

        [HttpGet]
        public IActionResult GetEditContainer()
        {
            return PartialView("_EditContainer");
        }

        [HttpGet]
        public async Task<Dictionary<int, string>> GetRisks()
        {
            var risks = await _rep.GetRisks();
            return risks;
        }

        [HttpGet]
        public IActionResult GetFilterDatas()
        {
            var model = new FilterViewModel
            {
                LegalEntities = _rep.GetBankNames(),
                Owners = _rep.GetOwners(),
                Severities = _rep.GetSeverities()
            };

            return PartialView("_FilterFiledsets", model);
        }

        //[Route("{folder1:maxlength(100)}/{folder2:maxlength(100)}/Home/Import")]
        public IActionResult Import()
        {
            _service.ImportSurveysAudit();
            _service.ImportDescriptiveAttributes();
            _service.ImportSurveysComplaince();
            _service.ImportDescriptiveAttributesComplaince();

            var model = new ImportViewModel();
            //string[] Url = Request.Path.ToString().Split('/');
            //model.Url = '/' +  Url[1] + '/' + Url[2] + '/' + Url[3] + '/' + "Index";
            return View(model);
        }
    }
}