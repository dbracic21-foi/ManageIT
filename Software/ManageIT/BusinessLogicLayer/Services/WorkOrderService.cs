﻿using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services {
    public class WorkOrderService {
        public Receipt receiptNew { get; set; }
        private EmailService emailService = new EmailService();

        public WorkOrderService() 
        {
            receiptNew = new Receipt();
        }
        public bool AddWorkOrder(WorkOrder workOrder) {
            bool isSuccessful = false;
            using(var repo = new WorkOrderRepository()) {
                int affectedRows = repo.Add(workOrder);
                isSuccessful = affectedRows > 0;
                SendNewWorkOrderEmail(workOrder);             
            }
            return isSuccessful;
        }

        public Receipt AddReceipt(WorkOrder workOrder)
        {
            using (var repo = new ReceiptRepository())
            {
                Receipt receiptNew = new Receipt
                {
                    ID_receipt = workOrder.ID_Work_Order,
                    ID_Worker = workOrder.ID_Worker,
                    OIB = 398516979,
                    Date = workOrder.DateCreated,
                    Worker = workOrder.Worker,
                    Canceled = 0,
                    Additional_info = "",
                    WorkOrder = workOrder
                };

                repo.Add(receiptNew);
                return receiptNew;
            }
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
            string ime = workOrder.Worker.FirstName;
            Console.WriteLine(ime);
            string body = $"<br><br><strong>Poštovani {toEmail}</strong>,<br><br><strong>Novi radni nalog vam je dodijeljen</strong>";

            if (workOrder.OrderDetail != null)
            {
                if (workOrder.OrderDetail.Client != null)
                {
                    body += $"<br><strong> Za klijenta: {workOrder.OrderDetail.Client.CompanyName}</strong>";
                }

                body += $".<br><br><strong>Detalji:</strong><br><strong>Vrijeme trajanja :</strong> {workOrder.OrderDetail.Duration}<br>";

                if (workOrder.OrderDetail.WorkType != null)
                {
                    body += $" <br><strong>Tip čišćenja :</strong> {workOrder.OrderDetail.WorkType.Name}";
                }

                body += $"<br><strong>Datum:</strong> {workOrder.DateCreated}<br>";

                if (!string.IsNullOrEmpty(workOrder.OrderDetail.Location))
                {
                    body += $"<br><strong>Na Lokaciji:</strong> {workOrder.OrderDetail.Location}<br>";
                }
                else
                {
                    body += "<br>";
                }
            }
            else
            {
                body += ".<br><br><strong>Detalji nisu dostupni.</strong><br>";
            }

            body += "<br><strong>Srdačan pozdrav,<br>ManageIT</strong>";



            Console.WriteLine($"Sending email to {toEmail}");

           await emailService.SendEmail(toEmail, subject, body,true);
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

        public int GetWorkOrderId()
        {
            using(var repo = new WorkOrderRepository())
            {
                return repo.GetLastWorkOrderID();
            }
        }
    }
      
}
