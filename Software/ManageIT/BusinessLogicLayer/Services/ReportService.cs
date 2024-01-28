﻿using BusinessLogicLayer.Generator;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public List<ReportView> DefineListItem(DateTime startDate, DateTime endDate, Worker creatorWorker, int ID_report, int ID_Worker)
        {
            using (var reportRepo = new ReportRepo())
            {
                List<WorkOrder> workOrders = new List<WorkOrder>();
                if (ID_Worker == 0)
                {
                    workOrders = reportRepo.GetWorkOrderByDate(startDate, endDate).ToList();
                }
                else
                {
                    workOrders = reportRepo.GetWorkOrdersByDateAndWorker(startDate, endDate, ID_Worker).ToList();
                }
                reportNew.ID_Report = ID_report;
                reportNew.startDate = startDate;
                reportNew.finishDate = endDate;
                reportNew.creatorWorker = creatorWorker;
                reportNew.workOrderReport = workOrders;

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
                    reportLine.Worker = $"{item.OrderDetail.Worker.FirstName} {item.OrderDetail.Worker.LastName}";
                    reportLine.Address = $"{item.OrderDetail.Client.Client_Address}";
                    reportLine.Date = $"{item.DateCreated.ToString("MM/dd/yyyy")}";
                    reportViewList.Add(reportLine);
                }

                return reportViewList;
            }  
        }

        public ReportModel FillDataToModel(DateTime startDate, DateTime endDate, Worker creatorWorker, int ID_report, int ID_worker)
        {
            using (var reportRepo = new ReportRepo())
            {
                List<WorkOrder> workOrders = new List<WorkOrder>();
                if(ID_worker == 0)
                {
                    workOrders = reportRepo.GetWorkOrderByDate(startDate, endDate).ToList();
                }else
                {
                    workOrders = reportRepo.GetWorkOrdersByDateAndWorker(startDate, endDate, ID_worker).ToList();
                }
                reportNew.ID_Report = ID_report;
                reportNew.startDate = startDate;
                reportNew.finishDate = endDate;
                reportNew.creatorWorker = creatorWorker;
                reportNew.workOrderReport = workOrders;

                return reportNew;
            }
        }

        public List<string> GetAllReports()
        {
            if (Directory.Exists("../../../BusinessLogicLayer/Reports"))
            {
                string[] fileNames = Directory.GetFiles("../../../BusinessLogicLayer/Reports");

                // Create a list to store the file names
                List<string> fileList = new List<string>();
                foreach (string fileName in fileNames)
                {
                    fileList.Add(Path.GetFileName(fileName));
                }

                Console.WriteLine("List of file names:");
                return fileList;
            }
            else
            {
                Console.WriteLine("The folder does not exist.");
                return null;
            } 
        }

        public bool deleteReport(string reportName)
        {
            string filePath = Path.Combine("../../../BusinessLogicLayer/Reports", reportName);
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Report '{reportName}' deleted successfully.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting report '{reportName}': {ex.Message}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Report '{reportName}' does not exist.");
                return false;
            }
        }

        public void OpenReport(string reportName)
        {
            string filePath = Path.Combine("../../../BusinessLogicLayer/Reports", reportName);
            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error opening report '{reportName}': {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Report '{reportName}' does not exist.");
            }
        }
    }
}
