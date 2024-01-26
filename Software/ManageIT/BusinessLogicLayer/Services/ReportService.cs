using BusinessLogicLayer.Generator;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogicLayer.Services
{
    public class ReportService
    {
        public ReportModel reportNew { get; set; }

        public ReportService()
        {
            reportNew = new ReportModel();
        }
        public List<ReportView> DefineListItem(DateTime startDate, DateTime endDate, Worker creatorWorker, int ID_report)
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

                List<ReportView> reportViewList = new List<ReportView>();

                foreach (var item in reportNew.workOrderReport)
                {
                    ReportView reportLine = new ReportView();
                    reportLine.WorkType = item.OrderDetail.WorkType.Name.ToString();
                    if (item.OrderDetail.Client.ID_type == 1)
                    {
                        reportLine.Client=$"{item.OrderDetail.Client.FirstName} {item.OrderDetail.Client.LastName}";
                    }
                    else reportLine.Client = $"{item.OrderDetail.Client.CompanyName}";
                    reportLine.Worker = $"{item.Worker.FirstName} {item.Worker.LastName}";
                    reportLine.Address = $"{item.OrderDetail.Client.Client_Address}";
                    reportLine.Date = $"{item.DateCreated}";
                    reportViewList.Add(reportLine);
                }

                return reportViewList;
            }  
        }

        public ReportModel FillDataToModel(DateTime startDate, DateTime endDate, Worker creatorWorker, int ID_report)
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
