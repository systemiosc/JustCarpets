using JustCarpets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Models
{
    public class FlooringDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CarpetStyle Style { get; set; }
        public int DurabilityFactor { get; set; }
        public bool PetFriendly { get; set; }
        public decimal PriceM2 { get; set; }

        public List<string> Properties { get; set; } = new List<string>();
        public List<FlooringSizeDto> Sizes { get; set; } = new List<FlooringSizeDto>();
        public List<FlooringImageDto> Images { get; set; } = new List<FlooringImageDto>();
    }
}
