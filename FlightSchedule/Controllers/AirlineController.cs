using FlightSchedule.Enities;
using FlightSchedule.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FlightSchedule.Controllers
{
    public class AirlineController : Controller
    {

        private readonly ApplicationDbContext.ApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AirlineController(ApplicationDbContext.ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }


        public static List<AirlineViewModel> Airlines = new List<AirlineViewModel>();
        [HttpGet]
        public IActionResult CreateAirline()
        {
            return View();
        }

//        private bool ValidateEmail(string  email)
//        {
//            bool isValid = true;

//            if (
//string.IsNullOrEmpty(email))
//            {

//                isValid = false; 
//            }


//            if (email.Length < 7)
//            {
//                isValid = false; 
//            }


//            if (!email.Contains('@'))
//            { 
//             isValid = false;
//            }



//           return isValid; 
        
//        }
        [HttpPost]
        public IActionResult CreateAirline(AirlineViewModel airline, IFormFile file)
        {
            airline.NameEN=  airline.NameEN.Trim(); 
            var anyRecordsWithSameEnName = _applicationDbContext.Airlines.Where(x => x.NameEN.ToLower() == airline.NameEN.ToLower()).Count();

            string errMsg=string.Empty;

            if (anyRecordsWithSameEnName > 0)
            {

                errMsg = "Name Already Exsist";

            }
            else
            {

                    FlightSchedule.Enities.Airline airlineObjectToInsert= new Enities.Airline();

                    airlineObjectToInsert.NameEN = airline.NameEN; 
                    airlineObjectToInsert.NameAR = airline.NameAR; 
                    airlineObjectToInsert.AirlineEmail = airline.AirlineEmail; 
                    airlineObjectToInsert.IATA = airline.IATA;
                    airlineObjectToInsert.ICAO = airline.ICAO;
                    _applicationDbContext.Airlines.Add(airlineObjectToInsert);
                    _applicationDbContext.SaveChanges();

                    string uniqueFileName = null; ;
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        uniqueFileName = airlineObjectToInsert.Id.ToString() + fileExtension;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                    airline.Images = uniqueFileName;
                    airlineObjectToInsert.Images = airline.Images;
                    _applicationDbContext.Airlines.Update(airlineObjectToInsert);
                    _applicationDbContext.SaveChanges();

            }
            ViewBag.ErrMsg = errMsg; 
                return View(airline);
            }


        [HttpGet]
        public IActionResult Index(string? airlineName) //  Get  All Records 
        {

            //  Spigate Code 

            //List<AirlineViewModel> allAirlinesViewModel =new List<AirlineViewModel>();

            //var dataFromDB = _applicationDbContext.Airlines.OrderByDescending(a => a).ToList(); 
            //foreach (var item in dataFromDB)
            //{

            //    allAirlinesViewModel.Add(new AirlineViewModel
            //    {
            //        AirlineEmail = item.AirlineEmail,
            //        IATA = item.IATA,
            //        ICAO = item.ICAO,
            //        Id = item.Id,
            //        NameAR = item.NameAR,
            //        NameEN = item.NameEN,
            //        Images = item.Images,
            //        DisplayName = $"{item.IATA} _ {item.NameEN}"
            //    });
            //}




            //  clean  Code

            List  <AirlineViewModel> allData=new List<AirlineViewModel>();
            if (string.IsNullOrEmpty(airlineName))
            {
                allData = _applicationDbContext.Airlines.OrderByDescending(a => a).Select(x => new AirlineViewModel
                {
                    AirlineEmail = x.AirlineEmail,
                    IATA = x.IATA,
                    ICAO = x.ICAO,
                    Id = x.Id,
                    NameAR = x.NameAR,
                    NameEN = x.NameEN,
                    Images = x.Images,
                    DisplayName = $"{x.IATA} _ {x.NameEN}"
                }).ToList();

            }
            else
            {

                airlineName = airlineName.Trim();   

                allData = _applicationDbContext.Airlines.Where(x=>x.NameEN.ToLower().Contains(airlineName) ).OrderByDescending(a => a).Select(x => new AirlineViewModel
                {
                    AirlineEmail = x.AirlineEmail,
                    IATA = x.IATA,
                    ICAO = x.ICAO,
                    Id = x.Id,
                    NameAR = x.NameAR,
                    NameEN = x.NameEN,
                    Images = x.Images,
                    DisplayName = $"{x.IATA} _ {x.NameEN}"
                }).ToList();




            }


            return View(allData);    
        }




        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                ViewBag.ErrMsg = "Value should not be 0";
            }
            var selectedAirline = _applicationDbContext.Airlines.FirstOrDefault(x => x.Id == id);
            return View(selectedAirline);  
        }

        [HttpPost]
        public IActionResult Update(Airline airline)
        {
            var airlineObject = _applicationDbContext.Airlines.FirstOrDefault(x => x.Id == airline.Id);

            if (airlineObject is not null&& ModelState.IsValid)
            { 
                airlineObject.ICAO=airline.ICAO;  
                airlineObject.IATA=airline.IATA;    
                airlineObject.AirlineEmail=airline.AirlineEmail;
                airlineObject.NameEN = airline.NameEN; 
                airlineObject.NameAR = airline.NameAR;  
            }
            return View(airline);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var selectedAirline = _applicationDbContext.Airlines.FirstOrDefault(x => x.Id == id);
            if(selectedAirline is not null)
            _applicationDbContext.Airlines.Remove(selectedAirline);
            _applicationDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
