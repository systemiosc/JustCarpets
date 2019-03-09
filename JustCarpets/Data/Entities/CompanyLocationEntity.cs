using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    public class CompanyLocationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public LocationType Type { get; set; }
        public CompanyEntity Company { get; set; }
        public List<InstallerRatesEntity> Rates { get; set; } = new List<InstallerRatesEntity>();
    }
}
