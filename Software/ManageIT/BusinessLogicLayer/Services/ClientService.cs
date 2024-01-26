using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services {
    public class ClientService {
        public List<Client> GetClients() {
            using (var repo = new ClientRepository()) {
                return repo.GetAll().ToList();
            }
        }
    }
}
