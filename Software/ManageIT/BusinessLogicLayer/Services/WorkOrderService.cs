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
            using (var repo = new WorkOrderRepository()) {
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
        }
        private async void SendNewWorkOrderEmail(WorkOrder workOrder) {
            string toEmail = workOrder.Worker.Email;
            string subject = "Novi radni nalog ! ";
            string ime = workOrder.Worker.FirstName;
            Console.WriteLine(ime);
            string body = $"<br><br><strong>Poštovani {toEmail}</strong>,<br><br><strong>Novi radni nalog vam je dodijeljen</strong>";

            if (workOrder.OrderDetail != null) {
                if (workOrder.OrderDetail.Client != null) {
                    body += $"<br><strong> Za klijenta: {workOrder.OrderDetail.Client.CompanyName}</strong>";
                }

                body += $".<br><br><strong>Detalji:</strong><br><strong>Vrijeme trajanja :</strong> {workOrder.OrderDetail.Duration}<br>";

                if (workOrder.OrderDetail.WorkType != null) {
                    body += $" <br><strong>Tip čišćenja :</strong> {workOrder.OrderDetail.WorkType.Name}";
                }

                body += $"<br><strong>Datum:</strong> {workOrder.DateCreated}<br>";

                if (!string.IsNullOrEmpty(workOrder.OrderDetail.Location)) {
                    body += $"<br><strong>Na Lokaciji:</strong> {workOrder.OrderDetail.Location}<br>";
                } else {
                    body += "<br>";
                }
            } else {
                body += ".<br><br><strong>Detalji nisu dostupni.</strong><br>";
            }

            body += "<br><strong>Srdačan pozdrav,<br>ManageIT</strong>";



            Console.WriteLine($"Sending email to {toEmail}");

            await emailService.SendEmail(toEmail, subject, body, true);
        }

        public bool RemoveWorkOrder(WorkOrder workOrder) {
            bool isSuccessful = false;

            using (var repo = new WorkOrderRepository()) {
                int affectedRows = repo.Remove(workOrder);
                isSuccessful = affectedRows > 0;
            }
            return isSuccessful;
        }

        public List<WorkOrder> GetWorkOrdersByName(string phrase) {
            using (var repo = new WorkOrderRepository()) {
                return repo.GetWorkOrderByName(phrase).ToList();
            }
        }

        public void ConcludeWorkOrder(int workerId, DateTime date) {
            using (var workOrderRepo = new WorkOrderRepository()) {
                // Fetch the relevant WorkOrder
                var workOrder = workOrderRepo
                    .GetAll()
                    .FirstOrDefault(w => w.ID_Worker == workerId && w.OrderDetail.Date == date);

                if (workOrder != null) {
                    // Update the IsFinished property
                    workOrder.IsFinished = true;

                    // Save changes to the database
                    workOrderRepo.SaveChanges();
                }
            }
        }

    }
}
