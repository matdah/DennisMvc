using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DennisMvc.Models;
using Newtonsoft.Json;





namespace DennisMvc.Controllers
{
    public class HomeController : Controller
    {
    
        public IActionResult Index()
        {
           return View();
        }

       [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

         [Route("/destinations")]
        public IActionResult Destinations()
        {
            var jsonStr = System.IO.File.ReadAllText("destinations.json");
            var JsonObj = JsonConvert.DeserializeObject<IEnumerable<Destinations>>(jsonStr);
            return View(JsonObj);
        }
    }
}