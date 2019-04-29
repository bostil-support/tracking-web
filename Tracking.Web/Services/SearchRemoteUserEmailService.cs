using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using Tracking.Web.Logs;

namespace Tracking.Web.Managers
{
    public class SearchRemoteUserEmailService
    {
        private readonly string _connAud = null;
        private readonly string _connCompl = null;
        private readonly ILogger<EmailServices> _logger;

        public EmailServices(string connAud, string connCompl)
        {
            _connAud = connAud;
            _connCompl = connCompl;
            
        }

        public string FindUserInAudience(string email)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connAud))
                {
                    var userEmail = db.Query<string>("Select Email From V_TrackingElencoUtentiRilievi Where Email = @email", new { email }).FirstOrDefault();
                    return userEmail;
                }
            }
            catch(Exception e)
            {
                _logger.Write(e.Message);
                return e.Message;
            }
        }

        public string FindUserInComplaince(string email)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connCompl))
                {
                    var userEmail = db.Query<string>("Select Email From V_TrackingElencoUtentiRilievi Where Email = @email", new { email }).FirstOrDefault();
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
