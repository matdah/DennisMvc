using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DennisMvc.Models;


namespace DennisMvc.Controllers
{
    public class HomeController : Controller
    {
    
        public IActionResult Index()
        {
            // read JSON
            var jsonStr = System.IO.File.ReadAllText("destinations.json");
            // convert json
            var JsonObj = JsonConvert.DeserializeObject<IEnumerable<Destinations>>(jsonStr);
            return View(JsonObj);
        }

       [Route("/about")]
        public IActionResult About()
        {
            return View();
        }
    }
}