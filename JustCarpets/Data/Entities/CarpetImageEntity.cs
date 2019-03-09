using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JustCarpets.Data.Entities
{
    [Table("CarpetImage")]
    public class CarpetImageEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string AlternateText { get; set; }
        public string Link { get; set; }
        public CarpetImageType ImageType { get; set; }
    }
}
