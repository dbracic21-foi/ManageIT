using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ReceiptRepository: Repository<Receipt>
    {
        public ReceiptRepository() : base(new ManageIT())
        {

        }
    }
}
