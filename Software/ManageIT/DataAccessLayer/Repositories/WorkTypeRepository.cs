using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories {
    public class WorkTypeRepository : Repository<WorkType> {
        public WorkTypeRepository() : base(new ManageIT())
        {
            
        }
    }
}
