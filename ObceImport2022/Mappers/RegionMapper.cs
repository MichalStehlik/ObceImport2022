using ObceImport2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace ObceImport2022.Mappers
{
    internal class RegionMapper : CsvMapping<Region>
    {
        public RegionMapper() : base()
        {
            MapProperty(0, x => x.NUTS3);
            MapProperty(1, x => x.Name);
        }
    }
}
