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
using BusinessLogicLayer.Services;
using EntitiesLayer.Entities;

namespace ManageIT.SideActivities {
    public partial class WorkOrderAdd : Window {
        public int id_worker { get; set; }
        public WorkOrderAdd(int ID_Worker) {
            id_worker = ID_Worker;
            InitializeComponent();
            LoadClients();
            LoadWorkers();
            LoadWorkTypes();
            txtLocation.Text = "";
            txtLocation.IsEnabled = false;
        }

        private void LoadWorkTypes() {
            var workTypeService = new WorkTypeService();
            var workType = workTypeService.GetWorkTypes();
            cmbWorkType.ItemsSource = workType;
        }

        private void LoadWorkers() {
            var workerService = new WorkerService();
            var workers = workerService.GetWorkers();
            cmbWorker.ItemsSource = workers;
        }

        private void LoadClients() {
            var clientService = new ClientService();
            var clients = clientService.GetClients();
            cmbClient.ItemsSource = clients;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            if (cmbClient.SelectedItem == null) {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            if (cmbWorker.SelectedItem == null) {
                MessageBox.Show("Please select a worker!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbWorkType.SelectedItem == null) {
                MessageBox.Show("Please select a work type!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var orderDetail = new OrderDetail {
                Client = cmbClient.SelectedItem as Client,
                Worker = cmbWorker.SelectedItem as Worker,
                Location = txtLocation.Text,
                Date = CombineDateAndTime(dateWorkOrder.SelectedDate ?? DateTime.Now, TimeSpan.Parse(txtStartTime.Text)),
                WorkType = cmbWorkType.SelectedItem as WorkType,
                Duration = TimeSpan.Parse(txtTime.Text),
            };

            var orderDetailService = new OrderDetailService();
            orderDetailService.AddOrderDetail(orderDetail);

            var workOrder = new WorkOrder {
                OrderDetail = orderDetail,
                ID_Worker = id_worker,
                DateCreated = DateTime.Now,
                IsFinished = false,
            };
            var workOrderService = new WorkOrderService();

            if (workOrderService.AddWorkOrder(workOrder)) {
                MessageBox.Show("Succesfully added a work order!");
                Close();
            } else {
                MessageBox.Show("Please fill in all the fields!");
            }
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
