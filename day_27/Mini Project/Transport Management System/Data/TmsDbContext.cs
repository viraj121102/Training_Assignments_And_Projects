using Microsoft.EntityFrameworkCore;
using Transport_Management_System.Models;

namespace Transport_Management_System.Data
{
    public class TmsDbContext: DbContext
    {
        public TmsDbContext(DbContextOptions<TmsDbContext> options): base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Models.Route> Routes { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
