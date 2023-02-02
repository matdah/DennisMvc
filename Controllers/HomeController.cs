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
            var JsonObj = JsonConvert.DeserializeObject<IEnumerable<Destinations>>(jsonStr);
            return View(JsonObj);
        }
    }
}