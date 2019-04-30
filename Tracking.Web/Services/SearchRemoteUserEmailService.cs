using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Logging;
using Tracking.Web.Logigng;

namespace Tracking.Web.Managers
{
    public class SearchRemoteUserEmailService
    {
        private readonly string _connAud = null;
        private readonly string _connCompl = null;
        private readonly ILogger<SearchRemoteUserEmailService> _logger;

        public SearchRemoteUserEmailService(string connAud, string connCompl)
        {
            _connAud = connAud;
            _connCompl = connCompl;
            
        }

        public string FindUserInAudience(string userName)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connAud))
                {
                    var userEmail = db.Query<string>("Select Email From V_TrackingElencoUtentiRilievi Where UserName = @userName", new { userName }).FirstOrDefault();
                    return userEmail;
                }
            }
            catch(Exception e)
            {
                _logger.Write(e.Message);
                return e.Message;
            }
        }

        public string FindUserInComplaince(string userName)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connCompl))
                {
                    var userEmail = db.Query<string>("Select Email From V_TrackingElencoUtentiRilievi Where UserName = @userName", new { userName }).FirstOrDefault();
                    return userEmail;
                }
            }
            catch(Exception e)
            {
                _logger.Write(e.Message);
                return e.Message;
            }

        }


    }
}
