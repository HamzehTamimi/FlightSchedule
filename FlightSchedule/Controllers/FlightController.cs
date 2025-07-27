using FlightSchedule.ApplicationDbContext;
using FlightSchedule.Enities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FlightSchedule.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext.ApplicationDbContext _context;
        public FlightController(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }


        public IActionResult Index()
        {
            var listofData = _context.Flights.ToList();
            return View(listofData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var AirlineList = (from airlines in _context.Airlines
                               select new SelectListItem
                               {
                                   Text = airlines.NameEN.ToString(),
                                   Value = airlines.Id.ToString(),
                               }).ToList(); ;

            AirlineList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            var flightTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Economy", Value = "1" },
                new SelectListItem { Text = "Premium Economy", Value = "2" },
                new SelectListItem { Text = "Business", Value = "3" },
                new SelectListItem { Text = "First Class", Value = "4" },
                new SelectListItem { Text = "Commercial", Value = "5" },
                new SelectListItem { Text = "Private", Value = "6" },
                new SelectListItem { Text = "Cargo", Value = "7" },
                new SelectListItem { Text = "Connecting", Value = "8" },
                new SelectListItem { Text = "Direct", Value = "9" },
                new SelectListItem { Text = "Non-Stop", Value = "10" },
            };

            ViewBag.flightTypes = flightTypes;
            ViewBag.AirlineList = AirlineList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Flight flight) { 

            _context.Flights.Add(flight);
            _context.SaveChanges();


            var AirlineList = (from airlines in _context.Airlines
                select new SelectListItem
                {
                    Text = airlines.NameEN.ToString(),
                    Value = airlines.Id.ToString(),
                }).ToList(); ;

            AirlineList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            var flightTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Economy", Value = "Economy" },
                new SelectListItem { Text = "Premium Economy", Value = "Premium Economy" },
                new SelectListItem { Text = "Business", Value = "Business" },
                new SelectListItem { Text = "First Class", Value = "First Class" },
                new SelectListItem { Text = "Commercial", Value = "Commercial" },
                new SelectListItem { Text = "Private", Value = "Private" },
                new SelectListItem { Text = "Cargo", Value = "Cargo" },
                new SelectListItem { Text = "Connecting", Value = "Connecting" },
                new SelectListItem { Text = "Direct", Value = "Direct" },
                new SelectListItem { Text = "Non-Stop", Value = "Non-Stop" },
            };

            ViewBag.flightTypes = flightTypes;
            ViewBag.AirlineList = AirlineList;
            return View();
        }
    }
}
