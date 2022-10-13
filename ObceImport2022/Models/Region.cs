using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObceImport2022.Models
{
    internal class Region
    {
        [Key]
        [MaxLength(5)]
        public string NUTS3 { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        
        [ForeignKey("LAU2")]
        public Municipality? Capital { get; set; }
        
        public string? LAU2 { get; set; }
        public ICollection<District>? Districts { get; set; }
    }
}
