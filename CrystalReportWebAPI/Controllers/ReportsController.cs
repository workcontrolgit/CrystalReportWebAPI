using CrystalReportWebAPI.Utilities;
using System.Net.Http;
using System.Web.Http;

namespace CrystalReportWebAPI.Controllers
{
    [RoutePrefix("api/Reports")]
    public class ReportsController : ApiController
    {
        [AllowAnonymous]
        [Route("Financial/VarianceAnalysisReport")]
        [HttpGet]
        [ClientCacheWithEtag(60)]  //1 min client side caching
        public HttpResponseMessage FinancialVarianceAnalysisReport()
        {
            string reportPath = "~/Reports/Financial";
            string reportFileName = "YTDVarianceCrossTab.rpt";
            string exportFilename = "YTDVarianceCrossTab.pdf";

            HttpResponseMessage result = CrystalReport.RenderReport(reportPath, reportFileName, exportFilename);
            return result;
        }

        [AllowAnonymous]
        [Route("Demonstration/ComparativeIncomeStatement")]
        [HttpGet]
        [ClientCacheWithEtag(60)]  //1 min client side caching
        public HttpResponseMessage DemonstrationComparativeIncomeStatement()
        {
            string reportPath = "~/Reports/Demonstration";
            string reportFileName = "ComparativeIncomeStatement.rpt";
            string exportFilename = "ComparativeIncomeStatement.pdf";

            HttpResponseMessage result = CrystalReport.RenderReport(reportPath, reportFileName, exportFilename);
            return result;
        }

        [AllowAnonymous]
        [Route("VersatileandPrecise/Invoice")]
        [HttpGet]
        [ClientCacheWithEtag(60)]  //1 min client side caching
        public HttpResponseMessage VersatileandPreciseInvoice()
        {
            string reportPath = "~/Reports/VersatileandPrecise";
            string reportFileName = "Invoice.rpt";
            string exportFilename = "Invoice.pdf";

            HttpResponseMessage result = CrystalReport.RenderReport(reportPath, reportFileName, exportFilename);
            return result;
        }

        [AllowAnonymous]
        [Route("VersatileandPrecise/FortifyFinancialAllinOneRetirementSavings")]
        [HttpGet]
        [ClientCacheWithEtag(60)]  //1 min client side caching
        public HttpResponseMessage VersatileandPreciseFortifyFinancialAllinOneRetirementSavings()
        {
            string reportPath = "~/Reports/VersatileandPrecise";
            string reportFileName = "FortifyFinancialAllinOneRetirementSavings.rpt";
            string exportFilename = "FortifyFinancialAllinOneRetirementSavings.pdf";

            HttpResponseMessage result = CrystalReport.RenderReport(reportPath, reportFileName, exportFilename);

            return result;
        }
    }
}