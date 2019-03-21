using System.Collections.Generic;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public interface IInterventionRepository
    {
        List<Intervention> GetAll();
        Survey GetSurveyById(int id);
    }
}
