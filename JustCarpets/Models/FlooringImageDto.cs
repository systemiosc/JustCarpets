using JustCarpets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Models
{
    public class FlooringImageDto
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string AlternateText { get; set; }
        public string Link { get; set; }
        public CarpetImageType ImageType { get; set; }
    }
}
