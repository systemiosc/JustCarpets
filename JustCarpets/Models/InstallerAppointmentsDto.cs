using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Models
{
    public class InstallerAppointmentsDto
    {
        public DateTime Date { get; set; }
        public bool AM { get; set; }
        public int InstallerId { get; set; }
    }
}
