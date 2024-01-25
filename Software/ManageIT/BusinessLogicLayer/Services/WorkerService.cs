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
        public List<Worker> GetWorkerByEmailAndPassword(string username, string password)
        {
            using (var workerRepo = new WorkerRepo())
            {
                return workerRepo.GetWorkerByEmailAndPassword(username, password).ToList();
            }
        }
        public Worker Authenticate(string username, string password)
        {
            using (var workerRepo = new WorkerRepo())
            {
                Worker authenticatedWorker = workerRepo.GetWorkerByEmailAndPassword(username, password).FirstOrDefault();

                return authenticatedWorker;
            }
        }
     

    }
}
