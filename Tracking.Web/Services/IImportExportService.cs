namespace Tracking.Web.Services
{
    public interface IImportExportService
    {
        void ImportSurveysAudit();
        void ImportSurveysComplaince();
        void ImportDescriptiveAttributes();
        void ImportDescriptiveAttributesComplaince();
    }
}