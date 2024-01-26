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
            LoadWorkOrders();
        }

        

        private void btnSearchWorkOrders_Click(object sender, RoutedEventArgs e) {

        }

        private void btnClearWorkOrders_Click(object sender, RoutedEventArgs e) {

        }

        private void btnAddWorkOrder_Click(object sender, RoutedEventArgs e) {
            WorkOrderAdd mainWindow = new WorkOrderAdd(ID_Worker);
            mainWindow.Show();
        }

        private void btnUpdateWorkOrder_Click(object sender, RoutedEventArgs e) {
            var selectedWorkOrder = GetSelectedWorkOrder() as WorkOrder;
            var selectedOrderDetail = selectedWorkOrder.Id_Order_Details;
            var orderDetail = OrderDetailService.GetOrderDetail(selectedOrderDetail) as OrderDetail;
            if(selectedWorkOrder != null) {
                WorkOrderUpdate mainWindow = new WorkOrderUpdate(orderDetail as OrderDetail);
                mainWindow.Show();
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
        }
    }
}
