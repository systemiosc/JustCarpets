using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Models
{
    public class CompanyDto
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public List<InstallerDto> Installers { get; set; }

    }
}
