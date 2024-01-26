using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services {
    public class OrderDetailService {
        public bool AddOrderDetail(OrderDetail orderDetail) {
            bool isSuccessful = false;
            using(var repo = new OrderDetailsRepository()) {
               int affectedRows = repo.Add(orderDetail);
               isSuccessful = affectedRows > 0;
            }
            return isSuccessful;
        }
    }
}
