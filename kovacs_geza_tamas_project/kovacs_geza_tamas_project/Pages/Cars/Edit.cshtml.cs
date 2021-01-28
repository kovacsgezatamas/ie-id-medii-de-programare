using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kovacs_geza_tamas_project.Data;
using kovacs_geza_tamas_project.Models;

namespace kovacs_geza_tamas_project.Pages.Cars
{
    public class EditModel : CarFuelsPageModel
    {
        private readonly kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext _context;

        public EditModel(kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car
                .Include(car => car.Make)
                .Include(car => car.CarFuels).ThenInclude(carFuel => carFuel.Fuel)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }

            PopulateAssignedFuelData(_context, Car);

            ViewData["Makes"] = new SelectList(_context.Set<Make>(), "ID", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedFuels)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carToUpdate = await _context.Car
                .Include(i => i.Make)
                .Include(i => i.CarFuels)
                .ThenInclude(i => i.Fuel)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (carToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Car>(
                carToUpdate,
                "Car",
                i => i.LicensePlate,
                i => i.ProductionYear,
                i => i.Color, 
                i => i.RentalPrice,
                i => i.NextInspectionDate,  
                i => i.MakeId))
            {
                UpdateCarFuels(_context, selectedFuels, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateCarFuels(_context, selectedFuels, carToUpdate);
            PopulateAssignedFuelData(_context, carToUpdate);

            return Page();
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
