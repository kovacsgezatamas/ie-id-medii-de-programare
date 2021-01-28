using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kovacs_geza_tamas_project.Models
{
    public class CarFuel
    {
        public int ID { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
    }
}
