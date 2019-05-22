using System.Collections.Generic;
using Tracking.Web.Models;

namespace Tracking.Web.Services
{
    public interface ISurveysService
    {
        IList<Survey> GetSurveysAuditorByUserEmail(string email);
        IList<Survey> GetSurveysComplainceByUserEmail(string email);
        IList<Survey> GetSurveysBusinessAuditor(TrackingUser user);
        IList<Survey> GetSurveysBusinessCompliancer(TrackingUser user);
    }
}