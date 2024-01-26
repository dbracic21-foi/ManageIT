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
using ManageIT.MainActivity;
using ManageIT.SideActivities;

namespace ManageIT {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public bool IsAdmin { get; private set; }
        public int ID_Worker { get; set; }

       
        public MainWindow()
        {
            InitializeComponent();
            InitializeUI();
        }
        public MainWindow(int user_role, int id_worker) : this()
        {
            ID_Worker = id_worker;
            if (user_role == 1)
            {
                IsAdmin = true;
            }
            else
            {
                IsAdmin = false;
            }
            InitializeUI();
        }

        private void InitializeUI()
        {
            btnWorkers.Visibility = IsAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReciepts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            contentPanel.Content = new MainActivity.UcClients();
        }

        private void btnWorkOrder_Click(object sender, RoutedEventArgs e)
        {
            contentPanel.Content = new MainActivity.UcWorkOrders(ID_Worker);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWorkers_Click(object sender, RoutedEventArgs e)
        {
            contentPanel.Content = new MainActivity.UcWorkers();
        }

        public static implicit operator MainWindow(WorkOrderAdd v) {
            throw new NotImplementedException();
        }
    }
}
