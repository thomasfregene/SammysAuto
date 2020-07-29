﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //Details: ServiceTypes/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if(serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        //Edit: ServiceTypes/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceType serviceType)
        {
            if(id != serviceType.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(serviceType);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        //Delete: ServiceTypes/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        //POST: ServiceTypes/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveServiceType(int id)
        {
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            _db.ServiceTypes.Remove(serviceType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
