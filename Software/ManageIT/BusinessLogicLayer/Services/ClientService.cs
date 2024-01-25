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

        public Client GetClientById(int id)
        {
            using (var clientRepo = new ClientRepo())
            {
                Client client = clientRepo.GetClientById(id).FirstOrDefault();
                return client;
            }
        }
        public void DeleteClient(int id)
        {
            using (var clientRepo = new ClientRepo())
            {
                clientRepo.DeleteClient(id);
            }
        }

        public void UpdateClient(Client client)
        { 
            using (var clientRepo = new ClientRepo())
            {
                clientRepo.UpdateClient(client);
            }
        }
    }
}