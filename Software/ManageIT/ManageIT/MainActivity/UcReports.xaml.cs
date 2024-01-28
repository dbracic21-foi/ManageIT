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
using System.Collections.ObjectModel;
using NuGet.Packaging;
using Newtonsoft.Json.Bson;
using System.Drawing;

namespace ManageIT.MainActivity
{
    /// <summary>
    /// Interaction logic for UcReports.xaml
    /// </summary>
    public partial class UcReports : UserControl
    {
        private int ID_Worker { get; set; }
        public ObservableCollection<string> ReportList { get; set; }
        Worker currentWorker = new Worker();
        ReportService reportService = new ReportService();
        WorkerService workerService = new WorkerService();
        public UcReports(Worker worker)
        {
            ID_Worker = 0;
            DataContext = this;
            ReportList = new ObservableCollection<string>(reportService.GetAllReports());
            currentWorker = worker;
            InitializeComponent();
            LoadWorkers();
        }

        private void RefreshList()
        {
            DataContext = this;
            ReportList.Clear(); 
            ReportList.AddRange(reportService.GetAllReports());
        }
        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            Worker selectedWorker = cmbWorkers.SelectedItem as Worker;
            if(selectedWorker != null)
            {
                ID_Worker = selectedWorker.ID_worker;
            }
            DateTime fromDate = (DateTime)dtpStartDate.SelectedDate;
            DateTime endDate = (DateTime)dtpEndDate.SelectedDate;

            if(dtpEndDate == null || dtpStartDate == null)
            {
                MessageBox.Show("You must select both dates to generate PDF.");
            }
            else if(fromDate < endDate)
            {
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
                report.GeneratePdf(filePath);
                RefreshList();
            }
            else
            {
                MessageBox.Show("Your First day must be earlier than your Last day.");
            }
            
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
            RefreshList();
        }

        private void LoadWorkers()
        {
            var workersForReport = workerService.GetAllWorkers();
            cmbWorkers.ItemsSource = workersForReport;
        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            cmbWorkers.IsEnabled = false;
            cmbWorkers.Background = System.Windows.Media.Brushes.Gray;
            ID_Worker = 0;
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            cmbWorkers.IsEnabled = true;
            cmbWorkers.Background = System.Windows.Media.Brushes.White;
        }
    }
}
