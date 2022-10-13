using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObceImport2022.Models
{
    internal class District
    {
        [Key]
        [MaxLength(6)]
        public string LAU1 { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("NUTS3")]
        public Region Region { get; set; }
        [Required]
        public string NUTS3 { get; set; }
        
        public ICollection<Municipality>? Municipalities { get; set; }
    }
}
