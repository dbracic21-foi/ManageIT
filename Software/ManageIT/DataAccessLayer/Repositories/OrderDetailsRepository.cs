using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories {
    public class OrderDetailsRepository: Repository<OrderDetail> {
        public OrderDetailsRepository(): base(new ManageIT())
        {
            
        }

        public override int Add(OrderDetail entity, bool saveChanges = true) {
            var client = Context.Clients.SingleOrDefault(c => c.ID_client == entity.Client.ID_client);
            var workType = Context.WorkTypes.SingleOrDefault(w => w.ID_Work_Type == entity.WorkType.ID_Work_Type);
            var worker = Context.Workers.SingleOrDefault(w => w.ID_worker == entity.Worker.ID_worker);

            var orderDetail = new OrderDetail();
            orderDetail.Client = client;
            orderDetail.WorkType = workType;
            orderDetail.Worker = worker;
            orderDetail.Duration = entity.Duration;
            orderDetail.Date = entity.Date;
            orderDetail.Location = entity.Location;
            
            Entities.Add(orderDetail);
            if(saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
        }
    }
}
