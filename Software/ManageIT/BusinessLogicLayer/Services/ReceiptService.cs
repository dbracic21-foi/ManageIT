using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    /// <remarks>
    /// Matej Desanić
    /// </remarks>
    public class ReceiptService
    {
        public List<Receipt> GetReceipts()
        {
            using (var recieptRepo = new ReceiptRepository())
            {
                List<Receipt> recieptList = new List<Receipt>();
                recieptList = recieptRepo.GetAll().ToList();

                return recieptList;
            }
        }

        public List<Receipt> GetCanceledReceipts()
        {
            using (var recieptRepo = new ReceiptRepository())
            {
                List<Receipt> recieptList = new List<Receipt>();
                recieptList = recieptRepo.GetAllCanceled().ToList();

                return recieptList;
            }
        }

        public void CancelReciept(int id)
        {
            using (var recieptRepo = new ReceiptRepository())
            {
                Receipt receiptToCancel = new Receipt();
                receiptToCancel = recieptRepo.GetReceiptByID(id).FirstOrDefault();

                receiptToCancel.Canceled = 1;

                recieptRepo.UpdateReceipt(receiptToCancel);
            }
        }

        public void OpenReciept(string receiptName)
        {
            string filePath = Path.Combine("../../../BusinessLogicLayer/Receipts", receiptName);
            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error opening report '{receiptName}': {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Report '{receiptName}' does not exist.");
            }
        }
    }
}
