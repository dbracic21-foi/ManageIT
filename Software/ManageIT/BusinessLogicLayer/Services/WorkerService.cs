using DataAccessLayer.Repositories;
using EntitiLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class WorkerService
    {
        public List<Worker> GetWorkerByEmailAndPassword(string email, string password)
        {
            using (var workerRepo = new WorkerRepo())
            {
                return workerRepo.GetWorkerByEmailAndPassword(email, password).ToList();
            }
        }
        public Worker Authenticate(string email, string password)
        {
            using (var workerRepo = new WorkerRepo())
            {
                Worker authenticatedWorker = workerRepo.GetWorkerByEmailAndPassword(email, password).FirstOrDefault();

                return authenticatedWorker;
            }
        }
     

    }
}
