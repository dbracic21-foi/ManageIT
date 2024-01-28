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
    /// Interaction logic for AddNewWorker.xaml
    /// </summary>
    ///<remarks>Darijo Bračić </remarks>
    public partial class AddNewWorker : Window
    {
        public AddNewWorker()
        {
          InitializeComponent();
        }
        ///<remarks>Darijo Bračić </remarks>
        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            var worker = new Worker
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Password = passwordBox.Password,
                Gender = txtGender.Text,
                UserName = txtUsername.Text,

            };
            if(worker.FirstName != "" && worker.LastName != "" && worker.Email !="" && worker.Password !="" )
            {
                var services = new WorkerService();
                bool isSuccessful = services.AddWorker(worker);

                if(isSuccessful == false)
                {
                    MessageBox.Show("Worker was not added!");
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Worker fields are important");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

  
    }
}
