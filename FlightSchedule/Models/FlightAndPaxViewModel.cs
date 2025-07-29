using FlightSchedule.Enities;
using FlightSchedule.VildationHelper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSchedule.Models
{
    public class FlightAndPaxViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        //[FLightNumberVildationAttribute]
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
        public int FlightType { get; set; }

        public int AirlineId { get; set; }

        public int FlightId { get; set; }
        [Required]

        public int Adult { get; set; }
        [Required]

        public int Child { get; set; }
        [Required]

        public int Infant { get; set; }
    }
}
