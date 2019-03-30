using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Data;

namespace JustCarpets.Models
{
    public class SearchParametersDto
    {
        public bool Pets { get; set; }
        public CarpetStyle Style { get; set; }
        public int Budget { get; set; }
        public bool Hardwearing { get; set; }
        public bool SkipSearchParameters { get; set; }
    }
}
