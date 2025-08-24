using FlightSchedule.Enities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entity = FlightSchedule.Enities; 
namespace FlightSchedule.ApplicationDbContext
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }




        public DbSet<Entity.Airline> Airlines { get; set; }
        public DbSet<Entity.Flight> Flights { get; set; }

        public DbSet<Entity.PaxInfo> PaxInfo { get; set; }
    }
}
