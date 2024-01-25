using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using EntitiesLayer.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManageIT.MainActivity
{
    /// <summary>
    /// Interaction logic for ClientView.xaml
    /// </summary>
    public partial class UcClients : UserControl
    {
        ClientService clientService = new ClientService();
        List<ClientViewModel> clients = new List<ClientViewModel>();
        public UcClients()
        {
            InitializeComponent();
            GetAllClients();
            ShowClients();
        }

        private void btnSearchClients_Click(object sender, RoutedEventArgs e)
        {
            string key = txtSearchClients.Text.ToString();
            clients = clientService.SearchClients(key);
            ShowClients();
        }

        private void btnClearClients_Click(object sender, RoutedEventArgs e)
        {
            GetAllClients();
            ShowClients();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetAllClients()
        {
            clients = clientService.GetClientsView();
        }

        private void ShowClients()
        {   
            dgClients.ItemsSource = clients;
        }
    }
}