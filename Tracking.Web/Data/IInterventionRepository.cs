using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tracking.Web.Models;
using Tracking.Web.Models.ViewModel;

namespace Tracking.Web.Data
{
    public interface IInterventionRepository
    {
        List<Intervention> GetAllInterventions();

        List<Survey> GetAllSurveys();

        Survey GetSurveyById(string id);

        Status GetStatusById(int id);

        List<Status> GetAllStatuses();

        List<SelectListItem> GetStatusesAsSelectList();

        List<RiskType> GetAllRiskTypes();

        RiskType GetRiskById(int id);

        List<Note> GetNotesForSurvey(string surveyId);

        void CreateNote(Note item);

        void CreateFile(File item);

        List<File> GetAllFiles();

        File GetFileByPath(string path);

        List<TrackingUser> GetAllUsers();

        List<Intervention> Filter(FilterViewModel model);

        void UpdateSurveyAsync(Survey survey);

        Task<Dictionary<string, string>> GetEntityNames();

        Task<Dictionary<int, string>> GetRisks();
    }
}
