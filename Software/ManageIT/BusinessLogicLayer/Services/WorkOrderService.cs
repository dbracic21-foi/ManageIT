using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services {
    public class WorkOrderService {
        public bool AddWorkOrder(WorkOrder workOrder) {
            bool isSuccessful = false;
            using(var repo = new WorkOrderRepository()) {
                int affectedRows = repo.Add(workOrder);
                isSuccessful = affectedRows > 0;
            }
            return isSuccessful;
        }

        public List<WorkOrder> GetWorkOrders() {
            using (var repo = new WorkOrderRepository()) {
                var workOrders = repo.GetAll().ToList();
                return workOrders;
            }
        }
    }
}
