using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11_First_MVC_App.Models;

namespace Lab11_First_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int firstyear, int secondyear)
        {
            return RedirectToAction("Results", new { firstyear, secondyear });
        }

        public IActionResult Results(int firstyear, int secondyear)
        {
            var people = TimePerson.GetPersons(firstyear, secondyear);
            return View(people);
        }

    }
}
