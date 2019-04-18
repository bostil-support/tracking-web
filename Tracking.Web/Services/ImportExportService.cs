using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tracking.Web.Models.ViewModel;

namespace Tracking.Web.Services
{
    public class ImportExportService : IImportExportService
    {
        private readonly string _connStringAudit = "Server=192.168.13.126,1433;Database=CCB_AuditXOP;User ID=svc_everestech';Password=dBY6V!cF5cZC=KL-;";
        private readonly string _conn;

        public ImportExportService(string connection)
        {
            _conn = connection;
        }

        public void ImportSurveysAudit()
        {
            var dt = GetDataTableAuditSurveys();

            using (var sqlcon = new SqlConnection(_conn))
            {
                using (var sqlcmd = new SqlCommand("ps_ImportSurveys", sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@surveys", dt);
                    sqlcmd.ExecuteNonQuery();
                }
            }
        }

        public void ImportDescriptiveAttributes()
        {
            var dt = GetDataTableDescriptiveAttributes();

            using (var sqlcon = new SqlConnection(_conn))
            {
                using (var sqlcmd = new SqlCommand("ps_ImportDescriptiveAttributes", sqlcon))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@descAttr", dt);
                    sqlcmd.ExecuteNonQuery();
                }
            }
        }
        
        private DataTable GetDataTableAuditSurveys()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connStringAudit))
            {
                conn.Open();

                using (var command = new SqlCommand("Select * from V_TrackingElencoRilievi", conn))
                {
                    // Loads the query results into the table
                    dt.Load(command.ExecuteReader());
                }
                conn.Close();
            }
            return dt;
        }

        private DataTable GetDataTableDescriptiveAttributes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connStringAudit))
            {
                conn.Open();

                using (var command = new SqlCommand("Select * from .V_TrackingElencoAlberatureRilievi", conn))
                {
                    // Loads the query results into the table
                    dt.Load(command.ExecuteReader());
                }
                conn.Close();
            }
            return dt;
        }
    }
}

