using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kovacs_geza_tamas_lab8.Models;

namespace kovacs_geza_tamas_lab8.Data
{
    public class kovacs_geza_tamas_lab8Context : DbContext
    {
        public kovacs_geza_tamas_lab8Context (DbContextOptions<kovacs_geza_tamas_lab8Context> options)
            : base(options)
        {
        }

        public DbSet<kovacs_geza_tamas_lab8.Models.Book> Book { get; set; }
    }
}
