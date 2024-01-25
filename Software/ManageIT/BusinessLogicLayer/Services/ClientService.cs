using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ClientService
    {
        public List<Client> GetClients()
        {
            using (var clientRepo = new ClientRepo())
            {
                return clientRepo.GetAll().ToList();
            }
        }
        public List<ClientViewModel> GetClientsView()
        {
            using (var clientRepo = new ClientRepo())
            {
                return clientRepo.GetClientView().ToList();
            }
        }

        public List<ClientViewModel> SearchClients(string key)
        {
            using (var clientRepo = new ClientRepo())
            {
                return clientRepo.SearchClients(key).ToList();
            }
        }

        public void DeleteClient(int id)
        {
            using (var clientRepo = new ClientRepo())
            {
                clientRepo.DeleteClient(id);
            }
        }
    }
}