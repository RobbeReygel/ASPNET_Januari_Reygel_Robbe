using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Januari_Reygel_Robbe.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ASPNET_Januari_Reygel_Robbe.Data
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase(EntityContext entityContext)
        {
            entityContext.Database.EnsureCreated();

            var types = new List<Entities.Type>
            {
                new Entities.Type() {Brand = "BMW", Model = "x5"},
                new Entities.Type() {Brand = "Ford", Model = "Fiesta"},
                new Entities.Type() {Brand = "MiniCooper", Model = "D"},
                new Entities.Type() {Brand = "Audi", Model = "A8"},
            };

            var owners = new List<Owner>();
            for (var i = 0; i < 10; i++)
            {
                owners.Add(new Owner {FirstName = $"First Name {i}", LastName = $"Last Name {i}"});
            }

            var cars = new List<Car>();
            for (var i = 0; i < 10; i++)
            {
                Entities.Type type = types[0];
                String color = "Geel";
                if (i % 4 == 0)
                {
                    type = types[1];
                    color = "Rood";
                }
                else if (i % 3 == 0)
                {
                    type = types[2];
                    color = "Blauw";
                }
                else if (i % 2 == 0)
                {
                    type = types[3];
                    color = "Groen";
                }
                cars.Add(new Car {Plate = $"DEZ46{i}", Owner = owners[i], Type = type, PurchaseDate = DateTime.Now.AddYears(-1).AddDays(i), Color = color });
            }
            
            entityContext.Type.AddRange(types);
            entityContext.Owners.AddRange(owners);
            entityContext.Cars.AddRange(cars);
            entityContext.SaveChanges();
        }
    }
}