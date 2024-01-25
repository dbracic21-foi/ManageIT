using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ClientViewModel
    {
        public int ID_Client { get; set; }
        public string TypeName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string IBAN { get; set; }
        public string Address { get; set; }

    }
}
