using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Services
{
    public class ImportManager : IImportService
    {
        private readonly string connStringAudit = "Server=192.168.13.126,1433;Database=CCB_AuditXOP;User ID=svc_everestech';Password=dBY6V!cF5cZC=KL-;";
        public void ImportSurveysAudit()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStringAudit))
            {
                conn.Open();
                // Creates a SQL command
                using (var command = new SqlCommand("Select * from V_TrackingElencoRilievi", conn))
                {
                    // Loads the query results into the table
                    dt.Load(command.ExecuteReader());
                }

                conn.Close();

            }            

        }
    }
}

