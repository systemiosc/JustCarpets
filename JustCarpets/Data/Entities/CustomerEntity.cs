using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JustCarpets.Data.Entities
{

    [Table("Customer")]
    public class CustomerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MacAddress { get; set; }
        public DateTime Created { get; set; }
        public DateTime AgreedDataProtection { get; set; }
        public DateTime AgreedTerms { get; set; }
        public DateTime AgreedMarketing { get; set; }
        public List<CustomerOrderEntity> Orders { get; set; } = new List<CustomerOrderEntity>();
    }
}
