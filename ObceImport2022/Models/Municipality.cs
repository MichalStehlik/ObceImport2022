using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObceImport2022.Models
{
    internal class Municipality
    {
        [Key]
        [MaxLength(6)]
        public string LAU2 { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("LAU1")]
        public District? District { get; set; }
        [Required]
        public string LAU1 { get; set; }
        public ICollection<Population>? PopulationData { get; set; }
        public Region? CapitalOf { get; set; }
    }
}
