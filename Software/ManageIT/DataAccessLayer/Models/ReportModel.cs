using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    /// <remarks>
    /// Matej Desanić
    /// </remarks>
    public class ReportModel
    {
        public List<WorkOrder> workOrderReport { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public Worker creatorWorker { get; set; }
        public int ID_Report { get; set; }
    }
}
