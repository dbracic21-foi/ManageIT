using BusinessLogicLayer.Generator;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ReportService
    {
        public ReportModel reportNew { get; set; }

        public ReportService()
        {
            reportNew = new ReportModel();
        }
        public ReportModel CatchReportData(DateTime startDate, DateTime endDate, Worker creatorWorker, int ID_report)
        {
            using (var reportRepo = new ReportRepo())
            {
                List<WorkOrder> workOrdersByDate = new List<WorkOrder>();
                workOrdersByDate = reportRepo.GetWorkOrderByDate(startDate, endDate).ToList();
                reportNew.ID_Report = ID_report;
                reportNew.startDate = startDate;
                reportNew.finishDate = endDate;
                reportNew.creatorWorker = creatorWorker;
                reportNew.workOrderReport = workOrdersByDate;

                return reportNew;
            }  
        }
    }
}
