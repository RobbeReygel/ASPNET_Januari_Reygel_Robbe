using System.Collections.Generic;
using System.Linq;
using ASPNET_Januari_Reygel_Robbe.Entities;
using ASPNET_Januari_Reygel_Robbe.Models;
using ASPNET_Januari_Reygel_Robbe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Dynamic;

namespace ASPNET_Januari_Reygel_Robbe.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("/cars")]
        public IActionResult Index()
        {
            var model = new CarListViewModel {Cars = new List<CarDetailViewModel>()};
            var allCars = _carService.GetAllCars();
            model.Cars.AddRange(allCars.Select(ConvertCarToCarDetailViewModel).ToList());
            return View(model);
        }


        [HttpGet("/types")]
        public IActionResult Types()
        {
            var model = new CarListViewModel { Cars = new List<CarDetailViewModel>() };
            var allCars = _carService.GetAllCars();
            model.Cars.AddRange(allCars.Select(ConvertCarToCarDetailViewModel).ToList());
            return View(model);
        }

        [HttpGet("/eigenaars")]
        public IActionResult Eigenaars()
        {
            var model = new CarListViewModel { Cars = new List<CarDetailViewModel>() };
            var allCars = _carService.GetAllCars();
            model.Cars.AddRange(allCars.Select(ConvertCarToCarDetailViewModel).ToList());
            return View(model);
        }

        protected CarDetailViewModel ConvertCarToCarDetailViewModel(Car car)
        {
            return new CarDetailViewModel()
            {
                Id = car.Id,
                Plate = car.Plate,
                PurchaseDate = car.PurchaseDate,
                Owner = car.Owner?.FullName,
                Type = car.Type?.Brand + " " + car.Type?.Model,
                Color = car.Color
            };
        }


        [HttpGet("/cars/{id}")]
        public IActionResult Detail([FromRoute] int id)
        {
            if (id == 0)
            {
                Car car = new Car()
                {
                    Id = 0,
                };

                var vm = ConvertCarToEditDetailViewModel(car);
                vm.Types = _carService.GetAllTypes().Select(x => new SelectListItem
                {
                    Text = x.Brand + " " + x.Model,
                    Value = x.Id.ToString(),
                }
                ).ToList();
                vm.Owners = _carService.GetAllOwners().Select(x => new SelectListItem
                {
                    Text = x.FullName,
                    Value = x.Id.ToString(),
                }
                ).ToList();
                vm.Owners.Insert(0, new SelectListItem()
                {
                    Text = "Geen Eigenaar",
                    Value = "0"
                });

                return View(vm);
            }
            else
            {
                var car = _carService.GetCarById(id);
                if (car == null)
                {
                    return NotFound();
                }

                var vm = ConvertCarToEditDetailViewModel(car);
                vm.Types = _carService.GetAllTypes().Select(x => new SelectListItem
                    {
                        Text = x.Brand + " " + x.Model,
                        Value = x.Id.ToString(),
                    }
                ).ToList();
                vm.Owners = _carService.GetAllOwners().Select(x => new SelectListItem
                {
                    Text = x.FullName,
                    Value = x.Id.ToString(),
                }
                ).ToList();
                vm.Owners.Insert(0, new SelectListItem()
                {
                    Text = "Geen Eigenaar",
                    Value = "0"
                });

                return View(vm);
            }
        }


        [HttpPost("/cars")]
        public IActionResult Persist([FromForm] CarEditDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var car = vm.Id == 0 ? new Car() : _carService.GetCarById(vm.Id);
                car.Plate = vm.Plate;
                car.Type = vm.TypeId.HasValue ? _carService.GetTypeById(vm.TypeId.Value) : null;
                car.Owner = vm.OwnerId.HasValue ? _carService.GetOwnerById(vm.OwnerId.Value) : null;
                car.PurchaseDate = vm.PurchaseDate;
                _carService.Persist(car);

                return Redirect("/cars");
            }
            return View("Detail", vm);
        }


        public CarEditDetailViewModel ConvertCarToEditDetailViewModel(Car car)
        {
            var vm = new CarEditDetailViewModel
            {
                Id = car.Id,
                Plate = car.Plate,
                PurchaseDate = car.PurchaseDate,
                Type = car.Type?.Brand + " " + car.Type?.Model,
                TypeId = car.Type?.Id,
                Owner = car.Owner?.FullName,
                OwnerId = car.Owner?.Id,
            };
            return vm;
        }

        [HttpPost("/cars/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _carService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}