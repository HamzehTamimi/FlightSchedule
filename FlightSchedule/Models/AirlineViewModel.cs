using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.Models
{
    public class AirlineViewModel
    {
        [Required]  
        public int Id { get; set; }

        [Required]

        public string  NameEN { get; set; }
        [Required]

        public string NameAR { get; set; }
        [Required]

        public string IATA { get; set; }
        [Required]

        public string ICAO { get; set; }

        [Display(Name ="Email (Airline)")]
        [EmailAddress]
        public string AirlineEmail { get; set; }

        public string ?Images { get; set; }
        public string ?DisplayName { get; set; }
    }
}
