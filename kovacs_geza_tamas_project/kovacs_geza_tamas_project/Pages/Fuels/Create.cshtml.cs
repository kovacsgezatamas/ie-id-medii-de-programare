using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using kovacs_geza_tamas_project.Data;
using kovacs_geza_tamas_project.Models;

namespace kovacs_geza_tamas_project.Pages.Fuels
{
    public class CreateModel : PageModel
    {
        private readonly kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext _context;

        public CreateModel(kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fuel Fuel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Fuel.Add(Fuel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
