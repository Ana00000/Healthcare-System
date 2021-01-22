﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Report.Models;
using Report.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HealthClinicBackend.Backend.Model.Util;

namespace Report.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileTransferController : ControllerBase
    {
        private readonly SftpService sftpService;
        private readonly HttpFTService httpFTService;
        private readonly MedicineReportService medicineReportService;
        private readonly IWebHostEnvironment env;

        public FileTransferController(IWebHostEnvironment env)
        {
            this.sftpService = new SftpService();
            this.httpFTService = new HttpFTService();
            this.medicineReportService = new MedicineReportService();
            this.env = env;
        }

        [HttpPost("report/{start}/{end}")]
        public IActionResult ReportUsingSftp(string start, string end)
        {
            var myFile = "Report" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            
            List<MedicineReport> result = medicineReportService.GetByDateInterval(new TimeInterval(DateTime.Parse(start), DateTime.Parse(end)));

            sftpService.GenerateFile(result, myFile);

            if (env.IsDevelopment())
            {
                if (sftpService.SendFile(myFile))
                {
                    medicineReportService.SendNotificationAboutReport(myFile);
                    return Ok(result);
                }
                else return BadRequest();

            }
            if (env.IsProduction())
            {
                if (httpFTService.UploadFile(myFile))
                {
                    medicineReportService.SendNotificationAboutReport(myFile);
                    return Ok(result);
                }
                else return BadRequest();
            }
            return BadRequest();
        }

        [HttpPost("reportHttp")]
        public IActionResult ReportUsingHttp(Interval interval)
        {
            var myFile = "ReportHttp" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            List<MedicineReport> result = medicineReportService.GetByDateInterval(new TimeInterval(DateTime.Parse(interval.Start), DateTime.Parse(interval.End)));

            sftpService.GenerateFile(result, myFile);

                if (httpFTService.UploadFile(myFile))
                {
                    medicineReportService.SendNotificationAboutReport(myFile);
                    return Ok(result);
                }
                else return BadRequest();
        }

        [HttpGet("downloadReport")]
        public IActionResult Download()
        {
            if (sftpService.DownloadFile("sshjFile.txt")) return Ok();
            else return BadRequest();
        }
    }
}
