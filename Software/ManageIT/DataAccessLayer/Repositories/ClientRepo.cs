using DataAccessLayer.Models;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ClientRepo : Repository<Client>
    {
        public ClientRepo() : base(new ManageITModel())
        {

        }

        public IQueryable<ClientViewModel> GetClientView()
        {
            var query = from c in Entities
                        select new ClientViewModel
                        {
                            ID_Client = c.ID_client,
                            TypeName = c.ClientType.Title,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            CompanyName = c.CompanyName,
                            IBAN = c.IBAN,
                            Email = c.Email,
                            Address = c.Client_Address,
                            Number = c.Number
                        };
            return query;
        }
    }
}