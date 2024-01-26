using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories {
    public class ClientRepository : Repository<Client> {

        public ClientRepository(): base(new ManageITModel())
        {

        }

    }
}
