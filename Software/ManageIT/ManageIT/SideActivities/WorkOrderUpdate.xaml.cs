using BusinessLogicLayer.Services;
using EntitiesLayer.Entities;
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
using System.Windows.Shapes;

namespace ManageIT.SideActivities {
    /// <summary>
    /// Interaction logic for WorkOrderUpdate.xaml
    /// </summary>
    public partial class WorkOrderUpdate : Window {
        private OrderDetail orderDetail;
        public WorkOrderUpdate(OrderDetail selectedOrder) {
            InitializeComponent();
            orderDetail = selectedOrder;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            txtLocation.Text = orderDetail.Location;
            txtStartTime.Text = orderDetail.Date.ToString();
            txtTime.Text = orderDetail.Duration.ToString();
            txtLocation.IsEnabled = false;

            LoadClients();
            SelectClient(orderDetail.ID_Client);
            LoadWorkers();
            SelectWorker(orderDetail.ID_Worker);
            LoadWorkTypes();
            SelectWorkType(orderDetail.ID_Work_Type);
        }

        private void SelectWorkType(int? iD_Work_Type) {
            for (int i = 0; i < cmbWorkType.Items.Count; i++) {
                WorkType c = cmbWorkType.Items[i] as WorkType;
                if (c.ID_Work_Type == iD_Work_Type) {
                    cmbWorkType.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SelectWorker(int? iD_Worker) {
            for (int i = 0; i < cmbWorker.Items.Count; i++) {
                Worker c = cmbWorker.Items[i] as Worker;
                if (c.ID_worker == iD_Worker) {
                    cmbWorker.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SelectClient(int? iD_Client) {
            for (int i = 0; i < cmbClient.Items.Count; i++) {
                Client c = cmbClient.Items[i] as Client;
                if(c.ID_client == iD_Client) {
                    cmbClient.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadWorkers() {
            var workerService = new WorkerService();
            var workers = workerService.GetWorkers();
            cmbWorker.ItemsSource = workers;
        }

        private void LoadWorkTypes() {
            var workTypeService = new WorkTypeService();
            var workType = workTypeService.GetWorkTypes();
            cmbWorkType.ItemsSource = workType;
        }

        private void LoadClients() {
            var clientService = new ClientService();
            var clients = clientService.GetClients();
            cmbClient.ItemsSource = clients;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e) {
            var client = cmbClient.SelectedItem as Client;
            var worker = cmbWorker.SelectedItem as Worker;
            var workType = cmbWorkType.SelectedItem as WorkType;

            orderDetail.Client = client;
            orderDetail.WorkType = workType;
            orderDetail.Worker = worker;
            orderDetail.Location = txtLocation.Text;
            orderDetail.Duration = TimeSpan.Parse(txtTime.Text);
            orderDetail.Date = CombineDateAndTime(dateWorkOrder.SelectedDate ?? DateTime.Now, TimeSpan.Parse(txtStartTime.Text));

            var detailService = new OrderDetailService();
            detailService.UpdateOrderDetail(orderDetail);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void cmbClient_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedClient = cmbClient.SelectedItem as Client;

            if (selectedClient != null) {
                txtLocation.Text = selectedClient.Client_Address;
            }
        }

        private DateTime CombineDateAndTime(DateTime date, TimeSpan time) {
            return date.Date + time;
        }
    }
}
