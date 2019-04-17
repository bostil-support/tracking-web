using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Tracking.Web.Managers
{
    public class SearchRemoteUserEmailService
    {
        private readonly string _connAud = null;
        private readonly string _connCompl = null;

        public SearchRemoteUserEmailService(string connAud, string connCompl)
        {
            _connAud = connAud;
            _connCompl = connCompl;
        }

        public string FindUserInAudience(string email)
        {
            using (IDbConnection db = new SqlConnection(_connAud))
            {
                var userEmail = db.Query<string>("Select Email From V_TrackingElencoUtentiRilievi Where Email = @email", new { email }).FirstOrDefault();
                return userEmail;
            }
        }

        public string FindUserInComplaince(string email)
        {
            using (IDbConnection db = new SqlConnection(_connCompl))
            {
                var userEmail = db.Query<string>("Select Email From V_TrackingElencoUtentiRilievi Where Email = @email", new { email }).FirstOrDefault();
                return userEmail;
            }
        }


    }
}
