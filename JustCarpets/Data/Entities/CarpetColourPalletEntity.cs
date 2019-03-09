using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    [Table("CarpetColourPallet")]
    public class CarpetColourPalletEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Hex { get; set; }
        public string RGB { get; set; }
        public int CarpetId { get; set; }
        public virtual CarpetEntity Carpet { get; set; }
    }
}
