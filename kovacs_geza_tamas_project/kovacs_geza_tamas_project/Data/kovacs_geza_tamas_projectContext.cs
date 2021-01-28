using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kovacs_geza_tamas_project.Models;

namespace kovacs_geza_tamas_project.Data
{
    public class kovacs_geza_tamas_projectContext : DbContext
    {
        public kovacs_geza_tamas_projectContext (DbContextOptions<kovacs_geza_tamas_projectContext> options)
            : base(options)
        {
        }

        public DbSet<kovacs_geza_tamas_project.Models.Car> Car { get; set; }

        public DbSet<kovacs_geza_tamas_project.Models.Make> Make { get; set; }

        public DbSet<kovacs_geza_tamas_project.Models.Fuel> Fuel { get; set; }
    }
}
