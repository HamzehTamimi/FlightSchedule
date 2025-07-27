using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace FlightSchedule.Enities
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        public string ArrivalAirport { get; set; }
        [Required]
        public string DepartureAirport { get; set; }
        [Required]
        public DateTime ScheduledTime { get; set; }
        [Required]
        public DateTime ActualTime { get; set; }
        [Required]
        public string FlightType { get; set; }

        public int AirlineId { get; set; }

        [ForeignKey("AirlineId")]

        public Airline Airline { get; set; }



    }
}
