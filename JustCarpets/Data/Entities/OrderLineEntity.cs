using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{

    [Table("OrderLine")]
    public class OrderLineEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CarpetId { get; set; }
        public int CarpetSizeOptionId { get; set; }
        public int Qty { get; set; }
        public int CustomerOrderId { get; set; }
        public virtual CarpetEntity Carpet { get; set; }
        public virtual CustomerOrderEntity CustomerOrder { get; set; }
        public virtual CarpetSizeOptionEntity SizeOption { get; set; }
    }
}
