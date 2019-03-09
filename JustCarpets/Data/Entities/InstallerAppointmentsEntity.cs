using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    [Table("InstallerAppointment")]
    public class InstallerAppointmentsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool AM { get; set; }
        public int CompanyLocationId { get; set; }
        public int CustomerLocationId { get; set; }
        public int OrderId { get; set; }

        public virtual CompanyLocation Customer { get; set; }
        public virtual CustomerOrderEntity Order { get; set; }
        public virtual CompanyLocation ComapnyLocation { get; set; }

    }
}
