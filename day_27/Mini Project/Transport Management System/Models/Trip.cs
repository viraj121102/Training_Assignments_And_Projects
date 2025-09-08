using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transport_Management_System.Models
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }

        [ForeignKey("Route")]
        public int RouteID { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        public string? Status { get; set; } // e.g., Scheduled, In Progress, Completed
        public string TripType { get; set; } // e.g., Freight, Passenger
        public int MaxPassengers { get; set; }

        // 🔗 Navigation Properties
        public Vehicle? Vehicle { get; set; }
        public Route? Route { get; set; }
    }
}
