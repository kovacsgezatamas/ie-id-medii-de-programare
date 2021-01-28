using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using kovacs_geza_tamas_project.Data;
using kovacs_geza_tamas_project.Models;

namespace kovacs_geza_tamas_project.Pages.Cars
{
    public class CreateModel : CarFuelsPageModel
    {
        private readonly kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext _context;

        public CreateModel(kovacs_geza_tamas_project.Data.kovacs_geza_tamas_projectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Makes"] = new SelectList(_context.Set<Make>(), "ID", "Name");

            var car = new Car();
            car.CarFuels = new List<CarFuel>();
            PopulateAssignedFuelData(_context, car);

            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedFuels)
        {
            var newCar = new Car();
            if (selectedFuels != null)
            {
                newCar.CarFuels = new List<CarFuel>();

                foreach (var fuel in selectedFuels)
                {
                    var carFuelToAdd = new CarFuel
                    {
                        FuelId = int.Parse(fuel)
                    };

                    newCar.CarFuels.Add(carFuelToAdd);
                }
            }

            if (await TryUpdateModelAsync<Car>(
                newCar,
                "Car",
                i => i.LicensePlate,
                i => i.ProductionYear,
                i => i.Color,
                i => i.RentalPrice,
                i => i.NextInspectionDate,
                i => i.MakeId))
            {
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedFuelData(_context, newCar);

            return Page();
        }
    }
}
