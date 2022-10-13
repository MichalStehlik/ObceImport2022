﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObceImport2022.Models
{
    internal class Population
    {
        [ForeignKey("LAU2")]
        public Municipality Municipality { get; set; }
        [Key]
        [MaxLength(6)]
        public string LAU2 { get; set; }
        [Key]
        public int Year { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public int Men { get; set; }
        [Required]
        public int Women { get; set; }
        [Required]
        public double Age { get; set; }
        [Required]
        public double MensAge { get; set; }
        [Required]
        public double WomensAge { get; set; }
    }
}
