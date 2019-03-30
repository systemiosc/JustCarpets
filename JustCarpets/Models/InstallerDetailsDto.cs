using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Data;

namespace JustCarpets.Models
{
    public class InstallerDetailsDto :  InstallerDto
    {
        public string LocationName { get; set; }
        public List<InstallerRatesDto> Rates { get; set; } = new List<InstallerRatesDto>();
        public List<InstallerReviews> Reviews { get; set; } = new List<InstallerReviews>();
        public List<InstallerOrder> Appointments { get; set; } = new List<InstallerOrder>();
    }

    public class InstallerRatesDto
    {
        public int Id { get; set; }
        public InstallerDayType Type { get; set; }
        public decimal Price { get; set; }
    }

    public class InstallerReviews
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int Rate { get; set; }
    }

    public class InstallerOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public string PostCode { get; set; }
        public bool AM { get; set; }
    }
}
