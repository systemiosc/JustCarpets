using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    [Table("Carpet")]
    public class CarpetEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CarpetStyle Style { get; set; }
        public int DurabilityFactor { get; set; }
        public bool PetFriendly { get; set; }
        public decimal PriceM2 { get; set; }
        public List<CarpetPropertyEntity> Propertys { get; set; } = new List<CarpetPropertyEntity>();
        public List<CarpetColourPalletEntity> CarpetColourPallets { get; set; } = new List<CarpetColourPalletEntity>();
        public List<CarpetSizeOptionEntity> Options { get; set; } = new List<CarpetSizeOptionEntity>();
        public List<CarpetImageEntity> Images { get; set; } = new List<CarpetImageEntity>();
    }
}
