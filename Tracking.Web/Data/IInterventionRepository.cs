using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public interface IInterventionRepository
    {
        List<Intervention> GetInterventionsWithSurveys();

        Survey GetSurveyById(int id);

        Status GetStatusById(int id);

        List<Status> GetAllStatuses();

        List<SelectListItem> GetStatusesAsSelectList();

        List<RiskType> GetAllRiskTypes();

        RiskType GetRiskById(int id);

        List<Note> GetNotesForSurvey(int surveyId); 
        List<Intervention> GetAll();
    }
}
