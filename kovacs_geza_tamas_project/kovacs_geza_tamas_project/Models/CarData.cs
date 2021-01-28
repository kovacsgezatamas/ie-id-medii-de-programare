using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kovacs_geza_tamas_project.Models
{
    public class CarData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Fuel> Fuels { get; set; }
        public IEnumerable<CarFuel> CarFuels { get; set; }
    }
}
