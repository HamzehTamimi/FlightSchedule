using FlightSchedule.ApplicationDbContext;
using FlightSchedule.Enities;
using FlightSchedule.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using static FlightSchedule.Constant.FlightScheduleConstant;

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
        public List<SelectListItem> FillFlightType()
        {
         
            
            return  new List<SelectListItem>
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


       
                 
        }
        public object FillStatus()
        {
            var list = Enum.GetValues(typeof(FlightStatus))
               .Cast<FlightStatus>()
               .ToDictionary(e => (int)e, e => e.ToString());

       var FlightStatus=     new List<SelectListItem>(); 

            foreach (var item in list)
                FlightStatus.Add(new SelectListItem { Text = item.Value, Value = item.Key.ToString() });





            return
                   FlightStatus;
        }

        [HttpGet]
        public JsonResult GetIata(int ? id)
        {
            if (id is not null && id != 0)
            {
              var airLine=  _context.Airlines.Find(id);

                if (airLine is not null)
                {

                    return Json(airLine.IATA);
                }

            }

            return Json(string.Empty);  
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






            ViewBag.flightTypes = FillFlightType();
            ViewBag.AirlineList = AirlineList;
            ViewBag.FlightStatus = FillStatus();


            return View();
        }

        [HttpPost]
        public IActionResult Create(FlightAndPaxViewModel flight) {


            if (ModelState.IsValid)
            {
                FlightSchedule.Enities.Flight flightObject = new Enities.Flight();
                flightObject.Status = flight.Status;
                flightObject.FlightNumber = flight.FlightNumber;
                flightObject.ArrivalAirport = flight.ArrivalAirport;
                flightObject.DepartureAirport = flight.DepartureAirport;
                flightObject.ScheduledTime = flight.ScheduledTime;
                flightObject.ActualTime = flight.ActualTime;
                flightObject.FlightType =  flight.FlightType;
                flightObject.AirlineId = flight.AirlineId;
                _context.Flights.Add(flightObject);
                _context.SaveChanges();

                FlightSchedule.Enities.PaxInfo paxObject = new Enities.PaxInfo();
                paxObject.Infant = flight.Infant;
                paxObject.Child  = flight.Child;
                paxObject.Adult = flight.Adult;
                paxObject.FlightId = flightObject.Id; 

               
                _context.PaxInfo.Add(paxObject);
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


                ViewBag.flightTypes = FillFlightType();
                ViewBag.AirlineList = AirlineList;
                ViewBag.FlightStatus = FillStatus();


                return  RedirectToAction("Index");

            }

            else
            {
                return View(flight);
            }


               
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _context.Flights.Where(x => x.Id == id).FirstOrDefault();

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
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Flight flight)
        {
            var data = _context.Flights.Where(x => x.Id == flight.Id).FirstOrDefault();

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

            if (data != null)
            {
                data.Status = flight.Status;
                data.FlightNumber = flight.FlightNumber;
                data.ArrivalAirport = flight.ArrivalAirport;
                data.DepartureAirport = flight.DepartureAirport;
                data.ScheduledTime = flight.ScheduledTime;
                data.ActualTime = flight.ActualTime;
                data.FlightType = flight.FlightType;
            }

              
            ViewBag.flightTypes = flightTypes;
            _context.SaveChanges();
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Flights.FirstOrDefault(x => x.Id == id);
            if (data is not null)
            _context.Flights.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
