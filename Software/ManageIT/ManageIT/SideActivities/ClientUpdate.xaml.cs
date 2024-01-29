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
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// <remarks>
    /// Matej Desanić
    /// </remarks>
    public partial class ClientUpdate : Window
    {
        private Client clientForUpdate;
        ClientService clientService = new ClientService();
        public ClientUpdate(Client client)
        {
            InitializeComponent();
            clientForUpdate = client;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtID.Text = clientForUpdate.ID_client.ToString();
            if(clientForUpdate.ID_type == 1)
            {
                txtTypeName.Text = "Pojedinac";
                txtCompanyName.Text = "";
                txtCompanyName.IsEnabled = false;
                txtIBAN.Text = "";
                txtIBAN.IsEnabled = false;
                txtLastName.Text = clientForUpdate.LastName;
                txtFirstName.Text = clientForUpdate.FirstName;
            }
            else
            {
                txtTypeName.Text = "Tvrtka";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtFirstName.IsEnabled = false;
                txtLastName.IsEnabled = false;
                txtCompanyName.Text = clientForUpdate.CompanyName;
                txtIBAN.Text = clientForUpdate.IBAN;
            }
            txtEmail.Text = clientForUpdate.Email.ToString();
            txtAddress.Text = clientForUpdate.Client_Address.ToString();
            txtNumber.Text = clientForUpdate.Number.ToString();
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            Client updatedClient = new Client
            {
                ID_client = clientForUpdate.ID_client,
                Email = txtEmail.Text.ToString(),
                FirstName = txtFirstName.Text.ToString(),
                LastName = txtLastName.Text.ToString(),
                CompanyName = txtCompanyName.Text.ToString(),
                IBAN = txtIBAN.Text.ToString(),
                Client_Address = txtAddress.Text.ToString(),
                Number = txtNumber.Text.ToString()
            };

            if (clientService.UpdateClient(updatedClient))
            {
                MessageBox.Show("Succesfully updated client!");
                Close();
            }
            else
            {
                MessageBox.Show("That email address is already in usage!");
            }
        }

        private void btnExitUpdate_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
