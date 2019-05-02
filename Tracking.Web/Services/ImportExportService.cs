using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using Tracking.Web.Logigng;

namespace Tracking.Web.Services
{
    public class ImportExportService : IImportExportService
    {
        private readonly string _connStringAudit = "Server=192.168.13.126,1433;Database='CCB_AuditXOP';User ID='svc_everestech';Password='dBY6V!cF5cZC=KL-';";
        private readonly string _connStringComplaince = "Server=192.168.13.126,1433;Database='CCB_ComplianceXOP';User ID='svc_everestech';Password='dBY6V!cF5cZC=KL-';";
        private readonly string _conn;
        private readonly ILogger<ImportExportService> _logger;

        public ImportExportService(string connection)
        {
            _conn = connection;
        }

        public void ImportSurveysAudit()
        {
            var dt = GetDataTableAuditSurveys();

            try
            {
                using (var sqlcon = new SqlConnection(_conn))
                {
                    sqlcon.Open();
                    using (var sqlcmd = new SqlCommand("sp_ImportSurveys", sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@surveys", dt);
                        sqlcmd.ExecuteNonQuery();
                    }
                    sqlcon.Close();
                }
            }
            catch (SqlException e)
            {
                _logger.Write(e.Message);
            }
        }

        public void ImportSurveysComplaince()
        {
            DataTable dt = GetDataTableComplainceSurveys();

            try
            {
                using (var sqlcon = new SqlConnection(_conn))
                {
                    sqlcon.Open();
                    using (var sqlcmd = new SqlCommand("sp_ImportSurveys", sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@surveys", dt);
                        sqlcmd.ExecuteNonQuery();
                    }
                    sqlcon.Close();
                }
            }
            catch (SqlException e)
            {
                var text = e.Message;
                //_logger.Write(e.Message);
            }
        }

        public void ImportDescriptiveAttributes()
        {
            var dt = GetDataTableDescriptiveAttributes();

            try
            {
                using (var sqlcon = new SqlConnection(_conn))
                {
                    sqlcon.Open();
                    using (var sqlcmd = new SqlCommand("sp_ImportDescriptiveAttributes", sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@descAttr", dt);
                        sqlcmd.ExecuteNonQuery();
                    }
                    sqlcon.Close();
                }
            }
            catch (SqlException e)
            {
                _logger.Write(e.Message);
            }
        }

        public void ImportDescriptiveAttributesComplaince()
        {
            var dt = GetDataTableDescriptiveAttributesComplaince();

            try
            {
                using (var sqlcon = new SqlConnection(_conn))
                {
                    sqlcon.Open();
                    using (var sqlcmd = new SqlCommand("sp_ImportDescriptiveAttributes", sqlcon))
                    {
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@descAttr", dt);
                        sqlcmd.ExecuteNonQuery();
                    }
                    sqlcon.Close();
                }
            }
            catch (SqlException e)
            {
                _logger.Write(e.Message);
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
        
        private DataTable GetDataTableComplainceSurveys()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connStringComplaince))
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

        private DataTable GetDataTableDescriptiveAttributesComplaince()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connStringComplaince))
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

