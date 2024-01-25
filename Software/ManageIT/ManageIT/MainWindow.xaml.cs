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

namespace ManageIT {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public bool IsAdmin { get; private set; }

       
        public MainWindow()
        {
            InitializeComponent();
            InitializeUI();
        }
        public MainWindow(int user_role) : this()
        {
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

        }

        private void btnWorkOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWorkers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
