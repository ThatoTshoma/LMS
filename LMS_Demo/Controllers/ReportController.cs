using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WebForms;
using LMS_Demo.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Reporting;

namespace LMS_Demo.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvirnoment;
        private readonly IReportReposit _reportRepository;


        public ReportController(IReportReposit reportRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvirnoment = webHostEnvironment;
            this._reportRepository = reportRepository;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
           
        }
        // public IEnumerable<Result> Results { get; set; }
      

        public async Task <IActionResult> Print()
        {
            string mimtype = ""; 
            int extension = 1;
            var path = $"{this._webHostEnvirnoment.WebRootPath}\\Report\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("parameter1", DateTime.Now.ToString("dd-MM-yyyy"));
            //parameters.Add("rp1", "ASP.NET CORE RDLC Report");
            //get products from product table 
            AspNetCore.Reporting.LocalReport localReport = new AspNetCore.Reporting.LocalReport(path);
            var results = await _reportRepository.GetResult();
            localReport.AddDataSource("DataSet1", results);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }
    }
}
