using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SammysAuto.Data;
using SammysAuto.ViewModel;

namespace SammysAuto.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServicesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET : Services/Create
        public IActionResult Create(int carId)
        {
            var car = _db.Cars.FirstOrDefault(c => c.Id == carId);
            var model = new CarAndServicesViewModel
            {
                CarId = car.Id,
                Make = car.Make,
                Model = car.Model,
                Style = car.Style,
                VIN = car.VIN,
                Year = car.Year,
                UserId = car.UserId,
                ServiceTypesObj = _db.ServiceTypes.ToList(),
                PastServicesObj = _db.Services.Where(s => s.CarId == carId).OrderByDescending(s => s.DateAdded).Take(5)
            };

            return View(model);
        }

        //POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarAndServicesViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.NewServiceObj.CarId = model.CarId;
                model.NewServiceObj.DateAdded = DateTime.Now;
                _db.Add(model.NewServiceObj);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Create), new { carId = model.CarId });
            }
            var car = _db.Cars.FirstOrDefault(c => c.Id == model.CarId);
            var newModel = new CarAndServicesViewModel
            {
                CarId = car.Id,
                Make = car.Make,
                Model = car.Model,
                Style = car.Style,
                VIN = car.VIN,
                Year = car.Year,
                UserId = car.UserId,
                ServiceTypesObj = _db.ServiceTypes.ToList(),
                PastServicesObj = _db.Services.Where(s => s.CarId == model.CarId).OrderByDescending(s => s.DateAdded).Take(5)
            };
            return View(newModel);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}
