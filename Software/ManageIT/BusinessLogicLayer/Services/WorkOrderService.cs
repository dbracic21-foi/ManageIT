using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services {
    public class WorkOrderService {
        private EmailService emailService = new EmailService();
        public bool AddWorkOrder(WorkOrder workOrder) {
            bool isSuccessful = false;
            using(var repo = new WorkOrderRepository()) {
                int affectedRows = repo.Add(workOrder);
                isSuccessful = affectedRows > 0;
                SendNewWorkOrderEmail(workOrder);

              
            }
            return isSuccessful;
        }

        public List<WorkOrder> GetWorkOrders() {
            using (var repo = new WorkOrderRepository()) {
                var workOrders = repo.GetAll().ToList();
                return workOrders;
            }
        }  private async void SendNewWorkOrderEmail(WorkOrder workOrder)
        {
            string toEmail = workOrder.Worker.Email;
            string subject = "Novi radni nalog ! ";
            string body = $"Poštovani {workOrder.Worker.FirstName},\n\nNovi radni nalog vam je dodijeljen.\n\nDetalji:\nNalog ID: {workOrder.ID_Worker}\nDatum: {workOrder.DateCreated} \n\n Na lokaciji : {workOrder.OrderDetail.Location} \n\nSrdačan pozdrav,\nManageIT";
            Console.WriteLine($"Sending email to {toEmail}");

           await emailService.SendEmail(toEmail, subject, body);
        }
    }
      
}
