using BusinessLogicLayer.Services;
using EntitiLayer.Entities;
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

namespace ManageIT.MainActivity
{
    /// <summary>
    /// Interaction logic for UcWorkers.xaml
    /// </summary>
    public partial class UcWorkers : UserControl
    {
        WorkerService services = new WorkerService();
        public UcWorkers()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
          AddNewWorker addNewWorker = new AddNewWorker();
            addNewWorker.Show();
            GetAllWorkers();
            ShowAllWorkers();
           
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Worker selectedWorker = GetSelectedWorker();
            if (selectedWorker != null)
            {
                bool isSuccessful = services.RemoveWorker(selectedWorker);
                if (isSuccessful == false)
                {
                    MessageBox.Show("Application failed to remove selected worker!");
                }
                GetAllWorkers();
                ShowAllWorkers();

            }
        }

        private Worker GetSelectedWorker()
        {
           return dgUsers.SelectedItem as Worker;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAllWorkers();
        }
        private void ShowAllWorkers()
        {
            var allWorkers = services.GetWorkers();
            dgUsers.ItemsSource = allWorkers;
            dgUsers.Columns[3].Visibility = Visibility.Hidden;
            dgUsers.Columns[7].Visibility = Visibility.Hidden;
            dgUsers.Columns[8].Visibility = Visibility.Hidden;
            dgUsers.Columns[9].Visibility = Visibility.Hidden;
            dgUsers.Columns[10].Visibility = Visibility.Hidden;
            dgUsers.Columns[11].Visibility = Visibility.Hidden;
            dgUsers.Columns[12].Visibility = Visibility.Hidden;
            dgUsers.Columns[13].Visibility = Visibility.Hidden;




        }
        private void GetAllWorkers()
        {
            var allWorkers = services.GetWorkers();
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
