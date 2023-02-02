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
            ViewBag.Heading = "ViewBag & ViewData";
            ViewBag.Text = "This heading and text is brought to you by the ViewBag property.";
            ViewData["ErrorMessage"] = "This example of a 'Error message' is brought to you from the ViewData!";
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
            ViewBag.Destinations = "Whenever I have ben to one of the great Alp destinations I can add a destination to my list throug the form below! (This description is presented with 'ViewBag').";
            var jsonStr = System.IO.File.ReadAllText("destinations.json");
            var JsonObj = JsonConvert.DeserializeObject<List<Destinations>>(jsonStr);
            ViewBag.JsonObj = JsonObj;

            /* Question: when using ViewBag to present the JsonObj I dont need to pass JsonObj into View()?*/
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/destinations")]
        public IActionResult Destinations(Destinations dest)
        {
            // Läs in data - igen o igen o igen o igen... :-)
            var jsonStr = System.IO.File.ReadAllText("destinations.json");
            var JsonObj = JsonConvert.DeserializeObject<List<Destinations>>(jsonStr);            
            ViewBag.Destinations = "Whenever I have ben to one of the great Alp destinations I can add a destination to my list throug the form below! (This description is presented with 'ViewBag').";
            ViewBag.JsonObj = JsonObj;

            if (ModelState.IsValid)
            {
                if (JsonObj == null)
                {
                    JsonObj = new List<Destinations>();
                }
                JsonObj.Add(dest);
                var newJsonStr = JsonConvert.SerializeObject(JsonObj, Formatting.Indented);
                System.IO.File.WriteAllText("destinations.json", newJsonStr);
                return RedirectToAction("Destinations");
            }            

            return View();
        }
    }
}