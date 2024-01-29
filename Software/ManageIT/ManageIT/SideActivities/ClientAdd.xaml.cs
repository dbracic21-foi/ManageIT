﻿using BusinessLogicLayer.Services;
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
    /// Interaction logic for ClientAdd.xaml
    /// </summary>
    /// <remarks>
    /// Matej Desanić
    /// </remarks>
    public partial class ClientAdd : Window
    {
        ClientService clientService = new ClientService();
        ClientTypeService ctService = new ClientTypeService();
        Client client = new Client();

        public ClientAdd()
        {
            InitializeComponent();
            LoadClientTypes();
            txtCompanyNameNew.IsEnabled = false;
            txtIBANNew.IsEnabled = false;
            txtCompanyNameNew.Background = Brushes.Gray;
            txtIBANNew.Background = Brushes.Gray;
            txtCompanyNameNew.Text = "";
            txtIBANNew.Text = "";
            txtFirstNameNew.IsEnabled = false;
            txtLastNameNew.IsEnabled = false;
            txtFirstNameNew.Background = Brushes.Gray;
            txtLastNameNew.Background = Brushes.Gray;
            txtFirstNameNew.Text = "";
            txtLastNameNew.Text = "";
        }

        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            if (LoadNewClient())
            {
                if (clientService.AddClient(client))
                {
                    MessageBox.Show("Succesfully added a new client!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Somethig's wrong.");
                }
            }
        }

        private bool LoadNewClient()
        {
            var clientType = cmbClientType.SelectedItem as ClientType;
            if (int.TryParse(txtIDNew.Text, out int id))
            {
                client.ID_client = id;
            }
            else
            {
                MessageBox.Show("Invalid ID format. Please enter a valid integer.");
                return false;
            }

            client.Email = txtEmailNew.Text.ToString();
            client.Number = txtNumberNew.Text.ToString();
            client.Client_Address = txtAddressNew.Text.ToString();
            client.ClientType = clientType;
            client.FirstName = txtFirstNameNew.Text.ToString();
            client.LastName = txtLastNameNew.Text.ToString();
            client.CompanyName = txtCompanyNameNew.Text.ToString();
            client.IBAN = txtIBANNew.Text.ToString();
            client.ID_type = clientType.ID_type;
            return true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadClientTypes();
        }

        private void btnExitAdd_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadClientTypes()
        {
            var clientTypes = ctService.GetClientTypes();
            cmbClientType.ItemsSource = clientTypes;
        }

        private void CheckClientType()
        {
            var ct = cmbClientType.SelectedItem as ClientType;
            if(ct.ID_type == 1) 
            {
                txtCompanyNameNew.IsEnabled = false;
                txtIBANNew.IsEnabled = false;
                txtCompanyNameNew.Background = Brushes.Gray;
                txtIBANNew.Background = Brushes.Gray;
                txtFirstNameNew.Background = Brushes.White;
                txtLastNameNew.Background = Brushes.White;
                txtCompanyNameNew.Text = "";
                txtIBANNew.Text = "";
                txtFirstNameNew.IsEnabled = true;
                txtLastNameNew.IsEnabled = true;
            }
            else
            {
                txtFirstNameNew.IsEnabled = false;
                txtLastNameNew.IsEnabled = false;
                txtFirstNameNew.Background = Brushes.Gray;
                txtLastNameNew.Background = Brushes.Gray;
                txtCompanyNameNew.Background = Brushes.White;
                txtIBANNew.Background = Brushes.White;
                txtFirstNameNew.Text = "";
                txtLastNameNew.Text = "";
                txtCompanyNameNew.IsEnabled = true;
                txtIBANNew.IsEnabled = true;
            }
        }

        private void cmbClientType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckClientType();
        }
    }
}
