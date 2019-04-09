using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int? InstallerReviewId { get; set; }
        public int? InstallerDate { get; set; }
        public int InstallerAppointmentId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
        public virtual CustomerDto Customer { get; set; }
        public virtual InstallerAppointmentsDto InstallerAppointment { get; set; }
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int CarpetId { get; set; }
        public int CarpetSizeOptionId { get; set; }
        public int Qty { get; set; }
        public int CustomerOrderId { get; set; }
    }


}
