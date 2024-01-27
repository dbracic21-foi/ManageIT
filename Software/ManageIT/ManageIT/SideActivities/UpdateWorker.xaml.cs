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

namespace ManageIT.SideActivities
{
    /// <summary>
    /// Interaction logic for UpdateWorker.xaml
    /// </summary>
    public partial class UpdateWorker : Window
    {
        public int selectedWorkerId { get; set; }
        public UpdateWorker(int SelectWorkerID)
        {
            InitializeComponent();
            selectedWorkerId = SelectWorkerID;
            MessageBox.Show(selectedWorkerId.ToString());
        }
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WorkerService workerService = new WorkerService();
            Worker worker = workerService.GetWorkersByID(selectedWorkerId);
            txtFirstName.Text = worker.FirstName;
            txtLastName.Text = worker.LastName;
            txtEmail.Text = worker.Email;
            txtGender.Text = worker.Gender;
            txtUsername.Text = worker.UserName;
            passwordBox.Password = worker.Password;

        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            Worker updatedWorker = new Worker { 
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text.ToString(),
                Gender = txtGender.Text,
                UserName = txtUsername.Text,
                Password = passwordBox.Password
            
            
            };
            WorkerService workerService = new WorkerService();
            if(workerService.UpdateWorker(updatedWorker))
            {
                MessageBox.Show("Worker updated");
                this.Close();
            }
            else
            {
                MessageBox.Show("Worker not updated");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
