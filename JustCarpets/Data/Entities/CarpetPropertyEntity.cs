using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    [Table("CarpetPropertys")]
    public class CarpetPropertyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BulletPoint { get; set; }
        public int CarpetId { get; set; }
        public virtual CarpetEntity Carpet { get; set; }
    }
}
