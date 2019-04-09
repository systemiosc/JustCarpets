using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Models
{
    public class FlooringServiceResponse
    {
        public string FriendlyError { get; set; }
        public List<FlooringDto> Results { get; set; } = new List<FlooringDto>();
        public bool Success { get; set; }
    }
}
