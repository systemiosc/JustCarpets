using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
 
    
    public class InstallerRatesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyLocationId { get; set; }
        public virtual CompanyLocationEntity CompanyLocation { get; set; }
        public decimal HalfDayRate { get; set; }
        public InstallerDayType Type { get; set; }

    }
}
