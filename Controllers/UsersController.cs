using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SammysAuto.Controllers
{
    public class UsersController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
