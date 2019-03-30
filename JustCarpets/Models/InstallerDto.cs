using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Models
{
    public class InstallerDto
    {
        public int CompanyId { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
    }
}
