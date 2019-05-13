using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Data;
using Tracking.Web.Logigng;
using Tracking.Web.Models;

namespace Tracking.Web.Services
{
    public class SurveysService : ISurveysService
    {
        private readonly string _connStringAudit = "Server=192.168.13.126,1433;Database='CCB_AuditXOP';User ID='svc_everestech';Password='dBY6V!cF5cZC=KL-';";
        private readonly string _connStringComplaince = "Server=192.168.13.126,1433;Database='CCB_ComplianceXOP';User ID='svc_everestech';Password='dBY6V!cF5cZC=KL-';";
        private readonly ILogger<SurveysService> _logger;
        private ApplicationDbContext _context;

        public SurveysService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get all surveys from remote Auditor Db related by user
        /// </summary>
        /// <param name="email">current auditor user email</param>
        public IList<Survey> GetSurveysAuditorByUserEmail(string email)
        {
            var surveys = new List<Survey>();
            try
            {
                using (IDbConnection db = new SqlConnection(_connStringAudit))
                {
                    var idsSurveys = db.Query<IdsSurveys>("Select (CONVERT(nvarchar(450), Id_Rilievo) + Funzione) as IdRilievo From V_TrackingElencoUtentiRilievi Where Email = @email",
                      new { email }).ToArray<IdsSurveys>();

                    int count = idsSurveys.Count();

                    surveys = _context.Surveys.Where(o => idsSurveys.Where(x => x.IdRilievo).Contains(o.Id)).ToList();
                }
            }
            catch (Exception e)
            {
                var err = e.Message;
                //_logger.Write(e.Message);
            }

            return surveys;
        }

        /// <summary>
        /// get all surveys from remote Complaince Db related by user
        /// </summary>
        /// <param name="email">current complaince user email</param>
        public IList<Survey> GetSurveysComplainceByUserEmail(string email)
        {
            var surveys = new List<Survey>();
            try
            {
                using (IDbConnection db = new SqlConnection(_connStringComplaince))
                {
                    var idsSurveys = db.Query<IdsSurveys>("Select (CONVERT(nvarchar(450), Id_Rilievo) + Funzione) as IdRilievo From V_TrackingElencoUtentiRilievi Where Email = @email",
                        email).ToList();

                    //surveys = _context.Surveys.Where(o => idsSurveys.Contains(o.Id)).ToList();
                }
            }
            catch (Exception e)
            {
                _logger.Write(e.Message);
            }

            return surveys;
        }
    }

    class IdsSurveys
    {
        public string IdRilievo { get; set; }
    }
}
