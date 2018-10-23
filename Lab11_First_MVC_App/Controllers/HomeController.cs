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
        /// <summary>
        /// gets the index and returns the view
        /// </summary>
        /// <returns>View()</returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        /// <summary>
        /// takes the resilt of user input on the index and returns a route to results
        /// </summary>
        /// <param name="firstyear"></param>
        /// <param name="secondyear"></param>
        /// <returns>RedirectToAction</returns>
        [HttpPost]
        public IActionResult Index(int firstyear, int secondyear)
        {
            return RedirectToAction("Results", new { firstyear, secondyear });
        }

        /// <summary>
        /// takes the information from the based on the parameters and displays the results on the rseults page
        /// </summary>
        /// <param name="firstyear"></param>
        /// <param name="secondyear"></param>
        /// <returns></returns>
        public IActionResult Results(int firstyear, int secondyear)
        {
            var people = TimePerson.GetPersons(firstyear, secondyear);
            return View(people);
        }
    }
}
