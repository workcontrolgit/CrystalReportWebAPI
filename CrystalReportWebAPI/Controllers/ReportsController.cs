using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalReportWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrystalReportWebAPI.Controllers
{
    [RoutePrefix("api/Reports")]
    public class ReportsController : ApiController
    {
        [AllowAnonymous]
        [Route("Position")]
        [HttpGet]
        public HttpResponseMessage PositionListing()
        {
            var rd = new ReportDocument();

            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "PositionListing.rpt"));
            MemoryStream ms = new MemoryStream();
            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                stream.CopyTo(ms);
            }

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(ms.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "PositionListing.pdf"
                };
            result.Content.Headers.ContentType =
                //new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            return result;
        }
        [AllowAnonymous]
        [Route("Demonstration/ComparativeIncomeStatement")]
        //[ActionName("GetComparativeIncomeStatement")]
        [HttpPost]
        public HttpResponseMessage DemonstrationComparativeIncomeStatement(LoginData login)
        {
            if (login != null) {
                string username = login.Username;
                string password = login.Password;
            };

                var rd = new ReportDocument();

            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports/Demonstration"), "ComparativeIncomeStatement.rpt"));
            MemoryStream ms = new MemoryStream();
            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                stream.CopyTo(ms);
            }

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(ms.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "PositionListing.pdf"
                };
            result.Content.Headers.ContentType =
                //new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            return result;
        }
    }
}
