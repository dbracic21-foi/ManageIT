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
        public List<Worker> GetWorkers()
        {
            using (var workerRepo = new WorkerRepo())
            {
                return workerRepo.GetWorkers().ToList();
            }
        }
        public bool RemoveWorker(Worker worker)
        {
            bool isSuccessful = false;
            bool canRemove = CheckIfWorkerCanBeRemoved(worker);
            using (var workerRepo = new WorkerRepo())
            {
                if (canRemove == true)
                {
                    int affectedRows = workerRepo.Remove(worker);
                    isSuccessful = affectedRows > 0;
                }
            }
            return isSuccessful;
        }

        private bool CheckIfWorkerCanBeRemoved(Worker worker)
        {
          if(worker == null) return false;
          using (var workerRepo = new WorkerRepo())
            {
                int numOfProducts = workerRepo.GetNumberOfProducts(worker).Single();
                if(numOfProducts > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
