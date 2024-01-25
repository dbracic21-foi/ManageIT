using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class WorkerService
    {       
        public IQueryable<Worker> GetWorkerByEmailAndPassword(string email, string password)
        {
            using (var workerRepo = new WorkerRepo())
            {
                return workerRepo.GetWorkerByEmailAndPassword(email, password);
            }
        }
    }
}
