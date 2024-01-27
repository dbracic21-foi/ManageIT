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
            var orderDetail = Context.OrderDetails.SingleOrDefault(o => o.Id_Order_Details == entity.OrderDetail.Id_Order_Details);
            var worker = Context.Workers.SingleOrDefault(w => w.ID_worker == entity.ID_Worker);
            var orderService = new OrderDetailsRepository();
            var orderDetails = orderService.GetAll().ToList();
            var orderDetail1 = orderDetails.LastOrDefault();

            var workOrder = new WorkOrder();
            workOrder.IsFinished = entity.IsFinished;
            workOrder.Worker = worker;
            workOrder.ID_Worker = entity.ID_Worker;
            workOrder.DateCreated = entity.DateCreated;
            workOrder.Id_Order_Details = orderDetail1.Id_Order_Details;
            workOrder.Worker.Email = worker.Email;

            Entities.Add(workOrder);
            if (saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
        }

        
    }
}
