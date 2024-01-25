using EntitiLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataAccessLayer.Repositories
{
    public class WorkerRepo : Repository<Worker>
    {
        public WorkerRepo() : base(new ManageIT())
        {

        }
        
        public IQueryable<Worker> GetWorkerByEmailAndPassword(string email, string password)
        {
            var query = from w in Entities
                        where w.Email == email && w.Password == password
                        select w;

            return query;
        }
     
       


    }
}
