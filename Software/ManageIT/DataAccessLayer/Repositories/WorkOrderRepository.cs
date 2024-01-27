using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories {
    public class WorkOrderRepository : Repository<WorkOrder> {
        public WorkOrderRepository(): base(new ManageIT())
        {
      
        }

        public override int Add(WorkOrder entity, bool saveChanges = true) {
            
            var worker = Context.Workers.SingleOrDefault(w => w.ID_worker == entity.ID_Worker);
            var orderService = new OrderDetailsRepository();
            var orderDetails = orderService.GetAll().ToList();
            var orderDetail = orderDetails.LastOrDefault();

            var workOrder = new WorkOrder();
            workOrder.IsFinished = entity.IsFinished;
            workOrder.Worker = worker;
            workOrder.ID_Worker = entity.ID_Worker;
            workOrder.DateCreated = entity.DateCreated;
            workOrder.Id_Order_Details = orderDetail.Id_Order_Details;

            Entities.Add(workOrder);
            if (saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
        }

        public override IQueryable<WorkOrder> GetAll() {
            var query = from p in Entities.Include("Worker")
                        select p;
            return query;
        }

        public IQueryable<WorkOrder> GetWorkOrderByName(string phrase) {
            var query = from p in Entities.Include("Worker")
                        where p.Worker.FirstName.ToLower().Contains(phrase.ToLower()) || p.Worker.LastName.ToLower().Contains(phrase.ToLower())
                        select p;
            return query;
        }
    }
}
