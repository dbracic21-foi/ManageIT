using BusinessLogicLayer.Generator;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using EntitiesLayer.Entities;
using QuestPDF.Fluent;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.InteropServices.ComTypes;


namespace ManageIT.MainActivity
{
    /// <summary>
    /// Interaction logic for UcReports.xaml
    /// </summary>
    public partial class UcReports : UserControl
    {
        public List<string> reportList { get; set; }
        Worker currentWorker = new Worker();
        ReportService reportService = new ReportService();
        WorkerService workerService = new WorkerService();
        public UcReports(Worker worker)
        {
            reportList = reportService.GetAllReports();
            currentWorker = worker;

            DataContext = this;
            InitializeComponent();
            LoadWorkers();
        }

        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            int ID_Worker = 0;
            Worker selectedWorker = cmbWorkers.SelectedItem as Worker;
            if(selectedWorker != null)
            {
                ID_Worker = selectedWorker.ID_worker;
            }
            DateTime fromDate = (DateTime)dtpStartDate.SelectedDate;
            DateTime endDate = (DateTime)dtpEndDate.SelectedDate;
            List<ReportView> reportViewList = new List<ReportView>();
            ReportModel reportModel = new ReportModel();
            reportViewList = reportService.DefineListItem(fromDate, endDate, currentWorker, 1, ID_Worker);
            reportModel = reportService.FillDataToModel(fromDate, endDate, currentWorker, 1, ID_Worker);

            var report = new ReportGenerator(reportModel, reportViewList);
            string formattedStartDate = fromDate.ToString("d.M.yyyy");
            string formattedFinishDate = endDate.ToString("d.M.yyyy");
            string date = DateTime.Now.ToString("d.M.yyyy");
            string time = DateTime.Now.ToString("HH.mm");
            var fileName = $"Report_IDWorker-{ID_Worker}_{date}_{time}_{formattedStartDate}_{formattedFinishDate}.pdf";
            string filePath = Path.Combine("../../../BusinessLogicLayer/Reports", fileName);
            report.GeneratePdf(filePath);;
        }

        private void btnOpenReport_Click(object sender, RoutedEventArgs e)
        {
            Button btnOpenReport = (Button)sender;
            string reportName = btnOpenReport.Tag.ToString();
            reportService.OpenReport(reportName);
        }

        private void btnDeleteReport_Click(object sender, RoutedEventArgs e)
        {
            Button btnDeleteReport = (Button)sender;
            string reportName = btnDeleteReport.Tag.ToString();

            if (reportService.deleteReport(reportName))
            {
                MessageBox.Show("Succesfully deleted report!");
            }
            else MessageBox.Show("There are some problems. Plesae contact the IT support.");
        }

        private void LoadWorkers()
        {
            var workersForReport = workerService.GetAllWorkers();
            cmbWorkers.ItemsSource = workersForReport;
        }
    }
}
