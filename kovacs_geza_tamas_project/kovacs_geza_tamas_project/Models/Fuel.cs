using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kovacs_geza_tamas_project.Models
{
    public class Fuel
    {
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<CarFuel> CarFuels { get; set; }
    }
}
