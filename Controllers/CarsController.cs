﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;
using SammysAuto.Models;
using SammysAuto.ViewModel;

namespace SammysAuto.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string userId = null)
        {
            if(userId == null)
            {
                //only called when a Customer  logs in
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            var model = new CarAndCustomerViewModel
            {
                Cars = _db.Cars.Where(c => c.UserId == userId),
                UserObj = _db.Users.FirstOrDefault(u => u.Id == userId)
            };

            return View(model);
        }

        //CREATE GET
        public IActionResult Create(string userId)
        {
            Car carObj = new Car
            {
                Year = DateTime.Now.Year,
                UserId = userId
            };
            return View(carObj);
        }

        //CREATE POST
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Add(car);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { userId = car.UserId });
            }

            return View(car);
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
