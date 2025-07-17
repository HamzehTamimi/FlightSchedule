using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.Enities
{
    public class Airline
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string NameEN { get; set; }
        [Required]

        public string NameAR { get; set; }
        [Required]

        public string IATA { get; set; }
        [Required]

        public string ICAO { get; set; }

        [Display(Name = "Email (Airline)")]
        [EmailAddress]
        public string ? AirlineEmail { get; set; }

        public string? Images { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.Now;
    }
}
