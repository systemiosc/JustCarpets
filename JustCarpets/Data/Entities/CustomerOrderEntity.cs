using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    [Table("CustomerOrder")]
    public class CustomerOrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int InstallerReviewId { get; set; }
        public virtual InstallerReviewEntity InstallerReview { get; set; }
        public DateTime ReviewDate { get; set; }
        public List<OrderLineEntity> OrderLines { get; set; } = new List<OrderLineEntity>();
        public virtual CompanyLocation Customer { get; set; }

      }
}
