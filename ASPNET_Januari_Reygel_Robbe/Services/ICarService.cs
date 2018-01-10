using System.Collections.Generic;
using ASPNET_Januari_Reygel_Robbe.Entities;

namespace ASPNET_Januari_Reygel_Robbe.Services
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        Car GetCarById(int id);
        List<Type> GetAllTypes();
        Type GetTypeById(int id);
        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);
        void Persist(Car car);
        void Delete(int id);
    }
}