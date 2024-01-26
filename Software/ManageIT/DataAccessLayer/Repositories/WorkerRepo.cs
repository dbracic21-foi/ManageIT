using EntitiesLayer.Entities;
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
        
        public IQueryable<Worker> GetWorkerByEmailAndPassword(string username, string password)
        {
            var query = from w in Entities
                        where w.UserName == username && w.Password == password
                        select w;

            return query;
        }
        public IQueryable<Worker> GetWorkers()
        {
            var query = from w in Entities
                        select w;

            return query;
        }
        public IQueryable<int> GetNumberOfProducts(Worker worker)
        {
            var query = from w in Entities
                        where w.ID_worker == worker.ID_worker
                        select w.Workers.Count;

            return query;
        }
        public override int Add(Worker entity, bool saveChanges = true)
        {
            var worker = new Worker
            {
                //ID_worker = entity.ID_worker,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Password = entity.Password,
                Email = entity.Email,
               
            };
            Entities.Add(worker);
            if (saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }




    }
}
