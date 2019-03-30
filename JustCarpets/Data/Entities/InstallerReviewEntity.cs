using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    [Table("InstallerReview")]
    public class InstallerReviewEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PunctualityFactor { get; set; }
        public int TimeKeepingFactor { get; set; }
        public int CleanupFactor { get; set; }
        public int QualityFactor { get; set; }
        public string Comments { get; set; }
        public int CustomerOrderId { get; set; }
        public int InstallerId { get; set; }
        public virtual CompanyLocationEntity Installer { get; set; }
        public virtual CustomerOrderEntity CustomerOrder { get; set; }
    }
}
