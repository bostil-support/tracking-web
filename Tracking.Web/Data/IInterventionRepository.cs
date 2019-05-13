using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tracking.Web.Models;
using Tracking.Web.Models.ViewModel;
using System.Linq;

namespace Tracking.Web.Data
{
    public interface IInterventionRepository
    {
        List<Intervention> GetAllInterventions();

        //List<Survey> GetAllSurveys();

        Survey GetSurveyById(string id);

        Task<List<IGrouping<int, Survey>>> GroupSurveyByIntervId(TrackingUser user);

        Status GetStatusById(int? id);

        List<Status> GetAllStatuses();

        List<SelectListItem> GetStatusesAsSelectList();

        List<RiskType> GetAllRiskTypes();

        string GetSurveyRisk(string SurveyId);

        List<Note> GetNotesForSurvey(string surveyId);

        void CreateNote(Note item);

        void CreateFile(File item);

        List<File> GetAllFiles();

        File GetFileByPath(string path);

        List<TrackingUser> GetAllUsers();

        List<IGrouping<int, Survey>> Filter(FilterViewModel model,TrackingUser user);

        void UpdateSurveyAsync(Survey survey);

        Task<Dictionary<string, string>> GetEntityNames();

        Task<Dictionary<int, string>> GetRisks();

        List<string> GetBankNames();

        List<string> GetOwners();

        List<string> GetSeverities();

        List<string> GetStatusesName();
    }
}
