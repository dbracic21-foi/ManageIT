using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

        public OrderDetail GetOrderDetail(int id) {
            using (var repo = new OrderDetailsRepository()) {
                var orderDetail = repo.GetOrderDetailById(id);
                return orderDetail;
            }
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail) {
            bool isSuccessful = false;
            using (var repo = new OrderDetailsRepository()) {
                int affectedRows = repo.Update(orderDetail);
                isSuccessful = affectedRows > 0;
            }
            return isSuccessful;
        }

        public List<OrderDetail> GetOrderDetailsForWorkerAndDate(int workerId, DateTime date) {
            using (var repo = new OrderDetailsRepository()) {
                var orderDetail = repo.GetOrderDetailsForWorkerAndDate(workerId, date);
                return orderDetail;
            }
        }
    }
}
