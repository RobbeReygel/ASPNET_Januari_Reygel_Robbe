using System.Collections.Generic;
using System.Linq;
using ASPNET_Januari_Reygel_Robbe.Data;
using ASPNET_Januari_Reygel_Robbe.Entities;
using ASPNET_Januari_Reygel_Robbe.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ASPNET_Januari_Reygel_Robbe.Controllers
{
    public class CarService : ICarService
    {
        private readonly EntityContext _entityContext;

        public CarService(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        private IIncludableQueryable<Car, Owner> GetFullGraph()
        {
            return _entityContext.Cars.Include(x => x.Type).Include(x => x.Owner);
        }

        public List<Car> GetAllCars()
        {
            return GetFullGraph().OrderBy(x => x.Plate)
                .ToList();
        }

        public Car GetCarById(int id)
        {
            return GetFullGraph()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Type> GetAllTypes()
        {
            return _entityContext.Type.ToList();
        }

        public Type GetTypeById(int id)
        {
            return _entityContext.Type.Find(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _entityContext.Owners.ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return _entityContext.Owners.Find(id);
        }

        public void Persist(Car car)
        {
            if (car.Id == 0)
                _entityContext.Cars.Add(car);
            else
                _entityContext.Cars.Update(car);
            _entityContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var toDelete = GetCarById(id);
            if (toDelete != null)
            {
                _entityContext.Cars.Remove(toDelete);
                _entityContext.SaveChanges();
            }
        }
    }
}