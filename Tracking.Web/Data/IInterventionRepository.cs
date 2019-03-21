using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Models;

namespace Tracking.Web.Data
{
    public interface IInterventionRepository
    {
        List<Intervention> GetInterventionsWithSurveys();
        Survey GetSurveyById(int id);
    }
}
