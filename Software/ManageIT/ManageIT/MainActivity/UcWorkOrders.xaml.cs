using BusinessLogicLayer.Services;
using EntitiesLayer.Entities;
using ManageIT.SideActivities;
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

namespace ManageIT.MainActivity {
    /// <summary>
    /// Interaction logic for UcWorkOrders.xaml
    /// </summary>
    public partial class UcWorkOrders : UserControl {
        public int ID_Worker { get; set; }
        private WorkOrderService service = new WorkOrderService();
        private OrderDetailService OrderDetailService = new OrderDetailService();
        public UcWorkOrders(int id_worker) {
            ID_Worker = id_worker;
            InitializeComponent();
        }

        

        private void btnSearchWorkOrders_Click(object sender, RoutedEventArgs e) {
            string phrase = txtSearchWorkOrders.Text;
            var workOrders = service.GetWorkOrdersByName(phrase);
            dgWorkOrders.ItemsSource = workOrders;
        }

        private void btnClearWorkOrders_Click(object sender, RoutedEventArgs e) {
            txtSearchWorkOrders.Clear();
            LoadWorkOrders();
        }

        private void btnAddWorkOrder_Click(object sender, RoutedEventArgs e) {
            WorkOrderAdd mainWindow = new WorkOrderAdd(ID_Worker);
            mainWindow.Show();
        }

        private void btnUpdateWorkOrder_Click(object sender, RoutedEventArgs e) {
            var selectedWorkOrder = GetSelectedWorkOrder() as WorkOrder;
            if(selectedWorkOrder != null) { 
            var selectedOrderDetail = selectedWorkOrder.Id_Order_Details;
            var orderDetail = OrderDetailService.GetOrderDetail(selectedOrderDetail) as OrderDetail;
            if(selectedWorkOrder != null) {
                WorkOrderUpdate mainWindow = new WorkOrderUpdate(orderDetail as OrderDetail);
                mainWindow.Show();
            }
            }
        }

        private void btnRemoveWorkOrder_Click(object sender, RoutedEventArgs e) {
            var selectedWorkOrder = GetSelectedWorkOrder();
            if(selectedWorkOrder != null) {
                service.RemoveWorkOrder(selectedWorkOrder as WorkOrder);
                LoadWorkOrders();
            }
        }

        private object GetSelectedWorkOrder() {
            return dgWorkOrders.SelectedItem as WorkOrder;
        }

        private void LoadWorkOrders() {
            WorkOrderService service = new WorkOrderService();
            var workOrders = service.GetWorkOrders();
            dgWorkOrders.ItemsSource = workOrders;
            HideColumns();
            DisplayNames();
        }

        private void DisplayNames() {
            dgWorkOrders.Columns[0].Header = "ID of work order";
            dgWorkOrders.Columns[1].Header = "Finished work order";
            dgWorkOrders.Columns[2].Header = "Date of creation";
            dgWorkOrders.Columns[4].Header = "ID of order detail related to the work order";
            dgWorkOrders.Columns[7].Header = "Work order created by";
        }

        private void HideColumns() {
            dgWorkOrders.Columns[5].Visibility = Visibility.Hidden;
            dgWorkOrders.Columns[6].Visibility = Visibility.Hidden;
            dgWorkOrders.Columns[3].Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            LoadWorkOrders();
        }

    }
}
