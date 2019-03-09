using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    [Table("Company")]
    public class CompanyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public virtual List<CompanyLocationEntity> CompanyLocations { get; set; } = new List<CompanyLocationEntity>();
        public virtual List<CarpetEntity> Carpets { get; set; } = new List<CarpetEntity>();

    }
}
