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
        public IQueryable<Worker> GetWorkerByID(int id)
        {
            var query = from w in Entities
                        where w.ID_worker == id
                        select w;
            return query;
        }
        public override int Add(Worker entity, bool saveChanges = true)
        {
            var worker = new Worker
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Password = entity.Password,
                Email = entity.Email,
                Gender = entity.Gender,
                Id_type = 2

               
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

        public override int Update(Worker entity, bool saveChanges = true)
        {
            var worker = Entities.SingleOrDefault(w => w.ID_worker == entity.ID_worker);
            worker.FirstName = entity.FirstName;
            worker.LastName = entity.LastName;
            worker.UserName = entity.UserName;
            worker.Password = entity.Password;
            worker.Email = entity.Email;
            worker.Gender = entity.Gender;

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
