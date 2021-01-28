using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kovacs_geza_tamas_project.Models
{
    public class AssignedFuelData
    {
        public int FuelId { get; set; }
        public string Type { get; set; }
        public bool Assigned { get; set; }
    }
}
