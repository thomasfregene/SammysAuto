﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;
using SammysAuto.Models;

namespace SammysAuto.Controllers
{
    public class ServiceTypes : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServiceTypes(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET: ServiceType
        public IActionResult Index()
        {
            return View(_db.ServiceTypes.ToList());
        }

        //GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
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
