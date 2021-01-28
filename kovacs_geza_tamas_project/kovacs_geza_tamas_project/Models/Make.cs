using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kovacs_geza_tamas_project.Models
{
    public class Make
    {
        public int ID { get; set; }
        [Display(Name = "Make"), Required]
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; } //navigation property
    }
}
