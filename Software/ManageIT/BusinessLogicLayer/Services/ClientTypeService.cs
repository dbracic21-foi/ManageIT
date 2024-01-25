using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ClientTypeService
    {
        public List<ClientType> GetClientTypes() 
        {
            using (var clientTypeRepo = new ClientTypeRepo())
            {
                return clientTypeRepo.GetClientTypes().ToList();
            }
        }
    }
}
