﻿using System;
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
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace Tracking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInterventionRepository _rep;
        private readonly IWorkContext _workContext;

        public HomeController(IInterventionRepository repo, IWorkContext workContext)
        {
            _rep = repo;
            _workContext = workContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetInterventions()
        {
            var interventions = _rep.GetAllInterventions();
            return PartialView("_InterventionSummary", interventions);
        }

        [HttpPost]
        public IActionResult Filter(FilterViewModel model)
        {
            var interventions = _rep.Filter(model);
            return PartialView("_InterventionSummary", interventions);
        }

        public IActionResult Show(int id)
        {
            var survey = _rep.GetSurveyById(id);
            var currentStatus = _rep.GetStatusById(survey.StatusId);
            var allStatuses = _rep.GetStatusesAsSelectList();
            var currentTypeRisk = _rep.GetRiskById(survey.RiskTypeId);
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
                SurveySeverity = survey.SurveySeverity,
                ValidatorAttribute = survey.ValidatorAttribute,
                UserName = survey.UserName,
                ScrepArea = survey.ScrepArea,
                SrepCluster = survey.SrepCluster,
                RiskType = currentTypeRisk,
                Notes = surveyNotes,
                LegalEntity = survey.LegalEntity,
                ActionOwner = survey.ActionOwner,
                ActionDescription = survey.ActionDescription,
                DueDateLocal = survey.DueDateLocal.ToString("dd.MM.yyyy"),
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

        [HttpPost]
        public async Task<IActionResult> EditSurvey(SurveyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var survey = _rep.GetSurveyById(model.Id);
                survey.Title = model.Title;
                survey.SurveySeverity = model.SurveySeverity;
                survey.UserName = model.UserName;
                survey.ValidatorAttribute = model.ValidatorAttribute;
                survey.Description = model.Description;
                survey.LegalEntityId = model.LegalEntity.Id;
                survey.SrepCluster = model.SrepCluster;
                survey.ScrepArea = model.ScrepArea != null ? model.ScrepArea : survey.ScrepArea;
                survey.ActionDescription = model.ActionDescription;
                survey.ActionOwner = model.ActionOwner;
                survey.StatusId = model.StatusId;
                survey.RiskTypeId = model.RiskType.Id != 0 ? model.RiskType.Id : survey.RiskTypeId;
                survey.DueDateLocal = DateTime.ParseExact(model.DueDateLocal, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                _rep.UpdateSurveyAsync(survey);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<Dictionary<int, string>> GetEntityNames()
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
    }
}