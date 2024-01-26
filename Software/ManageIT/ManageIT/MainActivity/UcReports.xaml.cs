using BusinessLogicLayer.Generator;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using EntitiesLayer.Entities;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManageIT.MainActivity
{
    /// <summary>
    /// Interaction logic for UcReports.xaml
    /// </summary>
    public partial class UcReports : UserControl
    {
        Worker currentWorker = new Worker();
        public UcReports(Worker worker)
        {
            currentWorker = worker;
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            DateTime fromDate = (DateTime)dtpStartDate.SelectedDate;
            DateTime endDate = (DateTime)dtpEndDate.SelectedDate;
            var reportService = new ReportService();
            List<ReportView> reportViewList = new List<ReportView>();
            ReportModel reportModel = new ReportModel();
            reportViewList = reportService.DefineListItem(fromDate, endDate, currentWorker, 1);
            reportModel = reportService.FillDataToModel(fromDate, endDate, currentWorker, 1);

            var report = new ReportGenerator(reportModel, reportViewList);
            report.GeneratePdf("C:\\Users\\mdesa\\Documents\\Test\\test.pdf");
        }
    }
}
