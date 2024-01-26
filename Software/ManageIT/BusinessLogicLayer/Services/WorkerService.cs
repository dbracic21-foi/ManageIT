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

                // Ako je authenticatedWorker != null, to znači da je pronađen korisnik sa zadanim emailom i lozinkom
                return authenticatedWorker;
            }
        }

        public List<Worker> GetWorkers() {
            using (var workerRepo = new WorkerRepo()) {
                return workerRepo.GetAll().ToList();
            }
        }
    }
}
