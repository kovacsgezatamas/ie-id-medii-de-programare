using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kovacs_geza_tamas_project.Data;
using kovacs_geza_tamas_project.Models;

namespace kovacs_geza_tamas_project.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext _context;

        public IndexModel(kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get;set; }
        public CarData CarD { get; set; }

        public async Task OnGetAsync()
        {
            CarD = new CarData();
            CarD.Cars = await _context.Car
                .Include(car => car.Make)
                .Include(car => car.CarFuels)
                .ThenInclude(car => car.Fuel)
                .AsNoTracking()
                .OrderBy(car => car.LicensePlate)
                .ToListAsync();
        }
    }
}
