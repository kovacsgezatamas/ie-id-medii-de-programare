using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using kovacs_geza_tamas_project.Data;

namespace kovacs_geza_tamas_project.Models
{
    public class CarFuelsPageModel:PageModel
    {
        public List<AssignedFuelData> AssignedFuelDataList;

        public void PopulateAssignedFuelData(kovacs_geza_tamas_projectContext context, Car car)
        {
            var allFuels = context.Fuel;
            var carFuels = new HashSet<int>(
                car.CarFuels.Select(carFuel => carFuel.FuelId)
            );

            AssignedFuelDataList = new List<AssignedFuelData>();

            foreach (var fuel in allFuels)
            {
                AssignedFuelDataList.Add(new AssignedFuelData
                {
                    FuelId = fuel.ID,
                    Type = fuel.Type,
                    Assigned = carFuels.Contains(fuel.ID)
                });
            }
        }

        public void UpdateCarFuels(kovacs_geza_tamas_projectContext context, string[] selectedFuels, Car carToUpdate)
        {
            if (selectedFuels == null)
            {
                carToUpdate.CarFuels = new List<CarFuel>();
                return;
            }

            var selectedFuelsHS = new HashSet<string>(selectedFuels);
            var carFuels = new HashSet<int>
                (carToUpdate.CarFuels.Select(carFuel => carFuel.Fuel.ID));

            foreach (var fuel in context.Fuel)
            {
                if (selectedFuelsHS.Contains(fuel.ID.ToString()))
                {
                    if (!carFuels.Contains(fuel.ID))
                    {
                        carToUpdate.CarFuels.Add(
                        new CarFuel
                        {
                            CarId = carToUpdate.ID,
                            FuelId = fuel.ID
                        });
                    }
                }
                else
                {
                    if (carFuels.Contains(fuel.ID))
                    {
                        CarFuel courseToRemove = carToUpdate
                            .CarFuels
                            .SingleOrDefault(i => i.FuelId == fuel.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
