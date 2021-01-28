using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kovacs_geza_tamas_project.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Display(Name = "License Plate"), Required, StringLength(8, MinimumLength = 6)]
        public string LicensePlate { get; set; }
        [Display(Name = "Production Year"), Range(2000, 2021)]
        public int ProductionYear { get; set; }
        public string Color { get; set; }
        [Display(Name = "Rental Price")]
        [Column(TypeName = "decimal(6, 2)")]
        [Range(1, 1000), Required]
        public decimal RentalPrice { get; set; }
        [Display(Name = "Next Inspection Date")]
        [DataType(DataType.Date)]
        public DateTime NextInspectionDate { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
        [Display(Name = "Fuel")]
        public ICollection<CarFuel> CarFuels { get; set; }
    }
}
