using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    public class CarpetSizeOptionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int M2 { get; set; }
        public int CarpetId { get; set; }
        public virtual CarpetEntity Carpet { get; set; }
    }
}
