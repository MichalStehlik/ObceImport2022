using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObceImport2022.Models
{
    internal class MunicipalityPopulation : Population
    {
        public string Name { get; set; }
        public District District { get; set; }
        public string LAU1 { get; set; }
    }
}
