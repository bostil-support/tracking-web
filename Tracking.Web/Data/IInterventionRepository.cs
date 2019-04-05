using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public interface IInterventionRepository
    {
        List<Intervention> GetAllInterventions();

        List<Survey> GetAllSurveys();

        Survey GetSurveyById(int id);

        Status GetStatusById(int id);

        List<Status> GetAllStatuses();

        List<SelectListItem> GetStatusesAsSelectList();

        List<RiskType> GetAllRiskTypes();

        RiskType GetRiskById(int id);

        List<Note> GetNotesForSurvey(int surveyId);

        void CreateNote(Note item);

        void CreateFile(File item);

        List<File> GetAllFiles();

        File GetFileByPath(string path);

        List<TrackingUser> GetAllUsers();

        List<Intervention> GetInterventionsByFilterSurveys(string surveySeverit);

        void UpdateSurveyAsync(Survey survey);
    }
}
