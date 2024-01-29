using BusinessLogicLayer.Services;
using EntitiesLayer.Entities;
using ManageIT.SideActivities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    ///<remarks>Darijo Bračić </remarks>
    public partial class Login : Window
    {
        WorkerService WorkerService = new WorkerService();
        ///<remarks>Darijo Bračić </remarks>
        public Login()
        {
            InitializeComponent();
            KeyDown += OnKeyDown;


        }
        ///<remarks>Darijo Bračić </remarks>
        private void Button_Click(object sender, RoutedEventArgs e)
        {        
            string username = txtUsername.Text;
            string password = passwordBox.Password;               
            Worker authenticatedWorker = WorkerService.Authenticate(username, password);
            if (authenticatedWorker != null)
        {
                int roleid = (int)authenticatedWorker.Id_type;
                int workerid = (int)authenticatedWorker.ID_worker;
                MainWindow mainWindow = new MainWindow(roleid, workerid, authenticatedWorker);
                mainWindow.Show();
                this.Close();
            }
        else
        {
                lblErrorMessage.Content = "Login unsuccesful. Check your credentials.";
                passwordBox.Password = "";
            }
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                OpenPdfDocument("Helpers\\Helper.pdf");  
            }
        }

        private void OpenPdfDocument(string pdfPath)
        {
           
                string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pdfPath);

               Process.Start(fullPath);
          
        }

    }
    }
