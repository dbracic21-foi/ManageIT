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

namespace ManageIT
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        WorkerService WorkerService = new WorkerService();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = passwordBox.Password;               
            Worker authenticatedWorker = WorkerService.Authenticate(email, password);

            if (authenticatedWorker != null)
        {
            MessageBox.Show("Uspješna prijava!");
        }
        else
        {
            MessageBox.Show("Neuspješna prijava. Provjerite korisničko ime i lozinku.");
        }
    }

           
        }
    }
