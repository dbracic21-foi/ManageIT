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
    public partial class ClientUpdate : Window
    {
        private Client clientForUpdate;
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
                txtIBAN.Text = "";
                txtLastName.Text = clientForUpdate.LastName;
                txtFirstName.Text = clientForUpdate.FirstName;
            }
            else
            {
                txtTypeName.Text = "Tvrtka";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtCompanyName.Text = clientForUpdate.CompanyName;
                txtIBAN.Text = clientForUpdate.IBAN;
            }
            txtEmail.Text = clientForUpdate.Email.ToString();
            txtAddress.Text = clientForUpdate.Client_Address.ToString();
            txtNumber.Text = clientForUpdate.Number.ToString();
        }
    }
}
