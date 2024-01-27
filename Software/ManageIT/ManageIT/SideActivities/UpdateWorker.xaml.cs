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
    ///<remarks>Darijo Bračić </remarks>
    public partial class UpdateWorker : Window
    {
        WorkerService workerService = new WorkerService();
        public int selectedWorkerId { get; set; }
        ///<remarks>Darijo Bračić </remarks>
        public UpdateWorker(int SelectWorkerID)
        {
            InitializeComponent();
            selectedWorkerId = SelectWorkerID;
        }
        ///<remarks>Darijo Bračić </remarks>
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
        ///<remarks>Darijo Bračić </remarks>
        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            Worker updatedWorker = new Worker { 
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Gender = txtGender.Text,
                UserName = txtUsername.Text,
                Password = passwordBox.Password,
            
            
            };
            if(workerService.UpdateWorker(updatedWorker))
            {
                MessageBox.Show("Worker updated");
                Close();
            }
            else
            {
                MessageBox.Show("Worker not updated");
            }
        }
        ///<remarks>Darijo Bračić </remarks>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
