using FlightSchedule.Enities;
using Microsoft.EntityFrameworkCore;
using Entity = FlightSchedule.Enities; 
namespace FlightSchedule.ApplicationDbContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }




        public DbSet<Entity.Airline> Airlines { get; set; }
    }
}
