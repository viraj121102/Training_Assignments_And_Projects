using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSRepository
{
    public class TmsDbContext: DbContext
    {
        public TmsDbContext(DbContextOptions<TmsDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
