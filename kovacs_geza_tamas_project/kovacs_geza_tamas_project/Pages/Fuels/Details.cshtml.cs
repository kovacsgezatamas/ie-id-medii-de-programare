using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kovacs_geza_tamas_project.Data;
using kovacs_geza_tamas_project.Models;

namespace kovacs_geza_tamas_project.Pages.Fuels
{
    public class DetailsModel : PageModel
    {
        private readonly kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext _context;

        public DetailsModel(kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext context)
        {
            _context = context;
        }

        public Fuel Fuel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fuel = await _context.Fuel.FirstOrDefaultAsync(m => m.ID == id);

            if (Fuel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
